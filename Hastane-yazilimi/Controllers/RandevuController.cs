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
                return RedirectToAction("HastaGecmisLogin", "Randevu");
            }


        }
        public ActionResult RandevuListesi()
        {
            var hasta = (string)Session["KullaniciAd"];
            var id = c.HastaTables.Where(x => x.HastaTC == hasta.ToString()).Select(y => y.HastaId).FirstOrDefault();
            var degerler = c.RandevuTables.Where(x => x.HastaId == id).ToList();
            return View(degerler);

            //var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == false).ToList();
        }
        public ActionResult RandevuSil()
        {
            var hasta = (string)Session["KullaniciAd"];
            var id = c.HastaTables.Where(x => x.HastaTC == hasta.ToString()).Select(y => y.HastaId).FirstOrDefault();
            var degerler = c.RandevuTables.Where(x => x.HastaId == id).ToList();
            return View(degerler);

            //var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == true).ToList();

        }
        public ActionResult RandevuSilmek(int id)
        {
            var randevu = c.RandevuTables.Find(id);
            c.RandevuTables.Remove(randevu);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Faturalar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Faturalar(HastaTable hasta)
        {
            var bilgi = c.HastaTables.FirstOrDefault(x => x.HastaTC == hasta.HastaTC);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.HastaTC, false);
                Session["KullaniciAd"] = bilgi.HastaTC.ToString();
                return RedirectToAction("FaturaListesi", "Randevu");
            }
            else
            {
                return RedirectToAction("Faturalar", "Randevu");
            }
        }

        public ActionResult FaturaListesi()
        {
            var hasta = (string)Session["KullaniciAd"];
            var id = c.RandevuTables.Where(x => x.Hasta.HastaTC == hasta.ToString()).Select(y => y.FaturaId).FirstOrDefault();
            var degerler = c.FaturaTables.Where(x => x.FaturaId == id).ToList();
            return View(degerler);

            //var degerler = c.RandevuTables.Where(x => x.RandevuDurumu == false).ToList();
        }
    }
}