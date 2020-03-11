using Models;
using QuanLyQuanAn2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var menu = new MenuMonAnModel();
            var model = menu.ListConHang();
            bool isKHDaDangNhap=false;
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                if (AccountModel.GetLoaiUser(this.HttpContext.User.Identity.Name) == "kh")
                    isKHDaDangNhap= true;
            }
            ViewBag.IsKhachHangDaDangNhap = isKHDaDangNhap;
            return View(model);
        }
    }
}