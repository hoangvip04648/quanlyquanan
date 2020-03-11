namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("MENUNUOCGIAIKHAT")]
    public partial class MENUNUOCGIAIKHAT
    {
        [Key]
        [StringLength(5)]
        public string MANUOCGIAIKHAT { get; set; }

        public virtual NUOCGIAIKHAT NUOCGIAIKHAT { get; set; }

        public void GetAllRefInfo()
        {
            GetNuocGiaiKhat();
        }
        public void GetNuocGiaiKhat()
        {
            object[] sqlParams =
                {
                    new SqlParameter("@MaNuocGiaiKhat",this.MANUOCGIAIKHAT),
                };
            this.NUOCGIAIKHAT = new QuanLyQuanAnDbContext().Database.SqlQuery<NUOCGIAIKHAT>("Sp_NUOCGIAIKHAT_GetByMaNuocGiaiKhat @MaNuocGiaiKhat", sqlParams).First();
            this.NUOCGIAIKHAT.GetAllRefInfo();
        }
        
    }
}
