using DoAnBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoAnBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: TrangChu
        public ActionResult TrangChu( )
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Search(string search)
        {
            return View(db.SanPham.Where(s => s.TenSP.Contains(search)));
        }
      
    }
}