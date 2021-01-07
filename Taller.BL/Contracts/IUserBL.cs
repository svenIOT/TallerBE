using System;
using System.Collections.Generic;
using System.Text;
using Taller.CORE.DTO;

namespace Taller.BL.Contracts
{
    public interface IUserBL
    {
        bool Login(UserDTO userDTO);
        void Add(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
    }
}
