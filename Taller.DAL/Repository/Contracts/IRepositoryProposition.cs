using System;
using System.Collections.Generic;
using System.Text;
using Taller.CORE.DTO;

namespace Taller.DAL.Repository.Contracts
{
    public interface IRepositoryProposition
    {
        IEnumerable<PropositionDTO> GetSalesPropositions(IEnumerable<UserDTO> users);
    }
}
