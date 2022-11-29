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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.SinhVien
{
    public partial class frmAdd_Edit_SinhVien : MetroFramework.Forms.MetroForm
    {
        bool check_edit;
        SinhViens sinhVien;
        string MAKHOA;
        public frmAdd_Edit_SinhVien(bool check_edit, SinhViens sinhViens, string MAKHOA)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.sinhVien = sinhViens;
            this.MAKHOA = MAKHOA;

            ShowDSLop();

            if (check_edit)
            {
                cboLop.SelectedValue = sinhVien.MaLop;
                txtTEn.Text = sinhVien.TenSV;
                txtSDT.Text = sinhVien.Sdt;
                txtEmail.Text = sinhVien.Email;
                txtQueQuan.Text = sinhVien.QueQuan;
                txtDiaChi.Text = sinhVien.DiaChi;
                txtNgaySinh.Value = sinhVien.NgaySinh;
                if (sinhVien.GioiTinh == "NAM")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }    
            }

        }

        public void ShowDSLop()
        {
            cboLop.DataSource = Lop_DAO.GetDSLop_Khoa(MAKHOA);
            cboLop.DisplayMember = "MALOP";
            cboLop.ValueMember = "MALOP";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (check_edit)
            {
                SinhViens sv = new SinhViens();
                sv.MaSV = sinhVien.MaSV;
                sv.TenSV = txtTEn.Text.Trim();
                if (radNam.Checked)
                {
                    sv.GioiTinh = "NAM";
                }
                else
                {
                    sv.GioiTinh = "NỮ";
                }
                sv.NgaySinh = txtNgaySinh.Value;
                sv.Email = txtEmail.Text.Trim();
                sv.Sdt = txtSDT.Text.Trim();
                sv.DiaChi = txtDiaChi.Text.Trim();
                sv.QueQuan = txtQueQuan.Text.Trim();
                sv.MaLop = cboLop.SelectedValue.ToString();

                if (SinhVien_DAO.UpdateSV(sv))
                {
                    KryptonMessageBox.Show("Cập nhật thông tin sinh viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật thông tin sinh viên KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            // Tạo mới sinh viên
            else
            {
                //Tạo tài khoản mật khẩu giống tên của nhân viên
                string mk;
                string[] ten = txtTEn.Text.Split(' ');
                if (ten.Length == 1)
                    mk = chuyen_khong_dau(ten[0]);
                else
                    mk = chuyen_khong_dau((ten[(ten.Length - 1) - 1] + ten[ten.Length - 1]).ToLower());

                SinhViens sv = new SinhViens();
                sv.TenSV = txtTEn.Text.Trim();
                sv.MatKhau = mk;
                if (radNam.Checked)
                {
                    sv.GioiTinh = "NAM";
                }
                else
                {
                    sv.GioiTinh = "NỮ";
                }
                sv.NgaySinh = txtNgaySinh.Value;
                sv.Email = txtEmail.Text.Trim();
                sv.Sdt = txtSDT.Text.Trim();
                sv.DiaChi = txtDiaChi.Text.Trim();
                sv.QueQuan = txtQueQuan.Text.Trim();
                sv.MaLop = cboLop.SelectedValue.ToString();

                if (SinhVien_DAO.InsertSV(sv, MAKHOA, 19))
                {
                    KryptonMessageBox.Show("Thêm sinh viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Thêm sinh viên KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private string chuyen_khong_dau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
