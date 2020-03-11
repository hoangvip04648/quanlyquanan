namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyQuanAnDbContext : DbContext
    {
        public QuanLyQuanAnDbContext()
            : base("name=QuanLyQuanAnDbContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CHAMCONGNHANVIEN> CHAMCONGNHANVIENs { get; set; }
        public virtual DbSet<CHIPHIKHAC> CHIPHIKHACs { get; set; }
        public virtual DbSet<CT_DONDATHANG> CT_DONDATHANG { get; set; }
        public virtual DbSet<CT_DONGOIMON> CT_DONGOIMON { get; set; }
        public virtual DbSet<CT_GIOHANG> CT_GIOHANG { get; set; }
        public virtual DbSet<CT_MONAN> CT_MONAN { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<DONGOIMON> DONGOIMONs { get; set; }
        public virtual DbSet<DONVITINH> DONVITINHs { get; set; }
        public virtual DbSet<DONVITINHLUONG> DONVITINHLUONGs { get; set; }
        public virtual DbSet<DUNGCU> DUNGCUs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIMATHANG> LOAIMATHANGs { get; set; }
        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<MENUMONAN> MENUMONANs { get; set; }
        public virtual DbSet<MENUNUOCGIAIKHAT> MENUNUOCGIAIKHATs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NGUYENLIEU> NGUYENLIEUx { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAPMATHANG> NHAPMATHANGs { get; set; }
        public virtual DbSet<NUOCGIAIKHAT> NUOCGIAIKHATs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }
        public virtual DbSet<THANHTOANLUONGNHANVIEN> THANHTOANLUONGNHANVIENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.LOAIUSER)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.ADMIN)
                .WithRequired(e => e.ACCOUNT);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.KHACHHANG)
                .WithRequired(e => e.ACCOUNT);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.NHANVIEN)
                .WithRequired(e => e.ACCOUNT);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MAADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.QUYEN)
                .IsUnicode(false);

            modelBuilder.Entity<CHAMCONGNHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<CHIPHIKHAC>()
                .Property(e => e.MACHIPHI)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONDATHANG>()
                .Property(e => e.MACTDDH)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONDATHANG>()
                .Property(e => e.MADON)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONDATHANG>()
                .Property(e => e.MAMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONGOIMON>()
                .Property(e => e.MACTDGM)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONGOIMON>()
                .Property(e => e.MADON)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DONGOIMON>()
                .Property(e => e.MAMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<CT_GIOHANG>()
                .Property(e => e.MAKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<CT_GIOHANG>()
                .Property(e => e.MAMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<CT_MONAN>()
                .Property(e => e.MAMONAN)
                .IsUnicode(false);

            modelBuilder.Entity<CT_MONAN>()
                .Property(e => e.MANGUYENLIEU)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.MADON)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.THOIGIAN)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.MAKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CT_DONDATHANG)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONGOIMON>()
                .Property(e => e.MADON)
                .IsUnicode(false);

            modelBuilder.Entity<DONGOIMON>()
                .Property(e => e.THOIGIAN)
                .IsUnicode(false);

            modelBuilder.Entity<DONGOIMON>()
                .Property(e => e.BAN)
                .IsUnicode(false);

            modelBuilder.Entity<DONGOIMON>()
                .HasMany(e => e.CT_DONGOIMON)
                .WithRequired(e => e.DONGOIMON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONVITINH>()
                .Property(e => e.MADONVITINH)
                .IsUnicode(false);

            modelBuilder.Entity<DONVITINHLUONG>()
                .Property(e => e.MADONVITINHLUONG)
                .IsUnicode(false);

            modelBuilder.Entity<DUNGCU>()
                .Property(e => e.MADUNGCU)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKHACHHANG)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.CT_GIOHANG)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONDATHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIMATHANG>()
                .Property(e => e.MALOAIMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIMATHANG>()
                .HasMany(e => e.NHACUNGCAPs)
                .WithOptional(e => e.LOAIMATHANG)
                .HasForeignKey(e => e.MALOAIMATHANGCUNGCAP);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.MAMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.MADONVITINH)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.MALOAIMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.CT_DONDATHANG)
                .WithRequired(e => e.MATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.CT_DONGOIMON)
                .WithRequired(e => e.MATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.CT_GIOHANG)
                .WithRequired(e => e.MATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANG>()
                .HasOptional(e => e.DUNGCU)
                .WithRequired(e => e.MATHANG);

            modelBuilder.Entity<MATHANG>()
                .HasOptional(e => e.MONAN)
                .WithRequired(e => e.MATHANG);

            modelBuilder.Entity<MATHANG>()
                .HasOptional(e => e.NGUYENLIEU)
                .WithRequired(e => e.MATHANG);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.NHAPMATHANGs)
                .WithRequired(e => e.MATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANG>()
                .HasOptional(e => e.NUOCGIAIKHAT)
                .WithRequired(e => e.MATHANG);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.NHACUNGCAPs)
                .WithMany(e => e.MATHANGs)
                .Map(m => m.ToTable("MATHANGNHAP_NHACUNGCAP").MapLeftKey("MAMATHANG").MapRightKey("MANHACUNGCAP"));

            modelBuilder.Entity<MENUMONAN>()
                .Property(e => e.MAMONAN)
                .IsUnicode(false);

            modelBuilder.Entity<MENUNUOCGIAIKHAT>()
                .Property(e => e.MANUOCGIAIKHAT)
                .IsUnicode(false);

            modelBuilder.Entity<MONAN>()
                .Property(e => e.MAMONAN)
                .IsUnicode(false);

            modelBuilder.Entity<MONAN>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.CT_MONAN)
                .WithRequired(e => e.MONAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .HasOptional(e => e.MENUMONAN)
                .WithRequired(e => e.MONAN);

            modelBuilder.Entity<NGUYENLIEU>()
                .Property(e => e.MANGUYENLIEU)
                .IsUnicode(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .HasMany(e => e.CT_MONAN)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANHACUNGCAP)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SODIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MALOAIMATHANGCUNGCAP)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.NHAPMATHANGs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MADONVITINHLUONG)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CHAMCONGNHANVIENs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.THANHTOANLUONGNHANVIENs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAPMATHANG>()
                .Property(e => e.MAPHIEUNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<NHAPMATHANG>()
                .Property(e => e.MAMATHANG)
                .IsUnicode(false);

            modelBuilder.Entity<NHAPMATHANG>()
                .Property(e => e.MANHACUNGCAP)
                .IsUnicode(false);

            modelBuilder.Entity<NUOCGIAIKHAT>()
                .Property(e => e.MANUOCGIAIKHAT)
                .IsUnicode(false);

            modelBuilder.Entity<NUOCGIAIKHAT>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<NUOCGIAIKHAT>()
                .HasOptional(e => e.MENUNUOCGIAIKHAT)
                .WithRequired(e => e.NUOCGIAIKHAT);

            modelBuilder.Entity<THAMSO>()
                .Property(e => e.MATHAMSO)
                .IsUnicode(false);

            modelBuilder.Entity<THAMSO>()
                .Property(e => e.KIEU)
                .IsUnicode(false);

            modelBuilder.Entity<THANHTOANLUONGNHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);
        }
    }
}
