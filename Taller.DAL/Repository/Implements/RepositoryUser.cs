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

        /// <summary>
        /// Comprueba si el usuario recibido existe en la BBDD
        /// </summary> 
        /// <param name="userDTO">Usuario</param>
        /// <returns>true o false</returns>
        public bool Login(UserDTO userDTO) => _context.Empleado.Any(
            e => e.Usuario == "jefe" && e.Contrasena == userDTO.Password
            );

        /// <summary>
        /// Añade el usuario a la BBDD en las tablas persona, empleado, y ventas o mécanico
        /// </summary> 
        /// <param name="userDTO">Usuario</param>
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

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary> 
        /// <returns>Enumerable con todos los usuarios</returns>
        public IEnumerable<UserDTO> GetUsers()
        {
            var usersDTO = new List<UserDTO>();

            var allUsers = _context.Persona.ToList();
            
            _context.Empleado.ToList().ForEach(u => usersDTO.Add(
                    new UserDTO
                    {
                        Dni = u.Dni,
                        Username = u.Usuario,
                        Password = u.Contrasena,
                        EmployeeId = u.CodEmpleado,
                        Name = allUsers.Where(e => e.Dni == u.Dni).First().Nombre,
                        Surnames = allUsers.Where(e => e.Dni == u.Dni).First().Apellidos,
                        Phone = allUsers.Where(e => e.Dni == u.Dni).First().Telefono,
                    }
                ));
            return usersDTO;
        }

        /// <summary>
        /// Añade el usuario en la tabla persona
        /// </summary> 
        /// <param name="userDTO">Usuario</param>
        private void _addInPersonTable(UserDTO userDTO) => _context.Persona.Add(new Persona()
            {
                Dni = userDTO.Dni,
                Nombre = userDTO.Name,
                Apellidos = userDTO.Surnames,
                Telefono = userDTO.Phone
            }
                );

        /// <summary>
        /// Añade el usuario en la tabla empleado
        /// </summary> 
        /// <param name="userDTO">Usuario</param>
        private void _addInEmployeeTable(UserDTO userDTO) => _context.Empleado.Add(new Empleado()
            {
                CodEmpleado = userDTO.EmployeeId, // Autogenerado
                Dni = userDTO.Dni,
                Usuario = userDTO.Username,
                Contrasena = userDTO.Password,
                CodConce = 1
            }
                );

        /// <summary>
        /// Añade el usuario en la tabla ventas o mecánico
        /// </summary> 
        /// <param name="userDTO">Usuario</param>
        private void _addInEmployeeTypeTable(UserDTO userDTO) 
        {
            if (userDTO.EmployeeType == "mechanic")
            {
                _context.Mecanico.Add(new Mecanico()
                {
                    CodMecanico = 0, // Autogenerado
                    CodMecanicoJefe = 1,
                    CodEspecialidad = _specialtyToNumber(userDTO.Specialty),
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

        /// <summary>
        /// Convierte el nombre de la especialidad del mecánico a su equivalente código para la tabla 
        /// especialidad en la BBDD
        /// </summary> 
        /// <param name="specialty">Nombre de la especialidad</param>
        /// <returns>Número con el código de la especialidad (1, 2 o 3)</returns>
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