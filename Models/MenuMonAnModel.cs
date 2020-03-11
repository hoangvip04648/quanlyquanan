using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MenuMonAnModel
    {
        private QuanLyQuanAnDbContext context = null;
        public MenuMonAnModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<MENUMONAN> ListAll()
        {
            var list = context.Database.SqlQuery<MENUMONAN>("Sp_MENUMONAN_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (MENUMONAN menuMonAn in list)
            {
                menuMonAn.GetAllRefInfo();
            }
            return list;
        }
        public List<MENUMONAN> ListConHang()
        {
            var list = context.Database.SqlQuery<MENUMONAN>("Sp_MENUMONAN_ListCon").ToList();
            //Lay thong tin khach hang
            foreach (MENUMONAN menuMonAn in list)
            {
                menuMonAn.GetAllRefInfo();
            }
            return list;
        }
        public static bool InsertMenuMonAn(string maMonAn, string trangThai, string giaBan)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_MENUMONAN_Insert @maMonAn='" + maMonAn + "', @trangThai=" + trangThai + ", @giaBan=" + giaBan;
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

        public static bool UpdateTrangThaiMenuMonAn(string maMonAn, string trangThai)
        {
            try
            {
                string updateCommand = "Sp_MENUMONAN_UpdateTrangThai @maMonAn='" + maMonAn + "', @trangThai=" + trangThai;
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

        public static bool UpdateAllMenuMonAn(string trangThaiAll)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_MENUMONAN_UpdateAll @trangThai=" + trangThaiAll;
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

        public static bool DeleteMenuMonAn(string maMonAn)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MENUMONAN_Delete @maMonAn='" + maMonAn + "'";
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

        public static bool UpdateMenuMonAn(string maMonAn, string trangThai, string giaBan)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MENUMONAN_Update @maMonAn='" + maMonAn + "', @trangThai=" + trangThai + ", @giaBan=" + giaBan;
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

        public MENUMONAN GetByMaMonAn(string maMonAn)
        {
            try
            {
                MENUMONAN menu = context.Database.SqlQuery<MENUMONAN>("select * from MENUMONAN where MAMONAN='" + maMonAn + "'").First();
                return menu;
            }
            catch
            {
                return null;
            }
        }
    }
}
