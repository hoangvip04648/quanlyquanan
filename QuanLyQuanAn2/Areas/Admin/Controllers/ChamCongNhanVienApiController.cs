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
    public class ChamCongNhanVienApiController : ApiController
    {
        // GET: api/NgayChamCongApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NgayChamCongApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NgayChamCongApi
        public string Post(string maNV,string ngayCham, string thoiGianLam)
        {
            ngayCham = ngayCham.Replace("-", "/");
            try
            {
                if (!ChamCongNhanVienModel.InsertChamCong(maNV, ngayCham, thoiGianLam,"0"))
                    return "Chấm công thất bại!";
            }
            catch
            {
                return "Chấm công thất bại!";
            }
            return "Chấm công thành công!";
        }

        // PUT: api/NgayChamCongApi/5
        public string Put(string maNhanVien, string ngayChamCong, string thoiGianLam)
        {
            try
            {
                ngayChamCong = ngayChamCong.Split('/')[2] +"/"+ ngayChamCong.Split('/')[1] +"/"+ ngayChamCong.Split('/')[0];
                if (!ChamCongNhanVienModel.UpdateChamCong(maNhanVien, ngayChamCong, thoiGianLam))
                    return "Sửa thất bại!";
            }
            catch
            {
                return "Sửa thất bại!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Sửa thành công!";
        }

        // DELETE: api/NgayChamCongApi/5
        public void Delete(int id)
        {
        }
    }
}
