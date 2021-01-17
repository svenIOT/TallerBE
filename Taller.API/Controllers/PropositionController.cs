using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.BL.Contracts;
using Taller.CORE.DTO;

namespace Taller.API.Controllers
{
    [ApiController, Route("Proposition")]
    public class PropositionController : ControllerBase
    {
        public IPropositionBL _propositionBL { get; set; }
        public PropositionController(IPropositionBL propositionBL)
        {
            _propositionBL = propositionBL;
        }

        [HttpGet, Route("Sales")]
        public ActionResult<IEnumerable<PropositionDTO>> GetSalesPropositions() => Ok(_propositionBL.GetSalesPropositions());
    }
}