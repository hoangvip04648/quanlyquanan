using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class DonDatHangController : Controller
    {
        // GET: Admin/QLDonDatHang
        public ActionResult Index(int id,string ngay,string thang,string nam,string q)
        {
            try
            {
                int pageLeghth = 10;
                int day, month, year;
                try
                {
                    day = Int32.Parse(ngay);
                    month = Int32.Parse(thang);
                    year = Int32.Parse(nam);
                }
                catch { return null; }
                var iplDonDatHang = new DonDatHangModel();
                var listDonDatHangPre = iplDonDatHang.ListByDay(day, month, year);
                //var userName = this.HttpContext.User.Identity.Name;
                //var isXacThuc= this.HttpContext.User.Identity.IsAuthenticated;


                //Phan trang
                //search 
                List<DONDATHANG> listDonDatHang;
                if (q != "" && q != null)
                {
                    listDonDatHang = new List<DONDATHANG>();
                    foreach (var item in listDonDatHangPre)
                    {
                        if (item.KHACHHANG.ACCOUNT.HOTEN.Contains(q) || item.DIACHIGIAOHANG.Contains(q) || item.GHICHU.Contains(q) || item.GHICHUCUANGUOIBAN.Contains(q)
                            || item.KHACHHANG.ACCOUNT.TAIKHOAN.Contains(q) || item.KHACHHANG.ACCOUNT.SDT.Contains(q))
                            listDonDatHang.Add(item);

                    }
                }
                else
                {
                    listDonDatHang = listDonDatHangPre;
                }



                //Chia theo page
                int start = pageLeghth * (id - 1) + 1;
                int end = pageLeghth * id;
                if (start > listDonDatHang.Count)
                {
                    start = (listDonDatHang.Count / pageLeghth) * pageLeghth + 1;
                    end = start + listDonDatHang.Count % pageLeghth - 1;
                }
                else if (end > listDonDatHang.Count)
                {
                    end = listDonDatHang.Count;
                }
                List<DONDATHANG> model = listDonDatHang.GetRange(start - 1, end - (start - 1));
                int SoLuongPage = listDonDatHang.Count % pageLeghth == 0 ? listDonDatHang.Count / pageLeghth : listDonDatHang.Count / pageLeghth + 1;
                //int SoLuongPage = 10;
                ViewBag.SoLuongPage = SoLuongPage;

                ViewBag.CurrentPage = id < SoLuongPage ? id : SoLuongPage;
                
                ViewBag.Ngay = ngay;
                ViewBag.Thang = thang;
                ViewBag.Nam = nam;
                if (q != null)
                    ViewBag.Query = q;
                else ViewBag.Query = "";


                if (ViewBag.CurrentPage == 0)
                {
                    ViewBag.CurrentPage = 1;
                }
                if (ViewBag.SoLuongPage == 0)
                {
                    ViewBag.SoLuongPage = 1;
                }

                return View(model);
            }
            catch
            {
                return null;
            }
        }

        // GET: Admin/QLDonDatHang/Details/DH000001
        public ActionResult Details(string maDon)
        {
            var iplDonDatHang = new DonDatHangModel();
            var model = iplDonDatHang.GetByMaDon(maDon);
            return View(model);
        }

        // GET: Admin/QLDonDatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLDonDatHang/Create
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

        // GET: Admin/QLDonDatHang/Edit/5
        public ActionResult Edit(string maDon)
        {
            var iplDonDatHang = new DonDatHangModel();
            var model = iplDonDatHang.GetByMaDon(maDon);
            return View(model);
        }

        // POST: Admin/QLDonDatHang/Edit/5
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

        [HttpPost]
        public ActionResult Edit(string MaDonHang,int TinhTrang,string GhiChuNguoiBan, string Redirect)
        {
            try
            {
                // TODO: Add update logic here
                Debug.WriteLine("Edit thanh cong "+MaDonHang+" "+TinhTrang+" "+GhiChuNguoiBan);
                //return RedirectToAction("Index");
                return RedirectToAction(Redirect);
            }
            catch
            {
                return View();
            }
        }



        // GET: Admin/QLDonDatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QLDonDatHang/Delete/5
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
