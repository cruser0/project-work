using API.Models.Entities;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/preference/")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly UserService _userService;
        public PreferenceController(UserService us)
        {
            _userService = us;
        }
        // GET: api/<ValuesController1>
        [HttpGet("customerdgv/{id}")]
        public IActionResult GetCustomerDGV(int id)
        {
            try
            {
                var result = _userService.GetCustomerDGV(id);
                return Ok(result);
                
            }catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("customerdgv")]
        public ActionResult<CustomerDGV> PostCustomerDGV([FromBody] CustomerDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateCustomerDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("customer-invoicedgv/{id}")]
        public IActionResult GetCustomerInvoiceDGV(int id)
        {
            try
            {
                var result = _userService.GetCustomerInvoiceDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("customer-invoicedgv")]
        public IActionResult PostCustomerInvoiceDGV([FromBody] CustomerInvoiceDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateCustomerInvoiceDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("customer-invoice-costdgv/{id}")]
        public IActionResult GetCustomerInvoiceCostDGV(int id)
        {
            try
            {
                var result = _userService.GetCustomerInvoiceCostDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("customer-invoice-costdgv")]
        public IActionResult PostCustomerInvoiceCostDGV([FromBody] CustomerInvoiceCostDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateCustomerInvoiceCostDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("supplierdgv/{id}")]
        public IActionResult GetSupplierDGV(int id)
        {
            try
            {
                var result = _userService.GetSupplierDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("supplierdgv")]
        public IActionResult PostSupplierDGV([FromBody] SupplierDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateSupplierDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("supplier-invoicedgv/{id}")]
        public IActionResult GetSupplierInvoiceDGV(int id)
        {
            try
            {
                var result = _userService.GetSupplierInvoiceDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("supplier-invoicedgv")]
        public IActionResult PostSupplierInvoiceDGV([FromBody] SupplierInvoiceDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateSupplierInvoiceDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("supplier-invoice-costdgv/{id}")]
        public IActionResult GetSupplierInvoiceCostDGV(int id)
        {
            try
            {
                var result = _userService.GetSupplierInvoiceCostDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("supplier-invoice-costdgv")]
        public IActionResult PostSupplierInvoiceCostDGV([FromBody] SupplierInvoiceCostDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateSupplierInvoiceCostDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("saledgv/{id}")]
        public IActionResult GetSaleDGV(int id)
        {
            try
            {
                var result = _userService.GetSaleDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("saledgv")]
        public IActionResult PostSaleDGV([FromBody] SaleDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateSaleDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("userdgv/{id}")]
        public IActionResult GetUserDGV(int id)
        {
            try
            {
                var result = _userService.GetUserDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("userdgv")]
        public IActionResult PostUserDGV([FromBody] UserDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateUserDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("create-favourite-page")]
        public IActionResult CreateFavouritePage([FromBody] string value)
        {
            try
            {
                _userService.CreateFavouritePages(value);
                return Ok("Favourite Page Created Successfully");

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("add-user-favourite-page/{id}")]
        public IActionResult AddUserFavouritePage([FromBody] List<string> value,int userID)
        {
            try
            {
                _userService.AddFavouritePagesToUser(value, userID);
                return Ok("Favourite Page added to user Successfully");

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


    }
}
