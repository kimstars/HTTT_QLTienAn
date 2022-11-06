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
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;

namespace HTTT_QLTienAn.GUI
{
    public partial class DaiDoi_NhapDanhSach : UserControl
    {
        MyDBContext db = new MyDBContext();
        int mahvTT = 0;
        int mahvRN = 0;

        List<HocVien_DangKyNghi> listDK = new List<HocVien_DangKyNghi>();

        public DaiDoi_NhapDanhSach()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            radioGroup1.SelectedIndex = 0;
            SetDefaultState();
        }

        public void ReloadAll()
        {
            DaiDoi_NhapDanhSach_Load(this, new EventArgs());
        }

        private void DaiDoi_NhapDanhSach_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = listDK;
            CanBo cb = db.CanBo.Where(s => s.MaCanBo == FormMain.maCB).FirstOrDefault();
            DonVi dv = db.DonVi.Where(s => s.MaDonVi == cb.MaDonVi).FirstOrDefault();
            gridControl1.DataSource = db.HocVien.Where(s => s.DonVi.TenDonVi == dv.TenDonVi).ToList();
        }

        private void SetDefaultState()
        {
            listDK.Clear();

            tbRN_HoTen.Text = "";
            tbRN_Lop.Text = "";
            tbTT_HoTen.Text = "";
            tbTT_Lop.Text = "";

            dtpRN_NgayNghi.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Saturday);
            dtpTT_NgayNghi.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Friday);
            dtpTT_NgayTra.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Sunday);

            chbRN_Sang.Checked = false;
            chbRN_Trua.Checked = false;
            chbRN_Toi.Checked = false;
            chbTT_SangNghi.Checked = false;
            chbTT_TruaNghi.Checked = false;
            chbTT_ToiNghi.Checked = true;
            chbTT_SangTra.Checked = true;
            chbTT_TruaTra.Checked = true;
            chbTT_ToiTra.Checked = false;

            gridControl2.DataSource = null;
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                mahvTT = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien"));
                tbTT_HoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
                tbTT_Lop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
            }
            else
            {
                mahvRN = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien"));
                tbRN_HoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
                tbRN_Lop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            if (edit.SelectedIndex == 0)
            {
                pnRaNgoai.Visible = false;
                pnTranhThu.Visible = true;
            }
            else
            {
                pnRaNgoai.Visible = true;
                pnTranhThu.Visible = false;
            }
        }

        private void btnRN_Them_Click(object sender, EventArgs e)
        {
            if (mahvRN == 0)
            {
                MessageBox.Show("Chưa chọn học viên");
                return;
            }

            if (chbRN_Sang.Checked == false && chbRN_Trua.Checked == false && chbRN_Toi.Checked == false)
            {
                MessageBox.Show("Chưa chọn buổi cắt cơm");
                return;
            }

            HocVien_DangKyNghi hv_dk = new HocVien_DangKyNghi();
            hv_dk.MaHocVien = mahvRN;
            hv_dk.HoTen = tbRN_HoTen.Text;
            hv_dk.Lop = tbRN_Lop.Text;
            hv_dk.NgayNghi = Convert.ToDateTime(dtpRN_NgayNghi.EditValue);
            hv_dk.Sang = chbRN_Sang.Checked ? 1 : 0;
            hv_dk.Trua = chbRN_Trua.Checked ? 1 : 0;
            hv_dk.Toi = chbRN_Toi.Checked ? 1 : 0;
            listDK.Add(hv_dk);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;
        }

        private void btnTT_Them_Click(object sender, EventArgs e)
        {
            if (mahvTT == 0)
            {
                MessageBox.Show("Chưa chọn học viên");
                return;
            }

            if (chbTT_SangNghi.Checked == false && chbTT_TruaNghi.Checked == false && chbTT_ToiNghi.Checked == false && chbTT_SangTra.Checked == false && chbTT_TruaTra.Checked == false && chbTT_ToiTra.Checked == false)
            {
                MessageBox.Show("Chưa chọn buổi cắt cơm");
                return;
            }

            HocVien_DangKyNghi hv_dk1 = new HocVien_DangKyNghi();
            hv_dk1.MaHocVien = mahvTT;
            hv_dk1.HoTen = tbTT_HoTen.Text;
            hv_dk1.Lop = tbTT_Lop.Text;

            hv_dk1.NgayNghi = Convert.ToDateTime(dtpTT_NgayNghi.EditValue);
            hv_dk1.Sang = chbTT_SangNghi.Checked ? 1 : 0;
            hv_dk1.Trua = chbTT_TruaNghi.Checked ? 1 : 0;
            hv_dk1.Toi = chbTT_ToiNghi.Checked ? 1 : 0;
            listDK.Add(hv_dk1);

            DateTime ngayTemp = hv_dk1.NgayNghi;
            while (DateTime.Compare(ngayTemp.AddDays(1), Convert.ToDateTime(dtpTT_NgayTra.EditValue)) < 0)
            {
                ngayTemp = ngayTemp.AddDays(1);
                HocVien_DangKyNghi temp = new HocVien_DangKyNghi();
                temp.MaHocVien = mahvTT;
                temp.HoTen = tbTT_HoTen.Text;
                temp.Lop = tbTT_Lop.Text;
                temp.NgayNghi = ngayTemp;
                temp.Sang = 1;
                temp.Trua = 1;
                temp.Toi = 1;
                listDK.Add(temp);
            }

            HocVien_DangKyNghi hv_dk2 = new HocVien_DangKyNghi();
            hv_dk2.MaHocVien = mahvTT;
            hv_dk2.HoTen = tbTT_HoTen.Text;
            hv_dk2.Lop = tbTT_Lop.Text;

            hv_dk2.NgayNghi = Convert.ToDateTime(dtpTT_NgayTra.EditValue);
            hv_dk2.Sang = chbTT_SangTra.Checked ? 1 : 0;
            hv_dk2.Trua = chbTT_TruaTra.Checked ? 1 : 0;
            hv_dk2.Toi = chbTT_ToiTra.Checked ? 1 : 0;

            listDK.Add(hv_dk2);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;
        }

        private void btnSendList_Click(object sender, EventArgs e)
        {
            // check danh sacsh co phan tu hay khog
            if (listDK.Count <= 0)
            {
                MessageBox.Show("Chưa có học viên nào được thêm");
                return;
            }

            DanhSachNghi ds = new DanhSachNghi();
            ds.NgayDK = DateTime.Now;
            ds.PheDuyet = -1;
            ds.MaCBDaiDoi = FormMain.maCB;
            db.DanhSachNghi.Add(ds);
            db.SaveChanges();

            var unique_HocVien = listDK.Select(o => o.MaHocVien).Distinct();

            foreach (var i in unique_HocVien)
            {
                DangKyNghi dk = new DangKyNghi();
                dk.MaDS = ds.MaDS;
                dk.MaHocVien = i;
                db.DangKyNghi.Add(dk);
                db.SaveChanges();

                foreach (var j in listDK)
                {
                    if (j.MaHocVien == i)
                    {
                        ChiTietNghi ctn = new ChiTietNghi();
                        ctn.NgayNghi = j.NgayNghi;
                        ctn.SoBuoiSang = j.Sang;
                        ctn.SoBuoiTrua = j.Trua;
                        ctn.SoBuoiToi = j.Toi;
                        ctn.MaDangKy = dk.MaDangKy;
                        db.ChiTietNghi.Add(ctn);
                        db.SaveChanges();
                    }
                }
            }

            db.SaveChanges();
            MessageBox.Show("Gửi danh sách thành công");

            SetDefaultState();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            listDK.RemoveAt(index);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;

        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            int row = gridView2.FocusedRowHandle;
            string colname = gridView2.Columns[gridView2.FocusedColumn.VisibleIndex].FieldName;
            int currVal = (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[colname]);
            switch (colname)
            {
                case "Sang":
                    listDK[row].Sang = currVal == 0 ? 1 : 0;
                    break;
                case "Trua":
                    listDK[row].Trua = currVal == 0 ? 1 : 0;
                    break;
                case "Toi":
                    listDK[row].Toi = currVal == 0 ? 1 : 0;
                    break;
                default:
                    break;
            }
            //MessageBox.Show(currVal.ToString());
        }
    }
}