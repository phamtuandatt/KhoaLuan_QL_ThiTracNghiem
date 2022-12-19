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
    public partial class frmQL_BaiThi : UserControl
    {
        public frmQL_BaiThi()
        {
            InitializeComponent();
            //frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            //frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            //pnContent.Controls.Add(frmDSCaThi_DaThi);
            //frmDSCaThi_DaThi.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDSCaThi_DaThi frmDSCaThi_DaThi = new frmDSCaThi_DaThi(pnContent);
            frmDSCaThi_DaThi.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frmDSCaThi_DaThi);
            frmDSCaThi_DaThi.BringToFront();
        }

        private void btnTKCaThi_Click(object sender, EventArgs e)
        {
            // Tạo cbo box hiển thị chi tiêt ca thi - MÔN HỌC - PHÒNG - TIẾT - 
            // Tạo DataTable gồm 2 thuộc tính - Tên: - MÔN HỌC - PHÒNG - TIẾT - 
            //                                - ID: - MÃ CA THI -
            // Gán vào cbo

            // Kiểm tra nếu check tìm theo ngày
            // Mà ngày > ngày hiện tại thì không tìm kiếm
            if (chkNgay.Checked == true && (cboDay.Value > DateTime.UtcNow))
            {
                KryptonMessageBox.Show($"Chưa có lịch thi trong ngày [{cboDay.Value.ToString()}] !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkNgay.Checked == true)
            {
                // Tìm kiếm theo 3 điều kiện
                gridDSCaThi.DataSource = CaThi_DAO.GetDSCaThiPhongTietNgay(cboPhong.Text.Trim(), cboTiet.Text.Trim(), cboDay.Value);
                if (gridDSCaThi.Rows.Count <= 0)
                {
                    KryptonMessageBox.Show($"Chưa có lịch thi trong ngày [{cboDay.Value.ToString()} - Phòng {cboPhong.Text.Trim()} - Tiết {cboTiet.Text.Trim()}] !",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtMH.Text = gridDSCaThi.Rows[0].Cells[2].Value.ToString();
                return;
            }
            // Tìm kiếm theo 2 điều kiện
            gridDSCaThi.DataSource = CaThi_DAO.GetDSCaThiPhongTiet(cboPhong.Text.Trim(), cboTiet.Text.Trim());
            if (gridDSCaThi.Rows.Count <= 0)
            {
                KryptonMessageBox.Show($"Chưa có lịch thi trong [Phòng {cboPhong.Text.Trim()} - Tiết {cboTiet.Text.Trim()}] !",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtMH.Text = gridDSCaThi.Rows[0].Cells[2].Value.ToString();
        }

        private void chkNgay_Click(object sender, EventArgs e)
        {
            if (chkNgay.Checked == true)
            {
                cboDay.Enabled = true;
            }
            else
            {
                cboDay.Enabled = false;
            }
            
        }


        // Tìm kiếm bài thi theo môn học, tiết thi, phòng thi
        // Nếu click chọn ngày thì tìm kiếm theo ngày và theo môn học, tiết thi, phòng thi
    }
}
