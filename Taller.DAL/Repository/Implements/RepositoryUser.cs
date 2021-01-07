using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taller.CORE.DTO;
using Taller.DAL.Models;
using Taller.DAL.Repository.Contracts;

namespace Taller.DAL.Repository.Implements
{
    public class RepositoryUser : IRepositoryUser
    {
        public tallerContext _context { get; set; }

        public RepositoryUser(tallerContext context)
        {
            _context = context;
        }
        public bool Login(UserDTO userDTO) => _context.Empleado.Any(
            e => e.Usuario == userDTO.Username && e.Contrasena == userDTO.Password
            );

        public void Add(UserDTO userDTO)
        {
            _context.Empleado.Add(new Empleado()
                {
                    Dni = "holiquetal",
                    Usuario = userDTO.Username,
                    Contrasena = userDTO.Password,
                    CodConce = 1
                }
            );
            _context.SaveChanges();
        }

        public IEnumerable<UserDTO> GetUsers() 
        {
            var usersDTO = new List<UserDTO>();

            _context.Empleado.ToList().ForEach(u => usersDTO.Add(
                    new UserDTO 
                    {
                        Username = u.Usuario,
                        Password = u.Contrasena
                    }
                ));
            return usersDTO;
        }
    }
}