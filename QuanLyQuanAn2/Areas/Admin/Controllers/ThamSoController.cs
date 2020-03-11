using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class ThamSoController : Controller
    {
        // GET: Admin/ThamSo
        public ActionResult Index()
        {
            var iplThamSo = new ThamSoModel();
            var model = iplThamSo.ListAll();
            return View(model);
        }

        // GET: Admin/ThamSo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ThamSo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThamSo/Create
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

        // GET: Admin/ThamSo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ThamSo/Edit/5
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

        // GET: Admin/ThamSo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ThamSo/Delete/5
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
