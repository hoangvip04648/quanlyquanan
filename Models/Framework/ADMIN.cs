namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(10)]
        public string MAADMIN { get; set; }

        [StringLength(10)]
        public string QUYEN { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
