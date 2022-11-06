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
    public partial class Admin_HocVien : UserControl
    {
        public MyDBContext db = new MyDBContext();
        public HocVien hv = new HocVien();
        public Admin_HocVien()
        {
            InitializeComponent();
        }

        private void Admin_HocVien_Load(object sender, EventArgs e)
        {
            var tthv = db.HocVien.ToList();
            dgvTTHV.DataSource = tthv;
            LoadChiTietHV();
        }
        public void LoadChiTietHV()
        {
            try
            {
                int mahv = (int)dgvTTHV_View.GetFocusedRowCellValue("MaHocVien");
                hv = db.HocVien.Where(p => p.MaHocVien == mahv).FirstOrDefault();
            }
            catch { }
            txtTenHV_CT.EditValue = hv.HoTen;
            txtLopHV_CT.EditValue = hv.Lop;
            txtCapBacHV_CT.EditValue = hv.CapBac;
            txtChucVuHV_CT.EditValue = hv.ChucVu;
            txtMaDVHV_CT.EditValue = hv.MaDonVi;
            txtMaTCAHV_CT.EditValue = hv.MaTCA;
            txtNgaySinhHV_CT.EditValue =  hv.NgaySinh.ToString("dd/MM/yy");

            txtSuaMaHV.EditValue = hv.MaHocVien;

        }

        private void dgvTTHV_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietHV();
        }
        private bool Check()
        {
            if (txtThemTenHV.Text == "")
            {
                MessageBox.Show("Tên học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemLopHV.Text == "")
            {
                MessageBox.Show("Lớp của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateThemHV.DateTime == null)
            {
                MessageBox.Show("Ngày sinh học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemCapBacHV.Text == "")
            {
                MessageBox.Show("Cấp bậc của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemChucVuHV.Text == "")
            {
                MessageBox.Show("Chức vụ của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaDonViHV.Text == "")
            {
                MessageBox.Show("Mã đơn vị của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaTCAHV.Text == "")
            {
                MessageBox.Show("Mã tiêu chuẩn ăn của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaDonViHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã đơn vị của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaTCAHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã tiêu chuẩn ăn của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int madvhv = int.Parse(txtThemMaDonViHV.Text);
            int matcahv= int.Parse(txtThemMaTCAHV.Text);
            var temp_hv = db.DonVi.Where(p => p.MaDonVi == madvhv).FirstOrDefault();
            if(temp_hv == null)
            {
                MessageBox.Show("Mã đơn vị không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var temp_hv1 = db.TieuChuanAn.Where(p => p.MaTCA == matcahv).FirstOrDefault();
            if (temp_hv1 == null)
            {
                MessageBox.Show("Mã tiêu chuẩn không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThemHV_Click(object sender, EventArgs e)
        {
            HocVien hv1 = new HocVien();
            if (Check())
            {
                hv1.HoTen = txtThemTenHV.Text;
                hv1.Lop = txtThemLopHV.Text;
                hv1.NgaySinh = dateThemHV.DateTime;
                hv1.CapBac = txtThemCapBacHV.Text;
                hv1.ChucVu = txtThemChucVuHV.Text;
                hv1.MaDonVi = int.Parse(txtThemMaDonViHV.Text);
                hv1.MaTCA = int.Parse(txtThemMaTCAHV.Text);
                db.HocVien.Add(hv1);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                dgvTTHV.DataSource = null;
                var tthv1 = db.HocVien.ToList();
                dgvTTHV.DataSource = tthv1;
                LoadChiTietHV();
                txtThemTenHV.Text = "";
                txtThemLopHV.Text = "";
                dateThemHV.EditValue = null;
                txtThemCapBacHV.Text = "";
                txtThemChucVuHV.Text = "";
                txtThemMaDonViHV.Text = "";
                txtThemMaTCAHV.Text = "";
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaHV_Click(object sender, EventArgs e)
        {

            HocVien hv2 = db.HocVien.Where(p => p.MaHocVien == hv.MaHocVien).FirstOrDefault();
            if (txtSuaMaDVHV.Text != "" && txtSuaMaTCA.Text != "")
            {
                int madvhv = int.Parse(txtSuaMaDVHV.Text);
                int matcahv = int.Parse(txtSuaMaTCA.Text);
                var temp_hv = db.DonVi.Where(p => p.MaDonVi == madvhv).FirstOrDefault();
                if (temp_hv == null)
                {
                    MessageBox.Show("Mã đơn vị không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    hv2.MaDonVi = int.Parse(txtSuaMaDVHV.Text);
                }
                var temp_hv1 = db.TieuChuanAn.Where(p => p.MaTCA == matcahv).FirstOrDefault();
                if (temp_hv1 == null)
                {
                    MessageBox.Show("Mã tiêu chuẩn không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    hv2.MaTCA = int.Parse(txtSuaMaTCA.Text);
                }
            }
            if (txtSuaTenHV.Text != "") hv2.HoTen = txtSuaTenHV.Text;
            if (txtSuaLopHV.Text != "") hv2.Lop = txtSuaLopHV.Text;
            if (dateSuaHV.DateTime != null) hv2.NgaySinh = dateSuaHV.DateTime;
            if (txtSuaCapBacHV.Text != "") hv2.CapBac = txtSuaCapBacHV.Text;
            if (txtSuaChucVuHV.Text != "") hv2.ChucVu = txtSuaChucVuHV.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTTHV.DataSource = null;
            var tthv1 = db.HocVien.ToList();
            dgvTTHV.DataSource = tthv1;
            LoadChiTietHV();
            txtSuaLopHV.Text = "";
            dateSuaHV.EditValue = null;
            txtSuaTenHV.Text = "";
            txtSuaCapBacHV.Text = "";
            txtSuaChucVuHV.Text = "";
            txtSuaMaDVHV.Text = "";
            txtSuaMaTCA.Text = "";
        }
    }
}
