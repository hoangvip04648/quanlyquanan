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
    public class MenuMonAnApiController : ApiController
    {
        // GET: api/MenuMonAnApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MenuMonAnApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuMonAnApi
        public string Post(string maMonAn, string trangThai, string giaBan)
        {
            if (MenuMonAnModel.InsertMenuMonAn(maMonAn, trangThai, giaBan))
                return "Thêm thành công!";
            else
                return "Thêm thất bại! Món ăn này đã được thêm vào rồi!";
        }

        // PUT: api/MenuMonAnApi/5
        public string Put(string maMonAn, string trangThai, string giaBan)
        {
            if (MenuMonAnModel.UpdateMenuMonAn(maMonAn, trangThai, giaBan))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        public string Put(string trangThaiAll)
        {
            if (MenuMonAnModel.UpdateAllMenuMonAn(trangThaiAll))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        // DELETE: api/MenuMonAnApi/5
        public string Delete(string maMonAn)
        {
            if (MenuMonAnModel.DeleteMenuMonAn(maMonAn))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
