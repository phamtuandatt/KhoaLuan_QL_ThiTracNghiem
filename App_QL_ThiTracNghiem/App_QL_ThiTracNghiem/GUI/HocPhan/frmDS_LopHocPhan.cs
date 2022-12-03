using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Docking;
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

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmDS_LopHocPhan : UserControl
    {
        string MAKHOA, MAHOCPHAN;
        public frmDS_LopHocPhan(string MAKHOA, string MAHOCPHAN)
        {
            InitializeComponent();
            this.MAKHOA = MAKHOA;
            this.MAHOCPHAN = MAHOCPHAN;

            gridDSLOPHP.DataSource = CT_HocPhan_DAO.GetDSLopHP(MAHOCPHAN);
        }

        private void xÓALỚPHỌCPHẦNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSLOPHP.CurrentRow.Index;
            string MALOPHOCPHAN = gridDSLOPHP.Rows[rsl].Cells[0].Value.ToString();
            //string TENHOCPHAN = gridDSLOPHP.Rows[rsl].Cells[1].Value.ToString();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa LỚP HỌC PHÂN [{""}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (CT_HocPhan_DAO.DeleteCT_HocPhan(MALOPHOCPHAN))
            {
                KryptonMessageBox.Show("Đã xóa LỚP HỌC PHẦN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridDSLOPHP.DataSource = CT_HocPhan_DAO.GetDSLopHP(MAHOCPHAN);
            }
            else
            {
                KryptonMessageBox.Show("Xóa LỚP HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridDSLOPHP.DataSource = CT_HocPhan_DAO.GetDSLopHP(MAHOCPHAN);
            }
        }

        private void tHÊMLỚPHỌCPHẦNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_HocPhan addHp = new frmAdd_Edit_HocPhan(false, true, MAKHOA, MAHOCPHAN);
            addHp.ShowDialog();
        }

        private void gridDSLOPHP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // HIển thị danh sách các lớp học phần của học phần khi click vào

            // Sau khi nhấn vào lớp học phần -> Hiện frmEdit_....

            int rsl = gridDSLOPHP.CurrentRow.Index;
            HocPhans hocPhan = HocPhan_DAO.GetHP(MAHOCPHAN);

            CT_HocPhans ct_hocphan = CT_HocPhan_DAO.CT_HocPhan(hocPhan.MaHocPhan);

            frmAdd_Edit_HocPhan edit = new frmAdd_Edit_HocPhan(true, hocPhan, ct_hocphan);
            edit.ShowDialog();
        }
    }
}
