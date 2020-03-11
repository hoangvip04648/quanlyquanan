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
    public class MonAnController : Controller
    {
        // GET: Admin/MonAn
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                MonAnModel monan = new MonAnModel();
                List<MONAN> listMonAnPre = monan.ListAll();
                //search 
                List<MONAN> listMonAn;
                if (q != "" && q != null)
                {
                    listMonAn = new List<MONAN>();
                    foreach (var item in listMonAnPre)
                    {
                        try
                        {
                            if (item.MAMONAN.Contains(q) || item.GIABAN.ToString().Contains(q)
                            || item.MATHANG.TENMATHANG.Contains(q))
                                listMonAn.Add(item);
                        }
                        catch { }

                    }
                }
                else
                {
                    listMonAn = listMonAnPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listMonAn.Count)
                {
                    start = (listMonAn.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listMonAn.Count % pageLeghth - 1;
                }
                else if (end > listMonAn.Count)
                {
                    end = listMonAn.Count;
                }
                List<MONAN> model = listMonAn.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listMonAn.Count % pageLeghth == 0 ? listMonAn.Count / pageLeghth : listMonAn.Count / pageLeghth + 1;
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

        // GET: Admin/MonAn/Details/5
        public ActionResult Details(string maMonAn)
        {
            var iplMonAn = new MonAnModel();
            var model = iplMonAn.GetByMaMonAn(maMonAn);
            return View(model);
        }

        // GET: Admin/MonAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonAn/Create
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

        // GET: Admin/MonAn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MonAn/Edit/5
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

        // GET: Admin/MonAn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MonAn/Delete/5
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
