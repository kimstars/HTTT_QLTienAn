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
    public partial class TieuDoan_TieuChuanAn : UserControl
    {
        public MyDBContext db = new MyDBContext();
        public TieuChuanAn tieuChuanAn = new TieuChuanAn();
        public TieuChuanAn t = new TieuChuanAn();
        public TieuDoan_TieuChuanAn()
        {
            InitializeComponent();
        }

        private void TieuDoan_TieuChuanAn_Load(object sender, EventArgs e)
        {
            var tca = db.TieuChuanAn.ToList();
            tca.Reverse();
            dgvLichSuTCA.DataSource = tca;
            LoadChiTietTCA();
        }
        public void LoadChiTietTCA()
        {
            try
            {
                int id = (int)dgvTCA_View.GetFocusedRowCellValue("MaTCA");
                tieuChuanAn = db.TieuChuanAn.Where(p => p.MaTCA == id).FirstOrDefault();
            }
            catch
            {

            }
            dateNgayApDung.DateTime = tieuChuanAn.NgayApDung;
            txtBuaSang.EditValue = tieuChuanAn.TienAnSang;
            txtBuaTrua.EditValue = tieuChuanAn.TienAnTrua;
            txtBuaToi.EditValue = tieuChuanAn.TienAnToi;
            txtTienCoBan.EditValue = tieuChuanAn.TienAnCoBan;
            txtTienHocVien.EditValue = (int)tieuChuanAn.TienAnSang + (int)tieuChuanAn.TienAnTrua + (int)tieuChuanAn.TienAnToi;
        }
        private bool check()
        {
            if (txtEditCoBan.Text == "")
            {
                MessageBox.Show("Tiền ăn cơ bản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditSang.Text == "")
            {
                MessageBox.Show("Tiền ăn sáng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditTrua.Text == "")
            {
                MessageBox.Show("Tiền ăn trưa không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditToi.Text == "")
            {
                MessageBox.Show("Tiền ăn tối không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditToi.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn tối phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditSang.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn sáng phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditTrua.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn trưa phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditCoBan.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn cơ bản phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {
               
                int count = db.TieuChuanAn.Count();
                t.MaTCA = count + 1;
                t.TienAnCoBan = int.Parse(txtEditCoBan.Text);
                t.TienAnSang = int.Parse(txtEditSang.Text);
                t.TienAnTrua = int.Parse(txtEditTrua.Text);
                t.TienAnToi = int.Parse(txtEditToi.Text);
                t.NgayApDung = dateEditNgayApDung.DateTime;
                db.TieuChuanAn.Add(t);
                db.SaveChanges();
                MessageBox.Show("Lưu tiêu chuẩn ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLichSuTCA.DataSource = null;
                var tca = db.TieuChuanAn.ToList();
                dgvLichSuTCA.DataSource = tca;
                txtEditToi.EditValue = "";
                txtEditSang.EditValue = "";
                txtEditTrua.EditValue = "";
                txtEditCoBan.EditValue = "";
            }
        }

        private void dgvTCA_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietTCA();
        }

       
    }
}
