using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class DonViTinhController : Controller
    {
        // GET: Admin/DonViThamSo
        public ActionResult Index()
        {
            var iplDonViTinh = new DonViTinhModel();
            var model = iplDonViTinh.ListAll();
            return View(model);
        }

        // GET: Admin/DonViThamSo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DonViThamSo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonViThamSo/Create
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

        // GET: Admin/DonViThamSo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DonViThamSo/Edit/5
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

        // GET: Admin/DonViThamSo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DonViThamSo/Delete/5
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
