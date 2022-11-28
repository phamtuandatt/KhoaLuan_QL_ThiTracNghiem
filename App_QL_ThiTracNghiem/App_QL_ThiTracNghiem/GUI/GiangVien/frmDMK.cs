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

namespace App_QL_ThiTracNghiem.GUI.GiangVien
{
    public partial class frmDMK : MetroFramework.Forms.MetroForm
    {
        GiangViens gv;
        public frmDMK(GiangViens giangViens)
        {
            InitializeComponent();
            this.gv = giangViens;

            txtTen.Text = gv.TenGV;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIOK_Click(object sender, EventArgs e)
        {
            if (GiangVien_DAO.ChangePassword(gv.MaGV, txtMKMoi.Text.Trim()))
            {
                KryptonMessageBox.Show("Thay đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Thay đổi mật khẩu KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
