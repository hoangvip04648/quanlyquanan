using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Nho dua ve public
    public class DonDatHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public DonDatHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public List<DONDATHANG> GetByMaKhachHang(string maKH)
        {
            var list = context.Database.SqlQuery<DONDATHANG>("Sp_DONDATHANG_ListByMaKH @maKH='"+ maKH + "'").ToList();
            //Lay thong tin khach hang
            foreach (DONDATHANG donDatHang in list)
            {
                donDatHang.GetAllRefInfo();
            }
            return list;
        }

        public List<DONDATHANG> ListAll()
        {
            var list = context.Database.SqlQuery<DONDATHANG>("Sp_DONDATHANG_ListAll").ToList();
            //Lay thong tin khach hang
            foreach(DONDATHANG donDatHang in list)
            {
                donDatHang.GetAllRefInfo();
            }
            return list;
        }

        public List<DONDATHANG> ListByDay(int ngay,int thang,int nam)
        {
            var list = context.Database.SqlQuery<DONDATHANG>("Sp_DONDATHANG_GetByDay @ngay="+ngay+", @thang="+thang+", @nam="+nam).ToList();
            //Lay thong tin khach hang
            foreach (DONDATHANG donDatHang in list)
            {
                donDatHang.GetAllRefInfo();
            }
            return list;
        }

        public string ThemDonDathang(string ngay, string thoiGian, string maKH, string diaChiGiaoHang, string ghiChu, string tinhTrangDonHang, string ghiChuNguoiBan)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("select top 1 MADON from DONDATHANG order by MADON desc").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "DH" + newMa;

            //insert
            string insertCommand = "Sp_DONDATHANG_Insert @maDon='" + newMa + "', @ngay='" + ngay + "',@thoiGian='" + thoiGian+"',@maKH='"
                                +maKH+"',@diaChiGiaoHang=N'"+diaChiGiaoHang + "',@ghiChu=N'" + ghiChu + "',@tinhTrangDonHang=" + tinhTrangDonHang + ",@ghiChuNguoiBan=N'"+ ghiChuNguoiBan+"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return newMa;
            else
                return "";
        }

        public DONDATHANG GetByMaDon(string MaDon)
        {
           
            object[] sqlParams =
                {
                    new SqlParameter("@MaDon",MaDon),
                };
            var ddh = context.Database.SqlQuery<DONDATHANG>("Sp_DONDATHANG_GetByMaDon @MaDon",sqlParams).First();
            //Lay thong tin khach hang
            ddh.GetAllRefInfo();
            return ddh;
        }

        public static bool UpdateTinhTrang_GhiChu(string MaDon, int TinhTrang, string GhiChu)
        {
            try
            {
               
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='"+MaDon+"', @tinhTrang="+TinhTrang+", @ghiChuNguoiBan=N'"+GhiChu+"'";
                var res=new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
                if (res >0)
                    return true;
                else
                    return false;
            }
            catch(Exception e) {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public bool HuyDonDatHang(string MaDon)
        {
            try
            {
                string updateCommand = "Sp_DONDATHANG_Update_HuyDon @maDon='" + MaDon + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
