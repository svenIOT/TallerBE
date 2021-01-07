using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Propuesta = new HashSet<Propuesta>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int CodCliente { get; set; }
        public string Dni { get; set; }

        public virtual Persona DniNavigation { get; set; }
        public virtual ICollection<Propuesta> Propuesta { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
