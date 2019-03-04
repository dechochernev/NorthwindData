using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Access.Queries
{
    public class GetEmployeesForTerritoryQuery
    {
        public GetEmployeesForTerritoryQuery(string territoryId)
        {
            this.TerritoryId = territoryId;
        }

        public string TerritoryId { get; }
    }
}
