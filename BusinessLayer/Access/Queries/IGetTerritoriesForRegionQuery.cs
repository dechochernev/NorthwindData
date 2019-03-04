using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Access.Queries
{
    public interface IGetTerritoriesForRegionQuery
    {
        Task<IEnumerable<Territory>> HandleAsync(GetTerritoriesForRegionQuery query);
    }
}
