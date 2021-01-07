using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taller.CORE.DTO;
using Taller.DAL.Models;
using Taller.DAL.Repository.Contracts;

namespace Taller.DAL.Repository.Implements
{
    public class RepositoryProposition: IRepositoryProposition
    {
        public tallerContext _context { get; set; }

        public RepositoryProposition(tallerContext context)
        {
            _context = context;
        }
        public IEnumerable<PropositionDTO> GetPropositions() 
        {
            var propositionDTO = new List<PropositionDTO>();

            _context.Propuesta.ToList().ForEach(p => propositionDTO.Add(
                    new PropositionDTO 
                    {
                        FechaValidez = p.FechaValidez,
                        NumBastidor = p.NumBastidor,
                        Precio = p.Precio,
                        Vendido = p.Vendido
                    }
                ));
            return propositionDTO;
        }
    }
}