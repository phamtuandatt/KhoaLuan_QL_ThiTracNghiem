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
    public partial class frmTao_DeThi : UserControl
    {
        bool check_edit_DeThi;
        public frmTao_DeThi()
        {
            InitializeComponent();
        }

        public frmTao_DeThi(bool check_edit_DeThi)
        {
            InitializeComponent();
            this.check_edit_DeThi = check_edit_DeThi;
            // Nếu là edit thì hiển thị thông tin đề thi và cập nhật
            // Nếu là tạo mới thì cho tạo mới
        }

        private void gridDSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCT_DeThi_CauHoi frmCT_DeThi_CauHoi = new frmCT_DeThi_CauHoi(1);
            frmCT_DeThi_CauHoi.ShowDialog();
        }

        private void gridDSCHDuocChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCT_DeThi_CauHoi frmCT_DeThi_CauHoi = new frmCT_DeThi_CauHoi(1);
            frmCT_DeThi_CauHoi.ShowDialog();
        }

        private void btnRanDom_Click(object sender, EventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {

        }
    }
}
