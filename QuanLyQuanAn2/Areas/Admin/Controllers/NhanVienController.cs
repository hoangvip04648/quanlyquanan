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
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                NhanVienModel nhanvien = new NhanVienModel();
                List<NHANVIEN> listNhanVienPre = nhanvien.ListAll();
                //search 
                List<NHANVIEN> listNhanVien;
                if (q != "" && q != null)
                {
                    listNhanVien = new List<NHANVIEN>();
                    foreach (var item in listNhanVienPre)
                    {
                        try
                        {
                            if (item.MANHANVIEN.Contains(q) || item.ACCOUNT.HOTEN.ToString().Contains(q) || item.ACCOUNT.SDT.ToString().Contains(q)
                                || item.ACCOUNT.TAIKHOAN.Contains(q) || item.ACCOUNT.DIACHI.Contains(q) || item.NGAYKYHOPDONG.Value.ToString("dd/MM/yyyy").Contains(q)
                                || item.LUONG.ToString().Contains(q) )
                                listNhanVien.Add(item);
                        }
                        catch { }

                    }
                }
                else
                {
                    listNhanVien = listNhanVienPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listNhanVien.Count)
                {
                    start = (listNhanVien.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listNhanVien.Count % pageLeghth - 1;
                }
                else if (end > listNhanVien.Count)
                {
                    end = listNhanVien.Count;
                }
                List<NHANVIEN> model = listNhanVien.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listNhanVien.Count % pageLeghth == 0 ? listNhanVien.Count / pageLeghth : listNhanVien.Count / pageLeghth + 1;
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

        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(string maNhanVien)
        {
            var iplNhanVien = new NhanVienModel();
            var model = iplNhanVien.GetByMaNhanVien(maNhanVien);
            return View(model);
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien/Create
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

        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NhanVien/Edit/5
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

        // GET: Admin/NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhanVien/Delete/5
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
