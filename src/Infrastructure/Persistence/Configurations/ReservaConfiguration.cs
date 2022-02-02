using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Infrastructure.Persistence.Configurations
{
    public class ReservaConfiguration: IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {

            builder.HasKey(b => b.Id);
            builder
                .HasOne(b => b.Hotel)
                .WithMany(b => b.Reservas)
                .HasForeignKey(b => b.hotelId);
            
            builder
                .HasOne(b => b.Usuario)
                .WithMany(b => b.Reservas)
                .HasForeignKey(b => b.usuarioId);
            
            builder
                .HasOne(b => b.Habitacion)
                .WithMany(b => b.Reservas)
                .HasForeignKey(b => b.habitacionId);
            
            
        }
    }
}