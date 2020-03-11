using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class BaoCaoThuChiController : Controller
    {
        // GET: Admin/BaoCaoThuChi
        public ActionResult Index(string thang,string nam)
        {
            int month;
            int year;
            try
            {
                month = Int32.Parse(thang);
                year = Int32.Parse(nam);
            }
            catch { return null; }

            //Viewbag
            List<int> dataChiThang = new List<int>();
            List<int> dataThuThang = new List<int>();
            List<int> dataDoanhThuThang = new List<int>();
            //Lay du lieu tung ngay
            BaoCaoModel baocao = new BaoCaoModel();
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                int chi = -baocao.GetTongChi1Ngay(i, month, year);
                int thu = baocao.GetTongThu1Ngay(i, month, year);
                dataChiThang.Add(chi);
                dataThuThang.Add(thu);
                dataDoanhThuThang.Add(thu + chi);
            }
            ViewBag.BaoCaoChiThang = dataChiThang;
            ViewBag.BaoCaoThuThang = dataThuThang;
            ViewBag.BaoCaoDoanhThuThang = dataDoanhThuThang;

            ViewBag.Thang = thang;
            ViewBag.Nam = nam;
            //LAY so ngay can hien thi
            int soNgayCanHienThi = 1;
            if (month == DateTime.Now.Month&&year==DateTime.Now.Year)
                soNgayCanHienThi = DateTime.Now.Day;
            else
                soNgayCanHienThi = DateTime.DaysInMonth(year, month);
            ViewBag.SoNgayCanHienThi = soNgayCanHienThi;


            //Lay bao cao tong doanh thu
            ViewBag.ThuBanHangTaiQuan = baocao.GetTongThuBanHangTaiQuan1Thang(month,year);
            ViewBag.ThuBanHangTrenWeb = baocao.GetTongThuBanHangTrenWeb1Thang(month,year);
            ViewBag.ThuKhac = baocao.GetTongThuKhac(month, year);

            ViewBag.ChiNhapNguyenLieu = baocao.GetTongChiNhapNguyenLieu(month, year);
            ViewBag.ChiNhapDungCu = baocao.GetTongChiNhapDungCu(month, year);
            ViewBag.ChiNhapNuocGiaiKhat = baocao.GetTongChiNhapNuocGiaiKhat(month, year);
            ViewBag.ChiTraLuongNhanVien = baocao.GetTongChiTraLuongNhanVien(month, year);
            ViewBag.ChiKhac = baocao.GetTongChiKhac(month, year);
            return View();
        }

        // GET: Admin/BaoCaoThuChi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BaoCaoThuChi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaoCaoThuChi/Create
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

        // GET: Admin/BaoCaoThuChi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoThuChi/Edit/5
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

        // GET: Admin/BaoCaoThuChi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoThuChi/Delete/5
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
