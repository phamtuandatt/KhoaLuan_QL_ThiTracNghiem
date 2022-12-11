using App_QL_ThiTracNghiem.DAO;
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
    public partial class frmDSCaThi_DaThi : UserControl
    {
        KryptonPanel pnContent;
        public frmDSCaThi_DaThi()
        {
            InitializeComponent();
        }

        public frmDSCaThi_DaThi(KryptonPanel pnContent)
        {
            InitializeComponent();
            this.pnContent = pnContent;

            gridDSCaThi.DataSource = CaThi_DAO.GetDSCaThi();

        }

        private void gridDSCaThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSCaThi.CurrentRow.Index;
            int MACATHI = int.Parse(gridDSCaThi.Rows[rsl].Cells[0].Value.ToString());
            string MAHOCPHAN = gridDSCaThi.Rows[rsl].Cells[1].Value.ToString();
            string TENHOCPHAN = gridDSCaThi.Rows[rsl].Cells[2].Value.ToString();
            DateTime NGAYTHI = DateTime.Parse(gridDSCaThi.Rows[rsl].Cells[6].Value.ToString());

            frmDSBaiThi frmDSBaiThi = new frmDSBaiThi(pnContent, MACATHI, MAHOCPHAN, TENHOCPHAN, NGAYTHI);
            frmDSBaiThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSBaiThi); 
            frmDSBaiThi.BringToFront();
        }
    }
}
