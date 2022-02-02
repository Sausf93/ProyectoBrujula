using System.Collections.Generic;
using System.Linq;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using ProyectoPruebaBrujula.Infrastructure.Persistence;
using ProyectoPruebaBrujula.Presentation.Filters;
using ProyectoPruebaBrujula.Presentation.Services;
using ProyectoPruebaBrujula.Infrastructure;
using ProyectoPruebaBrujula.Application;
using ProyectoPruebaBrujula.Application.Common.Interfaces;

namespace ProyectoPruebaBrujula.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IAppSettingsService, AppSettingsService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
            
            services.AddControllers(options =>
                    options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation();
            
            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddCors(options => 
            { 
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(Configuration.GetSection("Settings:CorsAllowedDomains")?.Value.Split(";"))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()); 
            });
            
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Tech.CleanArchitecture";
                configure.Version = "v1";
                configure.AddSecurity("oidc", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    In = OpenApiSecurityApiKeyLocation.Header,
                    OpenIdConnectUrl = $"{Configuration["Jwt:Authority"]}/.well-known/openid-configuration",
                    Flow = OpenApiOAuth2Flow.Application,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = $"{Configuration["Jwt:Authority"]}/protocol/openid-connect/auth",
                            TokenUrl = $"{Configuration["Jwt:Authority"]}/protocol/openid-connect/token",
                            Scopes = new Dictionary<string, string>{{"openid", "User Profile"}}
                        }
                    }
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("oidc"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors("CorsPolicy");

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseSwaggerUi3(settings =>
            {
                settings.DocExpansion = "list";
                settings.DocumentTitle = "Tech.CleanArchitecture Swagger";
                settings.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = Configuration["Jwt:Audience"],
                    AppName = Configuration["Jwt:Audience"],
                    AdditionalQueryStringParameters = {{"nonce", "1"}},
                    Realm = "intranet-test"
                };
                settings.Path = "/api";
                settings.DocumentPath = "/swagger/specification.json";
            });

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}