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
    public class MatHangApiController : ApiController
    {
        // GET: api/MatHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MatHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MatHangApi
        public string Post(string tenMatHang,string maDonViTinh,string maLoaiMatHang)
        {
            if (MatHangModel.ThemMatHang(tenMatHang, maDonViTinh, maLoaiMatHang)!="")
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/MatHangApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MatHangApi/5
        public void Delete(int id)
        {
        }
    }
}
