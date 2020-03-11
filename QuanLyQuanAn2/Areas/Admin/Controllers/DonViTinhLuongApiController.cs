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
    public class DonViTinhLuongApiController : ApiController
    {
        // GET: api/DonViTinhLuongApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DonViTinhLuongApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DonViTinhLuongApi
        public string Post(string tenDonViTinhLuong)
        {
            if (DonViTinhLuongModel.InsertDonViTinhLuong(tenDonViTinhLuong))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/DonViTinhLuongApi/5
        public string Put(string maDonViTinhLuong, string tenDonViTinhLuong)
        {
            try
            {
                if (!DonViTinhLuongModel.UpdateDonViTinhLuong(maDonViTinhLuong, tenDonViTinhLuong))
                    return "Sửa thất bại!";
            }
            catch
            {
                return "Sửa thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Sửa thành công!";
        }

        // DELETE: api/DonViTinhLuongApi/5
        public string Delete(string maDonViTinhLuong)
        {
            if (DonViTinhLuongModel.DeleteDonViTinhLuong(maDonViTinhLuong))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Đơn vị này đang được sử dụng!";
        }
    }
}
