namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ChoPheDuyet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayNghi { get; set; }
    }
}
