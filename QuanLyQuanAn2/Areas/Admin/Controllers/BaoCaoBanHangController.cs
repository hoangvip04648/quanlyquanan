using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class BaoCaoBanHangController : Controller
    {
        // GET: Admin/BaoCaoBanHang
        public ActionResult Index(string thang, string nam)
        {
            int month;
            int year;
            try
            {
                month = Int32.Parse(thang);
                year = Int32.Parse(nam);
            }
            catch { return null; }
            List<int> dataSanPhamDaBanOnline = new List<int>();//Lay du lieu tung ngay
            List<int> dataSanPhamDaBanTaiQuan = new List<int>();//Lay du lieu tung ngay
            List<int> dataTongSanPhamDaBan = new List<int>();//Lay du lieu tung ngay
            BaoCaoModel baocao = new BaoCaoModel();
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                int soSPBanOnline =  baocao.GetSoSPBanOnlineTrongNgay(i, month, year);
                int soSPBanTaiQuan = baocao.GetSoSPBanTaiQuanTrongNgay(i, month, year);
                dataSanPhamDaBanOnline.Add(soSPBanOnline);
                dataSanPhamDaBanTaiQuan.Add(soSPBanTaiQuan);
                dataTongSanPhamDaBan.Add(soSPBanOnline + soSPBanTaiQuan);
            }
            ViewBag.BaoCaoSoSanPhamBanOnlineCuaThang = dataSanPhamDaBanOnline;
            ViewBag.BaoCaoSoSanPhamBanTaiQuanCuaThang = dataSanPhamDaBanTaiQuan;
            ViewBag.BaoCaoSoSanPhamDaBanCuaThang = dataTongSanPhamDaBan;
            ViewBag.Thang = thang;
            ViewBag.Nam = nam;
            //LAY so ngay can hien thi
            int soNgayCanHienThi = 1;
            if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                soNgayCanHienThi = DateTime.Now.Day;
            else
                soNgayCanHienThi = DateTime.DaysInMonth(year, month);
            ViewBag.SoNgayCanHienThi = soNgayCanHienThi;

            //Lay BXH MONAN TRONG THANG
            //ViewBag.BXHMONAN = baocao.GetBXHMONANTrongThang(month,year);
            //ViewBag.BXHNGK = baocao.GetBXHNGKTrongThang(month, year);
            //LAY BXH NUOCGIAIKHAT TRONG THANG
            return View();
        }

        // GET: Admin/BaoCaoBanHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BaoCaoBanHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaoCaoBanHang/Create
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

        // GET: Admin/BaoCaoBanHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoBanHang/Edit/5
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

        // GET: Admin/BaoCaoBanHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BaoCaoBanHang/Delete/5
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
