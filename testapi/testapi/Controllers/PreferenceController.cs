using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetCustomerDGV(int id)
        {
            try
            {
                var result = await _userService.GetCustomerDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("customerdgv")]
        public async Task<ActionResult<CustomerDGV>> PostCustomerDGV([FromBody] CustomerDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateCustomerDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpGet("customer-invoicedgv/{id}")]
        public async Task<IActionResult> GetCustomerInvoiceDGV(int id)
        {
            try
            {
                var result = await _userService.GetCustomerInvoiceDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("customer-invoicedgv")]
        public async Task<IActionResult> PostCustomerInvoiceDGV([FromBody] CustomerInvoiceDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateCustomerInvoiceDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }
        [HttpGet("customer-invoice-costdgv/{id}")]
        public async Task<IActionResult> GetCustomerInvoiceCostDGV(int id)
        {
            try
            {
                var result = await _userService.GetCustomerInvoiceCostDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("customer-invoice-costdgv")]
        public async Task<IActionResult> PostCustomerInvoiceCostDGV([FromBody] CustomerInvoiceCostDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateCustomerInvoiceCostDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpGet("supplierdgv/{id}")]
        public async Task<IActionResult> GetSupplierDGV(int id)
        {
            try
            {
                var result = await _userService.GetSupplierDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("supplierdgv")]
        public async Task<IActionResult> PostSupplierDGV([FromBody] SupplierDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateSupplierDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }
        [HttpGet("supplier-invoicedgv/{id}")]
        public async Task<IActionResult> GetSupplierInvoiceDGV(int id)
        {
            try
            {
                var result = await _userService.GetSupplierInvoiceDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("supplier-invoicedgv")]
        public async Task<IActionResult> PostSupplierInvoiceDGV([FromBody] SupplierInvoiceDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateSupplierInvoiceDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }
        [HttpGet("supplier-invoice-costdgv/{id}")]
        public async Task<IActionResult> GetSupplierInvoiceCostDGV(int id)
        {
            try
            {
                var result = await _userService.GetSupplierInvoiceCostDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("supplier-invoice-costdgv")]
        public async Task<IActionResult> PostSupplierInvoiceCostDGV([FromBody] SupplierInvoiceCostDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateSupplierInvoiceCostDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpGet("saledgv/{id}")]
        public async Task<IActionResult> GetSaleDGV(int id)
        {
            try
            {
                var result = await _userService.GetSaleDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("saledgv")]
        public async Task<IActionResult> PostSaleDGV([FromBody] SaleDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateSaleDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpGet("userdgv/{id}")]
        public async Task<IActionResult> GetUserDGV(int id)
        {
            try
            {
                var result = await _userService.GetUserDGV(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [HttpPost("userdgv")]
        public async Task<IActionResult> PostUserDGV([FromBody] UserDGV value)
        {
            try
            {
                var result = await _userService.CreateUpdateUserDGV(value);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpPost("create-favourite-page")]
        public async Task<IActionResult> CreateFavouritePage([FromBody] string value)
        {
            try
            {
                await _userService.CreateFavouritePages(value);
                return Ok("Favourite Page Created Successfully");

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpPost("add-user-favourite-page/{id}")]
        public async Task<IActionResult> AddUserFavouritePage([FromBody] List<string> value, int id)
        {
            try
            {
                if (!value.Any())
                {
                    return UnprocessableEntity("Page list was empty");
                }
                await _userService.AddFavouritePagesToUser(value, id);
                return Ok("Favourite Page added to user Successfully");

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        [HttpDelete("remove-user-favourite-page/{id}")]
        public async Task<IActionResult> RemoveUserFavouritePage([FromBody] List<string> value, int id)
        {
            try
            {
                if (!value.Any())
                {
                    return UnprocessableEntity("Page list was empty");
                }
                await _userService.RemoveFavouritePagesToUser(value, id);
                return Ok("Favourite Page Removed to user Successfully");

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        [HttpGet("user-favourite-pages/{id}")]
        public async Task<IActionResult> GetUserFavouritePages(int id)
        {
            try
            {
                var result = await _userService.GetUserPreferredPages(id);
                return Ok(result);

            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }


    }
}
