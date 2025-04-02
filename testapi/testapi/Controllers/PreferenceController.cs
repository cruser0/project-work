using API.Models.Services;
using Entity_Validator.Entity.Entities.Preference;
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
        public async Task<IActionResult> GetCustomerDGV(int id)
        {

            var result = await _userService.GetCustomerDGV(id);
            return Ok(result);


        }
        [HttpPost("customerdgv")]
        public async Task<ActionResult<CustomerDGV>> PostCustomerDGV([FromBody] CustomerDGV value)
        {

            var result = await _userService.CreateUpdateCustomerDGV(value);
            return Ok(result);


        }

        [HttpGet("cost-registrydgv/{id}")]
        public async Task<IActionResult> GetCostRegistryDGV(int id)
        {

            var result = await _userService.GetCostRegistryDGV(id);
            return Ok(result);


        }
        [HttpPost("cost-registrydgv")]
        public async Task<IActionResult> PostCostRegistryDGV([FromBody] CostRegistryDGV value)
        {

            var result = await _userService.CreateUpdateCostRegistryDGV(value);
            return Ok(result);


        }

        [HttpGet("customer-invoicedgv/{id}")]
        public async Task<IActionResult> GetCustomerInvoiceDGV(int id)
        {

            var result = await _userService.GetCustomerInvoiceDGV(id);
            return Ok(result);


        }
        [HttpPost("customer-invoicedgv")]
        public async Task<IActionResult> PostCustomerInvoiceDGV([FromBody] CustomerInvoiceDGV value)
        {

            var result = await _userService.CreateUpdateCustomerInvoiceDGV(value);
            return Ok(result);


        }
        [HttpGet("customer-invoice-costdgv/{id}")]
        public async Task<IActionResult> GetCustomerInvoiceCostDGV(int id)
        {

            var result = await _userService.GetCustomerInvoiceCostDGV(id);
            return Ok(result);


        }
        [HttpPost("customer-invoice-costdgv")]
        public async Task<IActionResult> PostCustomerInvoiceCostDGV([FromBody] CustomerInvoiceCostDGV value)
        {

            var result = await _userService.CreateUpdateCustomerInvoiceCostDGV(value);
            return Ok(result);


        }

        [HttpGet("supplierdgv/{id}")]
        public async Task<IActionResult> GetSupplierDGV(int id)
        {

            var result = await _userService.GetSupplierDGV(id);
            return Ok(result);


        }
        [HttpPost("supplierdgv")]
        public async Task<IActionResult> PostSupplierDGV([FromBody] SupplierDGV value)
        {

            var result = await _userService.CreateUpdateSupplierDGV(value);
            return Ok(result);


        }
        [HttpGet("supplier-invoicedgv/{id}")]
        public async Task<IActionResult> GetSupplierInvoiceDGV(int id)
        {

            var result = await _userService.GetSupplierInvoiceDGV(id);
            return Ok(result);


        }
        [HttpPost("supplier-invoicedgv")]
        public async Task<IActionResult> PostSupplierInvoiceDGV([FromBody] SupplierInvoiceDGV value)
        {

            var result = await _userService.CreateUpdateSupplierInvoiceDGV(value);
            return Ok(result);


        }
        [HttpGet("supplier-invoice-costdgv/{id}")]
        public async Task<IActionResult> GetSupplierInvoiceCostDGV(int id)
        {

            var result = await _userService.GetSupplierInvoiceCostDGV(id);
            return Ok(result);


        }
        [HttpPost("supplier-invoice-costdgv")]
        public async Task<IActionResult> PostSupplierInvoiceCostDGV([FromBody] SupplierInvoiceCostDGV value)
        {

            var result = await _userService.CreateUpdateSupplierInvoiceCostDGV(value);
            return Ok(result);


        }

        [HttpGet("saledgv/{id}")]
        public async Task<IActionResult> GetSaleDGV(int id)
        {

            var result = await _userService.GetSaleDGV(id);
            return Ok(result);


        }
        [HttpPost("saledgv")]
        public async Task<IActionResult> PostSaleDGV([FromBody] SaleDGV value)
        {

            var result = await _userService.CreateUpdateSaleDGV(value);
            return Ok(result);


        }

        [HttpGet("userdgv/{id}")]
        public async Task<IActionResult> GetUserDGV(int id)
        {

            var result = await _userService.GetUserDGV(id);
            return Ok(result);


        }
        [HttpPost("userdgv")]
        public async Task<IActionResult> PostUserDGV([FromBody] UserDGV value)
        {

            var result = await _userService.CreateUpdateUserDGV(value);
            return Ok(result);


        }

        [HttpPost("create-favourite-page")]
        public async Task<IActionResult> CreateFavouritePage([FromBody] string value)
        {

            await _userService.CreateFavouritePages(value);
            return Ok("Favourite Page Created Successfully");


        }

        [HttpPost("add-user-favourite-page/{id}")]
        public async Task<IActionResult> AddUserFavouritePage([FromBody] List<string> value, int id)
        {

            if (!value.Any())
            {
                return UnprocessableEntity("Page list was empty");
            }
            await _userService.AddFavouritePagesToUser(value, id);
            return Ok("Favourite Page added to user Successfully");


        }

        [HttpDelete("remove-user-favourite-page/{id}")]
        public async Task<IActionResult> RemoveUserFavouritePage([FromBody] List<string> value, int id)
        {

            if (!value.Any())
            {
                return UnprocessableEntity("Page list was empty");
            }
            await _userService.RemoveFavouritePagesToUser(value, id);
            return Ok("Favourite Page Removed to user Successfully");


        }

        [HttpGet("user-favourite-pages/{id}")]
        public async Task<IActionResult> GetUserFavouritePages(int id)
        {

            var result = await _userService.GetUserPreferredPages(id);
            return Ok(result);


        }


    }
}
