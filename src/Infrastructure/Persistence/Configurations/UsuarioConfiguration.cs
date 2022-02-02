using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Hacemos el correo sea unico
            builder
                .HasIndex(b => b.mail)
                .IsUnique();
        }
    }
}