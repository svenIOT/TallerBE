using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Mecanico
    {
        public Mecanico()
        {
            InverseCodMecanicoJefeNavigation = new HashSet<Mecanico>();
            Reparacion = new HashSet<Reparacion>();
        }

        public int CodMecanico { get; set; }
        public int CodMecanicoJefe { get; set; }
        public int CodEspecialidad { get; set; }
        public int CodEmpleado { get; set; }

        public virtual Empleado CodEmpleadoNavigation { get; set; }
        public virtual Especialidad CodEspecialidadNavigation { get; set; }
        public virtual Mecanico CodMecanicoJefeNavigation { get; set; }
        public virtual ICollection<Mecanico> InverseCodMecanicoJefeNavigation { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
    }
}
