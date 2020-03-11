using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAn2.Models
{
    public class ThongTinNhanVienModel
    {
        public ThongTinNhanVienModel(string hoTen,string gioiTinh,int namSinh,string diaChi,string sdt)
        {
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.NamSinh = namSinh;
            this.DiaChi = diaChi;
            this.SoDienThoai = sdt;
        }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}