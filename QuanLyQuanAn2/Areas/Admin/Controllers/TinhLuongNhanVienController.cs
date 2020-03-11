using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class TinhLuongNhanVienController : Controller
    {
        // GET: Admin/TinhLuongNhanVien
        
        public ActionResult Index()
        {
            var iplNhanVien = new NhanVienModel();
            var model = iplNhanVien.ListAllConLamViec();
            foreach(var item in model)
            {
                item.GetChamCongNhanVien();
            }
            return View(model);
        }


        // GET: Admin/TinhLuongNhanVien/Details/5
        public ActionResult Details(string maNhanVien, string trangThaiThanhToan)
        {
            var iplNhanVien = new NhanVienModel();
            var model = iplNhanVien.GetByMaNhanVien(maNhanVien);
            model.GetChamCongNhanVien();
            model.trangThaiThanhToan = trangThaiThanhToan;

            return View(model);
        }

        // GET: Admin/TinhLuongNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinhLuongNhanVien/Create
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

        // GET: Admin/TinhLuongNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/TinhLuongNhanVien/Edit/5
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

        // GET: Admin/TinhLuongNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/TinhLuongNhanVien/Delete/5
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
