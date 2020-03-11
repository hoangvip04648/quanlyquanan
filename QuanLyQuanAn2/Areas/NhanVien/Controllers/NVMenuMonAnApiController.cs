using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.NhanVien.Controllers
{
    [Authorize(Roles = "nv")]
    public class NVMenuMonAnApiController : ApiController
    {
        // GET: api/NVMenuMonAnApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NVMenuMonAnApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NVMenuMonAnApi
        public void Post(int id)
        {
            
                
        }

        // PUT: api/NVMenuMonAnApi/5
        
        public string Put(string maMonAn, string trangThai)
        {
            if (MenuMonAnModel.UpdateTrangThaiMenuMonAn(maMonAn, trangThai))
                return "Sửa thành công!";
            else
                return "Sửa thất bại!";
        }

        // DELETE: api/NVMenuMonAnApi/5
        public void Delete(int id)
        {
        }
    }
}
