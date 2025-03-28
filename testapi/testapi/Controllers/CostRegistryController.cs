using API.Models.DTO;
using API.Models.Exceptions;
using API.Models.Mapper;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/cost-registry")]
    [ApiController]
    public class CostRegistryController : ControllerBase
    {
        private readonly ICostRegistryService _costRegistryService;
        public CostRegistryController(ICostRegistryService costRegistryService)
        {
            _costRegistryService = costRegistryService;
        }



        // GET: api/<CostRegistryController>

        //[Authorize(Roles = "Admin,CostRegistryRead,CostRegistryWrite,CostRegistryAdmin,SaleWrite,SaleAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CostRegistryFilter filter)
        {
            var data = await _costRegistryService.GetAllCostRegistry(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CostRegistryDTOGet>());
        }




        //[Authorize(Roles = "Admin,CostRegistryRead,CostRegistryWrite,CostRegistryAdmin,SaleWrite,SaleAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CostRegistryFilter filter)
        {
            var data = await _costRegistryService.CountRegistryCost(filter);
            return Ok(data);
        }



        // GET api/<CostRegistryController>/5
        //[Authorize(Roles = "Admin,CostRegistryRead,CostRegistryWrite,CostRegistryAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var data = await _costRegistryService.GetCostRegistryByCode(id);
            if (data == null)
                throw new NotFoundException("CostRegistry not found!");
            return Ok(data);
        }




        // POST api/<CostRegistryController>
        //[Authorize(Roles = "Admin,CostRegistryWrite,CostRegistryAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CostRegistryDTO costRegistry)
        {

            var data = await _costRegistryService.CreateCostRegistry(CostRegistryMapper.Map(costRegistry));
            if (data == null)
                throw new NotFoundException("Data can't be null!");
            return Ok(data);
        }




        // PUT api/<CostRegistryController>/5
        //[Authorize(Roles = "Admin,CostRegistryWrite,CostRegistryAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CostRegistryDTOGet costRegistry)
        {
            var data = await _costRegistryService.UpdateCostRegistry(id, CostRegistryMapper.MapGet(costRegistry));
            if (data == null)
                throw new NotFoundException("CostRegistry not found!");
            return Ok(data);
        }




        // DELETE api/<CostRegistryController>/5
        //[Authorize(Roles = "Admin,CostRegistryAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _costRegistryService.DeleteCostRegistry(id);
            if (data == null)
                throw new NotFoundException("CostRegistry not found!");
            return Ok(data);
        }




        //[Authorize(Roles = "Admin,CostRegistryAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _costRegistryService.MassDeleteCostRegistry(id);
            return Ok(data);
        }




        //[Authorize(Roles = "Admin,CostRegistryAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<CostRegistryDTOGet> newCostRegistrys)
        {
            var data = await _costRegistryService.MassUpdateCostRegistry(newCostRegistrys);
            return Ok(data);
        }
    }
}
