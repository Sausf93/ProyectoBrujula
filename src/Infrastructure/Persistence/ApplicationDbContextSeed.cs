using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ProyectoPruebaBrujula.Domain.Entities;


namespace ProyectoPruebaBrujula.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        private static ApplicationDbContext _context;
        public static async Task RunSeeders(ApplicationDbContext context)
        {
            _context = context;
            if (!_context.Habitaciones.Any() && !_context.Hoteles.Any() && !_context.Reservas.Any() && !_context.Usuarios.Any())
            {
                _context.Usuarios.Add(new Usuario
                {
                    nombre = "Saulo",
                    apellidos = "De la Santacruz Fernandez",
                    direccion = "Calle X",
                    mail = "saulodlsf@gmail.com",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = "Seerders"
                });
                

                _context.Habitaciones.Add(new Habitacion
                {
                    tipo_habitacion = "suite",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = "Seerders"
                });
                
                _context.Hoteles.Add(new Hotel()
                {
                    nombre = "Barcelo",
                    activo = true,
                    descripcion = "Hotel Barcelo 5 estrellas de los Gigantes, Tenerife",
                    latitud = "44552",
                    longitud = "9948",
                    numero_habitaciones = 150,
                    pais = "España",
                    Created = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = "Seerders"
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}