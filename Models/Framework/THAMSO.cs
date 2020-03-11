namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMSO")]
    public partial class THAMSO
    {
        [Key]
        [StringLength(5)]
        public string MATHAMSO { get; set; }

        [StringLength(50)]
        public string TENTHAMSO { get; set; }

        [StringLength(10)]
        public string KIEU { get; set; }

        public int? GIATRI { get; set; }

        public bool? TINHTRANG { get; set; }
    }
}
