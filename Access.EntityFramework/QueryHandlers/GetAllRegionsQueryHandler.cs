using Access.EntityFramework.Models;
using BusinessLayer.Access.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Access.EntityFramework.QueryHandlers
{
    public class GetAllRegionsQueryHandler : IGetAllRegionsQuery
    {
        private readonly NorthwindContext northwindContext;

        public GetAllRegionsQueryHandler(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task<IEnumerable<BusinessLayer.Models.Region>> HandleAsync()
        {
            using (var context = northwindContext)
            {
                var regions = await context.Region.ToListAsync();
                    
                return Transform(regions);
            }
        }

        private IEnumerable<BusinessLayer.Models.Region> Transform(List<Models.Region> regions)
        {
            foreach (var region in regions)
            {
                yield return new BusinessLayer.Models.Region
                {
                    RegionId = region.RegionId,
                    RegionDescription = region.RegionDescription
                };
            }
        }
    }
}
