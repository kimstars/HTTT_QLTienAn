namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhToan()
        {
            DangKyNghi = new HashSet<DangKyNghi>();
        }

        [Key]
        public int MaThanhToan { get; set; }

        public int TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTT { get; set; }

        public int? TrangThaiTT { get; set; }

        public int? MaHocVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyNghi> DangKyNghi { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
