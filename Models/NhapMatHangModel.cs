using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //nho dua ve public
    public class NhapMatHangModel
    {
        private QuanLyQuanAnDbContext context = null;
        public NhapMatHangModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<NHAPMATHANG> ListByDayAndType(int ngay, int thang, int nam, string maLoaiMatHang)
        {
            object[] sqlParams =
               {
                    new SqlParameter("@ngayNhap",ngay),
                    new SqlParameter("@thangNhap",thang),
                    new SqlParameter("@namNhap",nam),
                    new SqlParameter("@maLoaiMatHang",maLoaiMatHang)
               };

            var list = context.Database.SqlQuery<NHAPMATHANG>("Sp_NHAPMATHANG_ListByDayAndType @ngayNhap, @thangNhap, @namNhap, @maLoaiMatHang", sqlParams).ToList();
            //Lay thong tin khach hang
            foreach (NHAPMATHANG ctNhapHang in list)
            {
                ctNhapHang.GetAllRefInfo();
            }
            return list;
        }

        public static bool InsertCTDonDatHang(string maMatHang, string maNhaCungCap, string ngayNhap, string soLuong, string donGia, string thanhTien, string hanSuDung)
        {
            string maMoiNhat = new QuanLyQuanAnDbContext().Database.SqlQuery<string>("Sp_NHAPMAHANG_GetMaPhieuNhapLast").First();
            string newMa = maMoiNhat.Remove(0, 2);
            int newNum = Int32.Parse(newMa) + 1;
            newMa = newNum + "";
            int l = newMa.Length;
            for (int i = 0; i < maMoiNhat.Length - 2 - l; i++)
            {
                newMa = "0" + newMa;
            }
            newMa = "PN" + newMa;

            //insert
            string insertCommand = "Sp_NHAPMATHANG_Insert @MaPhieuNhap='"+newMa+"',@MaMatHang='"+maMatHang+ "',@MaNhaCungCap='" + maNhaCungCap + "',@NgayNhap='" + ngayNhap 
                        + "',@SoLuong=" + soLuong + ",@DonGia=" + donGia + ",@ThanhTien=" + thanhTien + ",@HanSuDung='" + hanSuDung + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(insertCommand);
            if (res > 0)
            {
                try //them so luong nuoc giai khat
                {
                    if (maMatHang.StartsWith("NC"))
                    {
                        string addCommand = "Sp_NUOCGIAIKHAT_AddCount @maNuocGiaiKhat='" + maMatHang + "',@soLuongThem=" + soLuong;
                        var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(addCommand);
                    }
                }
                catch { }
                return true;
            }
                
            else
                return false;
        }

       

        public static bool UpdateCTDonDatHang(string maPhieuNhap, string maMatHang, string maNhaCungCap, string ngayNhap, string soLuong, string donGia, string thanhTien, string hanSuDung)
        {
            //getSoLuongCu
            string getcmd = "select SOLUONG from NHAPMATHANG where MAPHIEUNHAP='" + maPhieuNhap + "'";
            int soLuongOld=new QuanLyQuanAnDbContext().Database.SqlQuery<int>(getcmd).First();

            //update
            string updateCommand = "Sp_NHAPMATHANG_Update @MaPhieuNhap='" + maPhieuNhap + "',@MaMatHang='" + maMatHang + "',@MaNhaCungCap='" + maNhaCungCap + "',@NgayNhap='" + ngayNhap
                        + "',@SoLuong=" + soLuong + ",@DonGia=" + donGia + ",@ThanhTien=" + thanhTien + ",@HanSuDung='" + hanSuDung + "'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
            if (res > 0)
            {
                try //sua so luong nuoc giai khat
                {
                    if (maMatHang.StartsWith("NC"))
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string dayString = dateTime.Year + "-";
                        if (dateTime.Month.ToString().Length == 1)
                            dayString += "0" + dateTime.Month;
                        else
                            dayString += dateTime.Month;
                        if(dateTime.Day.ToString().Length==1)
                            dayString+= "-0" + dateTime.Day;
                        else
                            dayString += "-" + dateTime.Day;
                        if (dayString == ngayNhap)
                        {
                            string addCommand = "Sp_NUOCGIAIKHAT_AddCount @maNuocGiaiKhat='" + maMatHang + "',@soLuongThem=" + (Int32.Parse(soLuong) - soLuongOld);
                            var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(addCommand);
                        }
                    }
                }
                catch { }
                return true;
            }
                
            else
                return false;
        }

        public static bool DeleteCTDonDatHang(string maPhieuNhap)
        {
            //getSoLuongCu
            string getcmd = "select SOLUONG from NHAPMATHANG where MAPHIEUNHAP='" + maPhieuNhap + "'";
            int soLuongOld = new QuanLyQuanAnDbContext().Database.SqlQuery<int>(getcmd).First();
            string getcmd2 = "select MAMATHANG from NHAPMATHANG where MAPHIEUNHAP='" + maPhieuNhap + "'";
            string maMatHang = new QuanLyQuanAnDbContext().Database.SqlQuery<string>(getcmd2).First();
            string getcmd3 = "select NGAYNHAP from NHAPMATHANG where MAPHIEUNHAP='" + maPhieuNhap + "'";
            DateTime dtNgayNhap = new QuanLyQuanAnDbContext().Database.SqlQuery<DateTime>(getcmd3).First();
            
            //Xoa
            string updateCommand = "Sp_NHAPMATHANG_Delete @MaPhieuNhap='" + maPhieuNhap+"'";
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(updateCommand);
            if (res > 0)
            {
                try //sua so luong nuoc giai khat
                {
                    if (maMatHang.StartsWith("NC"))
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        
                        if (dateTime.Date == dtNgayNhap.Date&&dateTime.Month==dtNgayNhap.Month&&dateTime.Year==dtNgayNhap.Year)
                        {
                            string addCommand = "Sp_NUOCGIAIKHAT_AddCount @maNuocGiaiKhat='" + maMatHang + "',@soLuongThem=" + ( - soLuongOld);
                            var res2 = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(addCommand);
                        }
                    }
                }
                catch { }

                return true;
            }
            else
                return false;
        }
    }
}
