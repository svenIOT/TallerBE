using System;
using System.Collections.Generic;

namespace Taller.DAL.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Ciclomotor = new HashSet<Ciclomotor>();
            Coche = new HashSet<Coche>();
            Motocicleta = new HashSet<Motocicleta>();
            Propuesta = new HashSet<Propuesta>();
            Reparacion = new HashSet<Reparacion>();
        }

        public string NumBastidor { get; set; }
        public int? CodVentas { get; set; }
        public int? CodCliente { get; set; }
        public int? CodConce { get; set; }
        public string TipoVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Combustible { get; set; }
        public string Precio { get; set; }
        public string Anno { get; set; }
        public string Kilometros { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; }
        public virtual Concesionario CodConceNavigation { get; set; }
        public virtual Ventas CodVentasNavigation { get; set; }
        public virtual ICollection<Ciclomotor> Ciclomotor { get; set; }
        public virtual ICollection<Coche> Coche { get; set; }
        public virtual ICollection<Motocicleta> Motocicleta { get; set; }
        public virtual ICollection<Propuesta> Propuesta { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
    }
}