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

namespace App_QL_ThiTracNghiem.GUI.GiangVien
{
    public partial class frmDSGiangVien : UserControl
    {
        public frmDSGiangVien()
        {
            InitializeComponent();
            Show_DSGV();
        }

        public void Show_DSGV()
        {
            gridDSGiangVien.DataSource = GiangVien_DAO.GetDSGV();
        }

        private void gridDSGiangVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSGiangVien.CurrentRow.Index;
            GiangViens gv = new GiangViens();
            gv.MaGV = gridDSGiangVien.Rows[rsl].Cells[0].Value.ToString().Trim();
            gv.TenGV = gridDSGiangVien.Rows[rsl].Cells[1].Value.ToString().Trim();
            gv.NgaySinh = DateTime.Parse(gridDSGiangVien.Rows[rsl].Cells[2].Value.ToString().Trim());
            gv.GioiTinh = gridDSGiangVien.Rows[rsl].Cells[3].Value.ToString().Trim();
            gv.QueQuan = gridDSGiangVien.Rows[rsl].Cells[4].Value.ToString().Trim();
            gv.HocVi = gridDSGiangVien.Rows[rsl].Cells[5].Value.ToString().Trim();
            gv.Sdt = gridDSGiangVien.Rows[rsl].Cells[6].Value.ToString().Trim();
            gv.Email = gridDSGiangVien.Rows[rsl].Cells[7].Value.ToString().Trim();
            gv.DiaChi = gridDSGiangVien.Rows[rsl].Cells[8].Value.ToString().Trim();
            gv.MaKhoa = gridDSGiangVien.Rows[rsl].Cells[11].Value.ToString().Trim();
            gv.MaChucVu = gridDSGiangVien.Rows[rsl].Cells[12].Value.ToString();

            frmAdd_Edit_GiangVien edit = new frmAdd_Edit_GiangVien(gv);
            edit.ShowDialog();
            Show_DSGV();
        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            int rsl = gridDSGiangVien.CurrentRow.Index;
            string MAGV = gridDSGiangVien.Rows[rsl].Cells[0].Value.ToString().Trim();
            string TENGV = gridDSGiangVien.Rows[rsl].Cells[1].Value.ToString().Trim();
            if (KryptonMessageBox.Show($"Bạn có muốn xóa giảng viên [{TENGV}] không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (GiangVien_DAO.DeleteGV(MAGV))
            {
                KryptonMessageBox.Show("Đã xóa Giảng viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("Xóa Giảng viên KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
