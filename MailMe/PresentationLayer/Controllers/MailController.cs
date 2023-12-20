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
using MailMeDataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace ScheduledMailSender.Controllers
{
    public class MailController : Controller
    {

        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        public MailController(Context context, UserManager<AppUser> userManager)
        {
            _context = new();
            _userManager = userManager;
        }

        // GET: Mail
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleMail(DateTime scheduledTime, string mailContent, string recipientEmail, string title)
        {
            var mail = new MailUser()
            {
                RecipientEmail = recipientEmail,
                ScheduledTime = scheduledTime.ToUniversalTime(),
                CreatedTime = DateTime.UtcNow,
                Title = title,
                MailContent = mailContent,
                AppUserId = int.Parse(_userManager.GetUserId(User))
            };
            _context.MailUsers.Add(mail);
            _context.SaveChanges();

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

            mimeMessage.Subject = title;

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
