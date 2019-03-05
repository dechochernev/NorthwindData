using BusinessLayer.Usecases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NorthwindApp.ViewModels;
using System.Threading.Tasks;

namespace NorthwindApp.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IGetAllRegions getAllRegions;
        private readonly IGetTerritoriesForRegion getTerritoriesForRegion;
        private readonly IGetEmployeesForTerritory getEmployeesForTerritory;
        private readonly IUpdateEmployeeNotes updateEmployeeNotes;
        private readonly IGetMostExpensiveProducts getMostExpensiveProducts;

        public RegionsController(
            IGetAllRegions getAllRegions, 
            IGetTerritoriesForRegion getTerritoriesForRegion, 
            IGetEmployeesForTerritory getEmployeesForTerritory, 
            IUpdateEmployeeNotes updateEmployeeNotes,
            IGetMostExpensiveProducts getMostExpensiveProducts)
        {
            this.getAllRegions = getAllRegions;
            this.getTerritoriesForRegion = getTerritoriesForRegion;
            this.getEmployeesForTerritory = getEmployeesForTerritory;
            this.updateEmployeeNotes = updateEmployeeNotes;
            this.getMostExpensiveProducts = getMostExpensiveProducts;
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetAllRegionsAsync()
        {
            var regions = await getAllRegions.GetAllRegionsAsync();

            return Json(regions);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetTerritoriesForRegionAsync(int regionId)
        {
            var territories = await getTerritoriesForRegion.GetTerritoriesForRegionAsync(regionId);

            return Json(territories);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetEmployeesForTerritoryAsync(string territoryId)
        {
            var employees = await getEmployeesForTerritory.GetEmployeesForTerritoryAsync(territoryId);

            return Json(employees);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateEmployeeNotesAsync(int employeeId, string notes)
        {
            await updateEmployeeNotes.UpdateEmployeeNotesAsync(employeeId, notes);
            return CreatedAtAction(nameof(UpdateEmployeeNotesAsync),employeeId);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetReportingDataAsync(string territoryId)
        {
            var reportingData = await getMostExpensiveProducts.GetMostExpensiveProductsAsync();
            var reportingViewModel = new ReportingViewModel();
            reportingViewModel.MostExpensiveProducts = reportingData;
            return Json(reportingViewModel);
        }
    }
}