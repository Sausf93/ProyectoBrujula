using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Infrastructure.Persistence.Configurations
{
    public class HabitacionConfiguration: IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            
        }
    }
}