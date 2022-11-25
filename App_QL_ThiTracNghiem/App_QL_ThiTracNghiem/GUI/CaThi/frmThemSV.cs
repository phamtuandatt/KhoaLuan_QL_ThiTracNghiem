using App_QL_ThiTracNghiem.DAO;
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
    public partial class frmThemSV : Form
    { 
        int MACATHI;
        string MAHOCPHAN, TENHOCPHAN;
        List<string> lst_SinhVien;

        public frmThemSV()
        {
            InitializeComponent();
        }

        public frmThemSV(int MACATHI, string MAHOCPHAN, string TENHOCPHAN)
        {
            InitializeComponent();
            this.MACATHI = MACATHI;
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            
            txtMonHoc.Text = TENHOCPHAN;
            cboDKLocSinhVien.SelectedIndex = 0;

            gridDSSinhVien.DataSource = CT_CaThi_DAO.GetDSSV_ChuaThi(this.MAHOCPHAN);

            lst_SinhVien = new List<string>();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CT_CaThi_DAO.Insert_CT_CaThi(lst_SinhVien, MACATHI))
            {
                if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                {
                    KryptonMessageBox.Show("Cập nhật danh sách sinh viên tham gia ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật danh sách sinh viên tham gia ca thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gridDSSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSSinhVien.CurrentRow.Index;
            string MASV = gridDSSinhVien.Rows[rsl].Cells[1].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                if (lst_SinhVien.Count == 0)
                {
                    lst_SinhVien.Add(MASV);
                }
                else
                {
                    bool status = false;
                    // Kiểm tra trong lst_SinhVien có tồn tại hay sinh vien hay chưa
                    // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                    for (int i = 0; i < lst_SinhVien.Count; i++)
                    {
                        if (lst_SinhVien[i].Equals(MASV))
                        {
                            lst_SinhVien.RemoveAt(i);
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        lst_SinhVien.Add(MASV);
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            frmChon_SL_CauHoi sl = new frmChon_SL_CauHoi(true, false);
            sl.ShowDialog();
            int soLuong = sl.SoLuong;
            
            for (int i = 0; i < soLuong; i++)
            {
                gridDSSinhVien.Rows[i].Cells[0].Value = true;
                lst_SinhVien.Add(gridDSSinhVien.Rows[i].Cells[1].Value.ToString());
            }
        }
    }
}
