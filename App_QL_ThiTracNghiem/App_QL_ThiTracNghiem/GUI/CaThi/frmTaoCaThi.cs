using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.CaThi;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Word;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    public partial class frmTaoCaThi : UserControl
    {
        KryptonPanel content;
        bool check_create_edit;
        public frmTaoCaThi()
        {
            InitializeComponent();
        }
        public frmTaoCaThi(KryptonPanel content, bool check_create_edit)
        {
            InitializeComponent();
            this.content = content;
            this.check_create_edit = check_create_edit;
            // Nếu là true -> Tạo mới ca thi
            if (this.check_create_edit)
            {
                btnThemSV.Visible = false;
                cboDSMonHoc.DataSource = HocPhan_DAO.GetAllHocPhans();
                cboDSMonHoc.DisplayMember = "TENHOCPHAN";
                cboDSMonHoc.ValueMember = "MAHOCPHAN";
                cboDSMonHoc.SelectedIndex = 0;
                Show_DS_SV(cboDSMonHoc.SelectedValue.ToString());
            }
            // Nếu là false -> Cập nhật sửa đổi ca thi
            else
            {
                btnThemSV.Visible = true;
                Delete_Row_TableLayout();
            }
        }

        public void Show_DS_SV(string MAHOCPHAN)
        {
            gridDSSinhVien.DataSource = SinhVien_DAO.GetSinhViens(MAHOCPHAN);
        }

        public void Delete_Row_TableLayout()
        {
            // delete all controls of row that we want to delete
            for (int i = 0; i < tableLayoutContent.ColumnCount; i++)
            {
                var control = tableLayoutContent.GetControlFromPosition(i, 0);
                tableLayoutContent.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = 0 + 1; i < tableLayoutContent.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutContent.ColumnCount; j++)
                {
                    var control = tableLayoutContent.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        tableLayoutContent.SetRow(control, i - 1);
                    }
                }
            }

            var removeStyle = tableLayoutContent.RowCount - 1;

            if (tableLayoutContent.RowStyles.Count > removeStyle)
                tableLayoutContent.RowStyles.RemoveAt(removeStyle);

            tableLayoutContent.RowCount--;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string> lst_SV = new List<string>();
            foreach (DataGridViewRow item in gridDSSVDuocChon.Rows)
            {
                lst_SV.Add(item.Cells[0].Value.ToString().Trim());
            }

            frmCT_CaThi frmCTCaThi = new frmCT_CaThi(cboDSMonHoc.SelectedValue.ToString(), cboDSMonHoc.Text.Trim(), lst_SV);
            frmCTCaThi.ShowDialog();
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            // Truyền môn học vào form để hiển thị danh sách sinh viên đang theo học môn học đó
            frmThemSV frmThemSV = new frmThemSV(5);
            frmThemSV.ShowDialog();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (gridDSSVDuocChon.RowCount > 0)
            {
                if (KryptonMessageBox.Show("Bạn đã thực hiện CHỌN DANH SÁCH SINH VIÊN cho HỌC PHẦN [" + cboDSMonHoc.Text + "".ToUpper() + "]\nBạn có muốn tiếp tục lại không ?", "Cảnh báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
                gridDSSVDuocChon.Rows.Clear();
                foreach (DataGridViewRow item in gridDSSinhVien.Rows)
                {
                    item.Cells[0].Value = false;
                }

                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi(true);
                frmChon_SL_CauHoi.ShowDialog();
                int soLuong = frmChon_SL_CauHoi.SoLuongCauHoi;

                for (int i = 0; i < soLuong; i++)
                {
                    gridDSSinhVien.Rows[i].Cells[0].Value = true;
                    string[] row = new string[]
                    {
                        gridDSSinhVien.Rows[i].Cells[1].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[2].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[3].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[4].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[9].Value.ToString(),
                    };
                    gridDSSVDuocChon.Rows.Add(row);
                }
            }
            else
            {
                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi(true);
                frmChon_SL_CauHoi.ShowDialog();
                int soLuong = frmChon_SL_CauHoi.SoLuongCauHoi;

                for (int i = 0; i < soLuong; i++)
                {
                    gridDSSinhVien.Rows[i].Cells[0].Value = true;
                    string[] row = new string[]
                    {
                        gridDSSinhVien.Rows[i].Cells[1].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[2].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[3].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[4].Value.ToString(),
                        gridDSSinhVien.Rows[i].Cells[9].Value.ToString(),
                    };
                    gridDSSVDuocChon.Rows.Add(row);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void cboDSMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_DS_SV(cboDSMonHoc.SelectedValue.ToString());
        }

        private void gridDSSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rsl = gridDSSinhVien.CurrentRow.Index;
            if (e.ColumnIndex == 0)
            {
                string[] row = new string[]
                {
                    gridDSSinhVien.Rows[rsl].Cells[1].Value.ToString(),
                    gridDSSinhVien.Rows[rsl].Cells[2].Value.ToString(),
                    gridDSSinhVien.Rows[rsl].Cells[3].Value.ToString(),
                    gridDSSinhVien.Rows[rsl].Cells[4].Value.ToString(),
                    gridDSSinhVien.Rows[rsl].Cells[9].Value.ToString(),
                };

                if (gridDSSVDuocChon.RowCount == 0)
                {
                    gridDSSVDuocChon.Rows.Add(row);
                }
                else
                {
                    bool status = false;
                    // Kiểm tra trong gridCauHoi_Duyet có tồn tại hay câu hỏi hay chưa
                    // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                    for (int i = 0; i < gridDSSVDuocChon.RowCount; i++)
                    {
                        if (gridDSSVDuocChon.Rows[i].Cells[1].Value.ToString().Trim()
                        .Equals(row[1].ToString().Trim()))
                        {
                            gridDSSVDuocChon.Rows.RemoveAt(i);
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        gridDSSVDuocChon.Rows.Add(row);
                    }
                }

            }
        }
    }
}
