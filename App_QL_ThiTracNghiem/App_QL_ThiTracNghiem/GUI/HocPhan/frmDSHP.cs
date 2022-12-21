using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
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
    public partial class frmDSHP : UserControl
    {
        KryptonPanel pnNoiDung;
        string MAKHOA;
        public frmDSHP(KryptonPanel pnNoiDung ,string MAKHOA)
        {
            InitializeComponent();
            this.pnNoiDung = pnNoiDung;
            this.MAKHOA = MAKHOA;

            Show_DSHP(MAKHOA);
        }

        public void Show_DSHP(string MAKHOA)
        {
            gridDSHP.DataSource = HocPhan_DAO.GetDSHP(MAKHOA);
        }

        private void gridDSHP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSHP.CurrentRow.Index;
            string MAHOCPHAN = gridDSHP.Rows[rsl].Cells[0].Value.ToString();

            frmDS_LopHocPhan dslhp = new frmDS_LopHocPhan(MAKHOA, MAHOCPHAN);
            dslhp.Dock = DockStyle.Fill;
            pnNoiDung.Controls.Add(dslhp);
            dslhp.BringToFront();
        }

        private void sỬAĐỔIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDSHP.RowCount <= 0)
            {
                return;
            }
            else
            {
                int rsl = gridDSHP.CurrentRow.Index;
                HocPhans hocPhan = new HocPhans();
                hocPhan.MaHocPhan = gridDSHP.Rows[rsl].Cells[0].Value.ToString();
                hocPhan.TenHocPhan = gridDSHP.Rows[rsl].Cells[1].Value.ToString();
                hocPhan.SoTC = int.Parse(gridDSHP.Rows[rsl].Cells[2].Value.ToString());
                hocPhan.SoTietLT = int.Parse(gridDSHP.Rows[rsl].Cells[3].Value.ToString());
                hocPhan.SoTietTH = int.Parse(gridDSHP.Rows[rsl].Cells[4].Value.ToString());
                hocPhan.MaKhoa = gridDSHP.Rows[rsl].Cells[6].Value.ToString();

                frmEditHP edit = new frmEditHP(hocPhan);
                edit.ShowDialog();
                Show_DSHP(MAKHOA);
            }
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDSHP.RowCount <= 0)
            {
                return;
            }
            else
            {
                int rsl = gridDSHP.CurrentRow.Index;
                string MAHOCPHAN = gridDSHP.Rows[rsl].Cells[0].Value.ToString();
                string TENHOCPHAN = gridDSHP.Rows[rsl].Cells[1].Value.ToString();
                if (KryptonMessageBox.Show($"Bạn có muốn xóa HỌC PHẦN [{TENHOCPHAN}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (HocPhan_DAO.DeleteHP(MAHOCPHAN))
                {
                    KryptonMessageBox.Show("Đã xóa HỌC PHẦN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Show_DSHP(MAKHOA);
                }
                else
                {
                    KryptonMessageBox.Show("Xóa HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show_DSHP(MAKHOA);
                }
            }
        }
    }
}
