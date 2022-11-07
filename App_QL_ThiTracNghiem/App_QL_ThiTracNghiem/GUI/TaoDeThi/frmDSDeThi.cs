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
    public partial class frmDSDeThi : UserControl
    {
        KryptonPanel panel;
        public frmDSDeThi(KryptonPanel panel)
        {
            InitializeComponent();
            this.panel = panel;
        }

        private void gridDSDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCT_DeThi frmCT_DeThi = new frmCT_DeThi(panel);
            frmCT_DeThi.Dock = DockStyle.Fill;
            panel.Controls.Add(frmCT_DeThi);
            frmCT_DeThi.BringToFront();
        }
    }
}
