using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Habitacion> Habitaciones { get; set; }
        DbSet<Reserva> Reservas { get; set; }
        DbSet<Hotel> Hoteles { get; set; }
    }
}