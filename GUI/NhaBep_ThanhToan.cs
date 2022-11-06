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
using System.Data.Entity.Infrastructure;

namespace HTTT_QLTienAn.GUI
{
    public partial class NhaBep_ThanhToan : UserControl
    {
        MyDBContext db = new MyDBContext();

        


        public NhaBep_ThanhToan()
        {
            InitializeComponent();
        }
        public void reload()
        {
            cbbDonVi.Items.Clear();
            NhaBep_ThanhToan_Load(this, new EventArgs());
        }
        private void NhaBep_ThanhToan_Load(object sender, EventArgs e)
        {
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;

            List<DonVi> lstDonVi = db.DonVi.Where(s => s.TenDonVi.Contains("c")).ToList();
            foreach (var item in lstDonVi)
            {
                cbbDonVi.Items.Add(item.TenDonVi);
            }
            cbbDonVi.SelectedIndex = 1;

            cbbLop.SelectedIndex = -1;
            cbbLop.Text = "";

            LoadDataIntoComboBoxLop(cbbDonVi.SelectedItem.ToString(), lstDonVi);



            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
        }

        private void LoadDataIntoComboBoxLop(string tenDonVi, List<DonVi> lstDonVi)
        {
            //Clear Old List:
            cbbLop.Items.Clear();

            int maC = lstDonVi.Find(s => s.TenDonVi == tenDonVi).MaDonVi;

            var lstLopHocVien = db.HocVien.Where(s => s.MaDonVi == maC).Select(s => new { s.Lop }).Distinct().ToList();

            foreach (var item in lstLopHocVien)
            {
                cbbLop.Items.Add(item.Lop.ToString());
            }
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DonVi> lstDonVi = db.DonVi.Where(s => s.TenDonVi.Contains("c")).ToList();
            LoadDataIntoComboBoxLop(cbbDonVi.SelectedItem.ToString(), lstDonVi);

            //Clear Selected Item:
            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
            cbbLop.Text = "";
            cbbLop.SelectedIndex = -1;
            cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
        }

        private void ClearDataShowed()
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

            gridControl2.BeginUpdate();
            try
            {
                gridControl2.DataSource = null;
                gridControl2.Refresh();
            }
            finally
            {
                gridControl2.EndUpdate();
            }

            //Clear TextBox:

        }

        private void LoadDataGridControl1()
        {
            List<DonVi> lstDonVi = db.DonVi.Where(s => s.TenDonVi.Contains("c")).ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;
            string Lop = cbbLop.SelectedItem.ToString();
            List<NhaBep_LichSuCatComLop> lstCatComLop =
                db.NhaBep_LichSuCatComLop.Where(s => s.MaDonVi == maC && s.Lop == Lop && s.TrangThaiTT == 1 ).ToList();

            gridControl1.DataSource = lstCatComLop;
            gridControl1.Refresh();



        }

        private List<Class_DuLieuCatComHienthiGirdView> LoadDataGridControl2()
        {
            UndoingChangesDbContextLevel(db);
            List<DonVi> lstDonVi = db.DonVi.Where(s => s.TenDonVi.Contains("c")).ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;
            string Lop = cbbLop.SelectedItem.ToString();

            //FIx bug tạo thanh toán:
            List<NhaBep_FindToCreateThanhToan> lstFindToCreate = db.NhaBep_FindToCreateThanhToan.ToList();

            List<ThanhToan> lstThanhToanMoiThem = new List<ThanhToan>();
            foreach(var item in lstFindToCreate)
            {
                ThanhToan temp = new ThanhToan();
                temp.TongTien = 0;
                temp.NgayTT = null;
                temp.TrangThaiTT = -2;
                temp.MaHocVien = item.MaHocVien;
                db.ThanhToan.Add(temp);
                db.SaveChanges();

                lstThanhToanMoiThem.Add(temp);
            }

            foreach(var item in lstFindToCreate)
            {

                foreach(var item2 in lstThanhToanMoiThem)
                {
                    if(item.MaHocVien == item2.MaHocVien)
                    {
                        //BUGGG:

                        ThanhToan temp = db.ThanhToan.Where(s => s.TrangThaiTT == -2 && s.MaHocVien == item.MaHocVien && s.NgayTT == null && s.TongTien == 0).FirstOrDefault();

                        DangKyNghi thisDKN = db.DangKyNghi.Where(s => s.MaDangKy == item.MaDangKy).FirstOrDefault();
                        
                        thisDKN.MaThanhToan = temp.MaThanhToan;
                        temp.TrangThaiTT = 0;
                        db.SaveChanges();
                    }

                }
                 

            }

            List<NhaBep_CatComChuaThanhToan> lstChuaThanhToan = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC && s.Lop == Lop).ToList();


