using Models;
using Models.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.NhanVien.Controllers
{
    [Authorize(Roles = "nv")]
    public class NVCTDonGoiMonApiController : ApiController
    {
        // GET: api/NVCTDonGoiMonApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NVCTDonGoiMonApi/5
        public string Get(int id)
        {
            
            return "xin chao";
        }

        // POST: api/NVCTDonGoiMonApi
        public string Post(string maDon, string maMatHang, string soLuong, string donGia)
        {
            string[] lMaMatHang = maMatHang.Split('-');
            string[] lSoLuong = soLuong.Split('-');
            string[] lDonGia = donGia.Split('-');
            for(int i = 1; i < lMaMatHang.Length; i++)
            {
                CT_DonGoiMonModel.InsertCtDonGoiMon(maDon, lMaMatHang[i], lSoLuong[i], lDonGia[i]);
                try
                {
                    if (lMaMatHang[i].StartsWith("NC"))//Neu la nuoc giai khat thi cap nhat so luong
                    {
                        NuocGiaiKhatModel.UpdateThemSoLuongNuocGiaiKhat(lMaMatHang[i], "-" + lSoLuong[i]);
                    }
                }
                catch { }

            }
            //if (!CT_DonGoiMonModel.InsertCtDonGoiMon(maDon, maMatHang, soLuong, donGia))
            //   return "Thêm món " + maMatHang + " vào dữ liệu thất bại!";
            //else return "Thêm thành công!";
            return "";
        }
        
        
        // PUT: api/NVCTDonGoiMonApi/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/NVCTDonGoiMonApi/5
        public void Delete(int id)
        {
        }
    }
}
