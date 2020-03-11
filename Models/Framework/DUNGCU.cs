namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("DUNGCU")]
    public partial class DUNGCU
    {
        [Key]
        [StringLength(5)]
        public string MADUNGCU { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public void GetAllRefInfo()
        {
            GetMatHang();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MADUNGCU),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
        }
    }
}
