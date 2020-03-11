using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    public class BaoCaoHangNgayController : Controller
    {
        // GET: Admin/BaoCaoHangNgay
        public ActionResult Index(string ngay, string thang, string nam)
        {
            int day;
            int month;
            int year;
            try
            {
                day = Int32.Parse(ngay);
                month = Int32.Parse(thang);
                year = Int32.Parse(nam);
            }
            catch { return null; }

            BaoCaoModel baocao = new BaoCaoModel();
            //Lay so sp da ban
            int soSPDaBanHomNay = baocao.GetSoSPBanTaiQuanTrongNgay(day, month, year) + baocao.GetSoSPBanOnlineTrongNgay(day, month, year);
            ViewBag.SoSPDaBanHomNay = soSPDaBanHomNay;

            //Lay doanh thu 1 ngay
            ViewBag.TongThuHomNay = baocao.GetTongThu1Ngay(day, month, year);
            ViewBag.TongChiHomNay = baocao.GetTongChi1Ngay(day, month, year);

            int soDonChuaXacNhan = baocao.GetSoDDHChuaXacNhanTrongNgay(day, month, year);
            ViewBag.SoDonChuaXacNhan = soDonChuaXacNhan;

            ViewBag.SoTienThuTaiQuan = baocao.GetTongThuTaiQuan1Ngay(day, month, year);
            ViewBag.SoTienThuOnline = baocao.GetTongThuOnline1Ngay(day, month, year);
            ViewBag.SoTienThuKhac = baocao.GetTongThuKhac1Ngay(day, month, year);

            ViewBag.TongThuBuoiTrua = baocao.GetTongThuBuoiTrua1Ngay(day, month, year);
            ViewBag.TongThuBuoiToi = baocao.GetTongThuBuoiToi1Ngay(day, month, year);

            ViewBag.ChiNhapNguyenLieu = baocao.GetChiNhapNguyenLieu1Ngay(day, month, year);
            ViewBag.ChiNhapDungCu = baocao.GetChiNhapDungCu1Ngay(day, month, year);
            ViewBag.ChiNhapNuocGiaiKhat = baocao.GetChiNhapNuocGiaiKhat1Ngay(day, month, year);
            ViewBag.ChiTraLuongNhanVien = baocao.GetChiTraLuongNhanVien1Ngay(day, month, year);
            ViewBag.ChiKhac = baocao.GetChiKhac1Ngay(day, month, year);
            ViewBag.Ngay = ngay;
            ViewBag.Thang = thang;
            ViewBag.Nam = nam;
            return View();
        }

        // GET: Admin/BaoCaoHangNgay/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BaoCaoHangNgay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaoCaoHangNgay/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BaoCaoHangNgay/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoHangNgay/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BaoCaoHangNgay/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoHangNgay/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
