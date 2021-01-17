using System;
using System.Collections.Generic;
using System.Text;
using Taller.CORE.DTO;

namespace Taller.DAL.Repository.Contracts
{
    public interface IRepositoryUser
    {
        bool Login(UserDTO userDTO);
        void Add(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
    }
}
