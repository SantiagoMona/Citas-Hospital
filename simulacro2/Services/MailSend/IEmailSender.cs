using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simulacro2.Services.MailSend
{
    public interface IEmailSender
    {
        Task<String> SendEmailAsync(string info, string ToEmail);
    }
}