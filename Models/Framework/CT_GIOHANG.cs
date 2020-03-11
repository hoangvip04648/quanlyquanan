namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class CT_GIOHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MAKHACHHANG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        public int? SOLUONG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

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
        public void GetKhachHang()
        {
           this.KHACHHANG = new KHACHHANG().GetByMaKhachHang(MAKHACHHANG);
        }

    }
}
