namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhaBep_LichSuCatComLop
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHocVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Lop { get; set; }

        public int? MaDonVi { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTT { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TongTien { get; set; }

        public int? TrangThaiTT { get; set; }
    }
}
