using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MenuNuocGiaiKhatModel
    {
        private QuanLyQuanAnDbContext context = null;
        public MenuNuocGiaiKhatModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<MENUNUOCGIAIKHAT> ListAll()
        {
            var list = context.Database.SqlQuery<MENUNUOCGIAIKHAT>("Sp_MENUNUOCGIAIKHAT_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (MENUNUOCGIAIKHAT menuNuocGiaiKhat in list)
            {
                menuNuocGiaiKhat.GetAllRefInfo();
            }
            return list;
        }
        public static List<MENUNUOCGIAIKHAT> ListAllDangBan()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<MENUNUOCGIAIKHAT>("Sp_MENUNUOCGIAIKHAT_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (MENUNUOCGIAIKHAT menuNuocGiaiKhat in list)
            {
                menuNuocGiaiKhat.GetAllRefInfo();
            }
            return list;
        }
        public static List<MENUNUOCGIAIKHAT> ListCon()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<MENUNUOCGIAIKHAT>("Sp_MENUNUOCGIAIKHAT_ListCon").ToList();
            //Lay thong tin khach hang
            foreach (MENUNUOCGIAIKHAT menuNuocGiaiKhat in list)
            {
                menuNuocGiaiKhat.GetAllRefInfo();
            }
            return list;
        }

        public MENUNUOCGIAIKHAT GetByMaNuocGiaiKhat(string maMatHang)
        {
            try
            {
                MENUNUOCGIAIKHAT menu = context.Database.SqlQuery<MENUNUOCGIAIKHAT>("select * from MENUNUOCGIAIKHAT where MANUOCGIAIKHAT='" + maMatHang + "'").First();
                menu.GetAllRefInfo();
                return menu;
            }
            catch
            {
                return null;
            }
        }

        public static bool InsertMenuNuocGiaiKhat(string maNuocGiaiKhat, string giaBan)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_MENUNUOCGIAIKHAT_Insert @maNuocGiaiKhat='" + maNuocGiaiKhat + "', @giaBan=" + giaBan;
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
        

        public static bool DeleteMenuNuocGiaiKhat(string maNuocGiaiKhat)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MENUNUOCGIAIKHAT_Delete @maMatHang='" + maNuocGiaiKhat + "'";
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

        public static bool UpdateMenuNuocGiaiKhat(string maNuocGiaiKhat, string soLuongCon, string giaBan)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MENUNUOCGIAIKHAT_Update @maNuocGiaiKhat='" + maNuocGiaiKhat + "', @soLuongCon=" + soLuongCon + ", @giaBan=" + giaBan;
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
