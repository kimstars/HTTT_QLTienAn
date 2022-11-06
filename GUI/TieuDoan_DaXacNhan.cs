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
    public partial class TieuDoan_DaXacNhan : UserControl
    {
        public TieuDoan_DaXacNhan()
        {
            InitializeComponent();
        }
        public static MyDBContext db = new MyDBContext();

        public string MaDS_DaXacNhan;
        public void LoadDSDaXacNhan()
        {
            try
            {
                var ds_DaXacNhan = (from ds in db.DanhSachNghi
                                    join cbc in db.CanBo on ds.MaCBDaiDoi equals cbc.MaCanBo
                                    join cbd in db.CanBo on ds.MaCBTieuDoan equals cbd.MaCanBo
                                    join dv in db.DonVi on cbc.MaDonVi equals dv.MaDonVi
                                    where ds.PheDuyet == 1
                                    select new
                                    {
                                        MaDS = ds.MaDS,
                                        TenDonVi = dv.TenDonVi,
                                        NgayDK = ds.NgayDK,
                                        HoTenc=cbc.HoTen,
                                        HoTend=cbd.HoTen
                                    }).ToList();
                ds_DaXacNhan.Reverse();
                dgvDaXacNhan_View.OptionsBehavior.Editable = false;
                gridView2.OptionsBehavior.Editable = false;
                dgvDaXacNhan.DataSource = ds_DaXacNhan;

            }
            catch
            { }
            LoadDSChiTietDaXacNhan();
        }
        public void LoadDSChiTietDaXacNhan()
        {
            try
            {
                int mads =(int) dgvDaXacNhan_View.GetFocusedRowCellValue("MaDS");
                MaDS_DaXacNhan = mads.ToString();
                var dsCTDaXacNhan= (from ds in db.DanhSachNghi
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
                dgvChiTietDaXacNhan.DataSource = dsCTDaXacNhan;

            }
            catch
            { }
        }

        private void dgvDaXacNhan_Load(object sender, EventArgs e)
        {
            LoadDSDaXacNhan();
        }

        private void dgvDaXacNhan_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDSChiTietDaXacNhan();
        }
    }
}
