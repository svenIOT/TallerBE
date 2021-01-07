using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Reparacion
    {
        public int CodReparacion { get; set; }
        public int CodMecanico { get; set; }
        public string NumBastidor { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Piezas { get; set; }
        public string Precio { get; set; }
        public bool? Finalizado { get; set; }

        public virtual Mecanico CodMecanicoNavigation { get; set; }
        public virtual Vehiculo NumBastidorNavigation { get; set; }
    }
}
