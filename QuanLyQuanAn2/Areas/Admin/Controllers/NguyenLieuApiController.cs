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
    public class NguyenLieuApiController : ApiController
    {
        // GET: api/NguyenLieuApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NguyenLieuApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NguyenLieuApi
        public string Post(string maNguyenLieu, string maNhaCungCap)
        {
            if (NguyenLieuModel.ThemNguyenLieu_NhaCungCap(maNguyenLieu, maNhaCungCap))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        public string Post(string tenMatHang, string maDonViTinh, string maLoaiMatHang)
        {
            try
            {
                string maNL = MatHangModel.ThemMatHang(tenMatHang, maDonViTinh, maLoaiMatHang);
                if (maNL != "")
                {
                    if (NguyenLieuModel.ThemNguyenLieu(maNL))
                        return "Thêm thành công!";
                        
                }
                return "Thêm thất bại!";
            }
            catch
            {
                return "Thêm thất bại";
            }
        }
        // PUT: api/NguyenLieuApi/5
        public string Put(string maNguyenLieu, string tenNguyenLieu,string madonVi)
        {
            if (NguyenLieuModel.UpdateNguyenLieu(maNguyenLieu, tenNguyenLieu, madonVi))
                return "Lưu thành công!";
            else
                return "Sửa đổi thất bại!";
        }

        // DELETE: api/NguyenLieuApi/5    --Xoa nguyen lieu nha cung cap
        public string Delete(string maNguyenLieu,string maNhaCungCap)
        {
            if (NguyenLieuModel.DeleteNguyenLieu_NhaCungCap(maNguyenLieu, maNhaCungCap))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }

        public string Delete(string maMatHangNguyenLieu)
        {
            if (NguyenLieuModel.DeleteMatHangNguyenLieu(maMatHangNguyenLieu))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Nguyên liệu này đang được sử dụng trong các danh sách khác!";
        }
    }
}
