using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Mecanico = new HashSet<Mecanico>();
        }

        public int CodEspecialidad { get; set; }
        public string NombreEsp { get; set; }

        public virtual ICollection<Mecanico> Mecanico { get; set; }
    }
}
