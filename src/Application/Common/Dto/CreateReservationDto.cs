using System;
using AutoMapper;
using ProyectoPruebaBrujula.Application.Common.Mappings;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Application.Common.Dto
{
    public class CreateReservationDto : IMapFrom<Reserva>
    {
        public int habitacionId { get; set; }

        public int usuarioId { get; set; }

        public int hotelId { get; set; }

        public DateTime fecha_entrada { get; set; }

        public DateTime fecha_salida { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReservationDto, Reserva>();
        }
    }
}