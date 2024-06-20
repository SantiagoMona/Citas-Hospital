using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Models;
using simulacro2.Services.MailSend;

namespace simulacro2.Controllers.Slack
{
    
    public class EmailSend : ControllerBase
    {
        public readonly IEmailSender _emailSender;
        public EmailSend(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("api/Email/Send")]
        public async Task<IActionResult> SendEmail([FromBody]Email email)
        {
            try
            {
              var resul=  await _emailSender.SendEmailAsync(email.Asunto, email.ToEmail);
                return Ok(resul);

            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al enviar el correo"+ ex.Message);
            }
        }
    }
}