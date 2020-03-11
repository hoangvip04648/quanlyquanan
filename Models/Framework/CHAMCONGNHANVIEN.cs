namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CHAMCONGNHANVIEN")]
    public partial class CHAMCONGNHANVIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MANHANVIEN { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "smalldatetime")]
        public DateTime NGAYCHAMCONG { get; set; }

        public double? THOIGIANLAM { get; set; }

        public bool? TRANGTHAITHANHTOAN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public void GetAllRefInfo()
        {
            NHANVIEN= new QuanLyQuanAnDbContext().Database.SqlQuery<NHANVIEN>("Select *from NHANVIEN where MANHANVIEN='"+MANHANVIEN+"'").First();
            NHANVIEN.GetAllRefInfo();
        }
    }
}
