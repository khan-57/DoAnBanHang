using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnBanHang.Controllers
{
    public class QL_KhoController : Controller
    {
        // GET: QL_Kho
        //PhieuNhap
        public ActionResult DanhSachPhieuNhapSP()
        {
            return View();
        }
        public ActionResult AddNhap()
        {
            return View();
        }
        public ActionResult EditNhap()
        {
            return View();
        }
        //PhieuXuat
        public ActionResult DanhSachPhieuXuatSP()
        {
            return View();
        }
        public ActionResult AddXuat()
        {
            return View();
        }
        public ActionResult EditXuat()
        {
            return View();
        }
    }
}