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
    public partial class frmDSBaiThi : UserControl
    {
        KryptonPanel pnContent;
        int MACATHI;
        string MAHOCPHAN, TENHOCPHAN;
        DateTime NGAYTHI;

        public frmDSBaiThi(KryptonPanel pnContent, int MACATHI, string MAHOCPHAN, string TENHOCPHAN, DateTime NGAYTHI)
        {
            InitializeComponent();
            this.pnContent = pnContent;
            this.MACATHI = MACATHI;
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            this.NGAYTHI = NGAYTHI;

            gridDSSinhVienLamBai.DataSource = BaiThi_DAO.GetDSSVLamBaiThi(MACATHI);
            txtMocHOc.Text = TENHOCPHAN;
            txtNgayThi.Text = string.Format("{0:dd/MM/yyyy}", NGAYTHI);
            int svDaNop = 0;
            int svDangThi = 0;
            foreach (DataGridViewRow item in gridDSSinhVienLamBai.Rows)
            {
                if (item.Cells[5].Value.ToString().Length > 0) { svDaNop++; }
                else { svDangThi++; }
            }
            txtDaNop.Text = svDaNop + "";
            txtDangThi.Text = svDangThi + "";
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            gridDSSinhVienLamBai.DataSource = BaiThi_DAO.GetDSSVLamBaiThi(MACATHI);
            int svDaNop = 0;
            int svDangThi = 0;
            foreach (DataGridViewRow item in gridDSSinhVienLamBai.Rows)
            {
                if (item.Cells[5].Value.ToString().Length > 0) { svDaNop++; }
                else { svDangThi++; }
            }
            txtDaNop.Text = svDaNop + "";
            txtDangThi.Text = svDangThi + "";
        }

        private void gridDSSinhVienLamBai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSSinhVienLamBai.CurrentRow.Index;
            int MABAITHI = int.Parse(gridDSSinhVienLamBai.Rows[rsl].Cells[7].Value.ToString());

            // Hiển thị thông tin chi tiết bài thi của sinh vien
            frmCT_BaiThi frmCT_BaiThi = new frmCT_BaiThi(MABAITHI);
            frmCT_BaiThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmCT_BaiThi);
            frmCT_BaiThi.BringToFront();

        }
    }
}
