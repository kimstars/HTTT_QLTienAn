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
    public partial class Admin_CanBo : UserControl
    {
        public MyDBContext db = new MyDBContext();
        public CanBo cb = new CanBo();
        public Admin_CanBo()
        {
            InitializeComponent();
        }

        private void Admin_CanBo_Load(object sender, EventArgs e)
        {
            var ttcb = db.CanBo.ToList();
            dgvTTCB.DataSource = ttcb;
            LoadChiTietCB();
        }
        private void LoadChiTietCB()
        {
            try
            {
                int macb = (int)dgvTTCB_View.GetFocusedRowCellValue("MaCanBo");
                cb = db.CanBo.Where(p => p.MaCanBo == macb).FirstOrDefault();
            }
            catch { }
            txtCBCB_CT.EditValue = cb.CapBac;
            txtCVCB_CT.EditValue = cb.ChucVu;
            txtMDNCB_C.EditValue = cb.MaDangNhap;
            txtMDVCB_CT.EditValue = cb.MaDonVi;
            txtNSCB_CT.EditValue = ((DateTime)cb.NgaySinh).ToString("dd/MM/yy");
            txtTenCB_CT.EditValue = cb.HoTen;

            txtSuaMaCB.EditValue = cb.MaCanBo;
        }

        private void dgvTTCB_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietCB();
        }
        private bool Check()
        {
            if (txtThemTenCB.Text == "")
            {
                MessageBox.Show("Tên cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemChucVuCB.Text == "")
            {
                MessageBox.Show("Chức vụ của cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateThemNgaySinhCB.DateTime == null)
            {
                MessageBox.Show("Ngày sinh cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemCapBacCB.Text == "")
            {
                MessageBox.Show("Cấp bậc của cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (txtThemMaDNCB.Text == "")
            {
                MessageBox.Show("Mã đơn vị của cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaDNCB.Text == "")
            {
                MessageBox.Show("Mã đăng nhập của cán bộ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaDVCB.Text);
            }
            catch
            {
                MessageBox.Show("Mã đơn vị của cán bộ phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaDNCB.Text);
            }
            catch
            {
                MessageBox.Show("Mã đăng nhập của cán bộ phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int madvcb = int.Parse(txtThemMaDVCB.Text);
            int madncb = int.Parse(txtThemMaDNCB.Text);
            var temp_cb = db.DonVi.Where(p => p.MaDonVi == madvcb).FirstOrDefault();
            if (temp_cb == null)
            {
                MessageBox.Show("Mã đơn vị không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var temp_cb1 = db.TTDangNhap.Where(p => p.MaDangNhap == madncb).FirstOrDefault();
            if (temp_cb1 == null)
            {
                MessageBox.Show("Mã đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThemCB_Click(object sender, EventArgs e)
        {
            CanBo cb1 = new CanBo();
            if (Check())
            {
                cb1.HoTen = txtThemTenCB.Text;
                cb1.NgaySinh = dateThemNgaySinhCB.DateTime;
                cb1.CapBac = txtThemCapBacCB.Text;
                cb1.ChucVu = txtThemChucVuCB.Text;
                cb1.MaDonVi = int.Parse(txtThemMaDVCB.Text);
                cb1.MaDangNhap = int.Parse(txtThemMaDNCB.Text);
                db.CanBo.Add(cb1);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                dgvTTCB.DataSource = null;
                var ttcb1 = db.CanBo.ToList();
                dgvTTCB.DataSource = ttcb1;
                LoadChiTietCB();
                txtThemCapBacCB.Text = "";
                dateThemNgaySinhCB.EditValue = null;
                txtThemCapBacCB.Text = "";
                txtThemChucVuCB.Text = "";
                txtThemMaDVCB.Text = "";
                txtThemMaDNCB.Text = "";
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaCB_Click(object sender, EventArgs e)
        {
            CanBo cb2 = db.CanBo.Where(p => p.MaCanBo == cb.MaCanBo).FirstOrDefault();
            if (txtSuaMaDVCB.Text != "" && txtSuaMaDNCB.Text != "")
            {
                int madvcb = int.Parse(txtSuaMaDVCB.Text);
                int madncb = int.Parse(txtSuaMaDNCB.Text);
                var temp_cb = db.DonVi.Where(p => p.MaDonVi == madvcb).FirstOrDefault();
                if (temp_cb == null)
                {
                    MessageBox.Show("Mã đơn vị không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    cb2.MaDonVi = int.Parse(txtSuaMaDVCB.Text);
                }
                var temp_cb1 = db.TTDangNhap.Where(p => p.MaDangNhap == madncb).FirstOrDefault();
                if (temp_cb1 == null)
                {
                    MessageBox.Show("Mã đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    cb2.MaDangNhap = int.Parse(txtSuaMaDNCB.Text);
                }
            }
            if (txtSuaTenCB.Text != "") cb2.HoTen = txtSuaTenCB.Text;
            if (dateSuaNgaySinhCB.DateTime != null) cb2.NgaySinh = dateSuaNgaySinhCB.DateTime;
            if (txtSuaCapBacCB.Text != "") cb2.CapBac = txtSuaCapBacCB.Text;
            if (txtSuaChucVuCB.Text != "") cb2.ChucVu = txtSuaChucVuCB.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTTCB.DataSource = null;
            var tthv1 = db.CanBo.ToList();
            dgvTTCB.DataSource = tthv1;
            LoadChiTietCB();
           
            dateSuaNgaySinhCB.EditValue = null;
            txtSuaTenCB.Text = "";
            txtSuaCapBacCB.Text = "";
            txtSuaChucVuCB.Text = "";
            txtSuaMaDVCB.Text = "";
            txtSuaMaDNCB.Text = "";
        }
    }
}
