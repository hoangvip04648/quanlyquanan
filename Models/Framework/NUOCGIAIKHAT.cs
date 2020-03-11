namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("NUOCGIAIKHAT")]
    public partial class NUOCGIAIKHAT
    {
        [Key]
        [StringLength(5)]
        public string MANUOCGIAIKHAT { get; set; }

        public int? GIABAN { get; set; }

        public int? SOLUONGCON { get; set; }

        [StringLength(150)]
        public string HINHANH { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual MENUNUOCGIAIKHAT MENUNUOCGIAIKHAT { get; set; }

        public void GetAllRefInfo()
        {
            GetMatHang();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MANUOCGIAIKHAT),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
        }

        public static List<NUOCGIAIKHAT> GetAllNuocGiaiKhat()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<NUOCGIAIKHAT>("select * from NUOCGIAIKHAT").ToList();
            foreach (var item in list)
            {
                item.GetAllRefInfo();
            }
            return list;
        }
    }
}
