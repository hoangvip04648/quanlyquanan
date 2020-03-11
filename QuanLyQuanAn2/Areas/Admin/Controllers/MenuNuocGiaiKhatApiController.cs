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
    public class MenuNuocGiaiKhatApiController : ApiController
    {
        // GET: api/MenuNuocGiaiKhatApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MenuNuocGiaiKhatApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuNuocGiaiKhatApi
        public string Post(string maNuocGiaiKhat, string giaBan)
        {
            if (MenuNuocGiaiKhatModel.InsertMenuNuocGiaiKhat(maNuocGiaiKhat, giaBan))
                return "Thêm thành công!";
            else
                return "Thêm thất bại! Nước giải khát này đã được thêm vào rồi!";
        }

        // PUT: api/MenuNuocGiaiKhatApi/5
        public string Put(string maNuocGiaiKhat, string soLuongCon, string giaBan)
        {
            if (MenuNuocGiaiKhatModel.UpdateMenuNuocGiaiKhat(maNuocGiaiKhat, soLuongCon, giaBan))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        // DELETE: api/MenuNuocGiaiKhatApi/5
        public string Delete(string maNuocGiaiKhat)
        {
            if (MenuNuocGiaiKhatModel.DeleteMenuNuocGiaiKhat(maNuocGiaiKhat))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
