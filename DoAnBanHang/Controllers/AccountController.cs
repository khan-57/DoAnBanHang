using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
//using DoAnBanHang.Models.DTO;

namespace DoAnBanHang.Controllers
{
    public class AccountController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();

       
        // GET: Account
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult DangNhap(TaiKhoan User)
        //{
        //    var check = db.TaiKhoan.Where((s => s.Username.Equals(User.Username) && s.Password.Equals(User.Password))).FirstOrDefault();
            
        //    if (check == null)
        //    {
        //        ViewBag.error = "Sai ten dang nhap hoac mat khau!Hay thu lai!";
        //        return View("DangNhap", User);
        //    }
        //    else
        //    {
        //        var test = db.TaiKhoan.SingleOrDefault(s => s.Username == User.Username);
                
        //        if (test.Username == "admin" || test.ID_TK == 1)
        //        {
                    
        //            return RedirectToAction("Index", "QL_Home");
        //        }
        //        else
        //        {
        //            Session["IDUser"] = User.ID_TK;
        //            Session["Username"] = User.Username;
        //            return RedirectToAction("TrangChu", "TrangChu");
                   
        //        }
        //    }
        //}
        [HttpPost]
        public ActionResult DangNhap(TaiKhoan User)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(User.Username))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                 if (string.IsNullOrEmpty(User.Password))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                 if (ModelState.IsValid)
                {
                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khach = db.TaiKhoan.FirstOrDefault(k => k.Username == User.Username && k.Password == User.Password);
                    if (khach != null)
                    {
                        var test = db.TaiKhoan.SingleOrDefault(s => s.Username == User.Username);
                        

                        if (test.Username == "admin" || test.ID_TK == 1)
                        {
                            Session["TaiKhoan"] =  khach;
                            return RedirectToAction("Index", "QL_Home");
                        }
                        else
                        {
                            //Session["IDUser"] = User.ID_TK;
                            //Session["Username"] = User.Username;
                            Session["TaiKhoan"] = khach;
                           
                            return RedirectToAction("TrangChu", "TrangChu");

                        }
                       
                    }
                    else

                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
    

        public ActionResult DoiMatKhau()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult DangKy(TaiKhoan User)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (string.IsNullOrEmpty(User.Username))
        //            ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
        //        if (string.IsNullOrEmpty(User.Password))

        //            ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                
        //            //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
        //            var khachhang = db.TaiKhoan.FirstOrDefault(k => k.Username ==
        //            User.Username);
        //        if (khachhang != null)
        //            ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
        //        if (ModelState.IsValid)
        //        {
        //            db.TaiKhoan.Add(User);
        //            db.SaveChanges();

        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("DangNhap");
        //}
        [HttpPost]
        public ActionResult DangKy (TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
               
                if (string.IsNullOrEmpty(tk.Username))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(tk.Password))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(tk.Ten))
                    ModelState.AddModelError(string.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(tk.DiaChi))
                    ModelState.AddModelError(string.Empty, "Địa chỉ không được để trống");
                if (string.IsNullOrEmpty(tk.SDT))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");

                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                var khachhang = db.TaiKhoan.FirstOrDefault(k => k.Username == tk.Username);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    tk.Diem = 0;
                    db.TaiKhoan.Add(tk);
                    db.SaveChanges();

                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }

       
        
        public ActionResult ThongTinKhach(int id)
        {
            ViewBag.Diem = db.TaiKhoan.Where(diem=>diem.ID_TK == id).FirstOrDefault();
            
            var check = db.TaiKhoan.Where(tk => tk.ID_TK == id).FirstOrDefault();
            //if(check == null)
            //{
            //    RedirectToAction("NhapThongTin", "Account");
            //}
            return View(check);
        }
        public ActionResult CapNhatThongTin(int id)
        {
            ViewBag.Diem = db.TaiKhoan.Where(diem => diem.ID_TK == id).FirstOrDefault();

            var check = db.TaiKhoan.Where(tk => tk.ID_TK == id).FirstOrDefault();
            //if(check == null)
            //{
            //    RedirectToAction("NhapThongTin", "Account");
            //}
            return View(check);
        }
        [HttpPost]
        public ActionResult CapNhatThongTin(TaiKhoan check)
        {
            
            var result = db.TaiKhoan.Find(check.ID_TK);
            result.Ten =check.Ten;
            result.SDT = check.SDT;
            result.DiaChi = check.DiaChi;
             
            db.SaveChanges(); // lưu lại
            return RedirectToAction("ThongTinKhach"); // sau khi cập nhật quay về trang chủ Index
            
        }
        

        
        
    }
}