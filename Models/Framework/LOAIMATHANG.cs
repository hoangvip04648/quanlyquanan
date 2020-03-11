namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("LOAIMATHANG")]
    public partial class LOAIMATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMATHANG()
        {
            MATHANGs = new HashSet<MATHANG>();
            NHACUNGCAPs = new HashSet<NHACUNGCAP>();
        }

        [Key]
        [StringLength(5)]
        public string MALOAIMATHANG { get; set; }

        [StringLength(30)]
        public string TENLOAIMATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATHANG> MATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHACUNGCAP> NHACUNGCAPs { get; set; }

        public static List<LOAIMATHANG> GetAll()
        {
            List<LOAIMATHANG> list = new QuanLyQuanAnDbContext().Database.SqlQuery<LOAIMATHANG>("Sp_LOAIMATHANG_GetAll").ToList();
            return list;
        }

        public static List<LOAIMATHANG> GetAllLoaiMatHangNhap()
        {
            List<LOAIMATHANG> list = new QuanLyQuanAnDbContext().Database.SqlQuery<LOAIMATHANG>("Sp_LOAIMATHANG_GetAllLoaiMatHangNhap").ToList();
            return list;
        }
    }
}
