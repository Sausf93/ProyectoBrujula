using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProyectoPruebaBrujula.Application.Common.Dto;
using ProyectoPruebaBrujula.Application.Common.Exceptions;
using ProyectoPruebaBrujula.Application.Common.Interfaces;
using ProyectoPruebaBrujula.Domain.Entities;

namespace ProyectoPruebaBrujula.Application.Reservas.Command.CreateReservation
{
    public class CreateReservationCommand : CreateReservationDto, IRequest<int>
    {
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IApplicationDbContext context, IDateTime dateTime, IMapper mapper)
        {
            _context = context;
            _dateTime = dateTime;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reserva reserva = _mapper.Map<Reserva>(request);
                reserva.estado = true;
                //El campo createdby lo suelo poner para en un futuro con un login y demas poder saber quien hizo la reserva.
                //Si este caso fuera una web pondria al propio usuario. Lo mismo con los campos de modificacion.
                reserva.CreatedBy = "Pruebas";
                if (reserva.fecha_entrada >= reserva.fecha_salida)
                {
                    throw new NotFoundException("La fecha de entrada no puede ser igual o superior a la fecha de salida.");

                }
                //Seteamos cuando se crea una reserva el estado a 1.
                //Si se quiere cancelar hacemos un update de ese estado.
                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync(cancellationToken);
                return reserva.Id;
            }
            catch (Exception e)
            {
                throw new NotFoundException("No existen datos de este hotel o de este usuario o de habitacion.");
            }
        }
    }
}