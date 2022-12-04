using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.LopHoc
{
    public partial class frmDS_LopHoc : UserControl
    {
        public frmDS_LopHoc()
        {
            InitializeComponent();
            ShowDSLopHoc();
        }

        public void ShowDSLopHoc()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";

            gridDSLopHoc.DataSource = Lop_DAO.GetDSLH_Khoa("01");
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSLopHoc.CurrentRow.Index;
            string MALOP = gridDSLopHoc.Rows[rsl].Cells[0].Value.ToString().Trim();
            string TENLOP = gridDSLopHoc.Rows[rsl].Cells[1].Value.ToString().Trim();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa LỚP [{TENLOP}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (Lop_DAO.DeleteLop(MALOP))
            {
                KryptonMessageBox.Show("Đã xóa HỌC PHẦN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDSLopHoc();
            }
            else
            {
                KryptonMessageBox.Show("Xóa HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowDSLopHoc();
            }
        }

        private void sỬAĐỔIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSLopHoc.CurrentRow.Index;
            Lops lop = new Lops();
            lop.MaLop = gridDSLopHoc.Rows[rsl].Cells[0].Value.ToString().Trim();
            lop.TenLop = gridDSLopHoc.Rows[rsl].Cells[1].Value.ToString().Trim();
            lop.Siso = int.Parse(gridDSLopHoc.Rows[rsl].Cells[2].Value.ToString().Trim());
            lop.MaKhoa = gridDSLopHoc.Rows[rsl].Cells[4].Value.ToString().Trim();

            frmAdd_Edit_LopHoc edit = new frmAdd_Edit_LopHoc(true, lop);
            edit.ShowDialog();
            ShowDSLopHoc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_LopHoc edit = new frmAdd_Edit_LopHoc(false, null);
            edit.ShowDialog();
            ShowDSLopHoc();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDSLopHoc.DataSource = Lop_DAO.GetDSLH_Khoa(cboKhoa.SelectedValue.ToString());
        }

        private void gridDSLopHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSLopHoc.CurrentRow.Index;
            string MALOP = gridDSLopHoc.Rows[rsl].Cells[0].Value.ToString().Trim();
            string TENLOP = gridDSLopHoc.Rows[rsl].Cells[1].Value.ToString().Trim();
            frmDSSinhVienLop dsLop = new frmDSSinhVienLop(MALOP, TENLOP);
            dsLop.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportSV import = new frmImportSV();
            import.ShowDialog();

        }
    }
}
