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
    [Authorize(Roles ="kh")]
    public class GioHangApiController : ApiController
    {
        // GET: api/GioHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GioHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GioHangApi
        public string Post(string maMatHang, string soLuong)
        {
            //Kiem tra xem no con khong
            if (maMatHang.StartsWith("MA"))
            {
                try
                {
                    if (new MenuMonAnModel().GetByMaMonAn(maMatHang).TRANGTHAI.Value == false)
                        return "Sản phẩm này tạm thời đã hết! Vui lòng chọn sản phẩm khác nha!";

                }
                catch { }
                
            }else if (maMatHang.StartsWith("NC"))
            {
                try
                {
                    if (new MenuNuocGiaiKhatModel().GetByMaNuocGiaiKhat(maMatHang).NUOCGIAIKHAT.SOLUONGCON<1)
                        return "Sản phẩm này tạm thời đã hết! Vui lòng chọn sản phẩm khác nha!";

                }
                catch { }
            }

            //Them vao gio hang
            CT_GioHangModel ctGioHang = new CT_GioHangModel();
            try
            {
                string tmp= ctGioHang.AddItemToGioHang(maMatHang, soLuong, HttpContext.Current.User.Identity.Name);
                return tmp;
            }
            catch
            {
                return "Thêm vào giỏ hàng thất bại";
            }
            
            
        }

        // PUT: api/GioHangApi/5
        public string Put(string maMatHang, string soLuong)
        {
            CT_GioHangModel ctGioHang = new CT_GioHangModel();
            try
            {
                string tmp = ctGioHang.ChinhSuaSoLuongOfGioHang(maMatHang, soLuong, HttpContext.Current.User.Identity.Name);
                return tmp;
            }
            catch
            {
                return "Sua that bai";
            }
        }

        // DELETE: api/GioHangApi/5
        public string Delete(string maMatHang)
        {
            CT_GioHangModel ctGioHang = new CT_GioHangModel();
            try
            {
                string tmp = ctGioHang.XoaMatHangKhoiGioHang(maMatHang, HttpContext.Current.User.Identity.Name);
                return tmp;
            }
            catch
            {
                return "Xoa that bai";
            }
        }
    }
}
