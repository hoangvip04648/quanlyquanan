using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.NhanVien.Controllers
{
    [Authorize(Roles = "nv")]
    public class NVDonGoiMonApiController : ApiController
    {
        // GET: api/NVDonGoiMonApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NVDonGoiMonApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NVDonGoiMonApi
        public string Post(string ghiChu, string ban)
        {
            string ngay = DateTime.Now.ToString("yyyy/MM/dd");
            string thoiGian = DateTime.Now.ToString("hh:mm:ss");
            string maDon = DonGoiMonModel.InsertDonGoiMon(ngay, thoiGian, ghiChu, ban);
            return maDon;

        }

        // PUT: api/NVDonGoiMonApi/5
        public string Put(string maDon,string trangThai)
        {
            if (DonGoiMonModel.SuaTrangThaiDonGoiMon(maDon,trangThai))
                return "Sua thanh cong!";
            else
                return "Sua that bai!";
        }

        // DELETE: api/NVDonGoiMonApi/5
        public string Delete(string maDon)
        {
            if(DonGoiMonModel.HuyDonGoiMon(maDon))
                return "Huy thanh cong!";
            else
                return "Huy that bai!";
        }
    }
}
