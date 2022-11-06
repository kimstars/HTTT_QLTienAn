namespace HTTT_QLTienAn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<CanBo> CanBo { get; set; }
        public virtual DbSet<ChiTietNghi> ChiTietNghi { get; set; }
        public virtual DbSet<DangKyNghi> DangKyNghi { get; set; }
        public virtual DbSet<DanhSachNghi> DanhSachNghi { get; set; }
        public virtual DbSet<DonVi> DonVi { get; set; }
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<ThanhToan> ThanhToan { get; set; }
        public virtual DbSet<TieuChuanAn> TieuChuanAn { get; set; }
        public virtual DbSet<TTDangNhap> TTDangNhap { get; set; }
        public virtual DbSet<NhaBep_CatComChuaThanhToan> NhaBep_CatComChuaThanhToan { get; set; }
        public virtual DbSet<NhaBep_FindToCreateThanhToan> NhaBep_FindToCreateThanhToan { get; set; }
        public virtual DbSet<NhaBep_LichSuCatComLop> NhaBep_LichSuCatComLop { get; set; }
        public virtual DbSet<NhaBep_ListCatCom> NhaBep_ListCatCom { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghi)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBDaiDoi);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghi1)
                .WithOptional(e => e.CanBo1)
                .HasForeignKey(e => e.MaCBNhaBep);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghi2)
                .WithOptional(e => e.CanBo2)
                .HasForeignKey(e => e.MaCBTieuDoan);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.QuyenTruyCap)
                .IsUnicode(false);
        }
    }
}
