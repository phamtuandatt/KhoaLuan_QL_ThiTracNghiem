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

namespace App_QL_ThiTracNghiem.GUI.BaiThi
{
    public partial class frmQL_BaiThi : UserControl
    {
        public frmQL_BaiThi()
        {
            InitializeComponent();
            txtNgayThi.Text = DateTime.UtcNow.ToShortDateString();
            LoadCaThi();

            //frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            //frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            //pnContent.Controls.Add(frmDSCaThi_DaThi);
            //frmDSCaThi_DaThi.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSCaThi_DaThi);
            frmDSCaThi_DaThi.BringToFront();
        }

        private void LoadCaThi()
        {
            cboCaThi.DataSource = CaThi_DAO.GetDSCaThiCbo();
            cboCaThi.DisplayMember = "TENHOCPHAN";
            cboCaThi.ValueMember = "MACATHI";
        }

        private void btnTKCaThi_Click(object sender, EventArgs e)
        {
            // Tạo cbo box hiển thị chi tiêt ca thi - MÔN HỌC - PHÒNG - TIẾT - 
            // Tạo DataTable gồm 2 thuộc tính - Tên: - MÔN HỌC - PHÒNG - TIẾT - 
            //                                - ID: - MÃ CA THI -

            // Xây dựng lại proc GETDS SINH VIÊN THAM GIA CA THI

            gridDSSinhVienLamBai.DataSource = BaiThi_DAO.GetDSSVLamBaiThi(int.Parse(cboCaThi.SelectedValue.ToString()));
            int svDaNop = 0;
            int svDangThi = 0;
            foreach (DataGridViewRow item in gridDSSinhVienLamBai.Rows)
            {
                if (item.Cells[6].Value.ToString().Length > 0) { svDaNop++; }
                if (item.Cells[5].Value.ToString().Length > 0) { svDangThi++; }
            }
            txtDaNop.Text = svDaNop + "";
            txtDangThi.Text = svDangThi + "";
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            gridDSSinhVienLamBai.DataSource = BaiThi_DAO.GetDSSVLamBaiThi(int.Parse(cboCaThi.SelectedValue.ToString()));
            int svDaNop = 0;
            int svDangThi = 0;
            foreach (DataGridViewRow item in gridDSSinhVienLamBai.Rows)
            {
                if (item.Cells[6].Value.ToString().Length > 0) { svDaNop++; }
                if (item.Cells[5].Value.ToString().Length > 0) { svDangThi++; }
            }
            txtDaNop.Text = svDaNop + "";
            txtDangThi.Text = svDangThi + "";
           
        }

        private void gridDSSinhVienLamBai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSSinhVienLamBai.CurrentRow.Index;
            if (gridDSSinhVienLamBai.Rows[rsl].Cells[7].Value.ToString() != null
                && gridDSSinhVienLamBai.Rows[rsl].Cells[6].Value.ToString().Length > 0)
            {
                int MACATHI = int.Parse(gridDSSinhVienLamBai.Rows[rsl].Cells[7].Value.ToString());
                frmBaiThi bt = new frmBaiThi(MACATHI);
                bt.ShowDialog();
            }
        }
    }
}
