using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
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
        public SaleController(ISalesService saleService)
        {
            _saleService = saleService;
        }
        // GET: api/<SaleController>
        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SaleFilter filter)
        {
            try
            {
                var result = await _saleService.GetAllSales(filter);
                if (result.Any())
                {
                    return Ok(result);
                }
                else throw new Exception("Sale not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SaleFilter filter)
        {

            var result = await _saleService.CountSales(filter);
            return Ok(result);

        }

        // GET api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleRead,SaleWrite,SaleAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _saleService.GetSaleById(id);
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // POST api/<SaleController>
        [Authorize(Roles = "Admin,SaleWrite,SaleAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SaleDTO sale)
        {
            try
            {
                var data = await _saleService.CreateSale(SaleMapper.Map(sale));
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // PUT api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleWrite,SaleAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaleDTO sale)
        {
            try
            {
                var data = await _saleService.UpdateSale(id, SaleMapper.Map(sale));
                if (data == null)
                    throw new Exception("Couldn't update sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // DELETE api/<SaleController>/5
        [Authorize(Roles = "Admin,SaleAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _saleService.DeleteSale(id);
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }
    }
}
