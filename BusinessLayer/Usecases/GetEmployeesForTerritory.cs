using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using BusinessLayer.Usecases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases
{
    public class GetEmployeesForTerritory : IGetEmployeesForTerritory
    {
        private readonly IGetEmployeesForTerritoryQuery handlers;

        public GetEmployeesForTerritory(IGetEmployeesForTerritoryQuery handlers)
        {
            this.handlers = handlers;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesForTerritoryAsync(string territoryId)
        {
            var employees = await handlers.HandleAsync(new GetEmployeesForTerritoryQuery(territoryId));
            return employees;
        }
    }
}
