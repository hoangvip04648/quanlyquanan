using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MonAnModel
    {
        private QuanLyQuanAnDbContext context = null;
        public MonAnModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<MONAN> ListAll()
        {
            var list = context.Database.SqlQuery<MONAN>("Sp_MONAN_ListAll").ToList();
            //Lay thong tin khach hang
            foreach (MONAN monAn in list)
            {
                monAn.GetAllRefInfo();
            }
            return list;
        }

        public static bool ThemCT_MONAN(string maMonAn, string maNguyenLieu, string soLuong)
        {
            try
            {
                string insertCommand = "Sp_CT_MONAN_Insert @maMonAn='" + maMonAn + "', @maNguyenLieu='" + maNguyenLieu + "'"+", @soLuong="+soLuong;
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

        public MONAN GetByMaMonAn(string MaMonAn)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMonAn",MaMonAn),
                };
            var monAn = context.Database.SqlQuery<MONAN>("Sp_MONAN_GetByMaMonAn @MaMonAn", sqlParams).First();
            //Lay thong tin khach hang
            monAn.GetAllRefInfo();
            return monAn;
        }

 
        public static bool UpdateMonAn(string maMonAn, string tenMonAn, string madonVi, string giaBan, string hinhAnh)
        {
            try
            {
                //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_DONDATHANG_Update_TinhTrang_GhiChuBan @maDon='{0}', @tinhTrang=3, @ghiChuNguoiBan='{2}'", sqlParams[0], sqlParams[1], sqlParams[2]);
                string updateCommand = "Sp_MATHANG_Update @maMatHang='" + maMonAn + "', @tenMatHang=N'" + tenMonAn + "', @maDonVi='" + madonVi + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
                string updateCommand2 = "Sp_MONAN_Update @maMonAn='" + maMonAn + "', @giaBan=" + giaBan + ", @hinhAnh='" + hinhAnh + "'";
                var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand2);
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

        public static bool ThemMonAn(string maMA, string giaBan, string hinhAnh)
        {
            try
            {
                string insertCommand = "Sp_MONAN_Insert @maMonAn='" + maMA
                            + "', @giaban=" + giaBan +" , @hinhAnh='" + hinhAnh
                            + "'";
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

        public static bool DeleteCT_MonAn(string maMonAn, string maNguyenLieu)
        {
            try
            {
                string deleteCommand = "Sp_CT_MONAN_NGUYENLIEU_Delete @maMonAn='" + maMonAn + "', @maNguyenLieu='" + maNguyenLieu + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
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

       
        public static bool DeleteMatHangMonAn(string maMatHangMonAn)
        {
            try
            {
                try // xoa tu bang menumonan
                {
                    new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_MENUMONAN_Delete @MaMonAn='"+maMatHangMonAn+"'");
                }
                catch { }
                try //xoa tu bang ct mon an
                {
                    new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("Sp_CT_MONAN_Delete @MaMonAn='" + maMatHangMonAn + "'");
                }
                catch { }
                string deleteCommand = "Sp_MONAN_Delete @maMatHang='" + maMatHangMonAn + "'";
                var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand);
                if (res > 0)
                {
                    string deleteCommand2 = "Sp_MATHANG_Delete @maMatHang='" + maMatHangMonAn + "'";
                    try
                    {
                        var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(deleteCommand2);
                        if (res2 > 0)
                            return true;
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        //new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand("insert into MONAN values ('" + maMatHangMonAn + "')");
                        return false;
                    }

                }
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
