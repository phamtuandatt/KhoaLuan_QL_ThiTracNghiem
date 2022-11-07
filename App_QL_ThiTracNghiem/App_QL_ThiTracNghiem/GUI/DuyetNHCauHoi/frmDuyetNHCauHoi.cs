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

namespace App_QL_ThiTracNghiem.GUI.DuyetNHCauHoi
{
    public partial class frmDuyetNHCauHoi : UserControl
    {
        public frmDuyetNHCauHoi()
        {
            InitializeComponent();
        }

        private void gridDSGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDS_MonHoc_CauHoi frmDSMonHoc = new frmDS_MonHoc_CauHoi(pnContent, true);
            frmDSMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDSMonHoc);
            frmDSMonHoc.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {

        }
    }
}
