using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;

namespace DoAnBanHang.Controllers
{
    public class CartController : Controller
    {
        private DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: Cart
        public List<Cart> LayGioHang()
        {
            List<Cart> gioHang = Session["GioHang"] as List<Cart>;
            //Nếu giỏ hàng chưa tồn tại thì tạo mới và đưa vào Session
            if (gioHang == null)
            {
                gioHang = new List<Cart>();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }
        [HttpPost]
        public ActionResult ThemSanPhamVaoGio(FormCollection SanPham)
        {
            var selectId = Convert.ToInt32(SanPham["ID"]);
            var selectIdSize = Convert.ToInt32(SanPham["size"]);
            //Lấy giỏ hàng hiện tại
            List<Cart> gioHang = LayGioHang();
            //Kiểm tra xem có tồn tại mặt hàng trong giỏ hay chưa
            //Nếu có thì tăng số lượng lên 1, ngược lại thêm vào giỏ
            Cart sanPham = gioHang.FirstOrDefault(s => s.ID_SP == selectId && s.ID_Size == selectIdSize);
            if (sanPham == null ) //Sản phẩm chưa có trong giỏ
            {
                sanPham = new Cart(selectId,selectIdSize);
                gioHang.Add(sanPham);
            }
            else 
            {
                if(sanPham.ID_Size == selectIdSize)
                sanPham.SoLuong++; //Sản phẩm đã có trong giỏ thì tăng số lượng lên 1
                else
                {
                    sanPham = new Cart(selectId, selectIdSize);
                    gioHang.Add(sanPham);
                }
            }
            return RedirectToAction("Index", "Detail", new { id = selectId, id_size = selectIdSize });
        }
       
        private int TinhTongSL()
        {
            int tongSL = 0;
            List<Cart> gioHang = LayGioHang();
            if (gioHang != null)
                tongSL = gioHang.Sum(sp => sp.SoLuong);
            return tongSL;
        }

        private double TinhTongTien()
        {
            double TongTien = 0;
            List<Cart> gioHang = LayGioHang();
            if (gioHang != null)
                TongTien = gioHang.Sum(sp => sp.ThanhTien());
            return TongTien;
        }

        public ActionResult HienThiGioHang()
        {
            
            List<Cart> gioHang = LayGioHang();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (gioHang == null || gioHang.Count == 0)
            {
                return RedirectToAction("TrangChu", "TrangChu");
            }
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang); //Trả về View hiển thị thông tin giỏ hàng
        }

        public ActionResult XoaMatHang(int MaSP,int ID_Size)
        {
            List<Cart> gioHang = LayGioHang();
            //Lấy sản phẩm trong giỏ hàng
            var sanpham = gioHang.FirstOrDefault(s => s.ID_SP == MaSP);
            if (sanpham != null)
            {
                gioHang.RemoveAll(s => s.ID_SP == MaSP && s.ID_Size == ID_Size);
                return RedirectToAction("HienThiGioHang"); //Quay về trang giỏ hàng
            }
            if (gioHang.Count == 0) //Quay về trang chủ nếu giỏ hàng không có gì
                return RedirectToAction("TrangChu", "TrangChu");
            return RedirectToAction("HienThiGioHang");
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        
        public ActionResult ThanhToan()
        {
            
            ViewBag.ThanhToan = (from tt in db.CachThucThanhToans select tt).ToList();
            ViewBag.Voucher = (from km in db.Vouchers select km).ToList();
            if (Session["TaiKhoan"] == null) //Chưa đăng nhập
                    return RedirectToAction("DangNhap", "Account");
            else
            {
            //ThongTinKhach
            TaiKhoan khach = Session["TaiKhoan"] as TaiKhoan;
            List<Cart> gioHang = LayGioHang();
                if (gioHang == null || gioHang.Count == 0) //Chưa có giỏ hàng hoặc chưa có sp
                    return RedirectToAction("TrangChu", "TrangChu");
                ViewBag.TongSL = TinhTongSL();
                ViewBag.TongTien = TinhTongTien();
                return View(gioHang);

            }
            //Trả về View hiển thị thông tin giỏ hàng
        }
      
        public ActionResult DongYThanhToan(FormCollection Fields)
        {
            //ViewBag["ThanhToan"] = db.CachThucThanhToan.Where(m => m.Ten == thanhToan);
            int selectedValue = int.Parse(Fields["Check"]);
            int selectedKM = Convert.ToInt32(Fields["ID_KhuyenMai"]);
            TaiKhoan khach = Session["TaiKhoan"] as TaiKhoan; //Khách
            List<Cart> gioHang = LayGioHang(); //Giỏ hàng
            HoaDon DonHang = new HoaDon(); //Tạo mới đơn đặt hàng
            DonHang.ID_TK = khach.ID_TK;
            DonHang.DiaChiGiaoHang = khach.DiaChi;
            DonHang.TrangThaiThanhToan = 0;
            DonHang.ID_ThanhToan = selectedValue;
            //DonHang.ID_ThanhToan = 1;
            DonHang.ID_KM = 1;
            db.HoaDon.Add(DonHang);
            db.SaveChanges();
            //Lần lượt thêm từng chi tiết cho đơn hàng trên
            foreach (var sanpham in gioHang)
            {
                CT_HoaDon chitiet = new CT_HoaDon();
                chitiet.ID_HoaDon= DonHang.ID_HoaDon;
                chitiet.ID_Size = sanpham.ID_Size;
                chitiet.SoLuong = sanpham.SoLuong;
                chitiet.DonGia = sanpham.DonGia;
                db.CT_HoaDon.Add(chitiet);
            }
            db.SaveChanges();
            //Xóa giỏ hàng
            Session["GioHang"] = null;
            return RedirectToAction("HoanThanhDonHang");
        }
        public ActionResult HoanThanhDonHang()
        {
            return View();
        }
    }
}
