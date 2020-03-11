using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KhachHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public KhachHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public KHACHHANG GetByMaKhachHang(string maKH)
        {
            return new KHACHHANG().GetByMaKhachHang(maKH);
        }

        public bool UpdateDiaChiNhanHang(string userID, string diaChiNhanHang)
        {
            string command = "Sp_KHACHHANG_Update @maKH='"+userID+"', @diaChiNhanHang=N'"+diaChiNhanHang+"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }

        public List<KHACHHANG> GetAll()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<KHACHHANG>("select * from KHACHHANG order by MAKHACHHANG DESC").ToList();
            foreach(var item in list)
            {
                item.GetThongTinAccount();
            }            
            return list;
        }

        public bool InsertKhachHang(string taiKhoan, string matKhau, string hoTen, string ngaySinh, string gioiTinh, string sdt, string diaChi)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_KHACHHANG_GetMaKhachHangLast").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "kh" + newMa;

            //insert
            string insertCommand = "Sp_KHACHHANG_Insert @maKhachHang='" + newMa + "', @taiKhoan='" + taiKhoan + "', @matKhau='" + matKhau + "', @hoTen=N'" + hoTen + "', @ngaySinh='" + ngaySinh + "', @gioiTinh=N'" + gioiTinh + "', @sdt='" + sdt + "', @diaChi=N'" + diaChi +"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool DeleteKhachHang(string maKhachHang)
        {
            string Command = "Sp_KHACHHANG_Delete @maKhachHang='" + maKhachHang + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(Command);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateTaiKhoan(string maKhachHang, string taiKhoan, string matKhau)
        {
            string command = "Sp_ACCOUNT_UpdateTK @id='" + maKhachHang + "', @taiKhoan='" + taiKhoan + "', @matKhau='" + matKhau + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
