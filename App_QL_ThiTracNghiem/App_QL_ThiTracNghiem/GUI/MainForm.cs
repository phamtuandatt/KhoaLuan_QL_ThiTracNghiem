using App_QL_ThiTracNghiem.GUI.BaiThi;
using App_QL_ThiTracNghiem.GUI.CaThi;
using App_QL_ThiTracNghiem.GUI.DuyetNHCauHoi;
using App_QL_ThiTracNghiem.GUI.TaoDeThi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI
{
    public partial class MainForm : Form
    {
        int MANGANHANG;
        string MAGV;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(int MANGANHANG, string MAGV)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAGV = MAGV;
        }

        private void btnNganHangCauHoi_Click(object sender, EventArgs e)
        {
            // Lấy Mã ngân hàng - Mã giảng viên sau khi thực hiện đăng nhập
            frmNganHangCauHoi frmNHCH = new frmNganHangCauHoi(1, "01001001");
            frmNHCH.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(frmNHCH);
            frmNHCH.BringToFront();
        }

        private void btnDuyetNHCauHoi_Click(object sender, EventArgs e)
        {
            frmDuyetNHCauHoi frmDuyetCauHoi = new frmDuyetNHCauHoi();
            frmDuyetCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(frmDuyetCauHoi);
            frmDuyetCauHoi.BringToFront();
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            frmDeThi frmDeThi = new frmDeThi();
            frmDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(frmDeThi);
            frmDeThi.BringToFront();
        }

        private void btnCaThi_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người đăng nhập là nhân viên phòng khảo thí
            // -> Ẩn các chức năng Tạo ca thi - Sửa ca thi
            // True -> Giảng viên
            if (true)
            {
                frmCaThi frmDSCaThi = new frmCaThi(true);
                frmDSCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
                pnMain.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
            // False -> Nhân viên phòng khảo thí
            else
            {
                frmCaThi frmDSCaThi = new frmCaThi(false);
                frmDSCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
                pnMain.Controls.Add(frmDSCaThi);
                frmDSCaThi.BringToFront();
            }
        }

        private void btnChonCaThi_Click(object sender, EventArgs e)
        {
            frmCaThi frmDSCaThi = new frmCaThi(false);
            frmDSCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(frmDSCaThi);
            frmDSCaThi.BringToFront();
        }

        private void btnQuanLyBaiThi_Click(object sender, EventArgs e)
        {
            frmQL_BaiThi frmQL_BaiThi = new frmQL_BaiThi();
            frmQL_BaiThi.Dock = DockStyle.Fill;
            pnMain.Controls.Add(frmQL_BaiThi);
            frmQL_BaiThi.BringToFront();
        }
    }
}
