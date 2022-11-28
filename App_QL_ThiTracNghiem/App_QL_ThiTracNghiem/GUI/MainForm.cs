using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.BaiThi;
using App_QL_ThiTracNghiem.GUI.CaThi;
using App_QL_ThiTracNghiem.GUI.DuyetNHCauHoi;
using App_QL_ThiTracNghiem.GUI.GiangVien;
using App_QL_ThiTracNghiem.GUI.HocPhan;
using App_QL_ThiTracNghiem.GUI.Khoa;
using App_QL_ThiTracNghiem.GUI.LopHoc;
using App_QL_ThiTracNghiem.GUI.SinhVien;
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
        GiangViens gv;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(int MANGANHANG, GiangViens gv)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.gv = gv;
            this.MAGV = gv.MaGV;
        }

        private void btnNganHangCauHoi_Click(object sender, EventArgs e)
        {
            // Lấy Mã ngân hàng - Mã giảng viên sau khi thực hiện đăng nhập
            frmNganHangCauHoi frmNHCH = new frmNganHangCauHoi(MANGANHANG, MAGV);
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

        private void picAnhDaiDien_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_GiangVien edit_gv = new frmAdd_Edit_GiangVien(gv);
            edit_gv.ShowDialog();
        }

        private void menuDSGiangVien_Click(object sender, EventArgs e)
        {
            frmDSGiangVien dsgv = new frmDSGiangVien();
            dsgv.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(dsgv);
            dsgv.BringToFront();
        }

        private void menuDSKhoa_Click(object sender, EventArgs e)
        {
            frmDS_Khoa dS_Khoa = new frmDS_Khoa();
            dS_Khoa.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(dS_Khoa);
            dS_Khoa.BringToFront();
        }

        private void menuHocPhan_Click(object sender, EventArgs e)
        {
            frmDS_HocPhan hp = new frmDS_HocPhan();
            hp.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(hp);
            hp.BringToFront();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDS_LopHoc lophoc = new frmDS_LopHoc();
            lophoc.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(lophoc);
            lophoc.BringToFront();
        }

        private void menuSinhVien_Click(object sender, EventArgs e)
        {
            frmDS_SinhVien sinhVien = new frmDS_SinhVien();
            sinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            pnMain.Controls.Add(sinhVien);
            sinhVien.BringToFront();
        }
    }
}
