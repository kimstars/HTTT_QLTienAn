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
    public partial class NhaBep_ThongKe : UserControl
    {
        MyDBContext db = new MyDBContext();

        public NhaBep_ThongKe()
        {
            InitializeComponent();
            dtpCuoi.EditValue = DateTime.Now;
            dtpDau.EditValue = DateTime.Now.AddMonths(-1);
            //dtpCuoi.Properties.MaxValue = DateTime.Now;
            //dtpDau.Properties.MaxValue = DateTime.Now;
            LoadDataChart1();
            LoadDataChart2();
        }

        private void LoadDataChart1()
        {
            List<Class_RPNhaBep> lstData = new List<Class_RPNhaBep>();

            List<ThanhToan> lstThanhToan = 
                db.ThanhToan.Where(s => DbFunctions.TruncateTime(s.NgayTT) >= dtpDau.DateTime.Date && DbFunctions.TruncateTime(s.NgayTT) <= dtpCuoi.DateTime.Date).ToList();

            int tongtien = 0;

            foreach(var item in lstThanhToan)
            {
                var thisItem = lstData.Find(s => s.ngay == (DateTime)item.NgayTT);
                if (thisItem != null)
                {
                    thisItem.sotien += item.TongTien;
                }
                else
                {
                    thisItem = new Class_RPNhaBep();
                    thisItem.ngay = (DateTime) item.NgayTT;
                    thisItem.sotien = item.TongTien;
                    lstData.Add(thisItem);
                }

                

                
            }

            //chartControl1.DataSource = null;
            //chartControl1.Series.Clear();
            //chartControl1.DataSource = lstData;
            //chartControl1.Refresh();
            chartControl1.Series["BDTien"].Points.Clear();
            
            foreach(var item in lstData)
            {
                chartControl1.Series["BDTien"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.ngay, item.sotien));
                tongtien += item.sotien;
            }

            chartControl1.Refresh();

            txtTongTien.Text = tongtien.ToString();

        }



        private void LoadDataChart2()
        {
            List<ChiTietNghi> lstCTT = db.ChiTietNghi.Where(s => DbFunctions.TruncateTime(s.NgayNghi) >= dtpDau.DateTime.Date && DbFunctions.TruncateTime(s.NgayNghi) <= dtpCuoi.DateTime.Date).ToList();


            List<Class_RPNhaBep> lstData = new List<Class_RPNhaBep>();

            int soluot = 0;

            foreach(var item in lstCTT)
            {
                var thisItem = lstData.Find(s => s.ngay == (DateTime)item.NgayNghi);

                if(thisItem != null)
                {
                    thisItem.sotien = ((int)item.SoBuoiSang + (int)item.SoBuoiTrua + (int)item.SoBuoiToi + thisItem.sotien);
                }
                else
                {
                    thisItem = new Class_RPNhaBep();
                    thisItem.ngay = item.NgayNghi.Date;
                    thisItem.sotien = (int)item.SoBuoiSang + (int)item.SoBuoiToi + (int)item.SoBuoiTrua;
                    lstData.Add(thisItem);
                }
                
                
            }

            chartControl2.Series["BDLuot"].Points.Clear();
            foreach(var item in lstData)
            {
                chartControl2.Series["BDLuot"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.ngay, item.sotien));
                soluot += item.sotien;
            }
            chartControl2.Refresh();

            txtLuot.Text = soluot.ToString();

        }
        public void reload()
        {
            LoadDataChart1();
            LoadDataChart2();
        }

        private void dtpDau_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataChart1();
            LoadDataChart2();
        }

        private void dtpCuoi_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataChart1();
            LoadDataChart2();
        }
    }
}
