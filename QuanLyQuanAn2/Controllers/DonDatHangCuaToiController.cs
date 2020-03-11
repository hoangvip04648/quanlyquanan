using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    [Authorize(Roles ="kh")]
    public class DonDatHangCuaToiController : Controller
    {
        // GET: DonDatHangCuaToi
        
        public ActionResult Index(int id) //ID la page
        {
            int pageLeghth = 5;

            //Viewbag
            bool isKHDaDangNhap = false;
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                if (AccountModel.GetLoaiUser(this.HttpContext.User.Identity.Name) == "kh")
                    isKHDaDangNhap = true;
            }
            ViewBag.IsKhachHangDaDangNhap = isKHDaDangNhap;

            //Model
            DonDatHangModel dondathang = new DonDatHangModel();
            string userID = new AccountModel().GetID(System.Web.HttpContext.Current.User.Identity.Name);
            List<DONDATHANG> listDonDatHang= dondathang.GetByMaKhachHang(userID);

            //Chia theo page
            int start = pageLeghth * (id - 1) + 1;
            int end = pageLeghth * id;
            if (start > listDonDatHang.Count)
            {
                start = (listDonDatHang.Count / pageLeghth)*pageLeghth+1;
                end = start + listDonDatHang.Count % pageLeghth-1;
            }
            else if(end>listDonDatHang.Count)
            {
                end = listDonDatHang.Count;
            }
            List<DONDATHANG> model = listDonDatHang.GetRange(start - 1, end - (start - 1));
            int SoLuongPage= listDonDatHang.Count % 5 == 0 ? listDonDatHang.Count / 5 : listDonDatHang.Count / 5 + 1;
            //int SoLuongPage = 10;
            ViewBag.SoLuongPage = SoLuongPage;
            
            ViewBag.CurrentPage = id<SoLuongPage?id:SoLuongPage;
            return View(model);
        }

        // GET: DonDatHangCuaToi/Page/5
        public ActionResult Page(int id)
        {

            return View();
        }

        // GET: DonDatHangCuaToi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonDatHangCuaToi/Create
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

        // GET: DonDatHangCuaToi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonDatHangCuaToi/Edit/5
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

        // GET: DonDatHangCuaToi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonDatHangCuaToi/Delete/5
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
