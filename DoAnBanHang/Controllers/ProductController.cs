using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
using System.Dynamic;
using System.Data.Entity;
//using DoAnBanHang.Models.DTO;



namespace DoAnBanHang.Controllers
{
   

    public class ProductController : Controller
    {

        private List<SanPham> GetSanPham()
        {
            List<SanPham> sanpham = new List<SanPham>();
            return sanpham;
        }
        //private List<PhieuNhap> Getphieunhap()
        //{
        //    List<PhieuNhap> sanpham = new List<PhieuNhap>();
        //    return sanpham;
        //}

        //private List<CTPhieuNhap> Getctphieunhap()
        //{
        //    List<CTPhieuNhap> ctphieunhap = new List<CTPhieuNhap>();
        //    return ctphieunhap;
        //}

       

        DB_BanHang1Entities db = new DB_BanHang1Entities();
        //public void MinPrice(int id)
        //{
            
        //    var ketquagiamdan = from sp in db.SanPham
        //                 where sp.ID_Loai == id
        //                 orderby sp.DonGia descending
        //                 select sp;
        //}
        // GET: Product
        //public ActionResult Ỏrder(string sortOrder)
        //{
        //    // 1. Thêm biến NameSortParm để biết trạng thái sắp xếp tăng, giảm ở View
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

        //    // 2. Truy vấn lấy tất cả đường dẫn
        //    var sp = from s in db.SanPham
        //                select s;

        //    // 3. Thứ tự sắp xếp theo thuộc tính LinkName
        //    switch (sortOrder)
        //    {
        //        // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
        //        case "name_desc":
        //           sp = sp.OrderByDescending(s => s.DonGia);
        //            break;

        //        // 3.2 Mặc định thì sẽ sắp tăng
        //        default:
        //            sp = sp.OrderBy(s => s.DonGia);
        //            break;
        //    }

        //    // 4. Trả kết quả về Views
        //    //return View(sp.ToList());
        //    RedirectToAction("Ao", "Product", sp.ToList());
        //    //return View(db.SanPham.ToList());
            
        //}
        public ActionResult Ao()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Quan()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Giay()
        {
            return View(db.SanPham.ToList());
        }

        public ActionResult Nam()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Nu()
        {
            return View(db.SanPham.ToList());
        }
        
        //public ActionResult NewProducts()
        //{

            // var sp = db.CTPhieuNhap.Select(x => new DetailSP
            //{
            //    TenSP = x.SanPham.TenSP,
            //    DonGia = x.SanPham.DonGia,
            //    Image = x.SanPham.Image,
            //    NgayNhap = x.PhieuNhap.NgayNhap

            //}).ToList();

            //var query1 = (from sp in db.CTPhieuNhap
            //              select sp).Where(x => x.PhieuNhap.NgayNhap.Month == DateTime.Now.Month).ToList();
            //ViewBag.query = query1;
                         
            //return View();
            
           // ModelNgayNhap viewModel = new ModelNgayNhap(); //initialize it
           // viewModel.sanpham = GetSanPham();
           // viewModel.ctphieunhap = Getctphieunhap();
           // viewModel.phieunhap = Getphieunhap();
        //   // return View(viewModel);
        //}
    }
}