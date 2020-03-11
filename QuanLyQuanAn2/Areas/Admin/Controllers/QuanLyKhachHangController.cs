using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles ="ad")]
    public class QuanLyKhachHangController : Controller
    {
        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index(int id,string q)
        {
            try
            {
                int pageLeghth = 10;
                //Model
                KhachHangModel khachhang = new KhachHangModel();
                List<KHACHHANG> listKhachHangPre = khachhang.GetAll();
                //search 
                List<KHACHHANG> listKhachHang;
                if (q != "" && q != null)
                {
                    listKhachHang = new List<KHACHHANG>();
                    foreach (var item in listKhachHangPre)
                    {
                        if (item.ACCOUNT.HOTEN.Contains(q)
                            || item.ACCOUNT.TAIKHOAN.Contains(q) || item.ACCOUNT.SDT.Contains(q))
                            listKhachHang.Add(item);
                        else if (item.ACCOUNT.NGAYSINH.HasValue)
                        {
                            if (item.ACCOUNT.NGAYSINH.Value.ToString("dd/MM/yyyy").Contains(q))
                                listKhachHang.Add(item);
                        }
                    }
                }
                else
                {
                    listKhachHang = listKhachHangPre;
                }



                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listKhachHang.Count)
                {
                    start = (listKhachHang.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listKhachHang.Count % pageLeghth - 1;
                }
                else if (end > listKhachHang.Count)
                {
                    end = listKhachHang.Count;
                }
                List<KHACHHANG> model = listKhachHang.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listKhachHang.Count % pageLeghth == 0 ? listKhachHang.Count / pageLeghth : listKhachHang.Count / pageLeghth + 1;
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

        // GET: Admin/QuanLyTaiKhoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyTaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLyTaiKhoan/Create
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

        // GET: Admin/QuanLyTaiKhoan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/QuanLyTaiKhoan/Edit/5
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

        // GET: Admin/QuanLyTaiKhoan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QuanLyTaiKhoan/Delete/5
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
