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
    public class DungCuController : Controller
    {
        // GET: Admin/DungCu
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                DungCuModel dungcu = new DungCuModel();
                List<DUNGCU> listDungCuPre = dungcu.ListAll();
                //search 
                List<DUNGCU> listDungCu;
                if (q != "" && q != null)
                {
                    listDungCu = new List<DUNGCU>();
                    foreach (var item in listDungCuPre)
                    {
                        if (item.MADUNGCU.Contains(q)
                            || item.MATHANG.TENMATHANG.Contains(q) || item.MATHANG.DONVITINH.TENDONVITINH.Contains(q))
                            listDungCu.Add(item);
                    }
                }
                else
                {
                    listDungCu = listDungCuPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listDungCu.Count)
                {
                    start = (listDungCu.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listDungCu.Count % pageLeghth - 1;
                }
                else if (end > listDungCu.Count)
                {
                    end = listDungCu.Count;
                }
                List<DUNGCU> model = listDungCu.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listDungCu.Count % pageLeghth == 0 ? listDungCu.Count / pageLeghth : listDungCu.Count / pageLeghth + 1;
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

        // GET: Admin/DungCu/Details/5
        public ActionResult Details(string maDungCu)
        {
            var iplDungCu = new DungCuModel();
            var model = iplDungCu.GetByMaDungCu(maDungCu);
            return View(model);
        }

        // GET: Admin/DungCu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DungCu/Create
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

        // GET: Admin/DungCu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DungCu/Edit/5
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

        // GET: Admin/DungCu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DungCu/Delete/5
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
