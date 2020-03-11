using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CT_GioHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public CT_GioHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public List<CT_GIOHANG> GetAllByTaiKhoan(string taiKhoan)
        {
            var list = context.Database.SqlQuery<CT_GIOHANG>("Sp_CT_GIOHANG_GetAllByTaiKhoan @taiKhoan='"+taiKhoan+"'").ToList();
            foreach (var item in list)
            {
                item.GetMatHang();
            }
            return list;
        }

        public string AddItemToGioHang(string maMH,string soLuong,string taiKhoan)
        {
            string userID = new AccountModel().GetID(taiKhoan);
            //Kiem tra xem gio hang co chua
            if (CheckMatHangDaCoTrongGioChua(maMH, userID))//Neu co roi thi return da co
            {
                return "Sản phẩm đã tồn tại trong giỏ hàng!";
            }
            //Else
            //Them vao gio hang
            string insertCommand = "Sp_CT_GIOHANG_Insert @maKH='" + userID + "', @maMH='" + maMH + "',@soLuong="+soLuong;
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return "Thêm vào giỏ hàng thành công";
            else
                return "Thêm vào giỏ hàng thất bại";
        } 

        public bool CheckMatHangDaCoTrongGioChua(string maMH,string maKH)
        {
            int count = context.Database.SqlQuery<int>("Sp_CT_GIOHANG_DemMatHangTrongGio @MaKH='" + maKH + "',@MaMH='"+maMH+"'").First();
            if (count > 0)
                return true;
            else
                return false;
        }

        public string ChinhSuaSoLuongOfGioHang(string maMatHang, string soLuong, string taiKhoan)
        {
            string userID = new AccountModel().GetID(taiKhoan);

            //UPDATE
            string cmd = "Sp_CT_GIOHANG_Update @maKH='" + userID + "', @maMH='" + maMatHang + "',@soLuong=" + soLuong;
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
            if (res > 0)
                return "Sua thanh cong";
            else
                return "Sua that bai";

        }

        public string XoaMatHangKhoiGioHang(string maMH, string taiKhoan)
        {
            string userID = new AccountModel().GetID(taiKhoan);

            //UPDATE
            string cmd = "Sp_CT_GIOHANG_Delete @maKH='" + userID + "', @maMH='" + maMH + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
            if (res > 0)
                return "Xoa thanh cong";
            else
                return "Xoa that bai";
        }
    }
}
