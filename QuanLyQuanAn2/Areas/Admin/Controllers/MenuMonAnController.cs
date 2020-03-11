using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class MenuMonAnController : Controller
    {
        // GET: Admin/MenuBanHang
        public ActionResult Index()
        {
            var iplMonAn = new MenuMonAnModel();
            var model = iplMonAn.ListAll();
            return View(model);
        }

        // GET: Admin/MenuBanHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MenuBanHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuBanHang/Create
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

        // GET: Admin/MenuBanHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MenuBanHang/Edit/5
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

        // GET: Admin/MenuBanHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MenuBanHang/Delete/5
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
