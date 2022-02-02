using System.Threading.Tasks;

namespace ProyectoPruebaBrujula.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string Email { get; }
        string Name { get; }
        Task<string> JwtTokenAsync { get; }
    }
}