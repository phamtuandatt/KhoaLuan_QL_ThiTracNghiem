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
        public frmDSBaiThi()
        {
            InitializeComponent();
        }

        public frmDSBaiThi(KryptonPanel pnContent)
        {
            InitializeComponent();
            this.pnContent = pnContent;
        }

        private void gridDSSinhVienLamBai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị thông tin chi tiết bài thi của sinh vien
            frmCT_BaiThi frmCT_BaiThi = new frmCT_BaiThi();
            frmCT_BaiThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmCT_BaiThi);
            frmCT_BaiThi.BringToFront();

        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {

        }
    }
}
