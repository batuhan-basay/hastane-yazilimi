using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hastane_yazilimi.Models;
namespace Hastane_yazilimi.Controllers
{
    public class DoktorController : Controller
    {
        Context c = new Context();
        // GET: Doktor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DoktorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorLogin(DoktorTable doktor)
        {
            var bilgi = c.DoktorTables.FirstOrDefault(x => x.DoktorTC == doktor.DoktorTC && doktor.DoktorSoyad == doktor.DoktorSoyad);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.DoktorTC, false);
                Session["KullaniciAd"] = bilgi.DoktorTC.ToString();
                return RedirectToAction("DoktorListesi", "Doktor");
            }
            else
            {
                return RedirectToAction("Index", "Doktor");
            }

        }
        public ActionResult DoktorListesi()
        {
            var doktor = (string)Session["KullaniciAd"];
            var id = c.DoktorTables.Where(x => x.DoktorTC == doktor.ToString()).Select(y => y.DoktorId).FirstOrDefault();
            var degerler = c.RandevuTables.Where(x => x.DoktorId == id).ToList();
            return View(degerler);
        }
    }
}