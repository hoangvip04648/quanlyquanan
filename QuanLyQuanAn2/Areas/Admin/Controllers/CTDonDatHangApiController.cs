using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class CTDonDatHangApiController : ApiController
    {
        // GET: api/CTDonDatHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CTDonDatHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CTDonDatHangApi
        public string Post(string maDon, string maMatHang, string soLuong)
        {
            if (CT_DonDatHangModel.InsertCTDonDatHang(maDon, maMatHang, soLuong))
                return "Thêm thành công!";
            else
                return "Thêm thất bại!";
        }

        // PUT: api/CTDonDatHangApi/5
        public string Put(string maCTDDH,string maMatHang,string soLuong)
        {
            if (CT_DonDatHangModel.UpdateCTDonDatHang(maCTDDH, maMatHang, soLuong))
                return "Sửa đổi thành công!";
            else
                return "Sửa đổi thất bại!";
        }

        // DELETE: api/CTDonDatHangApi/5
        public string Delete(string maCTDDH)
        {
            if (CT_DonDatHangModel.DeleteCTDonDatHang(maCTDDH))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}
