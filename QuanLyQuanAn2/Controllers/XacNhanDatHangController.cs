using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    [Authorize(Roles = "kh")]
    public class XacNhanDatHangController : Controller
    {
        // GET: XacNhanDatHang
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
            try
            {
                model[0].GetKhachHang();
            }
            catch {
                return null;
            }
            int TongTien = 0;
            foreach(var ct in model)
            {
                if (ct.MAMATHANG.StartsWith("NC"))
                    TongTien += ct.SOLUONG.Value * ct.MATHANG.NUOCGIAIKHAT.GIABAN.Value;
                else if (ct.MAMATHANG.StartsWith("MA"))
                    TongTien += ct.SOLUONG.Value * ct.MATHANG.MONAN.GIABAN.Value;
            }
            if (TongTien < new ThamSoModel().GetThamSoByTen("SoTienDonDatHangToiThieu"))
                return null;
            return View(model);
        }

        // GET: XacNhanDatHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: XacNhanDatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XacNhanDatHang/Create
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

        // GET: XacNhanDatHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: XacNhanDatHang/Edit/5
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

        // GET: XacNhanDatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: XacNhanDatHang/Delete/5
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
