using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NhanVienModel
    {
        private QuanLyQuanAnDbContext context = null;
        public NhanVienModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public List<NHANVIEN> ListAll()
        {
            var list = context.Database.SqlQuery<NHANVIEN>("Sp_NHANVIEN_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (NHANVIEN nhanVien in list)
            {
                nhanVien.GetAllRefInfo();
            }
            return list;
        }

        public List<NHANVIEN> ListAllConLamViec()
        {
            var list = context.Database.SqlQuery<NHANVIEN>("Sp_NHANVIEN_ListAllConLamViec").ToList();
            //Lay thong tin khach hang
            foreach (NHANVIEN nhanVien in list)
            {
                nhanVien.GetAllRefInfo();
            }
            return list;
        }
        public List<NHANVIEN> ListAllNghiViec()
        {
            var list = context.Database.SqlQuery<NHANVIEN>("Sp_NHANVIEN_ListAllNghiViec").ToList();
            //Lay thong tin khach hang
            foreach (NHANVIEN nhanVien in list)
            {
                nhanVien.GetAllRefInfo();
            }
            return list;
        }

        public NHANVIEN GetByMaNhanVien(string maNhanVien)
        {
            var nhanVien = context.Database.SqlQuery<NHANVIEN>("Sp_NHANVIEN_GetByMaNhanVien @maNhanVien='"+maNhanVien+"'").First();
            //Lay thong tin
            nhanVien.GetAllRefInfo();
            return nhanVien;
        }
        public static NHANVIEN GetByMaNhanVienStt(string maNhanVien)
        {
            var nhanVien = new QuanLyQuanAnDbContext().Database.SqlQuery<NHANVIEN>("Sp_NHANVIEN_GetByMaNhanVien @maNhanVien='" + maNhanVien + "'").First();
            //Lay thong tin
            nhanVien.GetAllRefInfo();
            return nhanVien;
        }

        public static bool InsertNhanVien(string taiKhoan, string matKhau, string hoTen, string ngaySinh, string gioiTinh, string sdt, string diaChi, string luong, string maDVL, string ngayKyHopDong)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_NHANVIEN_GetMaNhanVienLast").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "nv" + newMa;

            //insert
            string insertCommand = "Sp_NHANVIEN_Insert @maNhanVien='"+newMa+"', @taiKhoan='"+taiKhoan+"', @matKhau='"+matKhau+"', @hoTen=N'"+ hoTen + "', @ngaySinh='"+ ngaySinh + "', @gioiTinh=N'"+ gioiTinh + "', @sdt='"+ sdt + "', @diaChi=N'"+ diaChi + "', @luong="+luong+", @maDVL='"+ maDVL + "', @ngayKyHopDong='"+ ngayKyHopDong + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }

        public static bool DeleteNhanVien(string maNhanVien)
        {
            string Command = "Sp_NHANVIEN_Delete @maNhanVien='" + maNhanVien + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(Command);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }

        public static bool UpdateNhanVien(string maNhanVien,string hoTen, string ngaySinh, string gioiTinh, string sdt, string diaChi, string luong, string maDVL, string ngayKyHopDong)
        {

            //insert
            //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("set dateformat dmy");
            string command = "Sp_NHANVIEN_Update @maNhanVien='" + maNhanVien + "', @hoTen=N'" + hoTen + "', @ngaySinh='" + ngaySinh + "', @gioiTinh=N'" + gioiTinh + "', @sdt='" + sdt + "', @diaChi=N'" + diaChi + "', @luong=" + luong + ", @maDVL='" + maDVL + "', @ngayKyHopDong='" + ngayKyHopDong + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
            {
                return true;
            }
            else
                return false;
        }

        public static bool UpdateTaiKhoanNhanVien(string maNhanVien, string taiKhoan, string matKhau)
        {
            string command = "Sp_ACCOUNT_UpdateTK @id='" + maNhanVien + "', @taiKhoan='" + taiKhoan + "', @matKhau='" + matKhau + "'";
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
