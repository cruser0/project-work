using API.Models.DTO;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISalesService _saleService;
        private readonly StatusService _statusService;
        public SaleController(ISalesService saleService, StatusService statusService)
        {
            _saleService = saleService;
            _statusService = statusService;
        }
        // GET: api/<SaleController>
        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SaleCustomerFilter filter)
        {
            var result = await _saleService.GetAllSales(filter);
            if (result.Any())
            {
                return Ok(result);
            }
            else return Ok(new List<SaleCustomerDTO>());
        }

        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SaleCustomerFilter filter)
        {
            var result = await _saleService.CountSales(filter);
            return Ok(result);
        }

        // GET api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _saleService.GetSaleById(id);
            if (data == null)
                throw new NotFoundException("Couldn't create sale");
            return Ok(data);
        }

        // POST api/<SaleController>
        [Authorize(Roles = "Admin,SaleWrite,SaleAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SaleDTO sale)
        {
            var data = await _saleService.CreateSale(SaleMapper.Map(sale, await _statusService.GetStatusByName(sale.Status!)));
            if (data == null)
                throw new NotFoundException("Couldn't create sale");
            return Ok(data);
        }

        // PUT api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleWrite,SaleAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaleDTO sale)
        {
            var data = await _saleService.UpdateSale(id, SaleMapper.Map(sale, await _statusService.GetStatusByName(sale.Status!)));
            if (data == null)
                throw new NotFoundException("Couldn't update sale");
            return Ok(data);
        }

        // DELETE api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var data = await _saleService.DeleteSale(id);
            if (data == null)
                throw new NotFoundException("Couldn't create sale");
            return Ok(data);
        }

        [Authorize(Roles = "Admin,SaleAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _saleService.MassDeleteSale(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<SaleDTOGet> newSales)
        {
            var data = await _saleService.MassUpdateSale(newSales);
            return Ok(data);
        }
    }
}
