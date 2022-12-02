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
        int MACATHI;
        string MAHOCPHAN, TENHOCPHAN;
        CaThis ct;

        public frmTaoCaThi()
        {
            InitializeComponent();
        }
        public frmTaoCaThi(KryptonPanel content, bool check_create_edit, int MACATHI, string MAHOCPHAN, string TENHOCPHAN, CaThis ct)
        { 
            InitializeComponent();
            this.content = content;
            this.check_create_edit = check_create_edit;
            this.MACATHI = MACATHI;
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            this.ct = ct;

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
                btnSelectAll.Enabled = false;
                cboDSMonHoc.Enabled = false;
                cboDKLocSinhVien.Enabled = false;
                txtLoc.Visible = false;
                cboDKLocSinhVien.Visible = false;
                cboDSMonHoc.DropDownStyle = ComboBoxStyle.DropDown;
                cboDSMonHoc.Text = TENHOCPHAN;

                gridDSSVDuocChon.ContextMenuStrip = contextMenuSV;

                Show_DSSV_CaThi(this.MACATHI);
                Delete_Row_TableLayout();
            }
        }

        public void Show_DS_SV(string MAHOCPHAN)
        {
            gridDSSinhVien.DataSource = SinhVien_DAO.GetSinhViens(MAHOCPHAN);
        }

        public void Show_DSSV_CaThi(int MACATHI)
        {
            gridDSSVDuocChon.DataSource = CT_CaThi_DAO.GetDS_SinhVien(MACATHI);
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
            // Tạo ca thi
            if (check_create_edit)
            {
                List<string> lst_SV = new List<string>();
                foreach (DataGridViewRow item in gridDSSVDuocChon.Rows)
                {
                    lst_SV.Add(item.Cells[0].Value.ToString().Trim());
                }

                frmCT_CaThi frmCTCaThi = new frmCT_CaThi(true, cboDSMonHoc.SelectedValue.ToString(), cboDSMonHoc.Text.Trim(), lst_SV, null);
                frmCTCaThi.ShowDialog();
            }
            // Cập nhật ca thi
            else
            {
                List<string> lst_SV = new List<string>();
                foreach (DataGridViewRow item in gridDSSVDuocChon.Rows)
                {
                    lst_SV.Add(item.Cells[0].Value.ToString().Trim());
                }
                CaThis cts = new CaThis();
                cts.MaCaThi = MACATHI;
                cts.MaHocPhan = MAHOCPHAN;
                cts.MaDeThi = ct.MaDeThi;
                cts.NgayThi = ct.NgayThi;
                cts.GioLamBai = ct.GioLamBai;
                cts.TinhTrang = ct.TinhTrang;


                frmCT_CaThi frmCTCaThi = new frmCT_CaThi(false, MAHOCPHAN, cboDSMonHoc.Text.Trim(), lst_SV, ct);
                frmCTCaThi.ShowDialog();
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            // Truyền môn học vào form để hiển thị danh sách sinh viên đang theo học môn học đó
            frmThemSV frmThemSV = new frmThemSV(MACATHI ,MAHOCPHAN, TENHOCPHAN);
            frmThemSV.ShowDialog();
            Show_DSSV_CaThi(MACATHI);
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

                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi(true, false);
                frmChon_SL_CauHoi.ShowDialog();
                if (frmChon_SL_CauHoi.Check == false)
                {
                    return;
                }
                int soLuong = frmChon_SL_CauHoi.SoLuong;

                while (soLuong > gridDSSinhVien.RowCount)
                {
                    KryptonMessageBox.Show("Số lượng sinh viên muốn chọn vượt quá số lượng đang có !\nHãy chọn lại hoặc bổ sung sinh viên.", "Cảnh báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    frmChon_SL_CauHoi.ShowDialog();
                    soLuong = frmChon_SL_CauHoi.SoLuong;
                }

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
                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi(true, false);
                frmChon_SL_CauHoi.ShowDialog();
                if (frmChon_SL_CauHoi.Check == false)
                {
                    return;
                }
                int soLuong = frmChon_SL_CauHoi.SoLuong;

                while (soLuong > gridDSSinhVien.RowCount)
                {
                    KryptonMessageBox.Show("Số lượng sinh viên muốn chọn vượt quá số lượng đang có !\nHãy chọn lại hoặc bổ sung sinh viên.", "Cảnh báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    frmChon_SL_CauHoi.ShowDialog();
                    soLuong = frmChon_SL_CauHoi.SoLuong;
                }

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
            gridDSSVDuocChon.Rows.Clear();
        }

        private void contextMenuSV_Click(object sender, EventArgs e)
        {
            int rowSL = gridDSSVDuocChon.CurrentRow.Index;
            string masv = gridDSSVDuocChon.Rows[rowSL].Cells[0].Value.ToString().Trim();
            foreach (DataGridViewRow item in gridDSSVDuocChon.Rows)
            {
                if (item.Cells[0].Value.ToString().Trim() == masv)
                {
                    gridDSSVDuocChon.Rows.RemoveAt(item.Index);
                }
            }
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
                    gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                    gridDSSVDuocChon.Rows.Add(row);
                }
                else
                {
                    bool status = false;
                    // Kiểm tra trong gridCauHoi_Duyet có tồn tại hay câu hỏi hay chưa
                    // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                    for (int i = 0; i < gridDSSVDuocChon.RowCount; i++)
                    {
                        if (gridDSSVDuocChon.Rows[i].Cells[0].Value.ToString().Trim()
                        .Equals(row[0].ToString().Trim()))
                        {
                            gridDSSinhVien.Rows[rsl].Cells[0].Value = false;
                            gridDSSVDuocChon.Rows.RemoveAt(i);
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                        gridDSSVDuocChon.Rows.Add(row);
                    }
                }
            }
        }
    }
}
