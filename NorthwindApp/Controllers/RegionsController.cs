using BusinessLayer.Usecases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NorthwindApp.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IGetAllRegions getAllRegions;
        private readonly IGetTerritoriesForRegion getTerritoriesForRegion;
        private readonly IGetEmployeesForTerritory getEmployeesForTerritory;
        private readonly IUpdateEmployeeNotes updateEmployeeNotes;

        public RegionsController(
            IGetAllRegions getAllRegions, 
            IGetTerritoriesForRegion getTerritoriesForRegion, 
            IGetEmployeesForTerritory getEmployeesForTerritory, 
            IUpdateEmployeeNotes updateEmployeeNotes)
        {
            this.getAllRegions = getAllRegions;
            this.getTerritoriesForRegion = getTerritoriesForRegion;
            this.getEmployeesForTerritory = getEmployeesForTerritory;
            this.updateEmployeeNotes = updateEmployeeNotes;
        }

        [HttpGet("[action]")]
        public async System.Threading.Tasks.Task<JsonResult> GetAllRegionsAsync()
        {
            var regions = await getAllRegions.GetAllRegionsAsync();

            return Json(regions);
        }

        [HttpGet("[action]")]
        public async System.Threading.Tasks.Task<JsonResult> GetTerritoriesForRegionAsync(int regionId)
        {
            var territories = await getTerritoriesForRegion.GetTerritoriesForRegionAsync(regionId);

            return Json(territories);
        }

        [HttpGet("[action]")]
        public async System.Threading.Tasks.Task<JsonResult> GetEmployeesForTerritoryAsync(string territoryId)
        {
            var employees = await getEmployeesForTerritory.GetEmployeesForTerritoryAsync(territoryId);

            return Json(employees);
        }

        [HttpPost("[action]")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateEmployeeNotesAsync(int employeeId, string notes)
        {
            await updateEmployeeNotes.UpdateEmployeeNotesAsync(employeeId, notes);
            return CreatedAtAction(nameof(UpdateEmployeeNotesAsync),employeeId);
        }
    }
}