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
    public class NuocGiaiKhatApiController : ApiController
    {
        // GET: api/NuocGiaiKhatApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NuocGiaiKhatApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NuocGiaiKhatApi
        public string Post(string maNuocGiaiKhat, string maNhaCungCap)
        {
            if (NuocGiaiKhatModel.ThemNuocGiaiKhat_NhaCungCap(maNuocGiaiKhat, maNhaCungCap))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        public string Post(string tenMatHang, string maDonViTinh, string maLoaiMatHang,string giaBan, string soLuongCon,string hinhAnh)
        {
            if(tenMatHang==""||tenMatHang==null)
                return "Thêm thất bại! Bạn chưa nhập vào tên của mặt hàng này!";
            if(giaBan==""||giaBan==null)
                return "Thêm thất bại! Bạn chưa nhập giá bán mặt hàng này!";
            if (soLuongCon == ""||soLuongCon==null)
                soLuongCon = "0";
            try
            {
                string maNL = MatHangModel.ThemMatHang(tenMatHang, maDonViTinh, maLoaiMatHang);
                if (maNL != "")
                {
                    if (NuocGiaiKhatModel.ThemNuocGiaiKhat(maNL,giaBan,soLuongCon,hinhAnh))
                        return "Thêm thành công!";

                }
                return "Thêm thất bại!";
            }
            catch
            {
                return "Thêm thất bại";
            }
        }
        // PUT: api/NuocGiaiKhatApi/5
        public string Put(string maNuocGiaiKhat, string tenNuocGiaiKhat, string madonVi,string giaBan, string soLuongCon,string hinhAnh)
        {
            if (NuocGiaiKhatModel.UpdateNuocGiaiKhat(maNuocGiaiKhat, tenNuocGiaiKhat, madonVi,giaBan,soLuongCon,hinhAnh))
                return "Lưu thành công!";
            else
                return "Sửa đổi thất bại!";
        }

        // DELETE: api/NuocGiaiKhatApi/5    --Xoa dung cu nha cung cap
        public string Delete(string maNuocGiaiKhat, string maNhaCungCap)
        {
            if (NuocGiaiKhatModel.DeleteNuocGiaiKhat_NhaCungCap(maNuocGiaiKhat, maNhaCungCap))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }

        public string Delete(string maMatHangNuocGiaiKhat)
        {
            if (NuocGiaiKhatModel.DeleteMatHangNuocGiaiKhat(maMatHangNuocGiaiKhat))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Nước giải khát này này đang được sử dụng trong các danh sách khác!";
        }

    }
}
