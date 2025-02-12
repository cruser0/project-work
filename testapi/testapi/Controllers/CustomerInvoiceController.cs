using Microsoft.AspNetCore.Mvc;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
    [Route("api/customer-invoice")]
    [ApiController]
    public class CustomerInvoiceController : ControllerBase
    {
        private readonly ICustomerInvoicesREPO _customerInvoiceREPO;
        public CustomerInvoiceController(ICustomerInvoicesREPO customerInvoiceREPO)
        {
            _customerInvoiceREPO = customerInvoiceREPO;
        }
        // GET: api/<CustomerInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _customerInvoiceREPO.GetAllCustomerInvoices();
                if (result.Any())
                {
                    return Ok(result);
                }
                else throw new Exception("Customer Invoices not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<CustomerInvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
               var data = _customerInvoiceREPO.GetCustomerInvoiceById(id);
                if (data == null)
                    throw new Exception("Customer Invoices not found");
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
            return Ok(_customerInvoiceREPO.GetCustomerInvoiceById(id));
        }

        // POST api/<CustomerInvoiceController>
        [HttpPost]
        public IActionResult Post(CustomerInvoiceDTO customerInvoice)
        {
            try
            {
                var data = _customerInvoiceREPO.CreateCustomerInvoice(CustomerInvoiceMapper.Map(customerInvoice));
                if (data == null)
                    throw new Exception("Customer Invoices not found!");
                return Ok(data);
            }
            catch (Exception ane) { return BadRequest(ane.Message); }
            
        }

        // PUT api/<CustomerInvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerInvoiceDTO customerInvoice)
        {
            try
            {
                var data = _customerInvoiceREPO.UpdateCustomerInvoice(id, CustomerInvoiceMapper.Map(customerInvoice));
                if (data == null)
                    throw new Exception("Customer Invoices not found!");
                return Ok(data);
            }
            catch (Exception ane) { return BadRequest(ane.Message); }
            
        }

        // DELETE api/<CustomerInvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _customerInvoiceREPO.DeleteCustomerInvoice(id);
                if (data == null)
                    throw new Exception("Customer Invoices not found!");
                return Ok(data);
            }
            catch (Exception ane) { return BadRequest(ane.Message); }
            
        }
    }
}
