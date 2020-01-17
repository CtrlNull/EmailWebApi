using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Alexa_Baylor_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaylorWhiteController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "working";
        }

        [HttpPost]
        public string Post(string email)
        {
            var fromAddress = new MailAddress("ctrlnull@gmail.com", "From Name");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "Re4peRC0de4r";
            const string subject = "test";
            const string body = "http://sharepoint.hilemangroup.com/clients/Documents/BSWH/01_Projects/Nikki_projects/Voice/BSWH_alexaskills_script_assessments.docx";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return "sent";
        }
    }
}
