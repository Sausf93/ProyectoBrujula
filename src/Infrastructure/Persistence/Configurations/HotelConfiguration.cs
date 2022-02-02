using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration: IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            
        }
    }
}