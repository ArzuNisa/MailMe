using MailMeDataAccessLayer.Concrete;
using MailMeEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        public MyProfileController(Context context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View(_context.MailUsers.Where(x => x.AppUserId == int.Parse(_userManager.GetUserId(User))).ToList());
        }
        [HttpGet]
        public IActionResult DeleteMail(string id)
        {
            var mail = _context.MailUsers.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.MailUsers.Remove(mail);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
