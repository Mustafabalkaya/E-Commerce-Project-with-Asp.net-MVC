using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariOtomasyon.Models.Siniflar;
namespace ticariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs=new Class1();
            //var deger = c.Uruns.Where(x => x.Urunid == 6).ToList();
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == 6).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayID == 1).ToList();
            return View(cs);
        }
    }
}