using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{   //nho public
    public class MatHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public MatHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public static string ThemMatHang(string tenMatHang, string maDonViTinh, string maLoaiMatHang)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@maLoaiMatHang",maLoaiMatHang),
                };
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_MATHANG_GetMaMatHangLast @maLoaiMatHang", sqlParams).First(); ;
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = maMoiNhat.Remove(2) + newMa;



            try
            {
                string insertCommand = "Sp_MATHANG_Insert @maMatHang='" + newMa + "', @tenMatHang=N'" + tenMatHang + "', @maDonViTinh='" + maDonViTinh + "', @maLoaiMatHang='" + maLoaiMatHang + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
                if (res > 0)
                    return newMa;
                else
                    return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
