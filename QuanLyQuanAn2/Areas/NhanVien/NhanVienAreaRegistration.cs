using System.Web.Mvc;

namespace QuanLyQuanAn2.Areas.NhanVien
{
    public class NhanVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NhanVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NhanVien_default",
                "NhanVien/{controller}/{action}/{id}",
                new { controller = "DonGoiMon",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}