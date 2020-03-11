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
    public class MonAnApiController : ApiController
    {
        // GET: api/MonAnApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MonAnApi/5
        public string Get(int id)
        {
            return "value";
        }

        public string Post(string maMonAn, string maNguyenLieu, string soLuong)
        {
            if (MonAnModel.ThemCT_MONAN(maMonAn, maNguyenLieu,soLuong))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        public string Post(string tenMatHang, string maDonViTinh, string maLoaiMatHang, string giaBan, string hinhAnh)
        {
            if (tenMatHang == "" || tenMatHang == null)
                return "Thêm thất bại! Bạn chưa nhập vào tên của mặt hàng này!";
            if (giaBan == "" || giaBan == null)
                return "Thêm thất bại! Bạn chưa nhập giá bán mặt hàng này!";
            
            try
            {
                string maMA = MatHangModel.ThemMatHang(tenMatHang, maDonViTinh, maLoaiMatHang);
                if (maMA != "")
                {
                    if (MonAnModel.ThemMonAn(maMA, giaBan, hinhAnh))
                        return "Thêm thành công!";

                }
                return "Thêm thất bại!";
            }
            catch
            {
                return "Thêm thất bại";
            }
        }
        // PUT: api/MonAnApi/5
        public string Put(string maMonAn, string tenMonAn, string madonVi, string giaBan, string hinhAnh)
        {
            if (MonAnModel.UpdateMonAn(maMonAn, tenMonAn, madonVi, giaBan, hinhAnh))
                return "Lưu thành công!";
            else
                return "Sửa đổi thất bại!";
        }

        // DELETE: api/MonAnApi/5    --Xoa dung cu nha cung cap
        public string Delete(string maMonAn, string maNguyenLieu)
        {
            if (MonAnModel.DeleteCT_MonAn(maMonAn, maNguyenLieu))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }

        public string Delete(string maMatHangMonAn)
        {
            if (MonAnModel.DeleteMatHangMonAn(maMatHangMonAn))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Món ăn này này đang được sử dụng trong các danh sách khác!";
        }
    }
}
