using API.Models.DTO;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CostRegistryController : Controller
    {
        private readonly CostRegistryService _costRegistryService;
        public CostRegistryController(CostRegistryService crs)
        {
            _costRegistryService = crs;
        }
        [Authorize()]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CostRegistryDTO> data = await _costRegistryService.GetAllCostRegistryByCode();
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CostRegistryDTO>());
        }
    }
}
