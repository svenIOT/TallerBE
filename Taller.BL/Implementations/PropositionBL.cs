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
        public IRepositoryUser _repositoryUser { get; set; }
        public PropositionBL(IRepositoryProposition repositoryProposition, IRepositoryUser repositoryUser)
        {
            _repositoryProposition = repositoryProposition;
            _repositoryUser = repositoryUser;
        }
        public IEnumerable<PropositionDTO> GetSalesPropositions() => _repositoryProposition.GetSalesPropositions(_repositoryUser.GetUsers());

       
    }
}
