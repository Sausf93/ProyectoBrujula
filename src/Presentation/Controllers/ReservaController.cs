using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaBrujula.Application.Common.Dto;
using ProyectoPruebaBrujula.Application.Reservas.Command.CancelationReservation;
using ProyectoPruebaBrujula.Application.Reservas.Command.CreateReservation;
using ProyectoPruebaBrujula.Application.Reservas.Querys.GetActiveReservation;

namespace ProyectoPruebaBrujula.Presentation.Controllers
{
    public class ReservaController: ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> CreateReservation(CreateReservationCommand query)
        {
            return await Mediator.Send(query);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> Update(int id, CancelationReservationCommand command)
        {
            //Esto lo suelo hacer para que tengan que pasarla por los dos parametros.
            if (id != command.IdReserva)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpGet("ActiveReservation")]
        public async Task<ActionResult<List<ReservationDto>>> GetActiveReservation(
          [FromQuery]  GetActiveReservationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}