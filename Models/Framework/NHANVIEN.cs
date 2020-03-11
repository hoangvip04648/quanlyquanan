namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            CHAMCONGNHANVIENs = new HashSet<CHAMCONGNHANVIEN>();
            THANHTOANLUONGNHANVIENs = new HashSet<THANHTOANLUONGNHANVIEN>();
        }

        [Key]
        [StringLength(10)]
        public string MANHANVIEN { get; set; }

        public void GetAllRefInfo()
        {
            GetAcount();
            GetDonViTinhLuong();
        }
        public void GetAcount()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@ID",this.MANHANVIEN),
                };
            this.ACCOUNT = new QuanLyQuanAnDbContext().Database.SqlQuery<ACCOUNT>("Sp_ACCOUNT_GetByID @ID", sqlParams).First();
           
        }
        public void GetDonViTinhLuong()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@maDonViTinhLuong",this.MADONVITINHLUONG),
                };
            this.DONVITINHLUONG = new QuanLyQuanAnDbContext().Database.SqlQuery<DONVITINHLUONG>("Sp_DONVITINHLUONG_GetByMaDonViTinhLuong @maDonViTinhLuong", sqlParams).First();

        }

        public string trangThaiThanhToan;
        public void GetChamCongNhanVien()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@maNhanVien",this.MANHANVIEN),
                };
            this.CHAMCONGNHANVIENs = new QuanLyQuanAnDbContext().Database.SqlQuery<CHAMCONGNHANVIEN>("Sp_CHAMCONGNHANVIEN_GetByMaNhanVien @maNhanVien", sqlParams).ToList();

        }



        public void GetThanhToanLuongNhanVien()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@maNhanVien",this.MANHANVIEN),
                };
            this.THANHTOANLUONGNHANVIENs = new QuanLyQuanAnDbContext().Database.SqlQuery<THANHTOANLUONGNHANVIEN>("Sp_THANHTOANLUONGNHANVIEN_GetByMaNhanVien @maNhanVien", sqlParams).ToList();

        }

        public int TinhTongSoTienLuongChuaThanhToan()
        {
            try
            {
                double S = new QuanLyQuanAnDbContext().Database.SqlQuery<double>("Sp_NHANVIEN_TinhTongSoTienLuongChuaThanhToan @maNhanVien='" + MANHANVIEN + "'").First();
                return (int)S;
            }
            catch { return 0; }
        }

        public double GetTongThoiGianLam()
        {
            double thoiGian = 0;
            foreach(CHAMCONGNHANVIEN item in CHAMCONGNHANVIENs)
            {
                if (item.TRANGTHAITHANHTOAN.HasValue)
                {
                    if (item.TRANGTHAITHANHTOAN.Value == false)
                    {
                        thoiGian += item.THOIGIANLAM.HasValue?item.THOIGIANLAM.Value:0;
                    }
                }
            }
            return thoiGian;
        }

        public int GetTongLuongChuaThanhToan()
        {
            if (LUONG.HasValue)
                return (int)(GetTongThoiGianLam() * LUONG.Value);
            else return 0;
        }

        public static List<NHANVIEN> GetAllConHoatDong()
        {
            var list = new QuanLyQuanAnDbContext().Database.SqlQuery<NHANVIEN>("select * from NHANVIEN where TRANGTHAI=1").ToList();
            foreach (var item in list)
                item.GetAllRefInfo();
            return list;
        }

        public string GetTrangThaiThanhToanLuongHomNay()
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            int dem = new QuanLyQuanAnDbContext().Database.SqlQuery<int>("select count(*) from CHAMCONGNHANVIEN where NGAYCHAMCONG='"+date+"' and MANHANVIEN='"+MANHANVIEN+"'").First();
            if (dem > 0)
                return "Đã chấm công";
            else
                return "Chưa chấm công";
        }

        public int? LUONG { get; set; }
        public bool? TRANGTHAI { get; set; }
        [StringLength(5)]
        public string MADONVITINHLUONG { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYKYHOPDONG { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAMCONGNHANVIEN> CHAMCONGNHANVIENs { get; set; }

        public virtual DONVITINHLUONG DONVITINHLUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOANLUONGNHANVIEN> THANHTOANLUONGNHANVIENs { get; set; }
    }
}
