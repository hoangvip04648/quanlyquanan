namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CT_DONDATHANG = new HashSet<CT_DONDATHANG>();
        }

        [Key]
        [StringLength(8)]
        public string MADON { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAY { get; set; }
        

        [StringLength(8)]
        public string THOIGIAN { get; set; }

        [Required]
        [StringLength(10)]
        public string MAKHACHHANG { get; set; }

        [StringLength(150)]
        public string DIACHIGIAOHANG { get; set; }

        [StringLength(150)]
        public string GHICHU { get; set; }

        public short? TINHTRANGDONHANG { get; set; }

        [StringLength(150)]
        public string GHICHUCUANGUOIBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONDATHANG> CT_DONDATHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }


        public void GetAllRefInfo()
        {
            GetThongTinKhachHang();
            GetCTDonDatHang();
        }

        public void GetThongTinKhachHang()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaKhachHang",this.MAKHACHHANG),
                };
            this.KHACHHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<KHACHHANG>("Sp_KHACHHANG_GetByMAKHACHHANG @MaKhachHang", sqlParams).First();
            this.KHACHHANG.GetThongTinAccount();

        }

        public void GetCTDonDatHang()
        {
            object[] sqlParams2 =
                {
                    new SqlParameter("@MaDon",this.MADON),
                };
            this.CT_DONDATHANG = new QuanLyQuanAnDbContext().Database.SqlQuery<CT_DONDATHANG>("Sp_CT_DONDATHANG_GetByMADON @MaDon", sqlParams2).ToList();
            foreach(var ct in CT_DONDATHANG)
            {
                ct.GetChiTietMatHang();
            }
        }


        public int GetSoLuongMatHangDaDat()
        {
            int s = 0;
            if (CT_DONDATHANG != null)
                try
                {
                    foreach (CT_DONDATHANG ct in CT_DONDATHANG)
                    {
                        if(ct.SOLUONG.HasValue)
                            s+=(int)ct.SOLUONG;
                    }
                    return s;
                }
                catch
                {
                    return 0;
                }
            else return 0;
        }

        public int GetTongTien()
        {
            int s = 0;
            if (CT_DONDATHANG != null)
                try
                {
                    foreach (CT_DONDATHANG ct in CT_DONDATHANG)
                    {
                        if (ct.SOLUONG.HasValue&&ct.DONGIA.HasValue)
                        {
                            s += (int)ct.SOLUONG*(int)ct.DONGIA;
                        }
                    }
                    return s;
                }
                catch
                {
                    return 0;
                }
            else return 0;
        }
        public List<MATHANG> GetAllNuocGiaiKhat_MonAn()
        {
            List<MATHANG>list= new QuanLyQuanAnDbContext().Database.SqlQuery<MATHANG>("Sp_MATHANG_GetAll_NuocGiaiKhat_MonAn").ToList();
            foreach(MATHANG item in list)
            {
                item.GetInforMatHang();
            }
            return list;

        }

    }
}
