namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("MATHANG")]
    public partial class MATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANG()
        {
            CT_DONDATHANG = new HashSet<CT_DONDATHANG>();
            CT_DONGOIMON = new HashSet<CT_DONGOIMON>();
            CT_GIOHANG = new HashSet<CT_GIOHANG>();
            NHAPMATHANGs = new HashSet<NHAPMATHANG>();
            NHACUNGCAPs = new HashSet<NHACUNGCAP>();
        }

        [Key]
        [StringLength(5)]
        public string MAMATHANG { get; set; }

        [StringLength(30)]
        public string TENMATHANG { get; set; }

        [StringLength(5)]
        public string MADONVITINH { get; set; }

        [StringLength(5)]
        public string MALOAIMATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONDATHANG> CT_DONDATHANG { get; set; }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONGOIMON> CT_DONGOIMON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_GIOHANG> CT_GIOHANG { get; set; }

        public virtual DONVITINH DONVITINH { get; set; }

        public virtual DUNGCU DUNGCU { get; set; }

        public virtual LOAIMATHANG LOAIMATHANG { get; set; }

        public virtual MONAN MONAN { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPMATHANG> NHAPMATHANGs { get; set; }

        public virtual NUOCGIAIKHAT NUOCGIAIKHAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHACUNGCAP> NHACUNGCAPs { get; set; }

        public void GetInforMatHang()
        {
            try
            {
                GetInforDungCu();
            }
            catch { }
            try
            {
                GetInforNguyenLieu();
            }
            catch { }
            try
            {
                GetInforNuocGiaiKhat();
            }
            catch { }
            try
            {
                GetInforMonAn();
            }
            catch { }
            try
            {
                GetNhaCungCap();
            }
            catch { }
        }

        public void GetInforNguyenLieu()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNguyenLieu",this.MAMATHANG),
                };
            this.NGUYENLIEU = new QuanLyQuanAnDbContext().Database.SqlQuery<NGUYENLIEU>("Sp_NGUYENLIEU_GetByMaNguyenLieu @MaNguyenLieu", sqlParams).First();
        }

        public void GetInforDungCu()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaDungCu",this.MAMATHANG),
                };
            this.DUNGCU = new QuanLyQuanAnDbContext().Database.SqlQuery<DUNGCU>("Sp_DungCu_GetByMaDungCu @MaDungCu", sqlParams).First();
        }
        public void GetInforNuocGiaiKhat()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNuocGiaiKhat",this.MAMATHANG),
                };
            this.NUOCGIAIKHAT = new QuanLyQuanAnDbContext().Database.SqlQuery<NUOCGIAIKHAT>("Sp_NUOCGIAIKHAT_GetByMaNuocGiaiKhat @MaNuocGiaiKhat", sqlParams).First();
        }
        public void GetInforMonAn()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMonAn",this.MAMATHANG),
                };
            this.MONAN = new QuanLyQuanAnDbContext().Database.SqlQuery<MONAN>("Sp_MONAN_GetByMaMonAn @MaMonAn", sqlParams).First();
            this.MONAN.GetMenuMonAn();
        }
        public void GetDonViTinh()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaDonViTinh",this.MADONVITINH),
                };
            this.DONVITINH = new QuanLyQuanAnDbContext().Database.SqlQuery<DONVITINH>("Sp_DONVITINH_GetByMaDonViTinh @MaDonViTinh", sqlParams).First();
        }

        public List<DONVITINH> GetAllDonViTinh()
        {
            return new QuanLyQuanAnDbContext().Database.SqlQuery<DONVITINH>("Sp_DONVITINH_GetAll").ToList();
        }

        public void GetNhaCungCap()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaMatHang",this.MAMATHANG),
                };
            this.NHACUNGCAPs = new QuanLyQuanAnDbContext().Database.SqlQuery<NHACUNGCAP>("Sp_MATHANG_GetNhaCungCap @MaMatHang", sqlParams).ToList();
        }

        public List<NHACUNGCAP> GetAllNhaCungCap()
        {
            return new QuanLyQuanAnDbContext().Database.SqlQuery<NHACUNGCAP>("Sp_NHACUNGCAP_ListAll").ToList();
        }

        public static List<MATHANG> GetAllByType(string maLoaiMatHang)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaLoaiMatHang",maLoaiMatHang),
                };
            return new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetAllByType @MaLoaiMatHang", sqlParams).ToList();
        }
    }
}
