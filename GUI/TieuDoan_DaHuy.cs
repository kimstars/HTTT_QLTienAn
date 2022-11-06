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

namespace HTTT_QLTienAn.GUI
{
    public partial class TieuDoan_DaHuy : UserControl
    {
        public TieuDoan_DaHuy()
        {
            InitializeComponent();
        }
        public static MyDBContext db = new MyDBContext();

        public string MaDS_DaHuy;
        public void LoadDSDaHuy()
        {
            try
            {
                var ds_DaHuy = (from ds in db.DanhSachNghi
                                join cbc in db.CanBo on ds.MaCBDaiDoi equals cbc.MaCanBo
                                join cbd in db.CanBo on ds.MaCBTieuDoan equals cbd.MaCanBo
                                join dv in db.DonVi on cbc.MaDonVi equals dv.MaDonVi
                                
                                where ds.PheDuyet == 0
                                select new
                                {
                                    MaDS = ds.MaDS,
                                    TenDonVi = dv.TenDonVi,
                                    NgayDK = ds.NgayDK,
                                    HoTenc=cbc.HoTen,
                                    HoTend=cbd.HoTen
                                }).ToList();
                ds_DaHuy.Reverse();
                dgvDaHuy_View.OptionsBehavior.Editable = false;
                gridView2.OptionsBehavior.Editable = false;
                dgvDaHuy.DataSource = ds_DaHuy;

            }
            catch
            { }
            LoadDSChiTietDaHuy();
        }
        public void LoadDSChiTietDaHuy()
        {
            try
            {
                int mads =(int) dgvDaHuy_View.GetFocusedRowCellValue("MaDS");
                MaDS_DaHuy = mads.ToString();
                var dsCTDaHuy= (from ds in db.DanhSachNghi
                                join dkn in db.DangKyNghi on ds.MaDS equals dkn.MaDS
                                join ctn in db.ChiTietNghi on dkn.MaDangKy equals ctn.MaDangKy
                                join hv1 in db.HocVien on dkn.MaHocVien equals hv1.MaHocVien
                                where ds.MaDS == mads
                                select new
                                {
                                    HoTen = hv1.HoTen,
                                    Lop = hv1.Lop,
                                    NgayNghi = ctn.NgayNghi,
                                    SoBuoiSang = ctn.SoBuoiSang,
                                    SoBuoiTrua = ctn.SoBuoiTrua,
                                    SoBuoiToi = ctn.SoBuoiToi
                                }).ToList();

                dgvChiTietDaHuy.DataSource = dsCTDaHuy;
            }
            catch
            { }
        }

        private void dgvDaHuy_Load(object sender, EventArgs e)
        {
            LoadDSDaHuy();
        }

        private void dgvDaHuy_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDSChiTietDaHuy();
        }
    }
}
