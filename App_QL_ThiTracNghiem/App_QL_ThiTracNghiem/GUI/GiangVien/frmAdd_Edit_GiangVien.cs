using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.Validate;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.GiangVien
{
    public partial class frmAdd_Edit_GiangVien : MetroFramework.Forms.MetroForm
    {
        GiangViens gv;
        bool check_edit;
        bool checkAction = false;
        public frmAdd_Edit_GiangVien()
        {
            InitializeComponent();
        }

        public frmAdd_Edit_GiangVien(bool check_edit, GiangViens giangViens)
        {
            InitializeComponent();
            this.gv = giangViens;
            this.check_edit = check_edit;

            Show_Khoa_ChucVu();

            // true -> edit
            if (check_edit)
            {
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
            else
            {
                txtHocvi.SelectedIndex = 0;
                btnEdit.Visible = false;
                btnDoiMatKhau.Visible = false;
                cboKhoa.Enabled = true;
                cboChucVu.Enabled = true;
                txtNgaySinh.Enabled = true;
                txtHocvi.Enabled = true;
                txtTen.ReadOnly = false;
                txtSDT.ReadOnly = false;
                txtQuequan.ReadOnly = false;
                txtdiachi.ReadOnly = false;
                txtEmail.ReadOnly = false;
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
            if (checkAction == true)
            {
                if (Validation.IsValid_HoTen(txtTen.Text) == false)
                {
                    KryptonMessageBox.Show("Tên không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    txtTen.SelectAll();
                    return;
                }
                if (Validation.IsNumberPhone_VN(txtSDT.Text) == false)
                {
                    KryptonMessageBox.Show("Chưa đúng định dạng số ở Việt Nam!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    txtSDT.SelectAll();
                    return;
                }
                if (Validation.IsValid_HoTen(txtQuequan.Text) == false)
                {
                    KryptonMessageBox.Show("Quê quán không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuequan.Focus();
                    txtQuequan.SelectAll();
                    return;
                }
                if (Validation.IsValid_DC(txtdiachi.Text) == false)
                {
                    KryptonMessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdiachi.Focus();
                    txtdiachi.SelectAll();
                    return;
                }
                if (check_edit)
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
                        this.Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show("Cập nhật thông tin KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            // Add
            else
            {
                if (check_edit == false)
                {
                    if (Validation.IsValid_HoTen(txtTen.Text) == false)
                    {
                        KryptonMessageBox.Show("Tên không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTen.Focus();
                        txtTen.SelectAll();
                        return;
                    }
                    if (Validation.IsNumberPhone_VN(txtSDT.Text) == false)
                    {
                        KryptonMessageBox.Show("Chưa đúng định dạng số ở Việt Nam!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSDT.Focus();
                        txtSDT.SelectAll();
                        return;
                    }
                    if (Validation.IsValid_HoTen(txtQuequan.Text) == false)
                    {
                        KryptonMessageBox.Show("Quê quán không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQuequan.Focus();
                        txtQuequan.SelectAll();
                        return;
                    }
                    if (Validation.IsValid_DC(txtdiachi.Text) == false)
                    {
                        KryptonMessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtdiachi.Focus();
                        txtdiachi.SelectAll();
                        return;
                    }
                    string mk;
                    string[] ten = txtTen.Text.Split(' ');
                    if (ten.Length == 1)
                        mk = chuyen_khong_dau(ten[0]);
                    else
                        mk = chuyen_khong_dau((ten[(ten.Length - 1) - 1] + ten[ten.Length - 1]).ToLower());

                    GiangViens gvien = new GiangViens();
                    gvien.MatKhau = mk;
                    gvien.TenGV = txtTen.Text.Trim();
                    gvien.NgaySinh = txtNgaySinh.Value;
                    if (radNam.Checked)
                    {
                        gvien.GioiTinh = "NAM";
                    }
                    else
                    {
                        gvien.GioiTinh = "NỮ";
                    }
                    gvien.QueQuan = txtQuequan.Text.Trim();
                    gvien.HocVi = txtHocvi.Text.Trim();
                    gvien.Sdt = txtSDT.Text.Trim();
                    gvien.Email = txtEmail.Text.Trim();
                    gvien.DiaChi = txtdiachi.Text.Trim();
                    gvien.MaKhoa = cboKhoa.SelectedValue.ToString().Trim();
                    gvien.MaChucVu = cboChucVu.SelectedValue.ToString();

                    if (GiangVien_DAO.Insert(gvien))
                    {
                        KryptonMessageBox.Show("Tạo GIẢNG VIÊN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show("Tạo GIẢNG VIÊN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
        }

        private string chuyen_khong_dau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
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
            txtHocvi.Enabled = true;
            txtTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtQuequan.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtEmail.ReadOnly = false;

            checkAction = true;
            txtTen.Focus();
            txtTen.SelectAll();
        }

        private void Valid()
        {
            if (Validation.IsValid_HoTen(txtTen.Text) == false)
            {
                KryptonMessageBox.Show("Tên không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                txtTen.SelectAll();
                return;
            }
            if (Validation.IsNumberPhone_VN(txtSDT.Text) == false)
            {
                KryptonMessageBox.Show("Chưa đúng định dạng số ở Việt Nam!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                txtSDT.SelectAll();
                return;
            }
            if (Validation.IsValid_HoTen(txtQuequan.Text) == false)
            {
                KryptonMessageBox.Show("Quê quán không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuequan.Focus();
                txtQuequan.SelectAll();
                return;
            }
            if (Validation.IsValid_DC(txtdiachi.Text) == false)
            {
                KryptonMessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                txtdiachi.SelectAll();
                return;
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
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

        }

        private void txtQuequan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
