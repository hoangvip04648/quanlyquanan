using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChamCongNhanVienModel
    {
        private QuanLyQuanAnDbContext context = null;
        public ChamCongNhanVienModel()
        {
            context = new QuanLyQuanAnDbContext();
        }


        public static bool UpdateChamCong(string maNhanVien, string ngayChamCong, string thoiGianLam)
        {
            try
            {
                string updateCommand = "Sp_CHAMCONGNHANVIEN_Update @maNhanVien='" + maNhanVien + "', @ngayChamCong='" + ngayChamCong + "', @thoiGianLam=" + thoiGianLam;
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
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

        public static bool InsertChamCong(string maNV, string ngayCham, string thoiGianLam, string trangThaiThanhToan)
        {
            try
            {
                string cmd = "Sp_CHAMCONGNHANVIEN_Insert @maNhanVien='" + maNV + "',@ngayCham='"+ ngayCham + "',@thoiGianLam=" + thoiGianLam+ ", @trangThaiThanhToan=" + trangThaiThanhToan;
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

        public List<CHAMCONGNHANVIEN> List3NgayGanNhat()
        {
            var list = context.Database.SqlQuery<CHAMCONGNHANVIEN>("Select top 10 * from CHAMCONGNHANVIEN where TRANGTHAITHANHTOAN=0 order by NGAYCHAMCONG desc").ToList();
            foreach(var item in list)
            {
                item.GetAllRefInfo();
            }
            return list;
        }

        public static bool UpdateAllTrangThai(string maNhanVien, string trangThaiThanhToan)
        {
            try
            {
                string updateCommand = "Sp_CHAMCONGNHANVIEN_UpdateAllTrangThai @maNhanVien='" + maNhanVien + "', @trangThaiThanhToan=" + trangThaiThanhToan;
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
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
