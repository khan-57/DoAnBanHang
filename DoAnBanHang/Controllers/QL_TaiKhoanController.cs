using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;

namespace DoAnBanHang.Controllers
{
    public class QL_TaiKhoanController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: QL_TaiKhoan
        //NhanVien
        public ActionResult TaiKhoan()
        {
            return View(db.TaiKhoan.ToList());
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View(db.TaiKhoan.Where(s => s.ID_TK == id).ToList());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TaiKhoan tk = db.TaiKhoan.Find(id);
            db.TaiKhoan.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("TaiKhoan");
        }

    }
}