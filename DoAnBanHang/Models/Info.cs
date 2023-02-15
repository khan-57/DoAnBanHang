using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnBanHang.Models
{
    public class Info
    {
        public int ID_HD { get; set; }
        public string Username { get; set; }
        public string TrangThai { get; set; }

        HoaDon hd = new HoaDon();

        
    }
}