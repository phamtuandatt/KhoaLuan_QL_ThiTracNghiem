using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.DuyetNHCauHoi;
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

namespace App_QL_ThiTracNghiem.GUI.CauHoi
{
    public partial class frmDS_MonHoc_CauHoi : UserControl
    {
        KryptonPanel pnContent;
        bool check_duyet_nh_cauhoi;
        public frmDS_MonHoc_CauHoi()
        {
            InitializeComponent();
        }

        public frmDS_MonHoc_CauHoi(KryptonPanel pnContent, bool check_duyet_nh_cauhoi)
        {
            InitializeComponent();
            this.pnContent = pnContent;
            this.check_duyet_nh_cauhoi = check_duyet_nh_cauhoi;
            Show_CT_NganHangCauHoi();
        }

        private void Show_CT_NganHangCauHoi()
        {
            gridDSMonHoc.DataSource = NganHangCauHoi_DAO.Get_CT_NganHangCauHoi();
        }

        private void gridDSMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu được gọi từ frmDuyetNHCauHoi
            // Được gọi từ frmDuyetNHCauHoi -> true
            if (check_duyet_nh_cauhoi)
            {
                frmDuyetCauHoi frmDuyetCauHoi = new frmDuyetCauHoi(1);
                frmDuyetCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
                pnContent.Controls.Add(frmDuyetCauHoi);
                frmDuyetCauHoi.BringToFront();

            }
            // ĐƯợc gọi từ frmNganHangCauHoi -> false
            else
            {
                // Lấy mã ngân hàng, mã học phần
                int row_sl = gridDSMonHoc.CurrentRow.Index;
                int MANGANHANG = int.Parse(gridDSMonHoc.Rows[row_sl].Cells[0].Value.ToString());
                string MAHOCPHAN = gridDSMonHoc.Rows[row_sl].Cells[5].Value.ToString();

                frmCT_CauHoi frmCT_MonHoc = new frmCT_CauHoi(MANGANHANG, MAHOCPHAN);
                frmCT_MonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
                pnContent.Controls.Add(frmCT_MonHoc);
                frmCT_MonHoc.BringToFront();
            }
        }
    }
}
