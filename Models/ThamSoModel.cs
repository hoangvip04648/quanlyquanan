using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThamSoModel
    {
        private QuanLyQuanAnDbContext context = null;
        public ThamSoModel()
        {
            context = new QuanLyQuanAnDbContext();
        }
        public List<THAMSO> ListAll()
        {
            var list = context.Database.SqlQuery<THAMSO>("Sp_THAMSO_ListAll").ToList();

            return list;
        }
        public int GetThamSoByTen(string tenTS)
        {
            var thamso = context.Database.SqlQuery<THAMSO>("select * from THAMSO where TENTHAMSO='"+tenTS+"'").First();

            if (thamso.TINHTRANG.Value == true && thamso.GIATRI.HasValue)
                return thamso.GIATRI.Value;
            else
                return -999;
        }
        
        public static bool UpdateThamSo(string maThamSo, string giaTri, string tinhTrang)
        {
            //update
            string command = "Sp_THAMSO_Update @maThamSo='" + maThamSo + "', @giaTri=" + giaTri + ",@tinhTrang="+tinhTrang;
            var res = new QuanLyQuanAnDbContext().Database.ExecuteSqlCommand(command);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
