using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    public partial class frmTao_DeThi : UserControl
    {
        bool check_edit_DeThi;
        public frmTao_DeThi()
        {
            InitializeComponent();
        }

        public frmTao_DeThi(bool check_edit_DeThi)
        {
            InitializeComponent();
            this.check_edit_DeThi = check_edit_DeThi;
            // Nếu là edit thì hiển thị thông tin đề thi và cập nhật
            // Nếu là tạo mới thì cho tạo mới
            // true -> tạo mới
            // false -> Edit

            Load_Combox_HocPhan();
            cboHocPhan.SelectedIndex = 0;
            Show_DS_CauHoi_DaDuyet(cboHocPhan.SelectedValue.ToString());
        }

        private void Load_Combox_HocPhan()
        {
            cboHocPhan.DataSource = HocPhan_DAO.GetAllHocPhans();
            cboHocPhan.DisplayMember = "TENHOCPHAN";
            cboHocPhan.ValueMember = "MAHOCPHAN";
        }

        private void Show_DS_CauHoi_DaDuyet(string MAHOCPHAN)
        {
            gridDSCauHoi.DataSource = NganHangCauHoi_DaDuyet_DAO.Get_DS_CauHoi_DaDuyet(MAHOCPHAN);
        }

        private void gridDSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSCauHoi.CurrentRow.Index;
            // Kiểm tra nếu click checkbox thì tạo row -> thêm vào bảng bên dưới
            if (e.ColumnIndex == 0)
            {
                // Tạo dòng dữ liệu insert vào bảng dưới.
                string[] row = new string[]
                {
                    gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[4].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[5].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[6].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[7].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[8].Value.ToString().Trim(),
                    gridDSCauHoi.Rows[row_sl].Cells[9].Value.ToString().Trim(),
                };

                if (gridDSCHDuocChon.RowCount == 0)
                {
                    gridDSCHDuocChon.Rows.Add(row);
                    txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
                }
                else
                {
                    bool status = false;
                    // Kiểm tra trong gridCauHoi_Duyet có tồn tại hay câu hỏi hay chưa
                    // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                    for (int i = 0; i < gridDSCHDuocChon.RowCount; i++)
                    {
                        if (gridDSCHDuocChon.Rows[i].Cells[1].Value.ToString().Trim()
                        .Equals(row[1].ToString().Trim()))
                        {
                            gridDSCHDuocChon.Rows.RemoveAt(i); 
                            txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        gridDSCHDuocChon.Rows.Add(row);
                        txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
                    }
                }
            }
        }

        private void btnRanDom_Click(object sender, EventArgs e)
        {
            if (gridDSCHDuocChon.RowCount > 0)
            {
                if (KryptonMessageBox.Show("Bạn đã thực hiện RANDOM câu hỏi+ cho cho đề thì môn [" + cboHocPhan.Text.ToUpper() + "]\nBạn có muốn RANDOM lại không ?", "Cảnh báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
                gridDSCHDuocChon.Rows.Clear();
                foreach (DataGridViewRow item in gridDSCauHoi.Rows)
                {
                    item.Cells[0].Value = false;
                }
                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi();
                frmChon_SL_CauHoi.ShowDialog();
                int soLuong_CauHoi = frmChon_SL_CauHoi.SoLuongCauHoi;

                int total_row = gridDSCauHoi.RowCount;
                Random rd = new Random();
                List<int> numbeHasRandom = new List<int>();
                int number_question = 0;
                while (number_question < soLuong_CauHoi)
                {
                    int row_sl = rd.Next(0, total_row);
                    while (numbeHasRandom.Contains(row_sl))
                    {
                        row_sl = rd.Next(0, total_row);
                    };
                    numbeHasRandom.Add(row_sl);

                    gridDSCauHoi.Rows[row_sl].Cells[0].Value = true;
                    string[] row = new string[]
                    {
                        gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[4].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[5].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[6].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[7].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[8].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[9].Value.ToString().Trim(),
                    };
                    gridDSCHDuocChon.Rows.Add(row);
                    number_question++;
                }
                txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
            }
            else
            {
                frmChon_SL_CauHoi frmChon_SL_CauHoi = new frmChon_SL_CauHoi();
                frmChon_SL_CauHoi.ShowDialog();
                int soLuong_CauHoi = frmChon_SL_CauHoi.SoLuongCauHoi;

                int total_row = gridDSCauHoi.RowCount;
                Random rd = new Random();
                List<int> numbeHasRandom = new List<int>();
                int number_question = 0;
                while (number_question < soLuong_CauHoi)
                {
                    int row_sl = rd.Next(0, total_row);
                    while (numbeHasRandom.Contains(row_sl))
                    {
                        row_sl = rd.Next(0, total_row);
                    };
                    numbeHasRandom.Add(row_sl);

                    gridDSCauHoi.Rows[row_sl].Cells[0].Value = true;
                    string[] row = new string[]
                    {
                        gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[4].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[5].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[6].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[7].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[8].Value.ToString().Trim(),
                        gridDSCauHoi.Rows[row_sl].Cells[9].Value.ToString().Trim(),
                    };
                    gridDSCHDuocChon.Rows.Add(row);
                    number_question++;
                }
                txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            // Thêm danh thông tin đề thi vào DETHI, CT_DETHI
            if (check_edit_DeThi)
            {
                DeThis deThis = new DeThis();
                deThis.MaDeThi = txtMaDe.Text.Trim();
                deThis.MaHocPhan = cboHocPhan.SelectedValue.ToString();
                deThis.NgayTao = DateTime.UtcNow;
                deThis.TGLamBai = int.Parse(txtTGLamBai.Text.Trim());
                deThis.SLCauHoi = int.Parse(txtSLCauHoi.Text.Trim());
                deThis.TinhTrang = 0;
                if (DeThi_DAO.Insert_DeThi(deThis))
                {
                    List<CT_DeThis> lst_CT_DeThi = new List<CT_DeThis>();
                    foreach (DataGridViewRow item in gridDSCHDuocChon.Rows)
                    {
                        CT_DeThis cT_DeThis = new CT_DeThis();
                        cT_DeThis.MaDeThi = txtMaDe.Text.Trim();
                        cT_DeThis.MaCauHoi = int.Parse(item.Cells[0].Value.ToString());
                        cT_DeThis.MaHocPhan = cboHocPhan.SelectedValue.ToString();

                        lst_CT_DeThi.Add(cT_DeThis);
                    }
                    if (CT_DeThi_DAO.Update_Database(lst_CT_DeThi))
                    {
                        KryptonMessageBox.Show("Tạo đề thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        KryptonMessageBox.Show("Tạo đề thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            // Cập nhật câu hỏi cho đề thi
            else
            {

            }

            
        }

        private void cboHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridDSCHDuocChon.RowCount > 0)
            {
                if (KryptonMessageBox.Show("Bạn đang thực hiện tạo đề thi cho môn [" + cboHocPhan.Text.ToUpper() + "]\nBạn có muốn hủy bỏ không ?", "Cảnh báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
                gridDSCHDuocChon.Rows.Clear();
            }
            Show_DS_CauHoi_DaDuyet(cboHocPhan.SelectedValue.ToString());
        }

        private void gridDSCauHoi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSCauHoi.CurrentRow.Index;
            int MACAUHOI = int.Parse(gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString().Trim());
            frmCT_DeThi_CauHoi frmCT_DeThi_CauHoi = new frmCT_DeThi_CauHoi(MACAUHOI);
            frmCT_DeThi_CauHoi.ShowDialog();
        }

        private void gridDSCHDuocChon_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSCHDuocChon.CurrentRow.Index;
            int MACAUHOI = int.Parse(gridDSCHDuocChon.Rows[row_sl].Cells[0].Value.ToString().Trim());
            frmCT_DeThi_CauHoi frmCT_DeThi_CauHoi = new frmCT_DeThi_CauHoi(MACAUHOI);
            frmCT_DeThi_CauHoi.ShowDialog();
        }
    }
}