            /////////////////////////////////////////////////////////////////////////
            /// New Method to Calculate:


            List<TieuChuanAn> lstTCA = db.TieuChuanAn.ToList();

            List<Object_ThanhToan> lstObj_Thanhtoan = new List<Object_ThanhToan>();
            foreach(var item in lstChuaThanhToan)
            {
                List<ChiTietNghi> item_lstCTN = db.ChiTietNghi.Where(s => s.MaDangKy == item.MaDangKy).ToList();

                foreach(var itemCTN in item_lstCTN)
                {
                    Object_ThanhToan temp = new Object_ThanhToan();
                    temp.maDKy = item.MaDangKy;
                    temp.maCTN = itemCTN.MaCTNghi;
                    temp.maHV = item.MaHocVien;
                    temp.maThanhToan = item.MaThanhToan;
                    temp.ngayNghi = itemCTN.NgayNghi;
                    temp.sang = (int)itemCTN.SoBuoiSang;
                    temp.trua =(int) itemCTN.SoBuoiTrua;
                    temp.toi =(int) itemCTN.SoBuoiToi;

                    temp.AutoFindTCA_CALTienCTN(lstTCA);

                    lstObj_Thanhtoan.Add(temp);
                }
                
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<ThanhToan> DayLaListCacThanhToan_DuocTinh = new List<ThanhToan>();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //Save ThanhToan
            foreach(var item in lstObj_Thanhtoan)
            {
                ThanhToan temp = db.ThanhToan.Where(s => s.MaThanhToan == item.maThanhToan).First();
                if ((int)temp.MaThanhToan == item.maThanhToan)
                {
                    if (temp.TongTien == null)
                    {
                        temp.TongTien = item.TienCuaCTN;
                    }
                    else
                        temp.TongTien += item.TienCuaCTN;
                }
                else
                {
                    continue;
                }
                temp.NgayTT = DateTime.Now;
                temp.TrangThaiTT = 1;

                if(DayLaListCacThanhToan_DuocTinh.Contains(temp) == false)
                    DayLaListCacThanhToan_DuocTinh.Add(temp);

                //UndoingChangesDbContextLevel(db);
            }

            //Danh dau CONHABEP:
            List<DanhSachNghi> thisDanhSachNghi = new List<DanhSachNghi>();
            foreach(var item in lstChuaThanhToan)
            {
                DanhSachNghi temp = db.DanhSachNghi.Where(s => s.MaDS == item.MaDS).First();

                if(thisDanhSachNghi.Contains(temp) == false)
                {
                    thisDanhSachNghi.Add(temp);
                }
            }

            foreach(var item in thisDanhSachNghi)
            {
                DanhSachNghi temp = db.DanhSachNghi.Where(s => s.MaDS == item.MaDS).First();
                temp.MaCBNhaBep = FormMain.maCB; //Ma: CONHABEP
                //UndoingChangesDbContextLevel(db);
            }

            //Tinh Toan de Hien Ket qua:
            int TongSoSang = 0;
            int TongSoTrua = 0;
            int TongSoToi = 0;
            int TongSoTien1 = 0;
            foreach(var item in lstObj_Thanhtoan)
            {
                TongSoSang += item.sang;
                TongSoTrua += item.trua;
                TongSoToi += item.toi;
                TongSoTien1 += item.TienCuaCTN;
            }

            //Tinhs de ktra cho chac
            int TongSoTien2 = 0;
            foreach(var item in DayLaListCacThanhToan_DuocTinh)
            {
                TongSoTien2 += item.TongTien;
            }

            //Show text:
            textEdit1.Text = TongSoSang.ToString();
            textEdit2.Text = TongSoTrua.ToString();
            textEdit3.Text = TongSoToi.ToString();
            textEdit4.Text = TongSoTien1.ToString();

            //Hien ra List:
            List<Class_DuLieuCatComHienthiGirdView> lstHienThi = new List<Class_DuLieuCatComHienthiGirdView>();
            foreach(var item in lstChuaThanhToan)
            {
                Class_DuLieuCatComHienthiGirdView temp = new Class_DuLieuCatComHienthiGirdView();
                temp.maHV = item.MaHocVien;
                temp.Hoten = item.HoTen;
                temp.TongTien = db.ThanhToan.Where(s => s.MaThanhToan == item.MaThanhToan).FirstOrDefault().TongTien;

                int sang = 0, trua = 0, toi = 0;

                List<ChiTietNghi> _tempCTN = db.ChiTietNghi.Where(s => s.MaDangKy == item.MaDangKy).ToList();

                foreach(var itemCTN in _tempCTN)
                {
                    sang +=(int) itemCTN.SoBuoiSang;
                    trua += (int)itemCTN.SoBuoiTrua;
                    toi += (int)itemCTN.SoBuoiToi;
                }
                temp.sobuasang = sang;
                temp.sobuatoi = toi;
                temp.sobuatrua = trua;

                lstHienThi.Add(temp);
            }
            gridControl2.BeginUpdate();
            gridView2.Columns.Clear();
            gridControl2.DataSource = lstHienThi.Select(s => new { s.Hoten, s.sobuasang, s.sobuatrua, s.sobuatoi, s.TongTien });
            gridControl2.RefreshDataSource();
            gridControl2.Refresh();
            gridControl2.EndUpdate();
            if (gridView2.RowCount > 0 && gridView2.Columns.Count == 5)
            {
                gridView2.Columns[0].Caption = "Họ tên";
                gridView2.Columns[1].Caption = "Số bữa sáng";
                gridView2.Columns[2].Caption = "Số bữa trưa";
                gridView2.Columns[3].Caption = "Số bữa tối";
                gridView2.Columns[4].Caption = "Tổng tiền";
            }


            return lstHienThi;
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataShowed();

            LoadDataGridControl1();

            LoadDataGridControl2();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UndoingChangesDbContextLevel(db);
            List<DonVi> lstDonVi = db.DonVi.Where(s => s.TenDonVi.Contains("c")).ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;
            string Lop = cbbLop.SelectedItem.ToString();

            //FIx bug tạo thanh toán:
            List<NhaBep_FindToCreateThanhToan> lstFindToCreate = db.NhaBep_FindToCreateThanhToan.ToList();

            List<ThanhToan> lstThanhToanMoiThem = new List<ThanhToan>();
            foreach (var item in lstFindToCreate)
            {
                ThanhToan temp = new ThanhToan();
                temp.TongTien = 0;
                temp.NgayTT = null;
                temp.TrangThaiTT = -2;
                temp.MaHocVien = item.MaHocVien;
                db.ThanhToan.Add(temp);
                db.SaveChanges();

                lstThanhToanMoiThem.Add(temp);
            }

            foreach (var item in lstFindToCreate)
            {

                foreach (var item2 in lstThanhToanMoiThem)
                {
                    if (item.MaHocVien == item2.MaHocVien)
                    {
                        ThanhToan temp = db.ThanhToan.Where(s => s.TrangThaiTT == -2 && s.MaHocVien == item.MaHocVien && s.NgayTT == null && s.TongTien == 0).FirstOrDefault();

                        DangKyNghi thisDKN = db.DangKyNghi.Where(s => s.MaDangKy == item.MaDangKy).FirstOrDefault();

                        thisDKN.MaThanhToan = temp.MaThanhToan;
                        temp.TrangThaiTT = 0;
                        db.SaveChanges();
                    }

                }
            }

            List<NhaBep_CatComChuaThanhToan> lstChuaThanhToan = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC && s.Lop == Lop).ToList();


