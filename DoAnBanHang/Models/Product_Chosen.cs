using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnBanHang.Models
{
    public class Product_Chosen
    {
        public int ID_SP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public int ID_Size { get; set; }
        public string Size { get; set; }

        public Product_Chosen product(Product_Chosen pro)
        {
            SanPham SP = new SanPham();
            KichCo KC = new KichCo();
            this.ID_SP = SP.ID_SP;
            this.TenSP = SP.TenSP;
            this.DonGia = SP.DonGia;
            this.ID_Size = KC.ID_Size;
            this.Size = KC.Size;
            return pro;
        }
    }  
}