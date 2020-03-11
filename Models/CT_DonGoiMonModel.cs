using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CT_DonGoiMonModel
    {
        private QuanLyQuanAnDbContext context = null;
        public CT_DonGoiMonModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public static bool InsertCtDonGoiMon(string maDon, string maMatHang, string soLuong, string donGia)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_CT_DONGOIMON_GetMaMoiNhat").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "CT" + newMa;

            //insert
            string insertCommand = "Sp_CT_DONGOIMON_Insert @maCT='" + newMa + "', @maDon='" + maDon + "', @maMatHang='" + maMatHang + "', @soLuong=" + soLuong + ",@donGia="+ donGia;
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
