using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        DeThis deThis;
        string TENHOCPHAN = "";
        string MADECON = "";
        List<CauHois> cauHois = new List<CauHois>();
        public frmTao_DeThi()
        {
            InitializeComponent();
        }

        public frmTao_DeThi(bool check_edit_DeThi, DeThis deThis, string MADECON, string TENHOCPHAN, List<CauHois> cauHois)
        {
            InitializeComponent();
            this.check_edit_DeThi = check_edit_DeThi;

            // Create
            if (check_edit_DeThi)
            {
                Load_Combox_HocPhan();
                cboHocPhan.SelectedIndex = 0;
                Show_DS_CauHoi_DaDuyet(cboHocPhan.SelectedValue.ToString());

                lblTT.Visible = false;
                lblNT.Visible = false;
                lblMaDe.Visible = false;
                txtTrangThai.Visible = false;
                txtNgayTao.Visible = false;
                cbolstDe.Visible = false;

            }
            // Edit
            else
            {
                this.deThis = deThis;
                this.TENHOCPHAN = TENHOCPHAN;
                this.MADECON = MADECON;
                this.cauHois = cauHois;

                Show_DS_CauHoi_DaDuyet(this.deThis.MaHocPhan);
                show_DS_DeThi_CauHOi();
                Show_DS_DeCon(deThis.MaDeThi);

                cboHocPhan.Text = TENHOCPHAN;
                if (CountElemntCbo(cbolstDe) == 1)
                {
                    cbolstDe.SelectedIndex = 0;
                }
                else
                {
                    cbolstDe.SelectedIndex = int.Parse(MADECON) - 1;
                }
                txtNgayTao.Text = deThis.NgayTao + "";
                txtSLCauHoi.Text = deThis.SLCauHoi + "";
                txtTGLamBai.Text = deThis.TGLamBai + "";
                if (this.deThis.TinhTrang == 0)
                {
                    txtTrangThai.Text = "Chưa được được sử dụng";
                }
                else
                {
                    txtTrangThai.Text = "Đã được sử dụng";
                }

                cboHocPhan.Enabled = false;
                cbolstDe.Enabled = false;
                txtSLCauHoi.ReadOnly = true;
                gridDSCauHoi.Columns[0].Visible = false;

                gridDSCauHoi.ContextMenuStrip = contextLeft;
                gridDSCHDuocChon.ContextMenuStrip = contextRight;
            }
        }

        public int CountElemntCbo(KryptonComboBox cbo)
        {
            int count = 0;
            foreach (var item in cbo.Items)
            {
                count++;
            }
            return count;
        }

        public void show_DS_DeThi_CauHOi()
        {
            foreach (var item in cauHois)
            {
                string[] row = new string[]
                {
                    item.MaCauHoi.ToString(),
                    item.NoiDung.ToString(),
                    item.DapAn1.ToString(),
                    item.DapAn2.ToString(),
                    item.DapAn3.ToString(),
                    item.DapAn4.ToString(),
                    item.DapAnDung.ToString(),
                };
                gridDSCHDuocChon.Rows.Add(row);
            }
        }

        private void Load_Combox_HocPhan()
        {
            cboHocPhan.DataSource = HocPhan_DAO.GetAllHocPhans();
            cboHocPhan.DisplayMember = "TENHOCPHAN";
            cboHocPhan.ValueMember = "MAHOCPHAN";
        }

        public void Show_DS_DeCon(int MADETHI)
        {
            cbolstDe.DataSource = CT_DeThi_DAO.Get_DS_DeCon(MADETHI);
            cbolstDe.DisplayMember = "MADECON";
            cbolstDe.ValueMember = "MADECON";
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
                    gridDSCauHoi.Rows[row_sl].Cells[0].Value = true;
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
                            gridDSCauHoi.Rows[row_sl].Cells[0].Value = false;
                            gridDSCHDuocChon.Rows.RemoveAt(i);
                            txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        gridDSCauHoi.Rows[row_sl].Cells[0].Value = true;
                        gridDSCHDuocChon.Rows.Add(row);
                        txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
                    }
                }
            }
        }

        int number_question = 0;
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
                if (frmChon_SL_CauHoi.Check == false)
                {
                    return;
                }

                int soLuong_CauHoi = frmChon_SL_CauHoi.SoLuong;
                if (soLuong_CauHoi > gridDSCauHoi.RowCount)
                {
                    KryptonMessageBox.Show("Số lượng câu hỏi muốn chọn vượt quá số lượng đang có !\nHãy chọn lại hoặc bổ sung câu hỏi.", "Cảnh báo",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }


                int total_row = gridDSCauHoi.RowCount;
                Random rd = new Random();
                List<int> numbeHasRandom = new List<int>();

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
                if (frmChon_SL_CauHoi.Check == false)
                {
                    return;
                }

                int soLuong_CauHoi = frmChon_SL_CauHoi.SoLuong;
                if (soLuong_CauHoi > gridDSCauHoi.RowCount)
                {
                    KryptonMessageBox.Show("Số lượng câu hỏi muốn chọn vượt quá số lượng đang có !\nHãy chọn lại hoặc bổ sung câu hỏi.", "Cảnh báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                int total_row = gridDSCauHoi.RowCount;
                Random rd = new Random();
                List<int> numbeHasRandom = new List<int>();
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
            if (txtTGLamBai.Text == "" || txtTGLamBai.Text.Length <= 0
                || gridDSCHDuocChon.RowCount <= 0)
            {
                KryptonMessageBox.Show("Hãy hoàn thành đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Thêm danh thông tin đề thi vào DETHI, CT_DETHI
            if (check_edit_DeThi)
            {
                // Hiện form cho chọn số lượng đề thi muốn sinh ra từ bộ câu hỏi
                frmChon_SL_CauHoi soluongde = new frmChon_SL_CauHoi(false, true);
                soluongde.ShowDialog();
                if (soluongde.Check == false)
                {
                    return;
                }

                List<string> dethi = soluongde.ds_DeThi;

                DeThis deThis = new DeThis();
                //deThis.MaDeThi = int.Parse(txtMaDe.Text.Trim());
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
                        cT_DeThis.MaDeThi = CT_DeThi_DAO.GetMaDeThi_MAX();
                        cT_DeThis.MaCauHoi = int.Parse(item.Cells[0].Value.ToString());

                        lst_CT_DeThi.Add(cT_DeThis);
                    }
                    if (CT_DeThi_DAO.Update_Database(lst_CT_DeThi, dethi))
                    {
                        KryptonMessageBox.Show("Tạo đề thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = "";
                        int sl = CT_DeThi_DAO.GetDS_DeThi_HocPhan(cboHocPhan.SelectedValue.ToString()).Count;
                        foreach (var item in CT_DeThi_DAO.GetDS_DeThi_HocPhan(cboHocPhan.SelectedValue.ToString()))
                        {
                            message += " - " + item + " - ";
                        }
                        KryptonMessageBox.Show($"Tạo đề thi KHÔNG thành công !\nMôn học này đã có {sl} đề thi {message} \t", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "";
                    int sl = CT_DeThi_DAO.GetDS_DeThi_HocPhan(cboHocPhan.SelectedValue.ToString()).Count;
                    foreach (var item in CT_DeThi_DAO.GetDS_DeThi_HocPhan(cboHocPhan.SelectedValue.ToString()))
                    {
                        message += " - " + item + " - ";
                    }
                    KryptonMessageBox.Show($"Tạo đề thi KHÔNG thành công !\nMôn học này đã có {sl} đề thi {message} \t", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Cập nhật câu hỏi cho đề thi
            else
            {
                string made_con = cbolstDe.SelectedValue.ToString().Trim();
                // Xóa CT_DeThi hiện tại
                if (CT_DeThi_DAO.DeleteCT_DeThi(deThis.MaDeThi, MADECON))
                {
                    DeThis deThi = new DeThis();
                    deThi.MaDeThi = deThis.MaDeThi;
                    deThi.MaHocPhan = this.deThis.MaHocPhan.Trim();
                    deThi.TGLamBai = int.Parse(txtTGLamBai.Text.Trim());
                    deThi.SLCauHoi = int.Parse(txtSLCauHoi.Text.Trim());
                    deThi.TinhTrang = 0;

                    if (DeThi_DAO.UpdateDeThi(deThis, made_con, deThis.MaHocPhan))
                    {
                        List<CT_DeThis> lst_CT_DeThi = new List<CT_DeThis>();
                        foreach (DataGridViewRow item in gridDSCHDuocChon.Rows)
                        {
                            CT_DeThis cT_DeThis = new CT_DeThis();
                            cT_DeThis.MaDeThi = deThis.MaDeThi;
                            cT_DeThis.MaDeCon = MADECON.Trim();
                            cT_DeThis.MaCauHoi = int.Parse(item.Cells[0].Value.ToString());

                            lst_CT_DeThi.Add(cT_DeThis);
                        }
                        if (CT_DeThi_DAO.Update_Database(lst_CT_DeThi, null))
                        {
                            KryptonMessageBox.Show("Cập nhật đề thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string message = "";
                            int sl = CT_DeThi_DAO.GetDS_DeThi_HocPhan(deThis.MaHocPhan).Count;
                            foreach (var item in CT_DeThi_DAO.GetDS_DeThi_HocPhan(deThis.MaHocPhan))
                            {
                                message += " - " + item + " - ";
                            }
                            KryptonMessageBox.Show($"Cập nhật đề thi KHÔNG thành công !\nMôn học này đã có {sl} đề thi {message} \t", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        string message = "";
                        int sl = CT_DeThi_DAO.GetDS_DeThi_HocPhan(deThis.MaHocPhan).Count;
                        foreach (var item in CT_DeThi_DAO.GetDS_DeThi_HocPhan(deThis.MaHocPhan))
                        {
                            message += " - " + item + " - ";
                        }
                        KryptonMessageBox.Show($"Tạo đề thi KHÔNG thành công !\nMôn học này đã có {sl} đề thi {message} \t", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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

        private void contextLeft_Click(object sender, EventArgs e)
        {
            int row_sl = gridDSCauHoi.CurrentRow.Index;
            gridDSCauHoi.Rows[row_sl].Cells[0].Value = true;

            foreach (DataGridViewRow item in gridDSCHDuocChon.Rows)
            {
                if (item.Cells[0].Value.ToString().Trim() == gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString().Trim())
                {
                    KryptonMessageBox.Show("Câu hỏi đã được chọn !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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
            txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
        }

        private void contextRight_Click(object sender, EventArgs e)
        {
            int rsl = gridDSCHDuocChon.CurrentRow.Index;
            gridDSCHDuocChon.Rows.RemoveAt(rsl);

            txtSLCauHoi.Text = gridDSCHDuocChon.RowCount + "";
        }

        private void gridDSCauHoi_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.gridDSCauHoi.ClearSelection();
                    this.gridDSCauHoi.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void txtTGLamBai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
