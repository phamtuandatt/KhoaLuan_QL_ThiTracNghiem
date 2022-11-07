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
    public partial class frmDSCaThi_DaThi : UserControl
    {
        KryptonPanel pnContent;
        public frmDSCaThi_DaThi()
        {
            InitializeComponent();
        }

        public frmDSCaThi_DaThi(KryptonPanel pnContent)
        {
            InitializeComponent();
            this.pnContent = pnContent;
        }

        private void gridDSCaThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDSBaiThi frmDSBaiThi = new frmDSBaiThi(pnContent);
            frmDSBaiThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSBaiThi);
            frmDSBaiThi.BringToFront();
        }
    }
}
