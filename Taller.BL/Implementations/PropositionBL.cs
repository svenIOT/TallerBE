using System;
using System.Collections.Generic;
using System.Text;
using Taller.BL.Contracts;
using Taller.CORE.DTO;
using Taller.DAL.Repository.Contracts;

namespace Taller.BL.Implementations
{
    public class PropositionBL : IPropositionBL
    {
        public IRepositoryProposition _repositoryProposition { get; set; }
        public PropositionBL(IRepositoryProposition repositoryProposition)
        {
            _repositoryProposition = repositoryProposition;
        }
        public IEnumerable<PropositionDTO> GetPropositions() => _repositoryProposition.GetPropositions();
    }
}
