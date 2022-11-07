using App_QL_ThiTracNghiem.GUI.CauHoi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI
{
    public partial class frmNganHangCauHoi : UserControl
    {
        public frmNganHangCauHoi()
        {
            InitializeComponent();
            frmDS_MonHoc_CauHoi frmDS_CauHoi = new frmDS_MonHoc_CauHoi(pnContent, false);
            frmDS_CauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDS_CauHoi);
            frmDS_CauHoi.BringToFront();
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDS_MonHoc_CauHoi frmDS_CauHoi = new frmDS_MonHoc_CauHoi(pnContent, false);
            frmDS_CauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDS_CauHoi);
            frmDS_CauHoi.BringToFront();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportCH importCH = new frmImportCH();
            importCH.ShowDialog();
            
        }

        private void btnTaoCauHoi_Click(object sender, EventArgs e)
        {
            frmTaoCauHoi frmTaoCauHoi = new frmTaoCauHoi(1);
            frmTaoCauHoi.ShowDialog();
        }

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            frmThemMonHoc frmThemMonHoc = new frmThemMonHoc(); 
            frmThemMonHoc.ShowDialog();
        }
    }
}
