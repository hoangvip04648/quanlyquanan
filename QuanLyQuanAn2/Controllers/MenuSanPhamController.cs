using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    public class MenuSanPhamController : Controller
    {
        // GET: MenuBanHang
        public ActionResult Index()
        {
            var menu = new MenuMonAnModel();
            var model = menu.ListAll();
            bool isKHDaDangNhap = false;
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                if (AccountModel.GetLoaiUser(this.HttpContext.User.Identity.Name) == "kh")
                    isKHDaDangNhap = true;
            }
            ViewBag.IsKhachHangDaDangNhap = isKHDaDangNhap;
            return View(model);
        }

        // GET: MenuBanHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuBanHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuBanHang/Create
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

        // GET: MenuBanHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuBanHang/Edit/5
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

        // GET: MenuBanHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuBanHang/Delete/5
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
