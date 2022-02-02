using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProyectoPruebaBrujula.Application.Common.Dto;
using ProyectoPruebaBrujula.Application.Common.Exceptions;
using ProyectoPruebaBrujula.Application.Common.Interfaces;
using ProyectoPruebaBrujula.Application.Common.Mappings;

namespace ProyectoPruebaBrujula.Application.Reservas.Querys.GetActiveReservation
{
    public class GetActiveReservationQuery : IRequest<List<ReservationDto>>
    {
        public DateTime InitDate { get; set; }
        public DateTime FinishDate { get; set; }
    }

    public class GetActiveReservationQueryHandler : IRequestHandler<GetActiveReservationQuery, List<ReservationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetActiveReservationQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<ReservationDto>> Handle(GetActiveReservationQuery request,
            CancellationToken cancellationToken)
        {
            var activereservation =  _context.Reservas
                .Where(e=>e.estado && e.fecha_entrada>= request.InitDate &&  e.fecha_salida < request.FinishDate)
                .Include(e=>e.Usuario)
                .Include(e=>e.Hotel)
                .AsQueryable();
            if (activereservation == null)
            {
                throw new NotFoundException("Error al buscar reservas activas entre estas fechas");
            }

            return await activereservation.ProjectToListAsync<ReservationDto>(_mapper.ConfigurationProvider);


        }
    }
}