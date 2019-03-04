using BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Access.Queries
{
    public interface IGetAllRegionsQuery
    {
        Task<IEnumerable<Region>> HandleAsync();
    }
}
