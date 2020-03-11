using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NuocGiaiKhatModel
    {
        private QuanLyQuanAnDbContext context = null;
        public NuocGiaiKhatModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<NUOCGIAIKHAT> ListAll()
        {
            var list = context.Database.SqlQuery<NUOCGIAIKHAT>("Sp_NUOCGIAIKHAT_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (NUOCGIAIKHAT nuocGiaiKhat in list)
            {
                nuocGiaiKhat.GetAllRefInfo();
            }
            return list;
        }
        public NUOCGIAIKHAT GetByMaNuocGiaiKhat(string MaNuocGiaiKhat)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNuocGiaiKhat",MaNuocGiaiKhat),
                };
            var nuocGiaiKhat = context.Database.SqlQuery<NUOCGIAIKHAT>("Sp_NUOCGIAIKHAT_GetByMaNuocGiaiKhat @MaNuocGiaiKhat", sqlParams).First();
            //Lay thong tin khach hang
            nuocGiaiKhat.GetAllRefInfo();
            return nuocGiaiKhat;
        }

        public static bool ThemNuocGiaiKhat(string maDC, string giaBan, string soLuongCon, string hinhAnh)
        {
            try
            {
                string insertCommand = "Sp_NUOCGIAIKHAT_Insert @maNuocGiaiKhat='" + maDC 
                            +"', @giaban="+giaBan+" , @soLuongCon="+soLuongCon+" , @hinhAnh='"+hinhAnh
                            + "'";
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

        public static bool DeleteNuocGiaiKhat_NhaCungCap(string maNuocGiaiKhat, string maNhaCungCap)
        {
            try
            {
                string deleteCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Delete @maMatHang='" + maNuocGiaiKhat + "', @maNhaCungCap='" + maNhaCungCap + "'";
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

        public static bool DeleteMatHangNuocGiaiKhat(string maMatHangNuocGiaiKhat)
        {
            try
            {
                string deleteCommand = "Sp_NUOCGIAIKHAT_Delete @maMatHang='" + maMatHangNuocGiaiKhat + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
                if (res > 0)
                {
                    string deleteCommand2 = "Sp_MATHANG_Delete @maMatHang='" + maMatHangNuocGiaiKhat + "'";
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
                        new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("insert into NUOCGIAIKHAT values ('" + maMatHangNuocGiaiKhat + "')");
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

        public static bool ThemNuocGiaiKhat_NhaCungCap(string maNuocGiaiKhat, string maNhaCungCap)
        {
            try
            {
                string insertCommand = "Sp_MATHANGNHAP_NHACUNGCAP_Insert @maMatHang='" + maNuocGiaiKhat + "', @maNhaCungCap='" + maNhaCungCap + "'";
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

        public static bool UpdateNuocGiaiKhat(string maNuocGiaiKhat, string tenNuocGiaiKhat, string madonVi, string giaBan, string soLuongCon, string hinhAnh)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MATHANG_Update @maMatHang='" + maNuocGiaiKhat + "', @tenMatHang=N'" + tenNuocGiaiKhat + "', @maDonVi='" + madonVi + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
                string updateCommand2 = "Sp_NUOCGIAIKHAT_Update @maNuocGiaiKhat='" + maNuocGiaiKhat + "', @giaBan=" + giaBan + ", @soLuongCon=" + soLuongCon + ", @hinhAnh='"+hinhAnh+"'";
                var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand2);
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

        public static bool UpdateThemSoLuongNuocGiaiKhat(string maNuocGiaiKhat, string soLuongThem)
        {
            try
            {
                string updateCommand2 = "Sp_NUOCGIAIKHAT_AddCount @maNuocGiaiKhat='" + maNuocGiaiKhat + "', @soLuongThem=" + soLuongThem;
                var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand2);
                if (res2 > 0)
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
