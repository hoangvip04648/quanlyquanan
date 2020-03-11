namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            NHAPMATHANGs = new HashSet<NHAPMATHANG>();
            MATHANGs = new HashSet<MATHANG>();
        }

        [Key]
        [StringLength(7)]
        public string MANHACUNGCAP { get; set; }

        public void GetAllRefInfo()
        {
            GetLoaiMathang();
        }

        public void GetLoaiMathang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaLoaiMatHang",this.MALOAIMATHANGCUNGCAP),
                };
            this.LOAIMATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<LOAIMATHANG>("Sp_LOAIMATHANG_GetByMALOAIMATHANG @MaLoaiMatHang", sqlParams).First();
            
        }

        [StringLength(50)]
        public string TENNHACUNGCAP { get; set; }

        [StringLength(50)]
        public string NGUOIDAIDIEN { get; set; }

        [StringLength(11)]
        public string SODIENTHOAI { get; set; }

        [StringLength(150)]
        public string DIACHI { get; set; }

        [StringLength(150)]
        public string MOTA { get; set; }

        [StringLength(5)]
        public string MALOAIMATHANGCUNGCAP { get; set; }

        public virtual LOAIMATHANG LOAIMATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPMATHANG> NHAPMATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATHANG> MATHANGs { get; set; }

        public List<LOAIMATHANG> GetAllLoaiMatHangCungCap()
        {
            List<LOAIMATHANG> list = new QuanLyQuanAnDbContext().Database.SqlQuery<LOAIMATHANG>("Sp_LOAIMATHANG_GetAll").ToList();
            return list;
        }

        public List<NHACUNGCAP> GetAllNhaCungCap()
        {
            return new QuanLyQuanAnDbContext().Database.SqlQuery<NHACUNGCAP>("Sp_NHACUNGCAP_ListAll").ToList();
        }
        public static List<NHACUNGCAP> GetAllByType(string maLoaiNhaCungCap)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaLoaiMatHang",maLoaiNhaCungCap),
                };
            return new QuanLyQuanAnDbContext().Database.SqlQuery<NHACUNGCAP>("Sp_NHACUNGCAP_GetAllByType @MaLoaiMatHang", sqlParams).ToList();
        }
    }
}
