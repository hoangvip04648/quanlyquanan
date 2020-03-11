using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Nho public
    public class NguyenLieuModel
    {
        private QuanLyQuanAnDbContext context = null;
        public NguyenLieuModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<NGUYENLIEU> ListAll()
        {
            var list = context.Database.SqlQuery<NGUYENLIEU>("Sp_NGUYENLIEU_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (NGUYENLIEU nguyenlieu in list)
            {
                nguyenlieu.GetAllRefInfo();
            }
            return list;
        }
        public NGUYENLIEU GetByMaNguyenLieu(string MaNguyenLieu)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNguyenLieu",MaNguyenLieu),
                };
            var nguyenlieu = context.Database.SqlQuery<NGUYENLIEU>("Sp_NGUYENLIEU_GetByMaNguyenLieu @MaNguyenLieu",sqlParams).First();
            //Lay thong tin khach hang
            nguyenlieu.GetAllRefInfo();
            return nguyenlieu;
        }

        public static bool ThemNguyenLieu(string maNL)
        {
            try
            {
                string insertCommand = "Sp_NGUYENLIEU_Insert @maNguyenLieu='" + maNL +"'";
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

        public static bool DeleteNguyenLieu_NhaCungCap(string maNguyenLieu, string maNhaCungCap)
        {
            try
            {
                string deleteCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Delete @maMatHang='" + maNguyenLieu + "', @maNhaCungCap='" + maNhaCungCap + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
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

        public static bool DeleteMatHangNguyenLieu(string maMatHangNguyenLieu)
        {
            try
            {
                string deleteCommand = "Sp_NGUYENLIEU_Delete @maMatHang='" + maMatHangNguyenLieu+ "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
                if (res > 0)
                {
                    string deleteCommand2 = "Sp_MATHANG_Delete @maMatHang='" + maMatHangNguyenLieu + "'";
                    try
                    {
                        var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand2);
                        if (res2 > 0)
                            return true;
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("insert into NGUYENLIEU values ('" + maMatHangNguyenLieu + "')");
                        return false;
                    }
                    
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ThemNguyenLieu_NhaCungCap(string maNguyenLieu, string maNhaCungCap)
        {
            try
            {
                string deleteCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Insert @maMatHang='" + maNguyenLieu + "', @maNhaCungCap='" + maNhaCungCap + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
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

        public static bool UpdateNguyenLieu(string maNguyenLieu, string tenNguyenLieu, string madonVi)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MATHANG_Update @maMatHang='" + maNguyenLieu + "', @tenMatHang=N'" + tenNguyenLieu + "', @maDonVi='" + madonVi + "'";
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
