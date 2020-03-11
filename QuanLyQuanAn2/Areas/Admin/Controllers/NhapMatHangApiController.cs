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
    public class NhapMatHangApiController : ApiController
    {
        // GET: api/NhapMatHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NhapMatHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NhapMatHangApi
        public string Post(string MaMatHang, string MaNhaCungCap, string NgayNhap, string SoLuong, string DonGia, string ThanhTien, string HanSuDung)
        {
            if(NgayNhap==null||MaNhaCungCap==null)
                return "Thêm thất bại! Vui lòng chọn ngày nhập!";
            if(MaMatHang == null)
                return "Thêm thất bại! Vui lòng chọn mặt hàng cần nhập!";
            if(MaNhaCungCap==null)
                return "Thêm thất bại! Vui lòng chọn nhà cung cấp!";
            if (SoLuong == null)
                SoLuong = "1";
            if (DonGia == null)
                DonGia = "1";
            if(ThanhTien==null)
                return "Thêm thất bại! Vui lòng nhập số tiền bạn mua mặt hàng này!";
            if (HanSuDung == null)
                HanSuDung = "";
            if (NhapMatHangModel.InsertCTDonDatHang(MaMatHang, MaNhaCungCap, NgayNhap, SoLuong, DonGia, ThanhTien, HanSuDung))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/NhapMatHangApi/5
        public string Put(string MaPhieuNhap,string MaMatHang, string MaNhaCungCap, string NgayNhap, string SoLuong, string DonGia, string ThanhTien, string HanSuDung)
        {
            if(MaPhieuNhap==null||MaPhieuNhap=="")
                return "Sửa thất bại! Không tìm thấy phiếu nhập này!";
            if (NgayNhap == null || MaNhaCungCap == null)
                return "Sửa thất bại! Vui lòng chọn ngày nhập!";
            if (MaMatHang == null)
                return "Sửa thất bại! Vui lòng chọn mặt hàng cần nhập!";
            if (MaNhaCungCap == null)
                return "Sửa thất bại! Vui lòng chọn nhà cung cấp!";
            if (SoLuong == null)
                SoLuong = "1";
            if (DonGia == null)
                DonGia = "1";
            if (ThanhTien == null)
                return "Sửa thất bại! Vui lòng nhập số tiền bạn mua mặt hàng này!";
            if (HanSuDung == null)
                HanSuDung = "";
            if (NhapMatHangModel.UpdateCTDonDatHang(MaPhieuNhap,MaMatHang, MaNhaCungCap, NgayNhap, SoLuong, DonGia, ThanhTien, HanSuDung))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        // DELETE: api/NhapMatHangApi/5
        public string Delete(string MaPhieuNhap)
        {
            if (NhapMatHangModel.DeleteCTDonDatHang(MaPhieuNhap))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
