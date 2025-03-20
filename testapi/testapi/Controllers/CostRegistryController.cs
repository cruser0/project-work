using API.Models.DTO;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CostRegistryController : ControllerBase
    {
        private readonly CostRegistryService _costRegistryService;
        public CostRegistryController(CostRegistryService crs)
        {
            _costRegistryService = crs;
        }
        [Authorize()]
        [HttpGet("get-all-cost-registry")]
        public async Task<IActionResult> Get()
        {
            List<CostRegistryDTOGet> data = await _costRegistryService.GetAllCostRegistryByCode();
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CostRegistryDTOGet>());
        }
    }
}
