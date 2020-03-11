using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    public class KhachHangApiController : ApiController
    {
        // GET: api/KhachHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/KhachHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/KhachHangApi
        public string Post(string taiKhoan, string matKhau, string hoTen,
            string ngaySinh, string gioiTinh, string sdt, string diaChi)
        {
            if (taiKhoan == null || taiKhoan == "" || matKhau == null || matKhau == "" || hoTen == null || hoTen == "" ||
                ngaySinh == null || ngaySinh == "" || gioiTinh == null || gioiTinh == "" || sdt == null || sdt == "" ||
                diaChi == null || diaChi == "")
                return "Thêm thất bại! Vui lòng nhập đầy đủ các thông tin bắt buộc!";
            if (gioiTinh == "1")
                gioiTinh = "Nam";
            else gioiTinh = "Nữ";

            ngaySinh = ngaySinh.Split('-')[2] + "/" + ngaySinh.Split('-')[1] + "/" + ngaySinh.Split('-')[0];
           
            matKhau = AccountModel.CalculateMD5Hash(taiKhoan + "" + matKhau);

            //Them ne
            if (new KhachHangModel().InsertKhachHang(taiKhoan, matKhau, hoTen, ngaySinh, gioiTinh, sdt, diaChi))
                return "Thêm thành công!";
            else
                return "Thêm thất bại! Khách hàng đã tồn tại!";
        }

        // PUT: api/KhachHangApi/5
        public string Put(string maKhachHang, string taiKhoan, string matKhau)
        {
            matKhau = AccountModel.CalculateMD5Hash(taiKhoan + "" + matKhau);
            if (new KhachHangModel().UpdateTaiKhoan(maKhachHang, taiKhoan, matKhau))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        // DELETE: api/KhachHangApi/5
        public string Delete(string maKhachHang)
        {
            if (new KhachHangModel().DeleteKhachHang(maKhachHang))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
