using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariOtomasyon.Models.Siniflar;
namespace ticariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {   //controller işin backend kısımıdır
        // GET: Kategori
        
        Context c = new Context();      

        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kt = c.Kategoris.Find(id);
            c.Kategoris.Remove(kt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult KategoriGetir(int id)
        {
            var kt = c.Kategoris.Find(id);
            return View("KategoriGetir", kt);
        }
        public ActionResult KategoriGuncelle(Kategori s)
        {
            var ktg = c.Kategoris.Find(s.KategoriID);
            ktg.KategoriAd = s.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }
     
    }
}