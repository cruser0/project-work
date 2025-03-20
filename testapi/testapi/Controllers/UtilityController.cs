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
        private readonly CostRegistryService _costRegistryService;
        private readonly CountryService _countryService;
        public UtilityController(CostRegistryService crs, CountryService cs)
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
    }
}
