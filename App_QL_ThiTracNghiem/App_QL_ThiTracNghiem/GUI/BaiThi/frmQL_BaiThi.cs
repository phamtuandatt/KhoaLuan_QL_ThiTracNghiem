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
            frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSCaThi_DaThi);
            frmDSCaThi_DaThi.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSCaThi_DaThi);
            frmDSCaThi_DaThi.BringToFront();
        }
    }
}
