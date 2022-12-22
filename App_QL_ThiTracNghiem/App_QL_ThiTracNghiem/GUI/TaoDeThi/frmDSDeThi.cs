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
    public partial class frmDSDeThi : UserControl
    {
        KryptonPanel panel;
        public frmDSDeThi(KryptonPanel panel)
        { 
            InitializeComponent();
            this.panel = panel;
            Show_DS_DeThi();
        }

        public void Show_DS_DeThi()
        {
            cboDSMonHoc.DataSource = HocPhan_DAO.GetAllHocPhans();
            cboDSMonHoc.DisplayMember = "TENHOCPHAN";
            cboDSMonHoc.ValueMember = "MAHOCPHAN";
            gridDSDeThi.DataSource = DeThi_DAO.GetDS_DeThi(cboDSMonHoc.SelectedValue.ToString().Trim());
        }

        private void cboDSMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDSDeThi.DataSource = DeThi_DAO.GetDS_DeThi(cboDSMonHoc.SelectedValue.ToString().Trim());
        }

        private void gridDSDeThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSDeThi.CurrentRow.Index;
            DeThis deThis = new DeThis();
            deThis.MaDeThi = int.Parse(gridDSDeThi.Rows[rsl].Cells[0].Value.ToString().Trim());
            deThis.MaHocPhan = gridDSDeThi.Rows[rsl].Cells[1].Value.ToString();
            deThis.NgayTao = DateTime.Parse(gridDSDeThi.Rows[rsl].Cells[3].Value.ToString());
            deThis.TGLamBai = int.Parse(gridDSDeThi.Rows[rsl].Cells[4].Value.ToString());
            deThis.SLCauHoi = int.Parse(gridDSDeThi.Rows[rsl].Cells[5].Value.ToString());
            if (bool.Parse(gridDSDeThi.Rows[rsl].Cells[6].Value.ToString()) == true)
            {
                deThis.TinhTrang = 1;
            }
            else
            {
                deThis.TinhTrang = 0;
            }


            frmCT_DeThi frmCT_DeThi = new frmCT_DeThi(panel, deThis, cboDSMonHoc.Text.ToString());
            frmCT_DeThi.Dock = DockStyle.Fill;
            panel.Controls.Add(frmCT_DeThi);
            frmCT_DeThi.BringToFront();
        }
    }
}
