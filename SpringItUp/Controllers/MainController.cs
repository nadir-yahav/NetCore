using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpringItUp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public void SendLid(Lid lid)
        {
            if (lid.IsValid())
                using (var message = new MailMessage())
                {
                    var owner = Owner.Instance.GetById(lid.OwnerId);
                    if (owner != null)
                    {
                        var accountDetails = Email.AccountDetails;
                        lid.OwnerName = owner.Name;
                        string body = Email.Templates.Lid(lid);
                        message.From = new MailAddress(accountDetails.From, accountDetails.DisplayName);
                        message.To.Add(new MailAddress(owner.Email));
                        message.Subject = accountDetails.Subject;
                        message.Body = body;
                        message.IsBodyHtml = true;
                        using (var client = new SmtpClient(accountDetails.Host))
                        {
                            client.Port = accountDetails.Port;
                            client.UseDefaultCredentials = true;
                            client.Credentials = new NetworkCredential(accountDetails.UserName, accountDetails.Password);
                            client.EnableSsl = true;
                            client.Send(message);
                        }
                    }
                }
        }
    }
}

