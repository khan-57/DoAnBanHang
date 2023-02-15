using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnBanHang.Models
{
    
    public class Cart
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        public int ID_SP { get; set; }
        public string TenSP { get; set; }
        public string Image { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ID_Size { get; set; }
        public string Size { get; set; }

        //Tính thành tiền = DongGia * SoLuong
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
        public Cart(int ID_SP, int ID_Size)
        {
            this.ID_SP = ID_SP;
            //Tìm sách trong CSDL có mã id cần và gán cho mặt hàng được mua
            var sp = db.SanPham.Single(s => s.ID_SP == this.ID_SP);
            this.TenSP = sp.TenSP;
            this.Image = sp.Image;
            this.DonGia = double.Parse(sp.DonGia.ToString());
            this.SoLuong = 1; //Số lượng mua ban đầu của một mặt hàng là 1 (cho lần clickđầu)
            //this.Size = db.KichCo.FirstOrDefault(s => s.ID_SP == this.ID_SP && s.Size == Size);
            this.ID_Size = ID_Size;
            var size = db.KichCoes.Where(s=>s.ID_Size == ID_Size).FirstOrDefault();
            this.Size = size.Size;
        }


    } 
}