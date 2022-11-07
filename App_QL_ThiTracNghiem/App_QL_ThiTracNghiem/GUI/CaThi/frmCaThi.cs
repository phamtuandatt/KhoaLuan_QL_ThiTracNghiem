using App_QL_ThiTracNghiem.GUI.TaoDeThi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    public partial class frmCaThi : UserControl
    {
        bool check_role_id;
        public frmCaThi()
        {
            InitializeComponent();
        }

        public frmCaThi(bool check_role_id)
        {
            InitializeComponent();
            this.check_role_id = check_role_id;
            // Kiểm tra mã giảng viên 
            // True -> Nếu là giảng viên
            if (check_role_id)
            {
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, true);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
            // False -> Nếu là nhân viên phòng khảo thí
            else
            {
                btnTaoCaThi.Visible = false;
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, false);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }

        private void btnTaoCaThi_Click(object sender, EventArgs e)
        {
            frmTaoCaThi frmTaoCaThi = new frmTaoCaThi(pnContent, true);
            frmTaoCaThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmTaoCaThi);
            frmTaoCaThi.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã giảng viên 
            // True -> Nếu là giảng viên
            if (check_role_id)
            {
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, true);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
            // False -> Nếu là nhân viên phòng khảo thí
            else
            {
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, false);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }
    }
}
