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

namespace App_QL_ThiTracNghiem.GUI.LopHoc
{
    public partial class frmAdd_Edit_LopHoc : MetroFramework.Forms.MetroForm
    {
        Lops lops;
        bool check_edit;
        public frmAdd_Edit_LopHoc(bool check_edit, Lops lops)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.lops = lops;

            ShowCboKhoa();
            if (check_edit)
            {
                cboKhoa.SelectedValue = lops.MaKhoa;
                txtMaLop.Text = lops.MaLop;
                txtTenLop.Text = lops.TenLop;
                cboKhoa.Enabled = false;
                txtMaLop.ReadOnly = true;
                txtTenLop.Focus();
            }
        }

        public void ShowCboKhoa()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (check_edit)
            {
                if (txtMaLop.Text.Length <= 0 || txtTenLop.Text.Length <= 0)
                {
                    KryptonMessageBox.Show("Hãy điền đầy đủ thông tin để tạo lớp !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                Lops lop = new Lops();
                lop.MaLop = txtMaLop.Text;
                lop.TenLop = txtTenLop.Text;

                if (Lop_DAO.UpdateLop(lop))
                {
                    KryptonMessageBox.Show("Cập nhật LỚP thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật LỚP KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
            {
                if (txtMaLop.Text.Length <= 0 || txtTenLop.Text.Length <= 0)
                {
                    KryptonMessageBox.Show("Hãy điền đầy đủ thông tin để tạo lớp !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                Lops lop = new Lops();
                lop.MaLop = txtMaLop.Text;
                lop.TenLop = txtTenLop.Text;
                lop.MaKhoa = cboKhoa.SelectedValue.ToString();

                if (Lop_DAO.InsertLop(lop))
                {
                    KryptonMessageBox.Show("Tạo LỚP thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Tạo LỚP KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }
    }
}
