using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace QuanLyQuanAn2.Controllers
{
    public class ThongTinCaNhanApiController : ApiController
    {
        // GET: api/ThongTinCaNhanApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ThongTinCaNhanApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ThongTinCaNhanApi
        public string Post(string oldPass,string newPass, string reNewPass)
        {
            var accountModel = new AccountModel();
            var tendangnhap = HttpContext.Current.User.Identity.Name;
            if (newPass != reNewPass)
                return "Đổi mật khẩu thất bại! Mật khẩu nhập lại không khớp!";
            string res=accountModel.ChangePassword(tendangnhap, oldPass,newPass);
            return res;
        }

        // PUT: api/ThongTinCaNhanApi/5
        public string Put(string hoTen,string gioiTinh,string ngaySinh,string sdt,string diaChi,string diaChiNhanHang)
        {
            if (gioiTinh == "1")
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            ngaySinh = ngaySinh.Split('-')[0] + "/" + ngaySinh.Split('-')[1] + "/" + ngaySinh.Split('-')[2];
            var accountModel = new AccountModel();
            var userID = accountModel.GetID(HttpContext.Current.User.Identity.Name);
            bool res= accountModel.UpdateInfo(userID,hoTen,gioiTinh,ngaySinh,sdt, HttpContext.Current.User.Identity.Name, diaChi);
            if (res)
            {
                new KhachHangModel().UpdateDiaChiNhanHang(userID,diaChiNhanHang);
                return "Sửa thành công!";
            }
            else
                return "Sửa thất bại!";
            
        }

        // DELETE: api/ThongTinCaNhanApi/5
        public void Delete(int id)
        {
        }
    }
}
