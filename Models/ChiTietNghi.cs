namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNghi")]
    public partial class ChiTietNghi
    {
        [Key]
        public int MaCTNghi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNghi { get; set; }

        public int? SoBuoiSang { get; set; }

        public int? SoBuoiTrua { get; set; }

        public int? SoBuoiToi { get; set; }

        public int? MaDangKy { get; set; }

        public virtual DangKyNghi DangKyNghi { get; set; }
    }
}
