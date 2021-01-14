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
            e => e.Usuario == "jefe" && e.Contrasena == userDTO.Password
            );

        public void Add(UserDTO userDTO)
        {
            userDTO.EmployeeId = 0; // Autogenerado
            // Añadir en empleado
            _addInEmployeeTable(userDTO);
            // Añadir en persona
            _addInPersonTable(userDTO);
            // Añadir en mecánico o ventas
            _addInEmployeeTypeTable(userDTO);

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

        private void _addInPersonTable(UserDTO userDTO) => _context.Persona.Add(new Persona()
            {
                Dni = userDTO.Dni,
                Nombre = userDTO.Name,
                Apellidos = userDTO.Surnames,
                Telefono = userDTO.Phone
            }
                );

        private void _addInEmployeeTable(UserDTO userDTO) => _context.Empleado.Add(new Empleado()
            {
                CodEmpleado = userDTO.EmployeeId, // Autogenerado
                Dni = userDTO.Dni,
                Usuario = userDTO.Username,
                Contrasena = userDTO.Password,
                CodConce = 1
            }
                );

        private void _addInEmployeeTypeTable(UserDTO userDTO) 
        {
            if (userDTO.EmployeeType == "mechanic")
            {
                _context.Mecanico.Add(new Mecanico()
                {
                    CodMecanico = 0, // Autogenerado
                    CodMecanicoJefe = 1,
                    CodEspecialidad = _specialtyToNumber(userDTO.EmployeeType),
                    CodEmpleado = userDTO.EmployeeId
                }
               );
            } 
            else
            {
                _context.Ventas.Add(new Ventas()
                {
                    CodVentas = 0, // Autogenerado
                    CodEmpleado = userDTO.EmployeeId
                }
               );
            }
        } 
        
        private int _specialtyToNumber(string specialty) 
        {
            int specialtyNumber;
            if (specialty == "car") specialtyNumber = 1;
            else if (specialty == "motorcycle") specialtyNumber = 2;
            else specialtyNumber = 3;

            return specialtyNumber;
        }
    }
}