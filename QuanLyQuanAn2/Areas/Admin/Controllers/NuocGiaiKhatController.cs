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
    public class NuocGiaiKhatController : Controller
    {
        // GET: Admin/NuocGiaiKhat
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                NuocGiaiKhatModel nuocgiaikhat = new NuocGiaiKhatModel();
                List<NUOCGIAIKHAT> listNuocGiaiKhatPre = nuocgiaikhat.ListAll();
                //search 
                List<NUOCGIAIKHAT> listNuocGiaiKhat;
                if (q != "" && q != null)
                {
                    listNuocGiaiKhat = new List<NUOCGIAIKHAT>();
                    foreach (var item in listNuocGiaiKhatPre)
                    {
                        try
                        {
                            if (item.MANUOCGIAIKHAT.Contains(q) || item.GIABAN.ToString().Contains(q) || item.SOLUONGCON.ToString().Contains(q)
                            || item.MATHANG.TENMATHANG.Contains(q) || item.MATHANG.DONVITINH.TENDONVITINH.Contains(q))
                                listNuocGiaiKhat.Add(item);
                        }
                        catch { }
                        
                    }
                }
                else
                {
                    listNuocGiaiKhat = listNuocGiaiKhatPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listNuocGiaiKhat.Count)
                {
                    start = (listNuocGiaiKhat.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listNuocGiaiKhat.Count % pageLeghth - 1;
                }
                else if (end > listNuocGiaiKhat.Count)
                {
                    end = listNuocGiaiKhat.Count;
                }
                List<NUOCGIAIKHAT> model = listNuocGiaiKhat.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listNuocGiaiKhat.Count % pageLeghth == 0 ? listNuocGiaiKhat.Count / pageLeghth : listNuocGiaiKhat.Count / pageLeghth + 1;
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

        // GET: Admin/NuocGiaiKhat/Details/5
        public ActionResult Details(string maNuocGiaiKhat)
        {
            var iplNuocGiaiKhat = new NuocGiaiKhatModel();
            var model = iplNuocGiaiKhat.GetByMaNuocGiaiKhat(maNuocGiaiKhat);
            return View(model);
        }

        // GET: Admin/NuocGiaiKhat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NuocGiaiKhat/Create
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

        // GET: Admin/NuocGiaiKhat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NuocGiaiKhat/Edit/5
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

        // GET: Admin/NuocGiaiKhat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NuocGiaiKhat/Delete/5
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
