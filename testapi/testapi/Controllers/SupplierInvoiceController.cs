using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/supplier-invoice")]
    [ApiController]
    public class SupplierInvoiceController : ControllerBase
    {
        private readonly ISupplierInvoiceService _supplierInvoiceService;
        public SupplierInvoiceController(ISupplierInvoiceService supplierInvoiceService)
        {
            _supplierInvoiceService = supplierInvoiceService;
        }
        // GET: api/<SupplierInvoiceController>
        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierInvoiceFilter filter)
        {
            try
            {
                var data = await _supplierInvoiceService.GetAllSupplierInvoices(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Supplier Invoice not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SupplierInvoiceFilter filter)
        {

            var data = await _supplierInvoiceService.CountSupplierinvoices(filter);
            return Ok(data);

        }

        // GET api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _supplierInvoiceService.GetSupplierInvoiceById(id);
                if (data == null)
                    throw new Exception("Supplier Invoice not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // POST api/<SupplierInvoiceController>
        [Authorize(Roles = "Admin,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInvoiceDTO supplierInvoice)
        {
            try
            {
                var data = await _supplierInvoiceService.CreateSupplierInvoice(SupplierInvoiceMapper.Map(supplierInvoice));
                if (data == null)
                    throw new Exception("Couldn't create supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierInvoiceDTO supplierInvoice)
        {
            try
            {
                var data = await _supplierInvoiceService.UpdateSupplierInvoice(id, SupplierInvoiceMapper.Map(supplierInvoice));
                if (data == null)
                    throw new Exception("Couldn't update supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _supplierInvoiceService.DeleteSupplierInvoice(id);
                if (data == null)
                    throw new Exception("Couldn't delete supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
