using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases.Interfaces
{
    public interface IGetEmployeesForTerritory
    {
        Task<IEnumerable<Employee>> GetEmployeesForTerritoryAsync(string territoryId);
    }
}
