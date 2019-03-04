using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases.Interfaces
{
    public interface IGetTerritoriesForRegion
    {
        Task<IEnumerable<Territory>> GetTerritoriesForRegionAsync(int regionId);
    }
}
