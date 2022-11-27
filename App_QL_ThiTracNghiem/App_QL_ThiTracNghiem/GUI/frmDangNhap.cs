using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI
{
    public partial class frmDangNhap : MetroFramework.Forms.MetroForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            if (GiangVien_DAO.Login(txtTK.Text.Trim(), txtMK.Text.Trim()))
            {
                GiangViens gv = GiangVien_DAO.GetGiangVien(txtTK.Text.Trim(), txtMK.Text.Trim());
                int MANGANHANG = GiangVien_DAO.GetNganHangOfGiangVien(gv.MaGV);
                MainForm frm = new MainForm(MANGANHANG,gv);
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Tài khoản - Mật khẩu không chính xác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.Focus();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
