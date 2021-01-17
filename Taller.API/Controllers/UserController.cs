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
    [ApiController, Route("User")]
    public class UserController : ControllerBase
    {
        public IUserBL _userBL { get; set; }
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost, Route("Add")]
        public ActionResult<bool> Add(UserDTO usuarioDTO) 
        {
            _userBL.Add(usuarioDTO);
            return Ok(true);
        }

        [HttpPost]
        public ActionResult<IEnumerable<UserDTO>> GetUsers() => Ok(_userBL.GetUsers());
    }
}