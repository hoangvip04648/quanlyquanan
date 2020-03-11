using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class NhapMatHangController : Controller
    {
        // GET: /Admin/NhapMatHang/Index?ngayNhap=20192111&maLoaiMatHang=LH001
        public ActionResult Index()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            try
            {
                int ngay = dateTime.Day;
                int thang = dateTime.Month;
                int nam = dateTime.Year;

                var iplNhapMatHang = new NhapMatHangModel();
                var model = iplNhapMatHang.ListByDayAndType(ngay, thang, nam, "LH001");
                NHAPMATHANG.DayTmp = ngay;
                NHAPMATHANG.MonthTmp = thang;
                NHAPMATHANG.YearTmp = nam;
                NHAPMATHANG.MaLMHTmp = "LH001";
                NHAPMATHANG.dateTmp = new DateTime(nam, thang, ngay);
                return View(model);
            }
            catch
            {
                return null;
            }
        }

        public ActionResult Index2(string ngayNhap, string thangNhap,string namNhap, string maLoaiMatHang)
        {
            try
            {
                int ngay = Int32.Parse(ngayNhap);
                int thang = Int32.Parse(thangNhap);
                int nam = Int32.Parse(namNhap);

                var iplNhapMatHang = new NhapMatHangModel();
                var model = iplNhapMatHang.ListByDayAndType(ngay,thang,nam, maLoaiMatHang);
                NHAPMATHANG.DayTmp = ngay;
                NHAPMATHANG.MonthTmp = thang;
                NHAPMATHANG.YearTmp = nam;
                NHAPMATHANG.MaLMHTmp = maLoaiMatHang;
                NHAPMATHANG.dateTmp = new DateTime(nam,thang,ngay);
                return View(model);
            }
            catch {
                return null;
            }
        }
        // GET: Admin/NhapMatHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhapMatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhapMatHang/Create
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

        // GET: Admin/NhapMatHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NhapMatHang/Edit/5
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

        // GET: Admin/NhapMatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhapMatHang/Delete/5
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
