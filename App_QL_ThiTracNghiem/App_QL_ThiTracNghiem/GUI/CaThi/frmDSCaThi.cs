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
        public frmDSCaThi()
        {
            InitializeComponent();
        }

        public frmDSCaThi(KryptonPanel content, bool check_user)
        {
            InitializeComponent();
            this.content = content;
            this.check_user = check_user;

            Show_DS_CaThi();
            // Nếu true -> Là giảng viên -> Tạo ca thi, sửa ca thi
            if (check_user)
            {
                gridDSCaThi.Columns[5].Visible = false;
            }
            // Nêu false -> Là nhân viên phòng khảo thí -> Ẩn 2 cột edit, delete
            else
            {

            }
        }

        public void Show_DS_CaThi()
        {
            gridDSCaThi.DataSource = CaThi_DAO.Get_DS_CaThi();
        }

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
                if ((bool)gridDSCaThi.Rows[rsl].Cells[8].Value == false)
                {
                    ct.TinhTrang = 0;
                }
                else
                {
                    ct.TinhTrang = 1;
                }

                frmTaoCaThi frmTaoCaThi = new frmTaoCaThi(content, false, MACATHI, MAHOCPHAN, TENHOCPHAN, ct);
                frmTaoCaThi.Dock = DockStyle.Fill;
                content.Controls.Add(frmTaoCaThi);
                frmTaoCaThi.BringToFront();


            }
            // False -> Nhân viên phòng khảo thì 
            // -> Click vào row -> Hiện cửa sổ cho phép chọn Đề thi cho ca thi
            else
            {
                // Cửa sổ chọn đề thi
                if (e.ColumnIndex == 5)
                {
                    int rsl = gridDSCaThi.CurrentRow.Index;
                    // Hiện các đề của tổ hợp đề cho chọn
                    frmShowDS_DeThiCon dtc = new frmShowDS_DeThiCon(int.Parse(gridDSCaThi.Rows[rsl].Cells[4].Value.ToString()), int.Parse(gridDSCaThi.Rows[rsl].Cells[1].Value.ToString()));
                    dtc.ShowDialog();
                    Show_DS_CaThi();
                }
            }
        }
    }
}
