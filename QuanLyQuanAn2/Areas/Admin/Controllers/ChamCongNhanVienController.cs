using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class ChamCongNhanVienController : Controller
    {
        // GET: Admin/ChamCongNhanVien
        public ActionResult Index()
        {
            var iplChamCongNhanVien = new ChamCongNhanVienModel();
            var model = iplChamCongNhanVien.List3NgayGanNhat();
            return View(model);
        }

        // GET: Admin/ChamCongNhanVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ChamCongNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChamCongNhanVien/Create
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

        // GET: Admin/ChamCongNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ChamCongNhanVien/Edit/5
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

        // GET: Admin/ChamCongNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ChamCongNhanVien/Delete/5
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
