using System;
using System.ComponentModel;

namespace ProyectoPruebaBrujula.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}