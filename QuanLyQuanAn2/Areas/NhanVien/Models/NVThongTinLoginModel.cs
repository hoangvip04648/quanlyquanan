﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAn2.Areas.NhanVien.Models
{
    public class NVThongTinLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}