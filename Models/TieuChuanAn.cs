namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TieuChuanAn")]
    public partial class TieuChuanAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TieuChuanAn()
        {
            HocVien = new HashSet<HocVien>();
        }

        [Key]
        public int MaTCA { get; set; }

        public int TienAnSang { get; set; }

        public int TienAnTrua { get; set; }

        public int TienAnToi { get; set; }

        public int TienAnCoBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayApDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocVien { get; set; }
    }
}
