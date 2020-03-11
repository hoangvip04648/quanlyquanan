namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class CT_MONAN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MAMONAN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MANGUYENLIEU { get; set; }

        public int? SOLUONG { get; set; }

        public virtual MONAN MONAN { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }

        public void GetAllRefInfo()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNguyenLieu",this.MANGUYENLIEU),
                };
            this.NGUYENLIEU = new QuanLyQuanAnDbContext().Database.SqlQuery<NGUYENLIEU>("Sp_NGUYENLIEU_GetByMANGUYENLIEU @MaNguyenLieu", sqlParams).First();
            this.NGUYENLIEU.GetAllRefInfo();
        }
    }
}
