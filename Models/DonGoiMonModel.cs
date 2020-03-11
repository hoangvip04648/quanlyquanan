using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Nho public
    public class DonGoiMonModel
    {
        private QuanLyQuanAnDbContext context = null;
        public DonGoiMonModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public List<DONGOIMON> ListAllDonGoiMonChuaGiao()
        {
            var list = context.Database.SqlQuery<DONGOIMON>("Sp_DONGOIMON_ListDangDoi").ToList();
            //Lay thong tin khach hang
            foreach (DONGOIMON donGoiMon in list)
            {
                donGoiMon.GetAllRefInfo();
            }
            return list;
        }

        public static List<DONGOIMON> List3DonGoiMonDaLamGanNhat()
        {
            string ngay = DateTime.Now.ToString("yyyy/MM/dd");
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<DONGOIMON>("Sp_DONGOIMON_List3DaLamGanNhat @ngay='"+ngay+"'").ToList();
            //Lay thong tin khach hang
            foreach (DONGOIMON donGoiMon in list)
            {
                donGoiMon.GetAllRefInfo();
            }
            return list;
        }

        public static string InsertDonGoiMon(string ngay, string thoiGian, string ghiChu, string ban)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("select top 1 MADON from DONGOIMON order by MADON desc").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "GM" + newMa;

            //insert
            string insertCommand = "Sp_DONGOIMON_Insert @maDon='" + newMa + "', @ngay='" + ngay + "',@thoiGian='"+ thoiGian+ "',@ghiChu=N'"+ ghiChu+ "',@ban='"+ ban+"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return newMa;
            else
                return "";
        }

        public static bool SuaTrangThaiDonGoiMon(string maDon, string trangThai)
        {
            string cmd = "Sp_DONGOIMON_UpdateTrangThai @MaDon='" + maDon + "',@trangThai="+trangThai;
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool HuyDonGoiMon(string maDon)
        {
            try //Tang so luong nuoc giai khat
            {
                string command = "Sp_CT_DONGOIMON_GetByMaDonGoiMon @MaDon='" + maDon + "'";
                List<CT_DONGOIMON> listCT= new QuanLyQuanAnDbContext().Database.SqlQuery<CT_DONGOIMON>(command).ToList();
                foreach(var item in listCT)
                {
                    if (item.MAMATHANG.StartsWith("NC")&&item.SOLUONG.HasValue)
                    {
                        NuocGiaiKhatModel.UpdateThemSoLuongNuocGiaiKhat(item.MAMATHANG, item.SOLUONG.Value+"");
                    }
                }
            }
            catch { }

            //
            string cmd = "Sp_DONGOIMON_Delete @MaDon='" + maDon + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(cmd);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
