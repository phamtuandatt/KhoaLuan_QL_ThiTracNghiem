using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
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
        DeThis deThis;
        string TENHOCPHAN = "";
        public frmCT_DeThi()
        {
            InitializeComponent();
        }

        public frmCT_DeThi(KryptonPanel panel, DeThis deThis, string TENHOCPHAN)
        {
            InitializeComponent();
            this.panel = panel;
            this.deThis = deThis;
            this.TENHOCPHAN = TENHOCPHAN;

            txtTenHP.Text = this.TENHOCPHAN;
            txtMaDe.Text = this.deThis.MaDeThi;
            txtSLCauHoi.Text = this.deThis.SLCauHoi + "";
            txtTGLamBai.Text = this.deThis.TGLamBai + "";

            Show_DS_CauHoi();
        }

        public void Show_DS_CauHoi()
        {
            gridDSCauHoi_DeThi.DataSource = CT_DeThi_DAO.GetDS_DeThi_CauHoi(deThis.MaDeThi.Trim(), deThis.MaHocPhan.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DeThis deThi = new DeThis();
            deThi.MaDeThi = txtMaDe.Text.Trim();
            deThi.MaHocPhan = this.deThis.MaHocPhan.Trim();
            deThi.TGLamBai = int.Parse(txtTGLamBai.Text.Trim());
            deThi.SLCauHoi = int.Parse(txtSLCauHoi.Text.Trim());

            List<CauHois> cauHois = new List<CauHois>();

            for (int i = 0; i < gridDSCauHoi_DeThi.RowCount; i++)
            {
                CauHois qs = new CauHois();
                qs.MaCauHoi = int.Parse(gridDSCauHoi_DeThi.Rows[i].Cells[1].Value.ToString().Trim());
                qs.NoiDung = gridDSCauHoi_DeThi.Rows[i].Cells[2].Value.ToString().Trim();
                qs.DapAn1 = gridDSCauHoi_DeThi.Rows[i].Cells[3].Value.ToString().Trim();
                qs.DapAn2 = gridDSCauHoi_DeThi.Rows[i].Cells[4].Value.ToString().Trim();
                qs.DapAn3 = gridDSCauHoi_DeThi.Rows[i].Cells[5].Value.ToString().Trim();
                qs.DapAn4 = gridDSCauHoi_DeThi.Rows[i].Cells[6].Value.ToString().Trim();
                qs.DapAnDung = gridDSCauHoi_DeThi.Rows[i].Cells[7].Value.ToString().Trim();

                cauHois.Add(qs);
            }

            frmTao_DeThi frmTao_DeThi = new frmTao_DeThi(false, deThis, txtTenHP.Text.Trim(), cauHois);
            frmTao_DeThi.Dock = DockStyle.Fill;
            panel.Controls.Add(frmTao_DeThi);
            frmTao_DeThi.BringToFront();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
