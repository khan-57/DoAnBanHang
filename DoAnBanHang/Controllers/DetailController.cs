using DoAnBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoAnBanHang.Controllers
{
    public class DetailController : Controller
    {
        private DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: Detail

        //    public List<KichCo> CheckKc(List<KichCo> query1)
        //{
        //    List<KichCo> KQ = new List<KichCo>();
        //    foreach (var value in query1)
        //    {
        //        if((int)value < 1)
        //        {
        //            KQ.Add(value);
        //        }
        //    }
        //}
        [HttpGet]
        public ActionResult Index(int id)
        {

            var sp = db.SanPham.Where(s => s.ID_SP == id).FirstOrDefault();
            ViewBag.query = (from kc in db.KichCoes where (kc.ID_SP == id) select kc).ToList();
            return View(sp);
        }
    }
}