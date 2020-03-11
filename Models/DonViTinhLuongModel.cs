using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DonViTinhLuongModel
    {
        private QuanLyQuanAnDbContext context = null;
        public DonViTinhLuongModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<DONVITINHLUONG> ListAll()
        {
            var list = context.Database.SqlQuery<DONVITINHLUONG>("Sp_DONVITINHLUONG_ListAll").ToList();

            return list;
        }

        public static bool InsertDonViTinhLuong(string tenDonViTinhLuong)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_DONVITINHLUONG_GetMaMoiNhat").First();
            string newMa = maMoiNhat.Remove(0, 3);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 3 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "DVT" + newMa;

            //insert
            string insertCommand = "Sp_DONVITINHLUONG_Insert @maDVT='" + newMa + "', @tenDVT=N'" + tenDonViTinhLuong + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteDonViTinhLuong(string maDonViTinhLuong)
        {
            //delete
            string command = "Sp_DONVITINHLUONG_Delete @maDVT='" + maDonViTinhLuong + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateDonViTinhLuong(string maDonViTinhLuong, string tenDonViTinhLuong)
        {
            //update
            string command = "Sp_DONVITINHLUONG_Update @maDVT='" + maDonViTinhLuong + "', @tenDVT=N'" + tenDonViTinhLuong + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
