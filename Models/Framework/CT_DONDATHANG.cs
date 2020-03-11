namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class CT_DONDATHANG
    {
        [Key]
        [StringLength(9)]
        public string MACTDDH { get; set; }

        [Required]
        [StringLength(8)]
        public string MADON { get; set; }

        [Required]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        public int? SOLUONG { get; set; }

        public int? DONGIA { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public void GetChiTietMatHang()
        {
            object[] sqlParams2 =
                {
                    new SqlParameter("@MaMatHang",this.MAMATHANG),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams2).First();
            this.MATHANG.GetInforMatHang();
        }
    }
}
