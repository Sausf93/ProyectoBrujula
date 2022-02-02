using System;

namespace ProyectoPruebaBrujula.Application.Common.Security
{
    /// <summary>
    /// Specifies the class this attribute is applied to requires authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute
    {
        public AuthorizeAttribute() { }

        public string Roles { get; set; }
    }
}