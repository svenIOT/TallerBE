using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Coche
    {
        public string MatCoche { get; set; }
        public string NumBastidor { get; set; }

        public virtual Vehiculo NumBastidorNavigation { get; set; }
    }
}
