using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CT_DonDatHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public CT_DonDatHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public static bool UpdateCTDonDatHang(string maCTDDH, string maMatHang, string soLuong)
        {
            try
            {

                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_CT_DONDATHANG_Update @maCTDDH='" + maCTDDH + "', @maMH=" + maMatHang + ", @soLuong='" + soLuong + "'";
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

        public static bool InsertCTDonDatHang(string maDon, string maMatHang, string soLuong)
        {
            try
            {
                string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_CT_DONDATHANG_GetMaMoiNhat").First();
                string newMa = maMoiNhat.Remove(0, 2);
                int newNum = Int32.Parse(newMa)+1;
                newMa = newNum + "";
                int l = newMa.Length;
                for(int i = 0; i < maMoiNhat.Length - 2 -l;i++)
                {
                    newMa = "0" + newMa;
                }
                newMa = "CT" + newMa;
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_CT_DONDATHANG_Insert @maCTDDH='"+newMa+"', @maDon='" + maDon + "', @maMH=" + maMatHang + ", @soLuong='" + soLuong + "'";
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

        public static bool DeleteCTDonDatHang(string maCTDDH)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_CT_DONDATHANG_Delete @maCTDDH='" + maCTDDH + "'";
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

        public bool ThemCTDonDatHang(string maDon, string maMatHang, string soLuong)
        {
            try
            {
                string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_CT_DONDATHANG_GetMaMoiNhat").First();
                string newMa = maMoiNhat.Remove(0, 2);
                int newNum = Int32.Parse(newMa) + 1;
                newMa = newNum + "";
                int l = newMa.Length;
                for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
                {
                    newMa = "0" + newMa;
                }
                newMa = "CT" + newMa;
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string insertCommand = "Sp_CT_DONDATHANG_Insert @maCTDDH='" + newMa + "', @maDon='" + maDon + "', @maMH=" + maMatHang + ", @soLuong='" + soLuong + "'";
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
    }
}
