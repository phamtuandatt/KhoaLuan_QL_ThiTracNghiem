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
    public partial class frmDeThi : UserControl
    {
        public frmDeThi()
        {
            InitializeComponent();
            frmDSDeThi frmDSDeThi = new frmDSDeThi(pnContent);
            frmDSDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDSDeThi);
            frmDSDeThi.BringToFront();
        }

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            // Khi tạo đề thi -> Hiện form truyền Id môn học để biết tạo đề cho môn học nào
            frmTao_DeThi frmTao_DeThi = new frmTao_DeThi();
            frmTao_DeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmTao_DeThi);
            frmTao_DeThi.BringToFront();
        }

        private void cboDSMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi thay đổi môn học -> sẽ hiển thị các đề thi tương ứng xuống phía dưới
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDSDeThi frmDSDeThi = new frmDSDeThi(pnContent);
            frmDSDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDSDeThi);
            frmDSDeThi.BringToFront();
        }
    }
}
