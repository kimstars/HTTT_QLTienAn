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
    public partial class Admin_DonVi : UserControl
    {
        public MyDBContext db = new MyDBContext();
        public int madv;
        public Admin_DonVi()
        {
            InitializeComponent();
        }

        private void Admin_DonVi_Load(object sender, EventArgs e)
        {
            var dv = db.DonVi.ToList();
            dgvDV.DataSource = dv;
            LoadChiTietDonVi();
        }

        private void LoadChiTietDonVi()
        {
            try
            {
                madv = (int)dgvDV_View.GetFocusedRowCellValue("MaDonVi");
            }
            catch { }
            txtSuaMaDV.EditValue = madv;
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            DonVi dv1 = new DonVi();
            if(txtThemTenDV.Text == "")
            {
                MessageBox.Show("Tên học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dv1.TenDonVi = txtThemTenDV.Text;
                db.DonVi.Add(dv1);
                db.SaveChanges();
                dgvDV.DataSource = null;
                var dv = db.DonVi.ToList();
                dgvDV.DataSource = dv;
                txtThemTenDV.Text = "";
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            DonVi dv1 = db.DonVi.Where(p => p.MaDonVi == madv).FirstOrDefault();
            if (txtSuaTenDV.Text != "") dv1.TenDonVi = txtSuaTenDV.Text;
            db.SaveChanges();
            dgvDV.DataSource = null;
            var dv = db.DonVi.ToList();
            dgvDV.DataSource = dv;
            LoadChiTietDonVi();
            txtSuaTenDV.Text = "";
        }

        private void dgvDV_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietDonVi();
        }
    }
}
