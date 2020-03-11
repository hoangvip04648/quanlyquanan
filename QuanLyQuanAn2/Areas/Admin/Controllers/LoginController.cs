using Models;
using QuanLyQuanAn2.Areas.Admin.Code;
using QuanLyQuanAn2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            //if(???)
                return View();
            //else return RedirectToAction("Index", "QuanLy");
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Lenh nay de no validate token tren sever vs tren client
        public ActionResult Index(ThongTinLoginModel model)
        {
            //var result = new AccountModel().Login(model.UserName,model.Password);
            //if (result == true && ModelState.IsValid)
            if (Membership.ValidateUser(model.UserName,model.Password) == true && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName=model.UserName});
                FormsAuthentication.SetAuthCookie(model.UserName,model.RememberMe);

                //Quay ve trang quan ly khi dang nhap thanh cong
                return RedirectToAction("Index", "QuanLy", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}