using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hastane_yazilimi.Models;
namespace Hastane_yazilimi.Controllers
{
    public class RandevuController : Controller
    {
        Context c = new Context();

        // GET: Randevu
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RandevuEkle()
        {
            List<SelectListItem> deger1 = (from x in c.DoktorTables.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd,
                                               Value = x.DoktorId.ToString()
                                           }).ToList();
            ViewBag.dprtmn = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult RandevuEkle(RandevuTable p)
        {

            c.RandevuTables.Add(p);

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HastaLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaLogin(HastaTable hasta)
        {
            var bilgi = c.HastaTables.FirstOrDefault(x => x.HastaTC == hasta.HastaTC && hasta.HastaSoyad == hasta.HastaSoyad);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.HastaTC, false);
                Session["KullaniciAd"] = bilgi.HastaTC.ToString();
                return RedirectToAction("RandevuSil", "Randevu");
            }
            else
            {
                return RedirectToAction("HastaLogin", "Randevu");
            }


        }

        [HttpGet]
        public ActionResult HastaGecmisLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaGecmisLogin(HastaTable hasta)
        {
            var bilgi = c.HastaTables.FirstOrDefault(x => x.HastaTC == hasta.HastaTC && hasta.HastaSoyad == hasta.HastaSoyad);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.HastaTC, false);
                Session["KullaniciAd"] = bilgi.HastaTC.ToString();
                return RedirectToAction("RandevuListesi", "Randevu");
            }
            else
            {
                return RedirectToAction("HastaLogin", "Randevu");
            }


        }
        public ActionResult RandevuListesi()
        {
            var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == false).ToList();
            return View(degerler);
        }
        public ActionResult RandevuSil()
        {
            var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == true).ToList();
            return View(degerler);

        }
        public ActionResult RandevuSilmek(int id)
        {
            var randevu = c.RandevuTables.Find(id);
            c.RandevuTables.Remove(randevu);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}