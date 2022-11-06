namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachNghi")]
    public partial class DanhSachNghi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSachNghi()
        {
            DangKyNghi = new HashSet<DangKyNghi>();
        }

        [Key]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        public int? PheDuyet { get; set; }

        public int? MaCBDaiDoi { get; set; }

        public int? MaCBTieuDoan { get; set; }

        public int? MaCBNhaBep { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual CanBo CanBo1 { get; set; }

        public virtual CanBo CanBo2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyNghi> DangKyNghi { get; set; }
    }
}
