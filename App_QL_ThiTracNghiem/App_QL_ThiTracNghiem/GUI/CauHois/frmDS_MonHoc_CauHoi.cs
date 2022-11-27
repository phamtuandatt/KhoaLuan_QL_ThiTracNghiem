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
        int MANGANHANG;
        string MAGIANGVIEN;

        public frmDS_MonHoc_CauHoi()
        {
            InitializeComponent();
        }

        public frmDS_MonHoc_CauHoi(KryptonPanel pnContent, bool check_duyet_nh_cauhoi, int MANGANHANG, string MAGIANGVIEN)
        {
            InitializeComponent();
            this.pnContent = pnContent;
            this.check_duyet_nh_cauhoi = check_duyet_nh_cauhoi;
            // Lấy danh sách các môn học theo từng ngân hàng được truyền từ Main
            this.MANGANHANG = MANGANHANG;
            this.MAGIANGVIEN = MAGIANGVIEN;
            Show_CT_NganHangCauHoi(); 
        }

        private void Show_CT_NganHangCauHoi()
        {
            gridDSMonHoc.DataSource = NganHangCauHoi_DAO.Get_CT_NganHangCauHoi(MANGANHANG);
        }

        private void gridDSMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSMonHoc.CurrentRow.Index;
            // Kiểm tra nếu được gọi từ frmDuyetNHCauHoi
            // Được gọi từ frmDuyetNHCauHoi -> true
            if (check_duyet_nh_cauhoi)
            {
                string MAHOCPHAN = gridDSMonHoc.Rows[row_sl].Cells[5].Value.ToString();
                string TENHOCPHAN = gridDSMonHoc.Rows[row_sl].Cells[1].Value.ToString();

                DataTable dt = NganHangCauHoi_DAO.Get_DS_CauHoi(MANGANHANG, MAHOCPHAN);
                if (dt.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("Ngân hàng câu hỏi đã được duyệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmDuyetCauHoi frmDuyetCauHoi = new frmDuyetCauHoi(MANGANHANG, MAHOCPHAN, TENHOCPHAN);
                    frmDuyetCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
                    pnContent.Controls.Add(frmDuyetCauHoi);
                    frmDuyetCauHoi.BringToFront();
                }
            }
            // ĐƯợc gọi từ frmNganHangCauHoi -> false
            else
            {
                // Lấy mã ngân hàng, mã học phần
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
