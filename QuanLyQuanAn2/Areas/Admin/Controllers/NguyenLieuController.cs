using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class NguyenLieuController : Controller
    {
        // GET: Admin/NguyenLieu
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                NguyenLieuModel nguyenlieu = new NguyenLieuModel();
                List<NGUYENLIEU> listNguyenLieuPre = nguyenlieu.ListAll();
                //search 
                List<NGUYENLIEU> listNguyenLieu;
                if (q != "" && q != null)
                {
                    listNguyenLieu = new List<NGUYENLIEU>();
                    foreach (var item in listNguyenLieuPre)
                    {
                        if (item.MANGUYENLIEU.Contains(q)
                            || item.MATHANG.TENMATHANG.Contains(q) || item.MATHANG.DONVITINH.TENDONVITINH.Contains(q))
                            listNguyenLieu.Add(item);
                    }
                }
                else
                {
                    listNguyenLieu = listNguyenLieuPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listNguyenLieu.Count)
                {
                    start = (listNguyenLieu.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listNguyenLieu.Count % pageLeghth - 1;
                }
                else if (end > listNguyenLieu.Count)
                {
                    end = listNguyenLieu.Count;
                }
                List<NGUYENLIEU> model = listNguyenLieu.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listNguyenLieu.Count % pageLeghth == 0 ? listNguyenLieu.Count / pageLeghth : listNguyenLieu.Count / pageLeghth + 1;
                //int SoLuongPage = 10;
                ViewBag.SoLuongPage = SoLuongPage;

                ViewBag.CurrentPage = id < SoLuongPage ? id : SoLuongPage;
                ViewBag.Query = q;
                return View(model);

            }
            catch
            {
                return null;
            }
            
            
        }

        // GET: Admin/NguyenLieu/Details/5
        public ActionResult Details(string maNguyenLieu)
        {
            var iplNguyenLieu = new NguyenLieuModel();
            var model = iplNguyenLieu.GetByMaNguyenLieu(maNguyenLieu);
            return View(model);
        }

        // GET: Admin/NguyenLieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguyenLieu/Create
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

        // GET: Admin/NguyenLieu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NguyenLieu/Edit/5
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

        // GET: Admin/NguyenLieu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NguyenLieu/Delete/5
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
