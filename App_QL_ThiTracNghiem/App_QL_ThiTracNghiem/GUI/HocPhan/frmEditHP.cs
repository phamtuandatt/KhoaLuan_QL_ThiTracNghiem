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

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmEditHP : MetroFramework.Forms.MetroForm
    {
        HocPhans hp;
        public frmEditHP(HocPhans hp)
        {
            InitializeComponent();
            this.hp = hp;

            ShowCboKhoa();
            cboKhoa.SelectedValue = hp.MaKhoa;
            txtMHP.Text = hp.MaHocPhan;
            txtTen.Text = hp.TenHocPhan;
            txtSTC.Text = hp.SoTC + "";
            txtLT.Text = hp.SoTietLT + "";
            txtTH.Text = hp.SoTietTH + "";

        }

        public void ShowCboKhoa()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HocPhans hocPhan = new HocPhans();
            hocPhan.MaHocPhan = hp.MaHocPhan;
            hocPhan.TenHocPhan = txtTen.Text;
            hocPhan.SoTC = int.Parse(txtSTC.Text.Trim());
            hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
            hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());
            hocPhan.MaKhoa = cboKhoa.SelectedValue.ToString();

            if (HocPhan_DAO.UpdateHP(hocPhan))
            {
                KryptonMessageBox.Show("Cập nhật HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Cập nhật KHÔNG HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
