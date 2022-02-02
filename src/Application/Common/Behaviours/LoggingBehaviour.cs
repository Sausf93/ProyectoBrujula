﻿using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using ProyectoPruebaBrujula.Application.Common.Interfaces;

namespace ProyectoPruebaBrujula.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;
            string userEmail = _currentUserService.Email;

            _logger.LogInformation("Tech.CleanArchitecture Request: {Name} {@UserId} {@UserEmail} {@Request}",
                requestName, userId, userEmail, request);
        }
    }
}