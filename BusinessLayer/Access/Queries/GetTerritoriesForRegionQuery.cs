using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Access.Queries
{
    public class GetTerritoriesForRegionQuery
    {
        public GetTerritoriesForRegionQuery(int regionId)
        {
            this.RegionId = regionId;
        }

        public int RegionId { get; }
    }
}
