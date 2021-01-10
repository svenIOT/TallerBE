using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.BL.Contracts;
using Taller.CORE.DTO;

namespace Taller.API.Controllers
{
    [ApiController, Route("Login")]
    public class LoginController
    {
        public IUserBL _userBL { get; set; }
        public LoginController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost]
        public bool Login(UserDTO user) => _userBL.Login(user);
    }
}