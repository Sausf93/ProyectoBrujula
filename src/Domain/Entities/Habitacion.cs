using System.Collections.Generic;
using ProyectoPruebaBrujula.Domain.Common;

namespace ProyectoPruebaBrujula.Domain.Entities
{
    public class Habitacion :BaseEntity
    {
        public string tipo_habitacion { get; set; }
        
        public virtual List<Reserva> Reservas { get; set; }
    }
}