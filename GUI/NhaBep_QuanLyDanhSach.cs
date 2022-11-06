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

namespace HTTT_QLTienAn.GUI
{
    public partial class NhaBep_QuanLyDanhSach : UserControl
    {
        MyDBContext db = new MyDBContext();

        public NhaBep_QuanLyDanhSach()
        {
            InitializeComponent();
        }

        private void NhaBep_QuanLyDanhSach_Load(object sender, EventArgs e)
        {

            //Load Ngay Hom nay:
            dtpNgayC.EditValueChanged -= dtpNgayC_EditValueChanged;
            dtpNgayD.EditValueChanged -= dtpNgayD_EditValueChanged;
            dtpNgayC.EditValue = DateTime.Now;
            dtpNgayD.EditValue = DateTime.Now;
            dtpNgayC.EditValueChanged += dtpNgayC_EditValueChanged;
            dtpNgayD.EditValueChanged += dtpNgayD_EditValueChanged;


            //Load don vi:
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
            List<DonVi> lstDonVi = db.DonVi.ToList();
            cbbDonVi.Items.Clear();
            foreach (var item in lstDonVi.ToList())
            {
                if (item.TenDonVi.Contains("c"))
                {
                    cbbDonVi.Items.Add(item.TenDonVi);
                }
            }
            cbbDonVi.SelectedIndex = 0;
            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;

            //Load quan so:
            StartupLoadQuanSoD();

            LoadQuanSoC();

            LoadQuanSoD();

            LoadDBDaiDoi();


        }


        private void LoadDBDaiDoi()
        {
            ClearGridControl();

            var thisDate = dtpNgayC.DateTime.Date;
            string tenDonVi = cbbDonVi.SelectedItem.ToString();

            List<DonVi> lstDonVi = db.DonVi.ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == tenDonVi).MaDonVi;

            List<NhaBep_ListCatCom> lstCatCom = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayNghi) == thisDate.Date && s.MaDonVi == maC).ToList();

            gridView1.Columns[3].Visible = false;
            gridControl1.DataSource = lstCatCom;
            gridControl1.Refresh();

            int sobuoisang = lstCatCom.Count(s => s.SoBuoiSang == 1);
            int sobuoitrua = lstCatCom.Count(s => s.SoBuoiTrua == 1);
            int sobuoitoi = lstCatCom.Count(s => s.SoBuoiToi == 1);
            int quansoC = LoadQuanSoC();
            textEdit1.Text = (quansoC - sobuoisang).ToString();
            textEdit2.Text = (quansoC - sobuoitrua).ToString();
            textEdit3.Text = (quansoC - sobuoitoi).ToString();
            

        }

        private void LoadDBTieuDoan()
        {
            var thisDate = dtpNgayD.DateTime.Date;
            ClearGridControl();

            List<NhaBep_ListCatCom> lstCatComD = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayNghi) == thisDate.Date).ToList();

            gridView1.Columns[3].Visible = true;
            gridControl1.DataSource = lstCatComD;
            gridControl1.Refresh();

            int sobuoisang = lstCatComD.Count(s => s.SoBuoiSang == 1);
            int sobuoitrua = lstCatComD.Count(s => s.SoBuoiTrua == 1);
            int sobuoitoi = lstCatComD.Count(s => s.SoBuoiToi == 1);
            int quansoD = LoadQuanSoD();
            textEdit4.Text = (quansoD - sobuoisang).ToString();
            textEdit5.Text = (quansoD - sobuoitrua).ToString();
            textEdit11.Text = (quansoD - sobuoitoi).ToString();
        }

        private int LoadQuanSoC()
        {
            List<DonVi> lstDonVi = db.DonVi.ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;
            int quansoC = db.HocVien.Where(s => s.MaDonVi == maC).ToList().Count;
            textEdit7.Text = quansoC.ToString();
            textEdit8.Text = quansoC.ToString();
            textEdit9.Text = quansoC.ToString();

            return quansoC;

        }


        private int LoadQuanSoD()
        {
            int quansoD = db.HocVien.ToList().Count;
            textEdit6.Text = quansoD.ToString();
            textEdit10.Text = quansoD.ToString();
            textEdit12.Text = quansoD.ToString();

            return quansoD;
        }

        private void StartupLoadQuanSoD()
        {
            var thisDate = dtpNgayD.DateTime.Date;
            List<NhaBep_ListCatCom> lstCatComD = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayNghi) == thisDate.Date).ToList();

            int sobuoisang = lstCatComD.Count(s => s.SoBuoiSang == 1);
            int sobuoitrua = lstCatComD.Count(s => s.SoBuoiTrua == 1);
            int sobuoitoi = lstCatComD.Count(s => s.SoBuoiToi == 1);
            int quansoD = LoadQuanSoD();
            textEdit4.Text = (quansoD - sobuoisang).ToString();
            textEdit5.Text = (quansoD - sobuoitrua).ToString();
            textEdit11.Text = (quansoD - sobuoitoi).ToString();

        }
        private void ClearGridControl()
        {
            gridControl1.BeginUpdate();
            try
            {
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DonVi> lstDonVi = db.DonVi.ToList();
            colTenDonVi.Visible = false;

            LoadDBDaiDoi();
        }

        private void dtpNgayC_EditValueChanged(object sender, EventArgs e)
        {
            colTenDonVi.Visible = false;
            LoadDBDaiDoi();
        }

        private void dtpNgayD_EditValueChanged(object sender, EventArgs e)
        {
            colTenDonVi.Visible = true;
            LoadDBTieuDoan();
        }
    }
}