            /////////////////////////////////////////////////////////////////////////
            /// New Method to Calculate:


            List<TieuChuanAn> lstTCA = db.TieuChuanAn.ToList();

            List<Object_ThanhToan> lstObj_Thanhtoan = new List<Object_ThanhToan>();
            foreach (var item in lstChuaThanhToan)
            {
                List<ChiTietNghi> item_lstCTN = db.ChiTietNghi.Where(s => s.MaDangKy == item.MaDangKy).ToList();

                foreach (var itemCTN in item_lstCTN)
                {
                    Object_ThanhToan temp = new Object_ThanhToan();
                    temp.maDKy = item.MaDangKy;
                    temp.maCTN = itemCTN.MaCTNghi;
                    temp.maHV = item.MaHocVien;
                    temp.maThanhToan = item.MaThanhToan;
                    temp.ngayNghi = itemCTN.NgayNghi;
                    temp.sang = (int)itemCTN.SoBuoiSang;
                    temp.trua = (int)itemCTN.SoBuoiTrua;
                    temp.toi = (int)itemCTN.SoBuoiToi;

                    temp.AutoFindTCA_CALTienCTN(lstTCA);

                    lstObj_Thanhtoan.Add(temp);
                }

            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<ThanhToan> DayLaListCacThanhToan_DuocTinh = new List<ThanhToan>();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Save ThanhToan
            foreach (var item in lstObj_Thanhtoan)
            {
                ThanhToan temp = db.ThanhToan.Where(s => s.MaThanhToan == item.maThanhToan).FirstOrDefault();
                if ((int)temp.MaThanhToan == item.maThanhToan)
                {
                    if (temp.TongTien == null)
                    {
                        temp.TongTien = item.TienCuaCTN;
                    }
                    else
                    {
                        //temp.TongTien += 0;
                        temp.TongTien += item.TienCuaCTN;
                    }
                }
                else
                {
                    continue;
                }
                temp.NgayTT = DateTime.Now;
                temp.TrangThaiTT = 1;

                if (DayLaListCacThanhToan_DuocTinh.Contains(temp) == false)
                    DayLaListCacThanhToan_DuocTinh.Add(temp);

                db.SaveChanges();
            }

            //Danh dau CONHABEP:
            List<DanhSachNghi> thisDanhSachNghi = new List<DanhSachNghi>();
            foreach (var item in lstChuaThanhToan)
            {
                DanhSachNghi temp = db.DanhSachNghi.Where(s => s.MaDS == item.MaDS).FirstOrDefault();

                if (thisDanhSachNghi.Contains(temp) == false)
                {
                    thisDanhSachNghi.Add(temp);
                }
            }

            foreach (var item in thisDanhSachNghi)
            {
                DanhSachNghi temp = db.DanhSachNghi.Where(s => s.MaDS == item.MaDS).FirstOrDefault();
                temp.MaCBNhaBep = FormMain.maCB; //Ma: CONHABEP
                db.SaveChanges();
            }

            //Tinh Toan de Hien Ket qua:
            int TongSoSang = 0;
            int TongSoTrua = 0;
            int TongSoToi = 0;
            int TongSoTien1 = 0;
            foreach (var item in lstObj_Thanhtoan)
            {
                TongSoSang += item.sang;
                TongSoTrua += item.trua;
                TongSoToi += item.toi;
                TongSoTien1 += item.TienCuaCTN;
            }

            //Tinhs de ktra cho chac
            int TongSoTien2 = 0;
            foreach (var item in DayLaListCacThanhToan_DuocTinh)
            {
                TongSoTien2 += item.TongTien;
            }

            //Show text:
            textEdit1.Text = TongSoSang.ToString();
            textEdit2.Text = TongSoTrua.ToString();
            textEdit3.Text = TongSoToi.ToString();
            textEdit4.Text = TongSoTien1.ToString();

            //Hien ra List:
            List<Class_DuLieuCatComHienthiGirdView> lstHienThi = new List<Class_DuLieuCatComHienthiGirdView>();
            foreach (var item in lstChuaThanhToan)
            {
                Class_DuLieuCatComHienthiGirdView temp = new Class_DuLieuCatComHienthiGirdView();
                temp.maHV = item.MaHocVien;
                temp.Hoten = item.HoTen;
                temp.TongTien = db.ThanhToan.Where(s => s.MaThanhToan == item.MaThanhToan).FirstOrDefault().TongTien;

                int sang = 0, trua = 0, toi = 0;

                List<ChiTietNghi> _tempCTN = db.ChiTietNghi.Where(s => s.MaDangKy == item.MaDangKy).ToList();

                foreach (var itemCTN in _tempCTN)
                {
                    sang += (int)itemCTN.SoBuoiSang;
                    trua += (int)itemCTN.SoBuoiTrua;
                    toi += (int)itemCTN.SoBuoiToi;
                }
                temp.sobuasang = sang;
                temp.sobuatoi = toi;
                temp.sobuatrua = trua;

                lstHienThi.Add(temp);
            }
            gridControl2.BeginUpdate();
            gridView2.Columns.Clear();
            gridControl2.DataSource = lstHienThi.Select(s => new { s.Hoten, s.sobuasang, s.sobuatrua, s.sobuatoi, s.TongTien });
            gridControl2.RefreshDataSource();
            gridControl2.Refresh();
            gridControl2.EndUpdate();
            if (gridView2.RowCount > 0 && gridView2.Columns.Count == 5)
            {
                gridView2.Columns[0].Caption = "Họ tên";
                gridView2.Columns[1].Caption = "Số bữa sáng";
                gridView2.Columns[2].Caption = "Số bữa trưa";
                gridView2.Columns[3].Caption = "Số bữa tối";
                gridView2.Columns[4].Caption = "Tổng tiền";
            }

            

            MessageBox.Show("Đã thanh toán thành công!");
            reload();
        }

        public static void UndoingChangesDbContextLevel(DbContext context)
        {
            foreach (DbEntityEntry entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
}
