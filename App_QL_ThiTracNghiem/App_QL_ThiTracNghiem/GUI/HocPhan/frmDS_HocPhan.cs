using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
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

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmDS_HocPhan : UserControl
    {
        public frmDS_HocPhan()
        {
            InitializeComponent();
            Show_DSHP();
        }

        public void Show_DSHP()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";

            gridDSHP.DataSource = HocPhan_DAO.GetDSHP("01");
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rsl = gridDSHP.CurrentRow.Index;
            string MAHOCPHAN = gridDSHP.Rows[rsl].Cells[0].Value.ToString();
            string TENHOCPHAN = gridDSHP.Rows[rsl].Cells[1].Value.ToString();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa HỌC PHÂN [{TENHOCPHAN}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (HocPhan_DAO.DeleteHP(MAHOCPHAN))
            {
                KryptonMessageBox.Show("Đã xóa HỌC PHẦN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_DSHP();
            }
            else
            {
                KryptonMessageBox.Show("Xóa HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Show_DSHP();
            }
        }

        private void sỬAĐỔIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HIển thị danh sách các lớp học phần của học phần khi click vào

            // Sau khi nhấn vào lớp học phần -> Hiện frmEdit_....

            int rsl = gridDSHP.CurrentRow.Index;
            HocPhans hocPhan = new HocPhans();
            hocPhan.MaHocPhan = gridDSHP.Rows[rsl].Cells[0].Value.ToString();
            hocPhan.TenHocPhan = gridDSHP.Rows[rsl].Cells[1].Value.ToString();
            hocPhan.SoTC = int.Parse(gridDSHP.Rows[rsl].Cells[2].Value.ToString());
            hocPhan.SoTietLT = int.Parse(gridDSHP.Rows[rsl].Cells[3].Value.ToString());
            hocPhan.SoTietTH = int.Parse(gridDSHP.Rows[rsl].Cells[4].Value.ToString()); 
            hocPhan.MaKhoa = gridDSHP.Rows[rsl].Cells[6].Value.ToString();

            CT_HocPhans ct_hocphan = CT_HocPhan_DAO.CT_HocPhan(hocPhan.MaHocPhan);

            frmAdd_Edit_HocPhan edit = new frmAdd_Edit_HocPhan(true, hocPhan, ct_hocphan);
            edit.ShowDialog();
            Show_DSHP();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_HocPhan edit = new frmAdd_Edit_HocPhan(false, null, null);
            edit.ShowDialog();
            Show_DSHP();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDSHP.DataSource = HocPhan_DAO.GetDSHP(cboKhoa.SelectedValue.ToString());
        }
    }
}
