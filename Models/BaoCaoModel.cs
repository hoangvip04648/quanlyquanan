using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaoCaoModel
    {
        private QuanLyQuanAnDbContext context = null;
        public BaoCaoModel()
        {
            context = new QuanLyQuanAnDbContext();
        }

        public int GetTongChi1Ngay(int ngay,int thang,int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChi1Ngay @ngay='" + nam + "/" + thang + "/" + ngay + "'").First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThu1Ngay(int ngay, int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThu1Ngay @ngay='" + nam + "/" + thang + "/" + ngay + "'").First();
                return res;
            }
            catch { return 0; }
        }
        
        public int GetTongThuBanHangTaiQuan1Thang(int thang,int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuBanHangTaiQuan1Thang @thang="+thang+",@nam="+nam).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuBanHangTrenWeb1Thang(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuBanHangTrenWeb1Thang @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuKhac(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuKhac @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongChiNhapNguyenLieu(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapNguyenLieu @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }

        

        public int GetTongChiNhapDungCu(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapDungCu @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetTongChiNhapNuocGiaiKhat(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapNuocGiaiKhat @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetTongChiTraLuongNhanVien(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiTraLuongNhanVien @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetTongChiKhac(int thang, int nam)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiKhac @thang=" + thang + ",@nam=" + nam).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetSoSPBanOnlineTrongNgay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetSoSanPhamBanOnlineNgay @ngay="+ day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetSoSPBanTaiQuanTrongNgay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetSoSanPhamBanTaiQuanNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        //public List<BANGXEPHANGSANPHAM> GetBXHMONANTrongThang(int month, int year)
        //{
        //    try
        //    {
        //        string cmd = "Sp_BaoCao_GetBXHMonAn @thang=" + month + ",@nam=" + year;
        //        var res = context.Database.SqlQuery<BANGXEPHANGSANPHAM>(cmd).ToList();
        //        foreach (var item in res)
        //        {
        //            item.GetMatHang();
        //        }
        //        return res;
        //    }
        //    catch { return null; }
        //}
        //public List<BANGXEPHANGSANPHAM> GetBXHNGKTrongThang(int month, int year)
        //{
        //    try
        //    {
        //        string cmd = "Sp_BaoCao_GetBXHNuocGiaiKhat @thang=" + month + ",@nam=" + year;
        //        var res = context.Database.SqlQuery<BANGXEPHANGSANPHAM>(cmd).ToList();
        //        foreach (var item in res)
        //        {
        //            item.GetMatHang();
        //        }
        //        return res;
        //    }
        //    catch { return null; }
        //}


        public int GetSoDDHChuaXacNhanTrongNgay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_DemSoDonChuaXacNhan @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuTaiQuan1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuTaiQuan1Ngay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuOnline1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuOnline1Ngay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuKhac1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuKhac1Ngay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }

        public int GetTongThuBuoiTrua1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuBuoiTrua1Ngay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetTongThuBuoiToi1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongThuBuoiToi1Ngay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }




        public int GetChiNhapNguyenLieu1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapNguyenLieuTrongNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetChiNhapDungCu1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapDungCuTrongNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetChiNhapNuocGiaiKhat1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiNhapNuocGiaiKhatTrongNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetChiTraLuongNhanVien1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiTraLuongNhanVienTrongNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
        public int GetChiKhac1Ngay(int day, int month, int year)
        {
            try
            {
                var res = context.Database.SqlQuery<int>("Sp_BaoCao_GetTongChiKhacTrongNgay @ngay=" + day + " ,@thang=" + month + ",@nam=" + year).First();
                return res;
            }
            catch { return 0; }
        }
    }
}
