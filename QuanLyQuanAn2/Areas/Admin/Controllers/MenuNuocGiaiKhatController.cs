﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class MenuNuocGiaiKhatController : Controller
    {
        // GET: Admin/MenuNuocGiaiKhat
        public ActionResult Index()
        {
            var iplNuocGiaiKhat = new MenuNuocGiaiKhatModel();
            var model = iplNuocGiaiKhat.ListAll();
            return View(model);
        }

        // GET: Admin/MenuNuocGiaiKhat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MenuNuocGiaiKhat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuNuocGiaiKhat/Create
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

        // GET: Admin/MenuNuocGiaiKhat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MenuNuocGiaiKhat/Edit/5
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

        // GET: Admin/MenuNuocGiaiKhat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MenuNuocGiaiKhat/Delete/5
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