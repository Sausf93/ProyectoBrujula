using System.Collections.Generic;
using ProyectoPruebaBrujula.Domain.Common;

namespace ProyectoPruebaBrujula.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        //Base entity es una clase que utilizo siempre para ponerle varios campos por defecto a las entidades
        public string nombre { get; set; }
        public string apellidos     { get; set; }
        public string mail     { get; set; }
        public string direccion     { get; set; }
        
        public virtual List<Reserva> Reservas { get; set; }
    }
}