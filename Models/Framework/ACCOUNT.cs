namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [StringLength(10)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TAIKHOAN { get; set; }

        [Required]
        [StringLength(32)]
        public string MATKHAU { get; set; }

        [Required]
        [StringLength(50)]
        public string HOTEN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(3)]
        public string GIOITINH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(150)]
        public string DIACHI { get; set; }

        [StringLength(2)]
        public string LOAIUSER { get; set; }

        public virtual ADMIN ADMIN { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
