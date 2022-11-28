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
    public partial class frmDS_Khoa : UserControl
    {
        public frmDS_Khoa()
        {
            InitializeComponent();
            ShowDSKhoa();
        }

        public void ShowDSKhoa()
        {
            griDSKhoa.DataSource = Khoa_DAO.GetDSKhoa();
        }

        private void sỬAĐỔIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = griDSKhoa.CurrentRow.Index;
            string MAKHOA = griDSKhoa.Rows[rsl].Cells[0].Value.ToString().Trim();
            string TENKHOA = griDSKhoa.Rows[rsl].Cells[1].Value.ToString().Trim();

            frmAdd_Edit_Khoa edit = new frmAdd_Edit_Khoa(true, MAKHOA, TENKHOA);
            edit.ShowDialog();
            ShowDSKhoa();
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = griDSKhoa.CurrentRow.Index;
            string MAKHOA = griDSKhoa.Rows[rsl].Cells[0].Value.ToString().Trim();
            string TENKHOA = griDSKhoa.Rows[rsl].Cells[1].Value.ToString().Trim();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa KHOA [{TENKHOA}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (Khoa_DAO.DeleteKhoa(MAKHOA))
            {
                KryptonMessageBox.Show("Đã xóa KHOA !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("Xóa KHOA KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnADd_Click(object sender, EventArgs e)
        {
            int rsl = griDSKhoa.CurrentRow.Index;
            string MAKHOA = griDSKhoa.Rows[rsl].Cells[0].Value.ToString().Trim();
            frmAdd_Edit_Khoa edit = new frmAdd_Edit_Khoa(false, MAKHOA, null);
            edit.ShowDialog();
            ShowDSKhoa();
        }
    }
}
