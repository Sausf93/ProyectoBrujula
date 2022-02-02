using System.Threading.Tasks;
using ProyectoPruebaBrujula.Domain.Common;

namespace ProyectoPruebaBrujula.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}