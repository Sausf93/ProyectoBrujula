using System.Collections.Generic;
using System.Threading;
using ProyectoPruebaBrujula.Domain.Common;

namespace ProyectoPruebaBrujula.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string nombre { get; set; }
        public string pais { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public int numero_habitaciones { get; set; }
        
        public virtual List<Reserva> Reservas { get; set; }
    }
}