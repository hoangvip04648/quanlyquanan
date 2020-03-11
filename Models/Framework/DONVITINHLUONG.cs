namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("DONVITINHLUONG")]
    public partial class DONVITINHLUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONVITINHLUONG()
        {
            NHANVIENs = new HashSet<NHANVIEN>();
        }

        [Key]
        [StringLength(5)]
        public string MADONVITINHLUONG { get; set; }

        [StringLength(6)]
        public string TENDONVITINHLUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }

        public static List<DONVITINHLUONG> GetAll()
        {
            return new QuanLyQuanAnDbContext().Database.SqlQuery<DONVITINHLUONG>("Sp_DONVITINHLUONG_ListAll").ToList();
        }

    }
}
