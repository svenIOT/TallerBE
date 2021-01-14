using System;
using System.Collections.Generic;
using System.Text;

namespace Taller.CORE.DTO
{
    public class UserDTO
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Phone { get; set; }
        public string EmployeeType { get; set; }

        public UserDTO()
        {

        }
    }
}
