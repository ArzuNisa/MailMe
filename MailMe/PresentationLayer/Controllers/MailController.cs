using MailMeDtoLayer.Dtos.AppUserDtos;
using MailMeEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace ScheduledMailSender.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleMail(DateTime scheduledTime, string mailContent, string recipientEmail)
        {
            // Şu anki zamandan belirli tarihe kadar geçen süreyi hesaplayın
            TimeSpan timeUntilScheduled = scheduledTime - DateTime.Now;

            // Task.Delay kullanarak belirli bir süre sonra işlemi çalıştırın
            await Task.Delay(timeUntilScheduled);

           
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MailMe Admin", "3kerekaf@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", recipientEmail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Your E-mail from past: \n" + mailContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "MailMe Mail";

            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("3kerekaf@gmail.com", "kjrgkfwircjwzhmv");
            client.Send(mimeMessage);
            client.Disconnect(true);

            ViewBag.Message = "Mail başarıyla gönderildi.";


            return RedirectToAction("Index", "MyProfile");

        }

       
    }
}
