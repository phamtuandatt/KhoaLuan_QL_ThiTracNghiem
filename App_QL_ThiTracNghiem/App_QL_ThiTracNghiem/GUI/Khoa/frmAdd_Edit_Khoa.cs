using App_QL_ThiTracNghiem.DAO;
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

namespace App_QL_ThiTracNghiem.GUI.Khoa
{
    public partial class frmAdd_Edit_Khoa : MetroFramework.Forms.MetroForm
    {
        string MAKHOA, TENKHOA;
        bool check_edit;
        public frmAdd_Edit_Khoa(bool check_edit, string MAKHOA, string TENKHOA)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.MAKHOA = MAKHOA;
            this.TENKHOA = TENKHOA;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Cập nhật
            if (check_edit)
            {
                if (KryptonMessageBox.Show($"Bạn có muốn sửa đổi tên KHOA không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (Khoa_DAO.UpdateKhoa(MAKHOA, txtTen.Text.Trim()))
                {
                    KryptonMessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Tạo mới
            else
            {
                if (Khoa_DAO.InsertKhoa(txtTen.Text.Trim()))
                {
                    KryptonMessageBox.Show("Tạo KHOA thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Tạo KHOA KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
