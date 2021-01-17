using System;
using System.Collections.Generic;
using System.Text;

namespace Taller.CORE.DTO
{
    public class PropositionDTO
    {
        public string NumBastidor { get; set; }
        public DateTime? FechaValidez { get; set; }
        public string Precio { get; set; }
        public bool? Vendido { get; set; }
        public string TipoVehiculo { get; set; }
        public int CodVentas { get; set; }
        public string NombreVendedor { get; set; }

        public PropositionDTO()
        {

        }
    }
}