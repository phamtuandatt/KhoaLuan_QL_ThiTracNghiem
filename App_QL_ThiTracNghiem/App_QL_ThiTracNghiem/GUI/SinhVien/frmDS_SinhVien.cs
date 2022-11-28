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

namespace App_QL_ThiTracNghiem.GUI.SinhVien
{
    public partial class frmDS_SinhVien : UserControl
    {
        public frmDS_SinhVien()
        {
            InitializeComponent();
            ShowDSSV();
        }

        public void ShowDSSV()
        {
            gridDSSV.DataSource = SinhVien_DAO.GetDSSV();
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSSV.CurrentRow.Index;
            string MASINHVIEN = gridDSSV.Rows[rsl].Cells[0].Value.ToString();
            string TENSINHVIEN = gridDSSV.Rows[rsl].Cells[1].Value.ToString();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa SINH VIÊN [{TENSINHVIEN}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (SinhVien_DAO.DeleteSV(MASINHVIEN))
            {
                KryptonMessageBox.Show("Đã xóa HỌC PHẦN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDSSV();
            }
            else
            {
                KryptonMessageBox.Show("Xóa HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowDSSV();
            }
        }

        private void sỬAĐỔIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSSV.CurrentRow.Index;
            SinhViens sv = new SinhViens();
            sv.MaSV = gridDSSV.Rows[rsl].Cells[0].Value.ToString();
            sv.TenSV = gridDSSV.Rows[rsl].Cells[1].Value.ToString();
            sv.GioiTinh = gridDSSV.Rows[rsl].Cells[2].Value.ToString();
            sv.NgaySinh = DateTime.Parse(gridDSSV.Rows[rsl].Cells[3].Value.ToString());
            sv.Email = gridDSSV.Rows[rsl].Cells[4].Value.ToString();
            sv.Sdt = gridDSSV.Rows[rsl].Cells[5].Value.ToString();
            sv.DiaChi = gridDSSV.Rows[rsl].Cells[6].Value.ToString();
            sv.QueQuan = gridDSSV.Rows[rsl].Cells[7].Value.ToString();
            sv.MaLop = gridDSSV.Rows[rsl].Cells[8].Value.ToString();
            sv.HocPhi = gridDSSV.Rows[rsl].Cells[9].Value.ToString();

            frmAdd_Edit_SinhVien edit = new frmAdd_Edit_SinhVien(true, sv);
            edit.ShowDialog();
            ShowDSSV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_SinhVien edit = new frmAdd_Edit_SinhVien(false, null);
            edit.ShowDialog();
            ShowDSSV();
        }
    }
}
