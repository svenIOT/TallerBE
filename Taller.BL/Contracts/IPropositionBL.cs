using System;
using System.Collections.Generic;
using System.Text;
using Taller.CORE.DTO;

namespace Taller.BL.Contracts
{
    public interface IPropositionBL
    {
        IEnumerable<PropositionDTO> GetSalesPropositions();
    }
}
