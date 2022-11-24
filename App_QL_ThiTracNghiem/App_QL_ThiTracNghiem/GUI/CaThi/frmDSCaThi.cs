using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.GUI.TaoDeThi;
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
            // Nếu true -> Là giảng viên -> Tạo ca thi, sửa ca thi
            // Nêu false -> Là nhân viên phòng khảo thí -> Ẩn 2 cột edit, delete

            Show_DS_CaThi();
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
                int MACATHI = int.Parse(gridDSCaThi.Rows[rsl].Cells[2].Value.ToString());
                string MAHOCPHAN = gridDSCaThi.Rows[rsl].Cells[3].Value.ToString();
                string TENHOCPHAN = gridDSCaThi.Rows[rsl].Cells[4].Value.ToString();

                frmTaoCaThi frmTaoCaThi = new frmTaoCaThi(content, false, MACATHI, MAHOCPHAN, TENHOCPHAN);
                frmTaoCaThi.Dock = DockStyle.Fill;
                content.Controls.Add(frmTaoCaThi);
                frmTaoCaThi.BringToFront();
            }
            // False -> Nhân viên phòng khảo thì 
            // -> Click vào row -> Hiện cửa sổ cho phép chọn Đề thi cho ca thi
            else
            {
                // Cửa sổ chọn đề thi
            }
        }
    }
}
