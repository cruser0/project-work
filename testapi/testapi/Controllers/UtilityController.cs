using API.Models.DTO;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private readonly ICostRegistryService _costRegistryService;
        private readonly CountryService _countryService;
        public UtilityController(ICostRegistryService crs, CountryService cs)
        {
            _costRegistryService = crs;
            _countryService = cs;
        }
        [Authorize()]
        [HttpGet("get-all-cost-registry")]
        public async Task<IActionResult> GetRegistry()
        {
            List<CostRegistryDTOGet> data = await _costRegistryService.GetAllCostRegistryByCode();
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CostRegistryDTOGet>());
        }
        [HttpGet("get-all-country")]
        public async Task<IActionResult> GetCountry()
        {
            List<CountryDTOGet> data = await _countryService.GetAllCountry();
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CountryDTOGet>());
        }

        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _costRegistryService.MassDeleteCostRegistry(id);
            return Ok(data);
        }
    }
}
