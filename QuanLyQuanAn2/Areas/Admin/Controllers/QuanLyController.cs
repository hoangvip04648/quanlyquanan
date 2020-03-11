using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin
{
    [Authorize(Roles ="ad")] //Bat buoc phai dang nhap voi vao duoc
    //[AllowAnonymous] khong can dang nhap van vao duoc
    public class QuanLyController : Controller
    {
        // GET: Admin/QuanLy
        public ActionResult Index()
        {
            BaoCaoModel baocao = new BaoCaoModel();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            //Lay so sp da ban
            int soSPDaBanHomNay = baocao.GetSoSPBanTaiQuanTrongNgay(day,month,year) + baocao.GetSoSPBanOnlineTrongNgay(day,month,year);
            ViewBag.SoSPDaBanHomNay = soSPDaBanHomNay;

            //Lay doanh thu 1 ngay
            ViewBag.TongThuHomNay = baocao.GetTongThu1Ngay(day, month, year);
            ViewBag.TongChiHomNay = baocao.GetTongChi1Ngay(day, month, year);

            int soDonChuaXacNhan = baocao.GetSoDDHChuaXacNhanTrongNgay(day, month, year);
            ViewBag.SoDonChuaXacNhan = soDonChuaXacNhan;

            ViewBag.SoTienThuTaiQuan = baocao.GetTongThuTaiQuan1Ngay(day, month, year);
            ViewBag.SoTienThuOnline = baocao.GetTongThuOnline1Ngay(day, month, year);
            ViewBag.SoTienThuKhac = baocao.GetTongThuKhac1Ngay(day, month, year);

            ViewBag.TongThuBuoiTrua = baocao.GetTongThuBuoiTrua1Ngay(day,month,year);
            ViewBag.TongThuBuoiToi = baocao.GetTongThuBuoiToi1Ngay(day, month, year);

            ViewBag.ChiNhapNguyenLieu = baocao.GetChiNhapNguyenLieu1Ngay(day, month, year);
            ViewBag.ChiNhapDungCu = baocao.GetChiNhapDungCu1Ngay(day, month, year);
            ViewBag.ChiNhapNuocGiaiKhat = baocao.GetChiNhapNuocGiaiKhat1Ngay(day, month, year);
            ViewBag.ChiTraLuongNhanVien = baocao.GetChiTraLuongNhanVien1Ngay(day, month, year);
            ViewBag.ChiKhac = baocao.GetChiKhac1Ngay(day, month, year);
            return View();
        }
    }
}