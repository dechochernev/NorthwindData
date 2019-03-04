using Access.EntityFramework.Models;
using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Access.EntityFramework.QueryHandlers
{
    public class GetTerritoriesForRegionQueryHandler : IGetTerritoriesForRegionQuery
    {
        private readonly NorthwindContext northwindContext;

        public GetTerritoriesForRegionQueryHandler(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task<IEnumerable<Territory>> HandleAsync(GetTerritoriesForRegionQuery query)
        {
            using (var context = northwindContext)
            {
                var territories = await context.Territories.Where(
                    t => t.RegionId == query.RegionId).ToListAsync();

                return Transform(territories);
            }
        }

        private IEnumerable<Territory> Transform(List<Territories> territories)
        {
            foreach (var territory in territories)
            {
                yield return new Territory
                {
                    TerritoryId = territory.TerritoryId,
                    TerritoryDescription = territory.TerritoryDescription
                };
            }
        }
    }
}
