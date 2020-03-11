namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("DONGOIMON")]
    public partial class DONGOIMON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONGOIMON()
        {
            CT_DONGOIMON = new HashSet<CT_DONGOIMON>();
        }

        [Key]
        [StringLength(8)]
        public string MADON { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAY { get; set; }

        [StringLength(8)]
        public string THOIGIAN { get; set; }

        [StringLength(4)]
        public string BAN { get; set; }

        [StringLength(150)]
        public string GHICHU { get; set; }

        public bool? TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONGOIMON> CT_DONGOIMON { get; set; }
        public void GetAllRefInfo()
        {
            GetCT_DONGOIMON();
        }
        public void GetCT_DONGOIMON()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaDon",this.MADON),
                };
            CT_DONGOIMON = new QuanLyQuanAnDbContext().Database.SqlQuery<CT_DONGOIMON>("Sp_CT_DONGOIMON_GetByMaDonGoiMon @MaDon",sqlParams).ToList();
            foreach(var item in CT_DONGOIMON)
                item.GetAllRefInfor();
        }
        public int GetTongTien()
        {
            try
            {
                int S = 0;
                foreach (var item in CT_DONGOIMON)
                {
                    S += item.DONGIA.Value * item.SOLUONG.Value;
                }
                return S;
            }
            catch {
                return 0;
            }
            
        }
        public static DONGOIMON GetByMaDonGoiMon(string madon)
        {
            DONGOIMON dgm = new DONGOIMON();
            dgm.MADON = madon;
            dgm.GetCT_DONGOIMON();
            return dgm;
        }
    }
}
