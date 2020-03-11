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
    public class DonViTinhApiController : ApiController
    {
        // GET: api/DonViTinhApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DonViTinhApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DonViTinhApi
        public string Post(string tenDonViTinh)
        {
            if (DonViTinhModel.InsertDonViTinh(tenDonViTinh))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/DonViTinhApi/5
        public string Put(string maDonViTinh, string tenDonViTinh)
        {
            try
            {
                if (!DonViTinhModel.UpdateDonViTinh(maDonViTinh, tenDonViTinh))
                    return "Sửa thất bại!";
            }
            catch
            {
                return "Sửa thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Sửa thành công!";
        }

        // DELETE: api/DonViTinhApi/5
        public string Delete(string maDonViTinh)
        {
            if (DonViTinhModel.DeleteDonViTinh(maDonViTinh))
                return "Xóa thành công!";
            else
                return "Xóa thất bại! Đơn vị này đang được sử dụng!";
        }
    }
}
