using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Concesionario
    {
        public Concesionario()
        {
            Empleado = new HashSet<Empleado>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int CodConce { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
