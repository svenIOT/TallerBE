using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Jefe
    {
        public int CodJefe { get; set; }
        public int CodEmpleado { get; set; }

        public virtual Empleado CodEmpleadoNavigation { get; set; }
    }
}
