using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    [Authorize(Roles ="kh")]
    public class ThongTinCaNhanController : Controller
    {
        // GET: ThongTinCaNhan

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
            var khachhangipl = new KhachHangModel();
            var maKH = new AccountModel().GetID(HttpContext.User.Identity.Name);
            var model = khachhangipl.GetByMaKhachHang(maKH);
            return View(model);
        }

        // GET: ThongTinCaNhan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThongTinCaNhan/Create
        public ActionResult EditPassword()
        {
            //Viewbag
            bool isKHDaDangNhap = false;
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                if (AccountModel.GetLoaiUser(this.HttpContext.User.Identity.Name) == "kh")
                    isKHDaDangNhap = true;
            }
            ViewBag.IsKhachHangDaDangNhap = isKHDaDangNhap;
            ViewBag.TenDangNhap = this.HttpContext.User.Identity.Name;
            return View();
        }

        // POST: ThongTinCaNhan/Create
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

        // GET: ThongTinCaNhan/Edit/5
        public ActionResult Edit()
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
            var khachhangipl = new KhachHangModel();
            var maKH = new AccountModel().GetID(HttpContext.User.Identity.Name);
            var model = khachhangipl.GetByMaKhachHang(maKH);
            return View(model);
        }

        // POST: ThongTinCaNhan/Edit/5
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

        // GET: ThongTinCaNhan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThongTinCaNhan/Delete/5
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
