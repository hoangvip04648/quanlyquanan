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
    public class NhaCungCapApiController : ApiController
    {
        // GET: api/NhaCungCapApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NhaCungCapApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NhaCungCapApi
        public string Post(string tenNCC, string nguoiDaiDien, string sdt, string diaChi, string maLoaiMHCC, string moTa)
        {
            if (tenNCC == null || tenNCC == "")
                return "Vui lòng nhập tên nhà cung cấp!";
            if (NhaCungCapModel.InsertNhaCungCap(tenNCC, nguoiDaiDien, sdt, diaChi, maLoaiMHCC, moTa))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/NhaCungCapApi/5
        public string Put(string maNCC, string tenNCC, string nguoiDaiDien, string sdt, string diaChi, string maLoaiMHCC, string moTa)
        {
            if (tenNCC == null || tenNCC == "")
                return "Vui lòng nhập tên nhà cung cấp!";
            try
            {
                if (!NhaCungCapModel.UpdateNhaCungCap(maNCC, tenNCC, nguoiDaiDien, sdt, diaChi, maLoaiMHCC, moTa))
                    return "Lưu thất bại!";
            }
            catch
            {
                return "Lưu thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Lưu thành công!";
        }

        // DELETE: api/NhaCungCapApi/5
        public string Delete(string maNhaCungCap)
        {
            if (NhaCungCapModel.DeleteNhaCungCap(maNhaCungCap))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
