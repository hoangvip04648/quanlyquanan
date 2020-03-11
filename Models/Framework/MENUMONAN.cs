namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("MENUMONAN")]
    public partial class MENUMONAN
    {
        [Key]
        [StringLength(5)]
        public string MAMONAN { get; set; }

        public bool? TRANGTHAI { get; set; }

        public virtual MONAN MONAN { get; set; }

        public void GetAllRefInfo()
        {
            GetMonAn();
        }
        public void GetMonAn()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMonAn",this.MAMONAN),
                };
            this.MONAN = new QuanLyQuanAnDbContext().Database.SqlQuery<MONAN>("Sp_MONAN_GetByMAMONAN @MaMonAn", sqlParams).First();
            this.MONAN.GetAllRefInfo();
        }
        public static List<MENUMONAN> GetAll()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<MENUMONAN>("select * from MENUMONAN inner join MATHANG on MATHANG.MAMATHANG=MENUMONAN.MAMONAN order by TRANGTHAI DESC, TENMATHANG ASC").ToList();
            foreach(var item in list)
            {
                item.GetAllRefInfo();
            }
            
            return list;
        }
    }
}
