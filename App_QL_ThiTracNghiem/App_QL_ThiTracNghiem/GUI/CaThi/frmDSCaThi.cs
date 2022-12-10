using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.TaoDeThi;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    public partial class frmDSCaThi : UserControl
    {
        KryptonPanel content;
        bool check_user;
        DataTable dt;
        public frmDSCaThi()
        {
            InitializeComponent();
        }

        public frmDSCaThi(KryptonPanel content, bool check_user, DataTable dt)
        {
            InitializeComponent();
            this.content = content;
            this.check_user = check_user;
            this.dt = dt;
            gridDSCaThi.DataSource = dt;
             
            //Show_DS_CaThi();
            // Nếu true -> Là giảng viên -> Tạo ca thi, sửa ca thi
            if (check_user)
            {
                gridDSCaThi.Columns[5].Visible = false;
                gridDSCaThi.Columns[0].Visible = false;
            }
            // Nêu false -> Là nhân viên phòng khảo thí -> Ẩn 2 cột edit, delete
            else
            {

            }
        }

        //public void Show_DS_CaThi()
        //{
        //    gridDSCaThi.DataSource = CaThi_DAO.Get_DS_CaThi();
        //}

        private void gridDSCaThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // True -> Giảng viên -> Xem CT ca thi
            if (check_user)
            {
                // Khi nhấn vào từng ca thi -> Hiển thị thông tin chi tiết ca thi
                int rsl = gridDSCaThi.CurrentRow.Index;
                int MACATHI = int.Parse(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString());
                string MAHOCPHAN = gridDSCaThi.Rows[rsl].Cells[2].Value.ToString();
                string TENHOCPHAN = gridDSCaThi.Rows[rsl].Cells[3].Value.ToString();

                CaThis ct = new CaThis();
                ct.MaCaThi = MACATHI;
                ct.MaHocPhan = MAHOCPHAN;
                ct.MaDeThi = gridDSCaThi.Rows[rsl].Cells[4].Value.ToString();
                ct.NgayThi = DateTime.Parse(gridDSCaThi.Rows[rsl].Cells[6].Value.ToString());
                ct.GioLamBai = gridDSCaThi.Rows[rsl].Cells[7].Value.ToString();

                frmTaoCaThi frmTaoCaThi = new frmTaoCaThi(content, false, MACATHI, MAHOCPHAN, TENHOCPHAN, ct);
                frmTaoCaThi.Dock = DockStyle.Fill;
                content.Controls.Add(frmTaoCaThi);
                frmTaoCaThi.BringToFront();
            }
            // False -> Nhân viên phòng khảo thì 
            // -> Click vào row -> Hiện cửa sổ cho phép chọn Đề thi cho ca thi
            else
            {
                if (e.ColumnIndex == 0)
                {
                    if (KryptonMessageBox.Show("Bạn có muốn CHO PHÉP THI hay không !", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                    // Cập nhật tình trạng ca thi -> true;
                    // Kiểm tra ca thi đã có đề thi hay chưa
                    // Chưa thì bắt cập nhật đề thi trước     
                    int rsl = gridDSCaThi.CurrentRow.Index;
                    if (gridDSCaThi.Rows[rsl].Cells[5].Value.ToString().Trim() == "CHUA CÓ")
                    {
                        frmShowDS_DeThiCon dtc = new frmShowDS_DeThiCon(int.Parse(gridDSCaThi.Rows[rsl].Cells[4].Value.ToString()), int.Parse(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()));
                        dtc.ShowDialog();
                        gridDSCaThi.DataSource = dt;
                        if (dtc.check == false)
                        {
                            return;
                        }
                        // Kiểm tra tình trạng ca thi -> đã là 1 thì k cho update nữa
                        if (CaThi_DAO.CheckTinhTrangCaThi(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()))
                        {
                            KryptonMessageBox.Show("Ca thi đã được thi !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (CaThi_DAO.UpdateTinhTrangCaThi(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()))
                        {
                            KryptonMessageBox.Show("CHO PHÉP THI thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Kiểm tra tình trạng ca thi -> đã là 1 thì k cho update nữa
                        if (CaThi_DAO.CheckTinhTrangCaThi(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()))
                        {
                            KryptonMessageBox.Show("Ca thi đã được thi !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (CaThi_DAO.UpdateTinhTrangCaThi(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()))
                        {
                            KryptonMessageBox.Show("CHO PHÉP THI thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            KryptonMessageBox.Show("CHO PHÉP THI KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Cửa sổ chọn đề thi
                if (e.ColumnIndex == 5)
                {
                    int rsl = gridDSCaThi.CurrentRow.Index;
                    // Hiện các đề của tổ hợp đề cho chọn
                    frmShowDS_DeThiCon dtc = new frmShowDS_DeThiCon(int.Parse(gridDSCaThi.Rows[rsl].Cells[4].Value.ToString()), int.Parse(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()));
                    dtc.ShowDialog();
                    gridDSCaThi.DataSource = dt;
                }
            }
        }
    }
}
