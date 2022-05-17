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
                return RedirectToAction("DoktorLogin", "Doktor");
            }

        }
        public ActionResult DoktorListesi()
        {
            var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == true).ToList();
            return View(degerler);
        }
    }
}