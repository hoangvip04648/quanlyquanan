namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class CT_DONGOIMON
    {
        [Key]
        [StringLength(9)]
        public string MACTDGM { get; set; }

        [Required]
        [StringLength(8)]
        public string MADON { get; set; }

        [Required]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        public int? SOLUONG { get; set; }

        public int? DONGIA { get; set; }

        public virtual DONGOIMON DONGOIMON { get; set; }

        public virtual MATHANG MATHANG { get; set; }
        public void GetAllRefInfor()
        {
            GetMatHang();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MAMATHANG),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            
        }
    }
}
