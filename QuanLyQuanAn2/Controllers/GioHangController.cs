using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        [Authorize(Roles ="kh")]
        public ActionResult Index()
        {
            //Viewbag
            bool isKHDaDangNhap = false;
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                if (AccountModel.GetLoaiUser(this.HttpContext.User.Identity.Name) == "kh")
                    isKHDaDangNhap = true;
            }
            ViewBag.IsKhachHangDaDangNhap = isKHDaDangNhap;

            //Model
            var ctGioHang = new CT_GioHangModel();
            var model = ctGioHang.GetAllByTaiKhoan(this.HttpContext.User.Identity.Name);
            
            return View(model);
        }

        // GET: GioHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHang/Create
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

        // GET: GioHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHang/Edit/5
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

        // GET: GioHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GioHang/Delete/5
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
