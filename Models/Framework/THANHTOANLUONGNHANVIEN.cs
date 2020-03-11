namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHTOANLUONGNHANVIEN")]
    public partial class THANHTOANLUONGNHANVIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MANHANVIEN { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "smalldatetime")]
        public DateTime NGAYTHANHTOAN { get; set; }

        public double? TONGTHOIGIANLAM { get; set; }

        public int? KHOANGKHAC { get; set; }

        [StringLength(150)]
        public string GHICHU { get; set; }

        public void GetAllRefInfo()
        {
            this.NHANVIEN = Models.NhanVienModel.GetByMaNhanVienStt(MANHANVIEN);
            NHANVIEN.GetAllRefInfo();
        }

        public int? TONGLUONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

    }
}
