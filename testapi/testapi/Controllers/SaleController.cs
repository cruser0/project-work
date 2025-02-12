using Microsoft.AspNetCore.Mvc;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISalesREPO _saleREPO;
        public SaleController(ISalesREPO saleREPO)
        {
            _saleREPO = saleREPO;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _saleREPO.GetAllSales();
                if(result.Any())
                {
                    return Ok(result);
                }
                else throw new Exception("Sale not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _saleREPO.GetSaleById(id);
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
            
        }

        // POST api/<SaleController>
        [HttpPost]
        public IActionResult Post(SaleDTO sale)
        {
            try
            {
                var data = _saleREPO.CreateSale(SaleMapper.Map(sale));
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaleDTO sale)
        {
            try
            {
                var data = _saleREPO.UpdateSale(id, SaleMapper.Map(sale));
                if (data == null)
                    throw new Exception("Couldn't update sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _saleREPO.DeleteSale(id);
                if (data == null)
                    throw new Exception("Couldn't create sale");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }
    }
}
