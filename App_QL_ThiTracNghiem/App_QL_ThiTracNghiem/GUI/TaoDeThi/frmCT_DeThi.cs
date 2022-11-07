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

namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    public partial class frmCT_DeThi : UserControl
    {
        KryptonPanel panel;
        public frmCT_DeThi()
        {
            InitializeComponent();
        }

        public frmCT_DeThi(KryptonPanel panel)
        {
            InitializeComponent();
            this.panel = panel;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTao_DeThi frmTao_DeThi = new frmTao_DeThi();
            frmTao_DeThi.Dock = DockStyle.Fill;
            panel.Controls.Add(frmTao_DeThi);
            frmTao_DeThi.BringToFront();
        }

        private void kryptonPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
