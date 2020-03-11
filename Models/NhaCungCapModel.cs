using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Nho dua ve public
    public class NhaCungCapModel
    {
        private QuanLyQuanAnDbContext context = null;
        public NhaCungCapModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<NHACUNGCAP> ListAll()
        {
            var list = context.Database.SqlQuery<NHACUNGCAP>("Sp_NHACUNGCAP_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (NHACUNGCAP nhaCungCap in list)
            {
                nhaCungCap.GetAllRefInfo();
            }
            return list;
        }

        public static bool InsertNhaCungCap(string tenNCC, string nguoiDaiDien, string sdt, string diaChi, string maLoaiMHCC, string moTa)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_NHACUNGCAP_GetMaMoiNhat").First();
            string newMa = maMoiNhat.Remove(0, 3);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 3 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "NCC" + newMa;

            //insert
            string insertCommand = "Sp_NHACUNGCAP_Insert @maNCC='" + newMa + "', @tenNCC=N'" + tenNCC + "', @nguoiDaiDien=N'" + nguoiDaiDien + "', @sdt='" + sdt + "', @diaChi=N'" + diaChi + "', @maLoaiMHCC='" + maLoaiMHCC + "', @moTa=N'" + moTa + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteNhaCungCap(string maNhaCungCap)
        {
            try
            {
                string detetecmd = "Sp_NHACUNGCAP_Delete @maNhaCungCap='" + maNhaCungCap + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(detetecmd);
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

        public static bool UpdateNhaCungCap(string maNCC, string tenNCC, string nguoiDaiDien, string sdt, string diaChi, string maLoaiMHCC, string moTa)
        {
            try
            {
                string updateCommand = "Sp_NHACUNGCAP_Update @maNCC='" + maNCC + "', @tenNCC=N'" + tenNCC + "', @nguoiDaiDien=N'" + nguoiDaiDien + "', @sdt='" + sdt + "', @diaChi=N'" + diaChi + "', @maLoaiMHCC='" + maLoaiMHCC + "', @moTa=N'" + moTa + "'";
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
