using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnBanHang.Models
{
    public class Account
    {
        public int ID_TK { get; set; }
        public string Username { get; set; }
        public Nullable<int> Diem { get; set; }
        public string Password { get; set; }
        
        //public int ID_TT { get; set; }
        //public string Ten { get; set; }
        //public string DiaChi { get; set; }
        //public string SDT { get; set; }

        public Account(TaiKhoan tk)
        {
            this.ID_TK = tk.ID_TK;
            this.Username = tk.Username;
            this.Diem = tk.Diem;
            this.Password = tk.Password;

        }
        //public NguoiDung(ThongTinTK tt)
        //{

        //    this.ID_TT = tt.ID_TT;
        //    this.DiaChi = tt.DiaChi;
        //    this.Ten = tt.Ten;
        //    this.SDT = tt.SDT;
        //}

    }
}
