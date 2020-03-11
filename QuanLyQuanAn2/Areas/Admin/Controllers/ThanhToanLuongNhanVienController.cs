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
    public class ThanhToanLuongNhanVienController : Controller
    {
        // GET: Admin/ThanhToanLuongNhanVien
        public ActionResult Index(int id, string q)
        {
            try
            {
                //
                int pageLeghth = 10;
                //Model
                ThanhToanLuongNhanVienModel ttluongnv = new ThanhToanLuongNhanVienModel();
                List<THANHTOANLUONGNHANVIEN> listThanhToanLuongNhanVienPre = ttluongnv.ListAll();
                foreach (var item in listThanhToanLuongNhanVienPre)
                {
                    item.GetAllRefInfo();
                }
                //search 
                List<THANHTOANLUONGNHANVIEN> listThanhToanLuongNhanVien;
                if (q != "" && q != null)
                {
                    listThanhToanLuongNhanVien = new List<THANHTOANLUONGNHANVIEN>();
                    foreach (var item in listThanhToanLuongNhanVienPre)
                    {
                        try
                        {
                            if (item.MANHANVIEN.Contains(q) || item.NHANVIEN.ACCOUNT.HOTEN.Contains(q) || item.TONGTHOIGIANLAM.ToString().Contains(q) || item.TONGLUONG.ToString().Contains(q)
                            || item.KHOANGKHAC.ToString().Contains(q) || item.GHICHU.Contains(q) || item.NGAYTHANHTOAN.ToString("dd/MM/yyyy").Contains(q))
                                listThanhToanLuongNhanVien.Add(item);
                        }
                        catch { }
                    }
                }
                else
                {
                    listThanhToanLuongNhanVien = listThanhToanLuongNhanVienPre;
                }

                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listThanhToanLuongNhanVien.Count)
                {
                    start = (listThanhToanLuongNhanVien.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listThanhToanLuongNhanVien.Count % pageLeghth - 1;
                }
                else if (end > listThanhToanLuongNhanVien.Count)
                {
                    end = listThanhToanLuongNhanVien.Count;
                }
                List<THANHTOANLUONGNHANVIEN> model = listThanhToanLuongNhanVien.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listThanhToanLuongNhanVien.Count % pageLeghth == 0 ? listThanhToanLuongNhanVien.Count / pageLeghth : listThanhToanLuongNhanVien.Count / pageLeghth + 1;
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

        // GET: Admin/ThanhToanLuongNhanVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ThanhToanLuongNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThanhToanLuongNhanVien/Create
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

        // GET: Admin/ThanhToanLuongNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ThanhToanLuongNhanVien/Edit/5
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

        // GET: Admin/ThanhToanLuongNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ThanhToanLuongNhanVien/Delete/5
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
