using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;


namespace DoAnBanHang.Controllers
{
    public class QL_HoaDonController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: QL_HoaDon
        public ActionResult DanhSachHoaDonChuaXacNhan()
        {
            return View(db.HoaDon.Where(s=>s.TrangThaiThanhToan == 0).ToList());
        }
        [HttpGet]
        public ActionResult DetailChuaXacNhan(int id)
        {
            double tong = 0;
            var check = db.CT_HoaDon.Where(s => s.ID_HoaDon == id);
            foreach (var item in check)
            {
                tong += TongTien(item.SoLuong, item.DonGia);
            }
            ViewBag.TongTien = tong.ToString();
            ViewBag.ChiTiet = db.CT_HoaDon.Where(s => s.ID_HoaDon == id).ToList();
            return View(db.HoaDon.Where(s => s.ID_HoaDon == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SetTrangThai(int id)
        {
            var check = db.HoaDon.Find(id);
            //_ = check.TrangThaiThanhToan == 1;
            check.TrangThaiThanhToan = 1;
            db.SaveChanges();
            return RedirectToAction("DanhSachHoaDonXacNhan", "QL_HoaDon");
        }
        [HttpGet]
        public ActionResult DeleteChuaXacNhan(int id)
        {

            var check = db.HoaDon.Find(id);
            check.TrangThaiThanhToan = 2;
            db.SaveChanges();
            return RedirectToAction("DanhSachHoaDonChuaXacNhan");
        }

        //DanhSachHoaDonXacNhan
        public ActionResult DanhSachHoaDonXacNhan()
        {
            var ds = db.HoaDon.Where(s => s.TrangThaiThanhToan == 1).ToList();
            return View(ds);
      
        }
        [HttpGet]
        public ActionResult DetailXacNhan(int id)
        {
            double tong = 0;
            ViewBag.ChiTiet = db.CT_HoaDon.Where(s => s.ID_HoaDon == id).ToList();
            var check = db.CT_HoaDon.Where(s => s.ID_HoaDon == id);
            foreach(var item in check)
            {
                tong += TongTien(item.SoLuong, item.DonGia);
            }
            ViewBag.TongTien = tong.ToString();
            return View(db.HoaDon.Where(s => s.ID_HoaDon == id).FirstOrDefault());
           
        }

        public double TongTien(int soLuong, double donGia)
        {
            return soLuong * donGia;
        }
    }
}