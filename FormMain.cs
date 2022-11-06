using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using HTTT_QLTienAn.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTTT_QLTienAn
{
    public partial class FormMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        bool logout;

        DaiDoi_NhapDanhSach uc1;
        DaiDoi_ChoXacNhan uc2;
        DaiDoi_DaXacNhan uc3;
        DaiDoi_DaHuy uc4;

        TieuDoan_ChoXacNhan uc6;
        TieuDoan_DaXacNhan uc7;
        TieuDoan_DaHuy uc8;
        TieuDoan_TieuChuanAn uc9;
       

        NhaBep_QuanLyDanhSach uc10;
        NhaBep_ThanhToan uc11;
        NhaBep_ThongKe uc12;

        Admin_TTDangNhap uc20;
        Admin_HocVien uc21;
        Admin_CanBo uc22;
        Admin_DonVi uc23;

        public static int maCB;

        public FormMain(int maCanBo, string accPer)
        {
            InitializeComponent();
            maCB = maCanBo;
            logout = false;
            LoadByAccessPermission(accPer);
        }

        public FormMain(string accPer)
        {
            InitializeComponent();
            logout = false;
            LoadByAccessPermission(accPer);
        }

        public void LoadByAccessPermission(string accPer)
        {
            switch (accPer)
            {
                case "c":
                    this.Text = "Đại đội";

                    AccordionControlElement it1 = new AccordionControlElement(ElementStyle.Item) { Text = "Nhập danh sách" };
                    AccordionControlElement it2 = new AccordionControlElement(ElementStyle.Item) { Text = "Đang chờ duyệt" };
                    AccordionControlElement it3 = new AccordionControlElement(ElementStyle.Item) { Text = "Đã duyệt" };
                    AccordionControlElement it4 = new AccordionControlElement(ElementStyle.Item) { Text = "Đã hủy" };
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it1, it2, it3, it4 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it1.Click += It1_Click;
                    it2.Click += It2_Click;
                    it3.Click += It3_Click;
                    it4.Click += It4_Click;

                    uc1 = new DaiDoi_NhapDanhSach();
                    uc2 = new DaiDoi_ChoXacNhan();
                    uc3 = new DaiDoi_DaXacNhan();
                    uc4 = new DaiDoi_DaHuy();
                    uc1.Dock = DockStyle.Fill;
                    uc2.Dock = DockStyle.Fill;
                    uc3.Dock = DockStyle.Fill;
                    uc4.Dock = DockStyle.Fill;
                    fluentDesignFormContainer1.Controls.AddRange(new Control[] { uc1, uc2, uc3, uc4 });
                    

                    break;
                case "d":
                    this.Text = "Tiểu đoàn";

                    //AccordionControlElement gr1 = new AccordionControlElement(ElementStyle.Group) { Text = "Quản lý danh sách" };
                    AccordionControlElement it6 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đang chờ duyệt" };
                    AccordionControlElement it7 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã duyệt" };
                    AccordionControlElement it8 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã hủy" };
                    AccordionControlElement it9 = new AccordionControlElement(ElementStyle.Item) { Text = "Tiêu chuẩn ăn học viên" };
                    
                    //gr1.Elements.AddRange(new AccordionControlElement[] { it6, it7, it8 });
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it6,it7,it8, it9 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it6.Click += It6_Click;
                    it7.Click += It7_Click;
                    it8.Click += It8_Click;
                    it9.Click += It9_Click;
                    

                    uc6 = new TieuDoan_ChoXacNhan(maCB);
                    uc7 = new TieuDoan_DaXacNhan();
                    uc8 = new TieuDoan_DaHuy();
                    uc9 = new TieuDoan_TieuChuanAn();
                   

                    uc6.Dock = DockStyle.Fill;
                    uc7.Dock = DockStyle.Fill;
                    uc8.Dock = DockStyle.Fill;
                    uc9.Dock = DockStyle.Fill;
    

                    fluentDesignFormContainer1.Controls.AddRange(new Control[] { uc6, uc7, uc8, uc9 });
                    uc6.BringToFront();

                    break;
                case "nb":
                    this.Text = "Nhà bếp";

                    AccordionControlElement it10 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lý danh sách" };
                    AccordionControlElement it11 = new AccordionControlElement(ElementStyle.Item) { Text = "Thanh toán" };
                    AccordionControlElement it12 = new AccordionControlElement(ElementStyle.Item) { Text = "Thống kê" };
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it10, it11, it12 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it10.Click += It10_Click;
                    it11.Click += It11_Click;
                    it12.Click += It12_Click;

                    uc10 = new NhaBep_QuanLyDanhSach();
                    uc11 = new NhaBep_ThanhToan();
                    uc12 = new NhaBep_ThongKe();
                    uc10.Dock = DockStyle.Fill;
                    uc11.Dock = DockStyle.Fill;
                    uc12.Dock = DockStyle.Fill;
                    fluentDesignFormContainer1.Controls.AddRange(new Control[] { uc10, uc11, uc12 });
                    uc10.BringToFront();
                    break;

                case "admin":
                    this.Text = "Quản lý";
                    AccordionControlElement it20 = new AccordionControlElement(ElementStyle.Item) { Text = "Tài khoản đăng nhập" };
                    AccordionControlElement it21 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lí học viên" };
                    AccordionControlElement it22 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lí cán bộ" };
                    AccordionControlElement it23 = new AccordionControlElement(ElementStyle.Item) { Text = "Thông tin đơn vị" };
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it20, it21, it22,it23 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it20.Click += It20_Click;
                    it21.Click += It21_Click;
                    it22.Click += It22_Click;
                    it23.Click += It23_Click;

                    uc20 = new Admin_TTDangNhap();
                    uc21 = new Admin_HocVien();
                    uc22 = new Admin_CanBo();
                    uc23 = new Admin_DonVi();

                    uc20.Dock = DockStyle.Fill;
                    uc21.Dock = DockStyle.Fill;
                    uc22.Dock = DockStyle.Fill;
                    uc23.Dock = DockStyle.Fill;

                    fluentDesignFormContainer1.Controls.AddRange(new Control[] { uc20, uc21, uc22,uc23 });
                    uc20.BringToFront();
                    break;
                default:
                    break;
            }
        }

        #region click events
        private void It12_Click(object sender, EventArgs e)
        {
            uc12.reload();
            uc12.BringToFront();
        }

        private void It11_Click(object sender, EventArgs e)
        {
            uc11.reload();
            uc11.BringToFront();
        }

        private void It10_Click(object sender, EventArgs e)
        {
            uc10.BringToFront();
        }

        private void It9_Click(object sender, EventArgs e)
        {
            uc9.BringToFront();
        }
        private void It8_Click(object sender, EventArgs e)
        {
            uc8.LoadDSDaHuy();
            uc8.BringToFront();
        }

        private void It7_Click(object sender, EventArgs e)
        {
            uc7.LoadDSDaXacNhan();
            uc7.BringToFront();
        }

        private void It6_Click(object sender, EventArgs e)
        {
            uc6.LoadDSCho();
            uc6.BringToFront();
        }

        private void It4_Click(object sender, EventArgs e)
        {
            uc4.ReloadAll();
            uc4.BringToFront();
        }

        private void It3_Click(object sender, EventArgs e)
        {
            uc3.ReloadAll();
            uc3.BringToFront();
        }

        private void It2_Click(object sender, EventArgs e)
        {
            uc2.ReloadAll();
            uc2.BringToFront();
        }

        private void It1_Click(object sender, EventArgs e)
        {
            uc2.ReloadAll();
            uc1.BringToFront();
        }
        #endregion
        private void It23_Click(object sender, EventArgs e)
        {
            uc23.BringToFront();
        }
        private void It22_Click(object sender, EventArgs e)
        {
            uc22.BringToFront();
        }

        private void It21_Click(object sender, EventArgs e)
        {
            uc21.BringToFront();
        }

        private void It20_Click(object sender, EventArgs e)
        {
            uc20.BringToFront();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout == false)
            {
                Application.Exit();
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout = true;
            this.Close();
        }
    }
}
