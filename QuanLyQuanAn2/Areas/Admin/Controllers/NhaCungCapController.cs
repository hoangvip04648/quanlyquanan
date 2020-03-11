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
    public class NhaCungCapController : Controller
    {
        // GET: Admin/NhaCungCap
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                NhaCungCapModel nhacungcap = new NhaCungCapModel();
                List<NHACUNGCAP> listNhaCungCapPre = nhacungcap.ListAll();
                //search 
                List<NHACUNGCAP> listNhaCungCap;
                if (q != "" && q != null)
                {
                    listNhaCungCap = new List<NHACUNGCAP>();
                    foreach (var item in listNhaCungCapPre)
                    {
                        try
                        {
                            if (item.MANHACUNGCAP.Contains(q) || item.SODIENTHOAI.Contains(q) || item.DIACHI.Contains(q) || item.MOTA.Contains(q)
                            || item.TENNHACUNGCAP.Contains(q) || item.NGUOIDAIDIEN.Contains(q) || item.LOAIMATHANG.TENLOAIMATHANG.Contains(q))
                                listNhaCungCap.Add(item);
                        }
                        catch { }
                    }
                }
                else
                {
                    listNhaCungCap = listNhaCungCapPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listNhaCungCap.Count)
                {
                    start = (listNhaCungCap.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listNhaCungCap.Count % pageLeghth - 1;
                }
                else if (end > listNhaCungCap.Count)
                {
                    end = listNhaCungCap.Count;
                }
                List<NHACUNGCAP> model = listNhaCungCap.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listNhaCungCap.Count % pageLeghth == 0 ? listNhaCungCap.Count / pageLeghth : listNhaCungCap.Count / pageLeghth + 1;
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

        // GET: Admin/NhaCungCap/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaCungCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Create
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

        // GET: Admin/NhaCungCap/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Edit/5
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

        // GET: Admin/NhaCungCap/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Delete/5
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
