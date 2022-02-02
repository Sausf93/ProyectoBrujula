using System;
using ProyectoPruebaBrujula.Application.Common.Interfaces;

namespace ProyectoPruebaBrujula.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}