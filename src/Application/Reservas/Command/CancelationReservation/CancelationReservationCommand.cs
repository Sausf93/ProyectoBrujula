using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProyectoPruebaBrujula.Application.Common.Exceptions;
using ProyectoPruebaBrujula.Application.Common.Interfaces;

namespace ProyectoPruebaBrujula.Application.Reservas.Command.CancelationReservation
{
    public class CancelationReservationCommand : IRequest<bool>
    {
        public int IdReserva { get; set; }
    }

    public class CancelationReservationCommandHandler : IRequestHandler<CancelationReservationCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CancelationReservationCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CancelationReservationCommand request, CancellationToken cancellationToken)
        {
            //Cancelar la reserva con el id que nos pasen en el request.

            var reservation=await _context.Reservas.FirstOrDefaultAsync(r => r.Id == request.IdReserva, cancellationToken);
            if (reservation != null)
            {
                reservation.estado = false;
                //Cancelamos
            }
            else
            {
                throw new NotFoundException("No existen una reserva con este Id");
                return false;
            }

            _context.Reservas.Update(reservation);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}