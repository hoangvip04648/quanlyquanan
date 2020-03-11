using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThanhToanLuongNhanVienModel
    {
        private QuanLyQuanAnDbContext context = null;
        public ThanhToanLuongNhanVienModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<THANHTOANLUONGNHANVIEN> ListAll()
        {
            var list = context.Database.SqlQuery<THANHTOANLUONGNHANVIEN>("select * from THANHTOANLUONGNHANVIEN").ToList();
            //Lay thong tin khach hang
            foreach (THANHTOANLUONGNHANVIEN ttLuong in list)
            {
                ttLuong.GetAllRefInfo();
            }
            return list;
        }

        public static bool InsertThanhToanLuong(string maNhanVien, string ngayThanhToan, string tongThoiGianLam, string tongLuong, string khoangKhac, string ghiChu)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_THANHTOANLUONGNHANVIEN_Insert @maNhanVien='" + maNhanVien + "', @ngayThanhToan='" + ngayThanhToan+ "', @tongThoiGianLam="+ tongThoiGianLam
                                + ",@tongLuong="+tongLuong+ ",@khoangKhac="+ khoangKhac+ ",@ghiChu=N'"+ ghiChu+"'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteThanhToanLuong(string maNhanVien, string ngayThanhToan)
        {
            try
            {
                string cmd = "Sp_THANHTOANLUONGNHANVIEN_Delete @maNhanVien='" + maNhanVien + "', @ngayThanhToan='" + ngayThanhToan + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdateThanhToanLuong(string maNhanVien, string ngayThanhToan, string khoangKhac, string ghiChu)
        {
            try
            {
                string cmd = "Sp_THANHTOANLUONGNHANVIEN_Update @maNhanVien='" + maNhanVien + "', @ngayThanhToan='" + ngayThanhToan + "',@khoangKhac="+ khoangKhac+ ",@ghiChu=N'"+ ghiChu+"'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
