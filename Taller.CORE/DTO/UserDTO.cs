using System;
using System.Collections.Generic;
using System.Text;

namespace Taller.CORE.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Phone { get; set; }

        public UserDTO()
        {

        }
    }
}
