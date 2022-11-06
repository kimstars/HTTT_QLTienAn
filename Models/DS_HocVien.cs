namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_HocVien
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string Lop { get; set; }
    }
}
