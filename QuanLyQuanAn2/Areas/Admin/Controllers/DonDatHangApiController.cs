using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyQuanAn2.Areas.Admin.Controllers
{
    [Authorize(Roles = "ad")]
    public class DonDatHangApiController : ApiController
    {
        // GET: api/DonDatHangApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DonDatHangApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DonDatHangApi
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/DonDatHangApi/5
        public string Put(string maDon, string tinhTrang, string ghiChuNguoiBan)
        {
            //var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
            
            int iTinhTrang;
            try
            {
                iTinhTrang = Int32.Parse(tinhTrang);
                if(!DonDatHangModel.UpdateTinhTrang_GhiChu(maDon,iTinhTrang,ghiChuNguoiBan))
                    return "Lưu thất bại!";
            }
            catch
            {
                return "Thất bại! Tình trạng đơn hàng không hợp lệ!";
            }
            //Debug.WriteLine(maDon + "" + iTinhTrang+"\n"+ghiChuNguoiBan);
            return "Lưu thành công!";
            
        }



        // DELETE: api/DonDatHangApi/5
        public void Delete(int id)
        {
        }
    }
}
