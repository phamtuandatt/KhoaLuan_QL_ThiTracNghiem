using App_QL_ThiTracNghiem.DAO;
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
            Show_DS_NganHangCauHoi_GiangVien();
        }

        private void Show_DS_NganHangCauHoi_GiangVien()
        {
            gridDSGiangVien.DataSource = NganHangCauHoi_DAO.Get_DS_NganHangCauHoi_GiangVien();
        }

        private void gridDSGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSGiangVien.CurrentRow.Index;
            int MANGANHANG = int.Parse(gridDSGiangVien.Rows[row_sl].Cells[4].Value.ToString());
            string MAGIANGVIEN = gridDSGiangVien.Rows[row_sl].Cells[0].Value.ToString();

            frmDS_MonHoc_CauHoi frmDSMonHoc = new frmDS_MonHoc_CauHoi(pnContent, true, MANGANHANG, MAGIANGVIEN);
            frmDSMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDSMonHoc);
            frmDSMonHoc.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {

        }
    }
}
