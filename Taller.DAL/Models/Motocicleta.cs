using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Motocicleta
    {
        public string MatMoto { get; set; }
        public string NumBastidor { get; set; }

        public virtual Vehiculo NumBastidorNavigation { get; set; }
    }
}
