﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taller.CORE.DTO;
using Taller.DAL.Models;
using Taller.DAL.Repository.Contracts;

namespace Taller.DAL.Repository.Implements
{
    public class RepositoryProposition: IRepositoryProposition
    {
        public tallerContext _context { get; set; }

        public RepositoryProposition(tallerContext context)
        {
            _context = context;
        }
        public IEnumerable<PropositionDTO> GetSalesPropositions(IEnumerable<UserDTO> users) 
        {
            var propositionDTO = new List<PropositionDTO>();

            var soldPropositions = _context.Propuesta.Where(p => p.Vendido == true).ToList();

            var vehicles = _context.Vehiculo.ToList();

            soldPropositions.ForEach(p => propositionDTO.Add(
                    new PropositionDTO
                    {
                        FechaValidez = p.FechaValidez,
                        NumBastidor = p.NumBastidor,
                        Precio = p.Precio,
                        Vendido = p.Vendido,
                        TipoVehiculo = vehicles.Where(v => v.NumBastidor == p.NumBastidor).First().TipoVehiculo,
                        CodVentas = p.CodVentas,
                        NombreVendedor = _getSalesEmployeeName(users.ToList(), p.CodVentas)

                    }
                ));
            return propositionDTO;
        }

        private string _getSalesEmployeeName(List<UserDTO> users, int salesId)
        {
            var salesUsers = _context.Ventas.ToList();
            var idResult = salesUsers.Where(s => s.CodVentas == salesId).First().CodEmpleado;
            var name = users.Where(u => u.EmployeeId == idResult).First().Name;
            var surnames = users.Where(u => u.EmployeeId == idResult).First().Surnames;
            return name + " " + surnames;
        }
    }
}