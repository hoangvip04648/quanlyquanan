using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DungCuModel
    {
        private QuanLyQuanAnDbContext context = null;
        public DungCuModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<DUNGCU> ListAll()
        {
            var list = context.Database.SqlQuery<DUNGCU>("Sp_DUNGCU_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (DUNGCU dungCu in list)
            {
                dungCu.GetAllRefInfo();
            }
            return list;
        }
        public DUNGCU GetByMaDungCu(string MaDungCu)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaDungCu",MaDungCu),
                };
            var dungCu = context.Database.SqlQuery<DUNGCU>("Sp_DUNGCU_GetByMaDungCu @MaDungCu", sqlParams).First();
            //Lay thong tin khach hang
            dungCu.GetAllRefInfo();
            return dungCu;
        }

        public static bool ThemDungCu(string maDC)
        {
            try
            {
                string insertCommand = "Sp_DUNGCU_Insert @maDungCu='" + maDC + "'";
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

        public static bool DeleteDungCu_NhaCungCap(string maDungCu, string maNhaCungCap)
        {
            try
            {
                string deleteCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Delete @maMatHang='" + maDungCu + "', @maNhaCungCap='" + maNhaCungCap + "'";
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

        public static bool DeleteMatHangDungCu(string maMatHangDungCu)
        {
            try
            {
                string deleteCommand = "Sp_DUNGCU_Delete @maMatHang='" + maMatHangDungCu + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
                if (res > 0)
                {
                    string deleteCommand2 = "Sp_MATHANG_Delete @maMatHang='" + maMatHangDungCu + "'";
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
                        new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("insert into DUNGCU values ('" + maMatHangDungCu + "')");
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

        public static bool ThemDungCu_NhaCungCap(string maDungCu, string maNhaCungCap)
        {
            try
            {
                string insertCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Insert @maMatHang='" + maDungCu + "', @maNhaCungCap='" + maNhaCungCap + "'";
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

        public static bool UpdateDungCu(string maDungCu, string tenDungCu, string madonVi)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MATHANG_Update @maMatHang='" + maDungCu + "', @tenMatHang=N'" + tenDungCu + "', @maDonVi='" + madonVi + "'";
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
