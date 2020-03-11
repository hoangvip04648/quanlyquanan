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
    public class ThamSoApiController : ApiController
    {
        // GET: api/ThamSoApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ThamSoApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ThamSoApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThamSoApi/5
        public string Put(string maThamSo, string giaTri, string tinhTrang)
        {
            try
            {
                if (!ThamSoModel.UpdateThamSo(maThamSo, giaTri,tinhTrang))
                    return "Sửa thất bại!";
            }
            catch
            {
                return "Sửa thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Sửa thành công!";

        }

        // DELETE: api/ThamSoApi/5
        public void Delete(int id)
        {
        }
    }
}
