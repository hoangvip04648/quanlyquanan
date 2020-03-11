namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("BANGXEPHANGSANPHAM")]
    public partial class BANGXEPHANGSANPHAM
    {
        [Key]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        public int? TONGDABAN { get; set; }

        public virtual MATHANG MATHANG { get; set; }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MAMATHANG),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
            this.MATHANG.GetInforMatHang();
        }
    }
}
