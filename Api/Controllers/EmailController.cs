using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("allEmails")]
        public async Task<IActionResult> GetAllEmails()
        {
            var result = await _emailService.GetAllEmails();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailById(int id)
        {
            var result = await _emailService.GetEmailById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmail([FromBody] PostEmailDTO email)
        {
            var result = await _emailService.AddEmail(email);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditEmail([FromBody] PutEmailDTO email)
        {
            var result = await _emailService.UpdateEmail(email);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            var result = await _emailService.DeleteEmail(id);
            return Ok(result);
        }
    }
}