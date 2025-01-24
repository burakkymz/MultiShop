using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress mailBoxAddressFrom = new MailboxAddress("MultiShop Katalog" , "burakkymz03@gmail.com");
            message.From.Add(mailBoxAddressFrom);

            MailboxAddress mailBoxAddressTo = new MailboxAddress("User", mailRequest.ReciverMail);
            message.To.Add(mailBoxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("burakkymz03@gmail.com", "enwbgahxjsxxgizy");
            client.Send(message);
            client.Disconnect(true);
            return View();
        }
    }
}
