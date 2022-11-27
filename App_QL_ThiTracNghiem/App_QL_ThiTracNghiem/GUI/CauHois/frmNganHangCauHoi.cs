using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.GUI.CauHoi;
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

namespace App_QL_ThiTracNghiem.GUI
{
    public partial class frmNganHangCauHoi : UserControl
    {
        int MANGANHANG;
        string MAGV;
        public frmNganHangCauHoi()
        {
            InitializeComponent();
            frmDS_MonHoc_CauHoi frmDS_CauHoi = new frmDS_MonHoc_CauHoi(pnContent, false, MANGANHANG, MAGV);
            frmDS_CauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDS_CauHoi);
            frmDS_CauHoi.BringToFront();
        }

        public frmNganHangCauHoi(int MANGANHANG, string MAGV)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAGV = MAGV;

            frmDS_MonHoc_CauHoi frmDS_CauHoi = new frmDS_MonHoc_CauHoi(pnContent, false, MANGANHANG, MAGV);
            frmDS_CauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDS_CauHoi);
            frmDS_CauHoi.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDS_MonHoc_CauHoi frmDS_CauHoi = new frmDS_MonHoc_CauHoi(pnContent, false, MANGANHANG, MAGV);
            frmDS_CauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            pnContent.Controls.Add(frmDS_CauHoi);
            frmDS_CauHoi.BringToFront();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Truyền mã ngân hàng 
            // Truyền Mã giảng viên để lấy danh sách các học phần mà giảng viên phụ trách
            frmImportCH importCH = new frmImportCH(MANGANHANG, MAGV);
            importCH.ShowDialog();
            
        }

        private void btnTaoCauHoi_Click(object sender, EventArgs e)
        {
            frmTaoCauHoi frmTaoCauHoi = new frmTaoCauHoi(MANGANHANG, MAGV);
            frmTaoCauHoi.ShowDialog();
        }

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra số lượng môn học đã được giảng viên tạo
            // Nếu trong ngân hàng đã có tất cả các môn học mà giảng viên phụ trách thì không cho thêm nữa
            // Truyền mã giảng viên để lấy trong kho của giảng viên 
            DataTable count_ = HocPhan_DAO.GetHocPhan_NganHang(MANGANHANG, MAGV);
            if (count_.Rows.Count <= 0)
            {
                KryptonMessageBox.Show("Bạn đã tạo tất cả các môn học !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Lấy mã ngân hàng sau khi giảng viên đăng nhập vào -> Truyền vào để lấy danh sách môn học chưa được tạo của ngân hàng
                frmThemMonHoc frmThemMonHoc = new frmThemMonHoc(MANGANHANG, MAGV);
                frmThemMonHoc.ShowDialog();
            }
        }
    }
}
