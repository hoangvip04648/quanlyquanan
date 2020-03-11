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
    public class ThanhToanLuongNhanVienApiController : ApiController
    {
        // GET: api/ThanhToanLuongNhanVienApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ThanhToanLuongNhanVienApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ThanhToanLuongNhanVienApi
        public string Post(string maNhanVien, string tongThoiGianLam, string tongLuong, string khoangKhac, string ghiChu)
        {
            string ngayThanhToan=  DateTime.UtcNow.Date.ToString("yyyy/MM/dd");
            try
            {
                if (!ThanhToanLuongNhanVienModel.InsertThanhToanLuong(maNhanVien,ngayThanhToan, tongThoiGianLam, tongLuong, khoangKhac, ghiChu))
                    return "Thêm thất bại!";
            }
            catch
            {
                return "Thêm thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            //Tiep tuc cap nhat trang thai cham cong
            try
            {
                if (!ChamCongNhanVienModel.UpdateAllTrangThai(maNhanVien, "1"))
                {
                    ThanhToanLuongNhanVienModel.DeleteThanhToanLuong(maNhanVien, ngayThanhToan);
                    return "Thêm thất bại!";
                }
            }
            catch
            {
                ThanhToanLuongNhanVienModel.DeleteThanhToanLuong(maNhanVien, ngayThanhToan);
                return "Thêm thất bại!";
            }
            return "Thêm thành công!";
        }

        // PUT: api/ThanhToanLuongNhanVienApi/5
        public string Put(string maNhanVien, string ngayThanhToan, string khoangKhac, string ghiChu)
        {
            try
            {
                if (!ThanhToanLuongNhanVienModel.UpdateThanhToanLuong(maNhanVien, ngayThanhToan,khoangKhac,ghiChu))
                { 
                    return "Sửa thất bại!";
                }
            }
            catch
            {
                return "Sửa thất bại!";
            }
            return "Sửa thành công!";
        }

        // DELETE: api/ThanhToanLuongNhanVienApi/5
        public void Delete(int id)
        {
        }
    }
}
