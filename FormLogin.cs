using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HTTT_QLTienAn.Models;

namespace HTTT_QLTienAn
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (MyDBContext db = new MyDBContext())
            {
                string hashedPass = HashPass(txtPassword.Text);
                
                if (db.TTDangNhap.Any(s => s.TaiKhoan == txtUsername.Text && s.MatKhau == hashedPass))
                {
                    TTDangNhap acc = db.TTDangNhap.Where(s => s.TaiKhoan == txtUsername.Text && s.MatKhau == hashedPass).FirstOrDefault();
                    CanBo cb = db.CanBo.Where(s => s.MaDangNhap == acc.MaDangNhap).FirstOrDefault();

                    FormMain fm;
                    if (cb == null)
                    {
                        fm = new FormMain(acc.QuyenTruyCap);
                    }
                    else fm = new FormMain(cb.MaCanBo, acc.QuyenTruyCap);

                    this.Hide();
                    fm.ShowDialog();
                    if (!fm.IsDisposed)
                    {
                        txtPassword.Text = "";
                        txtUsername.Focus();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        public static string HashPass(string pass)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}