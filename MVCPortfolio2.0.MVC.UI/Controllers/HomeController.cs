using MVCPortfolio2._0.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVCPortfolio2._0.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            string body = $"You have received an email from <strong>{cvm.Name}</strong>. The email address given was <strong>{cvm.Email}</strong>.<br/><strong>The following message was sent:</strong>{cvm.Message}";

            MailMessage mm = new MailMessage("admin@edwardbarrier.com", "edwardbarrieriii@outlook.com", cvm.Subject, body);



            mm.IsBodyHtml = true;
            mm.ReplyToList.Add(cvm.Email);

            SmtpClient smtp = new SmtpClient("mail.edwardbarrier.com");

            smtp.Credentials = new NetworkCredential("admin@edwardbarrier.com", "Cam#Jay#71#");
            smtp.Send(mm);
            return Json(cvm);
        }


        public PartialViewResult ContactConfirmation(string name, string email)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            return PartialView("ContactConfirmation");
        }
    }
}