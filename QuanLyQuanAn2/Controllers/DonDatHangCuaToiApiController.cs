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
    public class DonDatHangCuaToiApiController : ApiController
    {
        // GET: api/DonDatHangCuaToiApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DonDatHangCuaToiApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DonDatHangCuaToiApi
        public string Post(string diaChiGiaoHang,string ghiChu)
        {
            //Kiem tra xem co du tien k
            var model = new CT_GioHangModel().GetAllByTaiKhoan(HttpContext.Current.User.Identity.Name);
            int TongTien = 0;
            foreach (var ct in model)
            {
                if (ct.MAMATHANG.StartsWith("NC"))
                    TongTien += ct.SOLUONG.Value * ct.MATHANG.NUOCGIAIKHAT.GIABAN.Value;
                else if (ct.MAMATHANG.StartsWith("MA"))
                    TongTien += ct.SOLUONG.Value * ct.MATHANG.MONAN.GIABAN.Value;
            }
            int tienToiThieu = new ThamSoModel().GetThamSoByTen("SoTienDonDatHangToiThieu");
            if (TongTien < tienToiThieu)
                return "Chúng tôi chỉ tiếp nhận những đơn hàng trên " + tienToiThieu+" VNĐ! Vui lòng chọn thêm sản phẩm!";

            //Them
            string ngay = DateTime.Now.ToString("yyyy/MM/dd");
            string thoiGian = DateTime.Now.ToString("HH:mm:ss");
            string maKH = new AccountModel().GetID(HttpContext.Current.User.Identity.Name);
            string tinhTrangDonHang = "0";
            string ghiChuNguoiBan = "";
            
            try //THEM DON DAT HANG VAO
            {
                string maDon = new DonDatHangModel().ThemDonDathang(ngay,thoiGian,maKH,diaChiGiaoHang,ghiChu,tinhTrangDonHang,ghiChuNguoiBan);

                var ctGiohang = new CT_GioHangModel();
                var listCtDatHang = ctGiohang.GetAllByTaiKhoan(HttpContext.Current.User.Identity.Name);
                var donDatHangModel = new CT_DonDatHangModel();
                
                foreach(var item in listCtDatHang)
                {
                    try
                    {
                        donDatHangModel.ThemCTDonDatHang(maDon, item.MAMATHANG, item.SOLUONG.Value + "");
                        ctGiohang.XoaMatHangKhoiGioHang(item.MAMATHANG, HttpContext.Current.User.Identity.Name);
                    }
                    catch
                    {
                        
                    }
                    
                }


                return "Đặt hàng thành công!";
            }
            catch
            {
                return "Đặt hàng thất bại!";
            }
        }

        // PUT: api/DonDatHangCuaToiApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DonDatHangCuaToiApi/5
        public string Delete(string maDon)
        {
            if (new DonDatHangModel().HuyDonDatHang(maDon))
                return "Hủy đơn hàng thành công!";
            else
                return "Hủy đơn hàng thất bại!";
        }
    }
}
