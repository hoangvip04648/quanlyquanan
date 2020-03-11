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
    public class DungCuApiController : ApiController
    {
        // GET: api/DungCuApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DungCuApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DungCuApi
        public string Post(string maDungCu, string maNhaCungCap)
        {
            if (DungCuModel.ThemDungCu_NhaCungCap(maDungCu, maNhaCungCap))
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
                    if (DungCuModel.ThemDungCu(maNL))
                        return "Thêm thành công!";

                }
                return "Thêm thất bại!";
            }
            catch
            {
                return "Thêm thất bại";
            }
        }
        // PUT: api/DungCuApi/5
        public string Put(string maDungCu, string tenDungCu, string madonVi)
        {
            if (DungCuModel.UpdateDungCu(maDungCu, tenDungCu, madonVi))
                return "Lưu thành công!";
            else
                return "Sửa đổi thất bại!";
        }

        // DELETE: api/DungCuApi/5    --Xoa dung cu nha cung cap
        public string Delete(string maDungCu, string maNhaCungCap)
        {
            if (DungCuModel.DeleteDungCu_NhaCungCap(maDungCu, maNhaCungCap))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }

        public string Delete(string maMatHangDungCu)
        {
            if (DungCuModel.DeleteMatHangDungCu(maMatHangDungCu))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Nguyên liệu này đang được sử dụng trong các danh sách khác!";
        }
    }
}
