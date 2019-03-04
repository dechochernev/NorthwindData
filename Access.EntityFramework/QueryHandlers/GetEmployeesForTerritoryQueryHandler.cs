using Access.EntityFramework.Models;
using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Access.EntityFramework.QueryHandlers
{
    public class GetEmployeesForTerritoryQueryHandler : IGetEmployeesForTerritoryQuery
    {
        private readonly NorthwindContext northwindContext;

        public GetEmployeesForTerritoryQueryHandler(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task<IEnumerable<Employee>> HandleAsync(GetEmployeesForTerritoryQuery query)
        {
            using (var context = northwindContext)
            {
                var territory = (await context.Territories.Include(t => t.EmployeeTerritories)
                    .ThenInclude(e => e.Employee)
                    .Where(t => t.TerritoryId == query.TerritoryId)
                    .ToListAsync())
                    .FirstOrDefault();
                
                return Transform(territory);
            }
        }

        private IEnumerable<Employee> Transform(Territories territories)
        {
            foreach (var territoryEmployees in territories.EmployeeTerritories)
            {
                yield return new Employee
                {
                    FirstName = territoryEmployees.Employee.FirstName,
                    LastName = territoryEmployees.Employee.LastName,
                    BirthDate = territoryEmployees.Employee.BirthDate,
                    Country = territoryEmployees.Employee.Country,
                    EmployeeId = territoryEmployees.Employee.EmployeeId,
                    HomePhone = territoryEmployees.Employee.HomePhone,
                    Notes = territoryEmployees.Employee.Notes,
                    Photo = territoryEmployees.Employee.Photo,
                    Title = territoryEmployees.Employee.Title,
                    TitleOfCourtesy = territoryEmployees.Employee.TitleOfCourtesy
                };
            }
        }
    }
}
