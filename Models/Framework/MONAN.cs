namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("MONAN")]
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            CT_MONAN = new HashSet<CT_MONAN>();
        }

        [Key]
        [StringLength(5)]
        public string MAMONAN { get; set; }

        public int? GIABAN { get; set; }

        [StringLength(150)]
        public string HINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_MONAN> CT_MONAN { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual MENUMONAN MENUMONAN { get; set; }

        public void GetAllRefInfo()
        {
            GetMatHang();
            GetCT_MONAN();
        }
        public void GetMatHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MAMONAN),
                };
            this.MATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetByMAMATHANG @MaMatHang", sqlParams).First();
            this.MATHANG.GetDonViTinh();
        }

        public void GetCT_MONAN()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMonAn",this.MAMONAN),
                };
            this.CT_MONAN = new QuanLyQuanAnDbContext().Database.SqlQuery<CT_MONAN>("Sp_CT_MONAN_GetByMAMONAN @MaMonAn", sqlParams).ToList();
           foreach(var item in CT_MONAN)
            {
                item.GetAllRefInfo();
            }
        }

        public static List<MONAN> GetAllMonAn()
        {
            var list= new QuanLyQuanAnDbContext().Database.SqlQuery<MONAN>("select * from MONAN").ToList();
            foreach(var item in list)
            {
                item.GetAllRefInfo();
            }
            return list;
        }
        public void GetMenuMonAn()
        {
            MENUMONAN= new QuanLyQuanAnDbContext().Database.SqlQuery<MENUMONAN>("select * from MENUMONAN where MAMONAN='"+MAMONAN+"'").First();
        }
    }
}
