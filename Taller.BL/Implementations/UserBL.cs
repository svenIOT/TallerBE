using System;
using System.Collections.Generic;
using System.Text;
using Taller.BL.Contracts;
using Taller.CORE.DTO;
using Taller.DAL.Repository.Contracts;

namespace Taller.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IRepositoryUser _repositoryUser { get; set; }
        public UserBL(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public bool Login(UserDTO userDTO) => _repositoryUser.Login(userDTO);

        public void Add(UserDTO userDTO) => _repositoryUser.Add(userDTO);

        public IEnumerable<UserDTO> GetUsers() => _repositoryUser.GetUsers();
    }
}
