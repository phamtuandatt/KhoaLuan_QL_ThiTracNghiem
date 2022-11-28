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
    public partial class frmAdd_Edit_HocPhan : MetroFramework.Forms.MetroForm
    {
        bool check_edit;
        HocPhans hp;
        public frmAdd_Edit_HocPhan(bool check_edit, HocPhans hp)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.hp = hp;

            ShowCboKhoa();
            if (check_edit)
            {
                cboKhoa.SelectedValue = hp.MaKhoa;
                txtTen.Text = hp.TenHocPhan;
                txtSoTC.Text = hp.SoTC + "";
                txtLT.Text = hp.SoTietLT + "";
                txtTH.Text = hp.SoTietTH + "";
            }
        }

        public void ShowCboKhoa()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Cập nhật = true
            if (check_edit)
            {
                HocPhans hocPhan = new HocPhans();
                hocPhan.MaHocPhan = hp.MaHocPhan;
                hocPhan.TenHocPhan = txtTen.Text;
                hocPhan.SoTC = int.Parse(txtSoTC.Text.Trim());
                hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
                hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());
                if (HocPhan_DAO.UpdateHP(hocPhan))
                {
                    KryptonMessageBox.Show("Cập nhật HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            // Tạo mới
            else
            {
                HocPhans hocPhan = new HocPhans();
                hocPhan.MaHocPhan = hp.MaHocPhan;
                hocPhan.TenHocPhan = txtTen.Text;
                hocPhan.SoTC = int.Parse(txtSoTC.Text.Trim());
                hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
                hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());
                if (HocPhan_DAO.InsertHP(hocPhan))
                {
                    KryptonMessageBox.Show("Tạo HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Tạo HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
