using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class NhanVienApiController : ApiController
    {
        // GET: api/NhanVienApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NhanVienApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NhanVienApi
        public string Post(string taiKhoan, string matKhau, string hoTen,
            string ngaySinh, string gioiTinh, string sdt,
            string diaChi, string luong, string maDVL,string ngayKyHopDong)
        {
            if (taiKhoan == null || taiKhoan == "" || matKhau == null || matKhau == "" || hoTen == null || hoTen == "" ||
                ngaySinh == null || ngaySinh == "" || gioiTinh == null || gioiTinh == "" || sdt == null || sdt == "" ||
                diaChi == null || diaChi == "" || luong == null || luong == "" || maDVL == null || maDVL == "" ||
                ngayKyHopDong == null || ngayKyHopDong == "")
                return "Thêm thất bại! Vui lòng nhập đầy đủ các thông tin bắt buộc!";
            if (gioiTinh == "1")
                gioiTinh = "Nam";
            else gioiTinh = "Nữ";

            ngaySinh = ngaySinh.Split('-')[0]+"/"+ ngaySinh.Split('-')[1] + "/" + ngaySinh.Split('-')[2];
            ngayKyHopDong = ngayKyHopDong.Split('-')[0] + "/" + ngayKyHopDong.Split('-')[1] + "/" + ngayKyHopDong.Split('-')[2];

            matKhau= AccountModel.CalculateMD5Hash(taiKhoan + "" + matKhau);

            //Them ne
            if (NhanVienModel.InsertNhanVien(taiKhoan, matKhau, hoTen, ngaySinh, gioiTinh, sdt, diaChi, luong, maDVL, ngayKyHopDong))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/NhanVienApi/5
        public string Put(string maNhanVien,string hoTen,
            string ngaySinh, string gioiTinh, string sdt,
            string diaChi, string luong, string maDVL, string ngayKyHopDong)
        {
            if (hoTen == null || hoTen == "" ||
                ngaySinh == null || ngaySinh == "" || gioiTinh == null || gioiTinh == "" || sdt == null || sdt == "" ||
                diaChi == null || diaChi == "" || luong == null || luong == "" || maDVL == null || maDVL == "" ||
                ngayKyHopDong == null || ngayKyHopDong == "")
                return "Sửa thất bại! Vui lòng nhập đầy đủ các thông tin bắt buộc!";
            if (gioiTinh == "1")
                gioiTinh = "Nam";
            else gioiTinh = "Nữ";

            ngaySinh = ngaySinh.Split('-')[0] + "/" + ngaySinh.Split('-')[1] + "/" + ngaySinh.Split('-')[2];
            ngayKyHopDong = ngayKyHopDong.Split('-')[0] + "/" + ngayKyHopDong.Split('-')[1] + "/" + ngayKyHopDong.Split('-')[2];
            
            //Them ne
            if (NhanVienModel.UpdateNhanVien(maNhanVien,hoTen, ngaySinh, gioiTinh, sdt, diaChi, luong, maDVL, ngayKyHopDong))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        public string Put(string maNhanVien,string taiKhoan,string matKhau)
        {
            matKhau = AccountModel.CalculateMD5Hash(taiKhoan + "" + matKhau);
            if (NhanVienModel.UpdateTaiKhoanNhanVien(maNhanVien, taiKhoan,matKhau))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }


        // DELETE: api/NhanVienApi/5
        public string Delete(string maNhanVien)
        {
            if (NhanVienModel.DeleteNhanVien(maNhanVien))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
