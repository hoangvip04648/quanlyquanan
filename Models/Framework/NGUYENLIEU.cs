namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("NGUYENLIEU")]
    public partial class NGUYENLIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUYENLIEU()
        {
            CT_MONAN = new HashSet<CT_MONAN>();
        }

        [Key]
        [StringLength(5)]
        public string MANGUYENLIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_MONAN> CT_MONAN { get; set; }

        public void GetAllRefInfo()
        {
            GetMatHang();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MANGUYENLIEU),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
        }

        public virtual MATHANG MATHANG { get; set; }

        public static List<NGUYENLIEU> GetAllNguyenLieu()
        {
            
            List<NGUYENLIEU> list= new QuanLyQuanAnDbContext().Database.SqlQuery<NGUYENLIEU>("Select * from NGUYENLIEU").ToList();
            foreach(var item in list)
            {
                item.GetAllRefInfo();
            }
            return list;
        }
    }
}
