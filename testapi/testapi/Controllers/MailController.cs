﻿using API.Models.Services;
using Entity_Validator.Entity.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        IEmailService _emailService;
        public MailController(IEmailService es)
        {
            _emailService = es;
        }
        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailDTO body)
        {

            var data = await _emailService.SendEmail(body);
            return Ok(data);
        }
    }
}
