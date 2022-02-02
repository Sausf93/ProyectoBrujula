using System;
using AutoMapper;
using ProyectoPruebaBrujula.Application.Common.Mappings;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Application.Common.Dto
{
    public class ReservationDto: IMapFrom<Reserva>
    {
        public int habitacionId { get; set; }
        
        public int usuarioId { get; set; }

        public int hotelId { get; set; }
        
        public DateTime fecha_entrada { get; set; }

        public DateTime fecha_salida { get; set; }
        
        public string NombreHotel { get; set; }
        
        public string UserMail { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reserva, ReservationDto>()
                .ForMember(r => r.NombreHotel, op =>
                    op.MapFrom(dom => dom.Hotel.nombre))
                .ForMember(r => r.UserMail, op =>
                    op.MapFrom(dom => dom.Usuario.mail));

        }
    }
}