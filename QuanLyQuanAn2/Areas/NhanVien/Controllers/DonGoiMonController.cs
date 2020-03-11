using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace QuanLyQuanAn2.Areas.NhanVien.Controllers
{
    [Authorize(Roles ="nv")]
    public class DonGoiMonController : Controller
    {
        // GET: NhanVien/DonGoiMon
        public ActionResult Index()
        {
            //if (HttpContext.User.Identity.Name)
            var iplDonGoiMon = new DonGoiMonModel();
            var model = iplDonGoiMon.ListAllDonGoiMonChuaGiao();
            return View(model);
        }

        // GET: NhanVien/DonGoiMon/Details/5
        public ActionResult Details(string maso)
        {
            return View();
        }

        // GET: NhanVien/DonGoiMon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/DonGoiMon/Create
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

        // GET: NhanVien/DonGoiMon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NhanVien/DonGoiMon/Edit/5
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

        // GET: NhanVien/DonGoiMon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanVien/DonGoiMon/Delete/5
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
