using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DonViTinhModel
    {
        private QuanLyQuanAnDbContext context = null;
        public DonViTinhModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<DONVITINH> ListAll()
        {
            var list = context.Database.SqlQuery<DONVITINH>("Sp_DONVITINH_ListAll").ToList();
          
            return list;
        }

        public static bool InsertDonViTinh(string tenDonViTinh)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_DONVITINH_GetMaMoiNhat").First();
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
            string insertCommand = "Sp_DONVITINH_Insert @maDVT='" + newMa + "', @tenDVT=N'" + tenDonViTinh+ "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteDonViTinh(string maDonViTinh)
        {
            //delete
            string command = "Sp_DONVITINH_Delete @maDVT='" + maDonViTinh + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateDonViTinh(string maDonViTinh, string tenDonViTinh)
        {
            //update
            string command = "Sp_DONVITINH_Update @maDVT='" + maDonViTinh + "', @tenDVT=N'" + tenDonViTinh + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
