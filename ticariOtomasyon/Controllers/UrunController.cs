using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ticariOtomasyon.Models.Siniflar;
namespace ticariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {

            var degerler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(y => y.UrunAd.Contains(p));

            }
            return View(degerler.ToList());
        }    
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()

                                           }).ToList();
            ViewBag.x = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun sb)
        {
            c.Uruns.Add(sb);
            c.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from sb in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = sb.KategoriAd,
                                               Value = sb.KategoriID.ToString()

                                           }).ToList();
            ViewBag.sb = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka= p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}