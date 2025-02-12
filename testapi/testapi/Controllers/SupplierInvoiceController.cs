using Microsoft.AspNetCore.Mvc;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
    [Route("api/supplier-invoice")]
    [ApiController]
    public class SupplierInvoiceController : ControllerBase
    {
        private readonly ISupplierInvoiceREPO _supplierInvoiceREPO;
        public SupplierInvoiceController(ISupplierInvoiceREPO supplierInvoiceREPO)
        {
            _supplierInvoiceREPO = supplierInvoiceREPO;
        }
        // GET: api/<SupplierInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _supplierInvoiceREPO.GetAllSupplierInvoices();
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
                var data = _supplierInvoiceREPO.GetSupplierInvoiceById(id);
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
                var data = _supplierInvoiceREPO.CreateSupplierInvoice(SupplierInvoiceMapper.Map(supplierInvoice));
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
                var data = _supplierInvoiceREPO.UpdateSupplierInvoice(id, SupplierInvoiceMapper.Map(supplierInvoice));
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
                var data = _supplierInvoiceREPO.DeleteSupplierInvoice(id);
                if (data == null)
                    throw new Exception("Couldn't delete supplier invoice");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
