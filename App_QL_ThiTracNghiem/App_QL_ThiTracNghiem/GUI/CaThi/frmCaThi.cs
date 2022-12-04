using App_QL_ThiTracNghiem.DAO;
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
        DataTable dt;
        public frmCaThi()
        {
            InitializeComponent();

        }

        public frmCaThi(bool check_role_id)
        {
            InitializeComponent();
            this.check_role_id = check_role_id;
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";

            cboHocPhan.DataSource = HocPhan_DAO.GetDSHP(cboKhoa.SelectedValue.ToString());
            cboHocPhan.DisplayMember = "TENHOCPHAN";
            cboHocPhan.ValueMember = "MAHOCPHAN";

            dt = CaThi_DAO.Get_DS_CaThi_MaHocPhan(cboHocPhan.SelectedValue.ToString());
            // Kiểm tra mã giảng viên 
            // True -> Nếu là giảng viên
            if (check_role_id) 
            {
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, true, dt);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
            // False -> Nếu là nhân viên phòng khảo thí
            else
            {
                btnTaoCaThi.Visible = false;
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, false, dt);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }

        private void btnTaoCaThi_Click(object sender, EventArgs e)
        {
            frmTaoCaThi frmTaoCaThi = new frmTaoCaThi(pnContent, true, 0, null, null, null);
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
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, true, dt);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
            // False -> Nếu là nhân viên phòng khảo thí
            else
            {
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, false, dt);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHocPhan.DataSource = HocPhan_DAO.GetDSHP(cboKhoa.SelectedValue.ToString());
            cboHocPhan.DisplayMember = "TENHOCPHAN";
            cboHocPhan.ValueMember = "MAHOCPHAN";
        }

        private void cboHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check_role_id == true)
            {
                DataTable data = CaThi_DAO.Get_DS_CaThi_MaHocPhan(cboHocPhan.SelectedValue.ToString());
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, true, data);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }    
            else
            {
                DataTable data = CaThi_DAO.Get_DS_CaThi_MaHocPhan(cboHocPhan.SelectedValue.ToString());
                frmDSCaThi frmDSCaThi = new frmDSCaThi(pnContent, false, data);
                frmDSCaThi.Dock = DockStyle.Fill;
                pnContent.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }
    }
}
