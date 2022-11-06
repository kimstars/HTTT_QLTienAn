using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTT_QLTienAn.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace HTTT_QLTienAn.GUI
{
    public partial class TieuDoan_ChoXacNhan : UserControl
    {
        public static MyDBContext db = new MyDBContext();
        static int maCBd;
        public string MaDS_XacNhan;
        public TieuDoan_ChoXacNhan()
        {
            InitializeComponent();

        }
        public TieuDoan_ChoXacNhan(int maCB)
        {
            InitializeComponent();
            maCBd = maCB;
        }
        public void LoadDSCho()
        {
            try
            {
                var ds_ChoPheDuyet = (from ds in db.DanhSachNghi
                                      join cb in db.CanBo on ds.MaCBDaiDoi equals cb.MaCanBo
                                      join dv in db.DonVi on cb.MaDonVi equals dv.MaDonVi
                                      where ds.PheDuyet == -1
                                      select new
                                      { 
                                          MaDS=ds.MaDS,
                                          TenDonVi=dv.TenDonVi,
                                          NgayDK=ds.NgayDK,
                                          HoTen=cb.HoTen
                                      }).ToList();
                ds_ChoPheDuyet.Reverse();
                dgvDSCho.DataSource = ds_ChoPheDuyet;
                
            }
            catch
            { }
            LoadDS1();
        }
        public void LoadDS1()
        {
            try
            {
                int mads =(int) dgvDSCho_View.GetFocusedRowCellValue("MaDS");
                MaDS_XacNhan = mads.ToString();
                var ds_CTChoPheDuyet = (from ds in db.DanhSachNghi
                                        join dkn in db.DangKyNghi on ds.MaDS equals dkn.MaDS
                                        join ctn in db.ChiTietNghi on dkn.MaDangKy equals ctn.MaDangKy
                                        join hv1 in db.HocVien on dkn.MaHocVien equals hv1.MaHocVien
                                    
                                        where ds.MaDS==mads
                                        select new
                                        {
                                            HoTen=hv1.HoTen,
                                            Lop=hv1.Lop,
                                            NgayNghi=ctn.NgayNghi,
                                            SoBuoiSang=ctn.SoBuoiSang,
                                            SoBuoiTrua=ctn.SoBuoiTrua,
                                            SoBuoiToi=ctn.SoBuoiToi,
                                          
                                        }).ToList();
                ds_CTChoPheDuyet.Reverse();
                dgvDSCho_View.OptionsBehavior.Editable = false;
                gridView2.OptionsBehavior.Editable = false;
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            LoadDSCho();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachNghi.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 1;
                dsn.MaCBTieuDoan = maCBd;
                db.SaveChanges();
                MessageBox.Show("Danh sách đã được xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Danh sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDSCho.DataSource = null;
            dgvChiTietDS1.DataSource = null;
            LoadDSCho();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachNghi.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 0;
                dsn.MaCBTieuDoan = maCBd;
                db.SaveChanges();
                MessageBox.Show("Danh sách đã được huỷ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDSCho.DataSource = null;
            dgvChiTietDS1.DataSource = null;
            LoadDSCho();
        }

        private void dgvDSCho_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDS1();
        }
    }
}
