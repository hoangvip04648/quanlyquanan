namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("NHAPMATHANG")]
    public partial class NHAPMATHANG
    {
        [Key]
        [StringLength(10)]
        public string MAPHIEUNHAP { get; set; }

        [Required]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        [Required]
        [StringLength(7)]
        public string MANHACUNGCAP { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYNHAP { get; set; }

        public int? SOLUONG { get; set; }

        public void GetAllRefInfo()
        {
            GetMatHang();
            GetNhaCungCap();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MAMATHANG),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
        }
        public void GetNhaCungCap()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNhaCungCap",this.MANHACUNGCAP),
                };
            this.NHACUNGCAP = new QuanLyQuanAnDbContext().Database.SqlQuery<NHACUNGCAP>("Sp_NHACUNGCAP_GetByMaNhaCungCap @MaNhaCungCap", sqlParams).First();
            //this.NHACUNGCAP.Ge
        }

        public int? DONGIA { get; set; }

        public int? THANHTIEN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? HANSUDUNG { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public static int DayTmp, MonthTmp,YearTmp;
        public static string MaLMHTmp;
        public static DateTime dateTmp;
    }
}
