namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            CT_GIOHANG = new HashSet<CT_GIOHANG>();
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        [StringLength(10)]
        public string MAKHACHHANG { get; set; }

        [StringLength(150)]
        public string DIACHINHANHANG { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_GIOHANG> CT_GIOHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }

        public void GetThongTinAccount()
        {
            object[] sqlParams =
            {
                    new SqlParameter("@ID",this.MAKHACHHANG),
            };
            this.ACCOUNT = new QuanLyQuanAnDbContext().Database.SqlQuery<ACCOUNT>("Sp_ACCOUNT_GetByID @ID", sqlParams).First();

        }
        public KHACHHANG GetByMaKhachHang(string maKH)
        {
            var KH=new QuanLyQuanAnDbContext().Database.SqlQuery<KHACHHANG>("select * from KHACHHANG where MAKHACHHANG='"+maKH+"'").First();
            KH.GetThongTinAccount();
            return KH;
        }
    }
}
