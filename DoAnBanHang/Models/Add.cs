
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DoAnBanHang.Models
{
    internal class Add
    {
        public int ID_SP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public int ID_Size { get; set; }
        public string Size { get; set; }

        public Add product(Add pro)
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
}