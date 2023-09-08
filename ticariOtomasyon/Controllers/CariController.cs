using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariOtomasyon.Models.Siniflar;
namespace ticariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(s=>s.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler cr)
        {
            cr.Durum = true;
            c.Carilers.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler ca)
        {
          
            var cari = c.Carilers.Find(ca.Cariid);
            cari.CariAd = ca.CariAd;
            cari.CariSoyad = ca.CariSoyad;
            cari.CariSehir = ca.CariSehir;
            cari.CariMail = ca.CariMail;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var satislar = c.SatisHarekets.Where(s => s.Cariid == id).ToList();
            var cr = c.Carilers.Where(s => s.Cariid == id).Select(b=> b.CariAd + " " + b.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;

            return View(satislar);
        }

    }
}