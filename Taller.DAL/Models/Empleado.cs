using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Jefe = new HashSet<Jefe>();
            Mecanico = new HashSet<Mecanico>();
            Ventas = new HashSet<Ventas>();
        }

        public int CodEmpleado { get; set; }
        public string Dni { get; set; }
        public int CodConce { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public virtual Concesionario CodConceNavigation { get; set; }
        public virtual Persona DniNavigation { get; set; }
        public virtual ICollection<Jefe> Jefe { get; set; }
        public virtual ICollection<Mecanico> Mecanico { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
