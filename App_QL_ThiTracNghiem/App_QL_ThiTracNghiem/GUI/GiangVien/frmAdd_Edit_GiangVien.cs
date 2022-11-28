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
    public partial class frmAdd_Edit_GiangVien : MetroFramework.Forms.MetroForm
    {
        GiangViens gv;
        public frmAdd_Edit_GiangVien()
        {
            InitializeComponent();
        }

        public frmAdd_Edit_GiangVien(GiangViens giangViens)
        {
            InitializeComponent();
            this.gv = giangViens;

            Show_Khoa_ChucVu();
            cboKhoa.SelectedValue = gv.MaKhoa;
            txtTen.Text = gv.TenGV;
            txtHocvi.Text = gv.HocVi;
            txtSDT.Text = gv.Sdt;
            txtNgaySinh.Value = gv.NgaySinh;
            txtEmail.Text = gv.Email;
            txtQuequan.Text = gv.QueQuan;
            cboChucVu.SelectedValue = gv.MaChucVu;
            txtdiachi.Text = gv.DiaChi;
            if (gv.GioiTinh == "NAM")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }    
        }

        public void Show_Khoa_ChucVu()
        {
            cboChucVu.DataSource = ChucVu_DAO.GetChucVu();
            cboChucVu.DisplayMember = "TENCHUCVU";
            cboChucVu.ValueMember = "MACHUCVU";

            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GiangViens gvien = new GiangViens();
            gvien.MaGV = this.gv.MaGV;
            gvien.TenGV = txtTen.Text.Trim();
            gvien.HocVi = txtHocvi.Text.Trim();
            gvien.Sdt = txtSDT.Text.Trim();
            gvien.NgaySinh = txtNgaySinh.Value;
            gvien.Email = txtEmail.Text.Trim();
            gvien.QueQuan = txtQuequan.Text.Trim();
            gvien.DiaChi = txtdiachi.Text.Trim();
            if (radNam.Checked)
            {
                gvien.GioiTinh = "NAM";
            }
            else
            {
                gvien.GioiTinh = "Nữ";
            }

            if (GiangVien_DAO.Update_GV(gvien))
            {
                KryptonMessageBox.Show("Cập nhật thông tin thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("Cập nhật thông tin KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDMK dmk = new frmDMK(gv);
            dmk.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //cboKhoa.Enabled = true;
            //cboChucVu.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtTen.ReadOnly = false;
            txtHocvi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtQuequan.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtEmail.ReadOnly = false;
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHocvi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuequan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
