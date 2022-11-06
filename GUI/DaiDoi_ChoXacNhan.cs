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
    public partial class DaiDoi_ChoXacNhan : UserControl
    {
        MyDBContext db = new MyDBContext();
        public DaiDoi_ChoXacNhan()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;

            //gridControl3.DataSource = dtPeople;

        }

        public void ReloadAll()
        {
            DaiDoi_ChoXacNhan_Load(this, new EventArgs());
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[0]));

            if (gridView1.FocusedColumn == gridView1.Columns["fldXoa"])
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DanhSachNghi temp = db.DanhSachNghi.Where(s => s.MaDS == maDS).FirstOrDefault();
                    db.DanhSachNghi.Remove(temp);
                    db.SaveChanges();
                    ReloadAll();
                }
                return;
            }
            
            var chitiet = (from ds in db.DanhSachNghi
                           join dk in db.DangKyNghi on ds.MaDS equals dk.MaDS
                           join ct in db.ChiTietNghi on dk.MaDangKy equals ct.MaDangKy
                           join hv in db.HocVien on dk.MaHocVien equals hv.MaHocVien
                           where ds.MaDS == maDS
                           select new
                           {
                               HoTen = hv.HoTen,
                               Lop = hv.Lop,
                               NgayNghi = ct.NgayNghi,
                               Sang = ct.SoBuoiSang,
                               Trua = ct.SoBuoiTrua,
                               Toi = ct.SoBuoiToi
                           }).ToList();
            gridControl2.DataSource = chitiet;
        }

        private void DaiDoi_ChoXacNhan_Load(object sender, EventArgs e)
        {
            CanBo cbo = db.CanBo.Where(s => s.MaCanBo == FormMain.maCB).FirstOrDefault();
            var danhsach = (from ds in db.DanhSachNghi
                            join cb in db.CanBo on ds.MaCBDaiDoi equals cb.MaCanBo
                            join dv in db.DonVi on cb.MaDonVi equals dv.MaDonVi
                            where dv.MaDonVi == cbo.MaDonVi && ds.PheDuyet == -1
                            select new
                            {
                                MaDS = ds.MaDS,
                                NgayDangKy = ds.NgayDK,
                                CanBoDaiDoi = cb.HoTen,
                                //PheDuyet = ds.PheDuyet,
                            }).ToList();
            danhsach.Reverse();

            gridControl1.DataSource = danhsach;
            gridControl2.DataSource = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int maDStoXoa = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]));
            MessageBox.Show(maDStoXoa.ToString());
        }
    }
}
