using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
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
        [HttpGet]
        public IActionResult Get([FromQuery] SupplierInvoiceFilter filter)
        {
            try
            {
                var data = _supplierInvoiceService.GetAllSupplierInvoices(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Supplier Invoice not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<SupplierInvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _supplierInvoiceService.GetSupplierInvoiceById(id);
                if (data == null)
                    throw new Exception("Supplier Invoice not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // POST api/<SupplierInvoiceController>
        [HttpPost]
        public IActionResult Post(SupplierInvoiceDTO supplierInvoice)
        {
            try
            {
                var data = _supplierInvoiceService.CreateSupplierInvoice(SupplierInvoiceMapper.Map(supplierInvoice));
                if (data == null)
                    throw new Exception("Couldn't create supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<SupplierInvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierInvoiceDTO supplierInvoice)
        {
            try
            {
                var data = _supplierInvoiceService.UpdateSupplierInvoice(id, SupplierInvoiceMapper.Map(supplierInvoice));
                if (data == null)
                    throw new Exception("Couldn't update supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<SupplierInvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _supplierInvoiceService.DeleteSupplierInvoice(id);
                if (data == null)
                    throw new Exception("Couldn't delete supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
