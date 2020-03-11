namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHIPHIKHAC")]
    public partial class CHIPHIKHAC
    {
        [Key]
        [StringLength(8)]
        public string MACHIPHI { get; set; }

        [StringLength(50)]
        public string TENCHIPHI { get; set; }

        public int? SOTIEN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYTRA { get; set; }

        [StringLength(150)]
        public string MOTA { get; set; }

        public bool? ISCHIPHITHU { get; set; }
    }
}
