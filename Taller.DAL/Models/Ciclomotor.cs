using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Ciclomotor
    {
        public string MatCiclo { get; set; }
        public string NumBastidor { get; set; }

        public virtual Vehiculo NumBastidorNavigation { get; set; }
    }
}
