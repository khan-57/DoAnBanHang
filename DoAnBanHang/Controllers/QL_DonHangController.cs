using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnBanHang.Controllers
{
    public class QL_DonHangController : Controller
    {
        // GET: QL_DonHang
        //Đã xác nhận
        public ActionResult DanhSachDonXacNhan()
        {
            return View();
        }
        public ActionResult EditXacNhan()
        {
            return View();
        }

        //Chưa xác nhận
        public ActionResult DanhSachDonChuaXacNhan()
        {
            return View();
        }
        public ActionResult EditChuaXacNhan()
        {
            return View();
        }
    }
}