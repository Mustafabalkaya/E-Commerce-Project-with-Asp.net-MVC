using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariOtomasyon.Models.Siniflar;
namespace ticariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(s=>s.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dp= c.Departmans.Find(id);
            dp.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            
            return View("DepartmanGetir",dpt);
        }
        public ActionResult DepartmanGuncelle(Departman s)
        {
            var dep= c.Departmans.Find(s.Departmanid);
            dep.DepartmanAd = s.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(s => s.departmanid == id).ToList();
            var dpt = c.Departmans.Where(s => s.Departmanid == id).Select(b => b.DepartmanAd).FirstOrDefault();
            ViewBag.s = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(s => s.Personelid == id).ToList();
            var per = c.Personels.Where(s => s.Personelid == id).Select(b => b.PersonelAd +" "+ b.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(degerler);
        }
    }
}