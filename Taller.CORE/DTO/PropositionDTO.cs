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

        public PropositionDTO()
        {

        }
    }
}