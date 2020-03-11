using Models;
using QuanLyQuanAn2.Areas.Admin.Code;
using QuanLyQuanAn2.Areas.Admin.Models;
using QuanLyQuanAn2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyQuanAn2.Controllers
{
    public class DangNhapController : Controller
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
                string loaiUser = AccountModel.GetLoaiUser(model.UserName);
                
                if (loaiUser == "ad")
                    //Quay ve trang quan ly khi dang nhap thanh cong
                    return RedirectToAction("Index", "QuanLy", new { area = "Admin" });
                else if (loaiUser == "nv")
                    return RedirectToAction("Index", "DonGoiMon", new { area = "NhanVien" });
                else
                    return RedirectToAction("Index","Home");
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
            return RedirectToAction("Index", "DangNhap");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ThongTinRegisterModel model)
        {
            if(model.HoTen==null||model.UserName==null||model.Password==null||model.RePassword==null)
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin!");
            }
            else if (model.HoTen.Length<5)
            {
                ModelState.AddModelError("", "Vui lòng nhập chính xác họ tên!");
            }
            else if (model.UserName.Length<13||!model.UserName.Contains("@")|| !model.UserName.Contains("mail")|| !model.UserName.Contains("."))
            {
                ModelState.AddModelError("", "Vui lòng nhập đúng email!");
            }
            else if (model.Password.Length<6)
            {
                ModelState.AddModelError("", "Mật khẩu tối thiểu 6 ký tự!");
            }
            else if (model.Password != model.RePassword)
            {
                ModelState.AddModelError("", "Mật khẩu nhập lại không khớp!");
            }
            else
            if (new AccountModel().Register(model.HoTen,model.UserName, model.Password) == true)
            {
                if (Membership.ValidateUser(model.UserName, model.Password) == true && ModelState.IsValid)
                {
                    //SessionHelper.SetSession(new UserSession() { UserName=model.UserName});
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    string loaiUser = AccountModel.GetLoaiUser(model.UserName);

                    if (loaiUser == "ad")
                        //Quay ve trang quan ly khi dang nhap thanh cong
                        return RedirectToAction("Index", "QuanLy", new { area = "Admin" });
                    else if (loaiUser == "nv")
                        return RedirectToAction("Index", "DonGoiMon", new { area = "NhanVien" });
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo tài khoản thành công!");
                    return RedirectToAction("Index", "DangNhap");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tạo tài khoản thất bại!");
            }
            return View(model);
            
        }

    }
}