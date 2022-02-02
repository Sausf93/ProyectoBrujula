using System;
using ProyectoPruebaBrujula.Domain.Common;

namespace ProyectoPruebaBrujula.Domain.Entities
{
    public class Reserva : BaseEntity
    {
        public DateTime fecha_entrada { get; set; }

        public DateTime fecha_salida { get; set; }
        
        public bool estado { get; set; }
        //0 o false cancelado, 1 o true reservado

        public int habitacionId { get; set; }
        
        public int usuarioId { get; set; }

        public int hotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}