namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangKyNghi")]
    public partial class DangKyNghi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DangKyNghi()
        {
            ChiTietNghi = new HashSet<ChiTietNghi>();
        }

        [Key]
        public int MaDangKy { get; set; }

        public int? MaDS { get; set; }

        public int? MaThanhToan { get; set; }

        public int? MaHocVien { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNghi> ChiTietNghi { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual ThanhToan ThanhToan { get; set; }

        public virtual DanhSachNghi DanhSachNghi { get; set; }
    }
}
