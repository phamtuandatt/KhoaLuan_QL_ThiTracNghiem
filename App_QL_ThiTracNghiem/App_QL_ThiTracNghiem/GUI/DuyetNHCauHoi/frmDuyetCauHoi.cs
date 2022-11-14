using App_QL_ThiTracNghiem.DAO;
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

namespace App_QL_ThiTracNghiem.GUI.DuyetNHCauHoi
{
    public partial class frmDuyetCauHoi : UserControl
    {
        int maMh;
        int MANGANHANG;
        string MAHOCPHAN;
        public frmDuyetCauHoi(int maMh)
        {
            InitializeComponent();
            this.maMh = maMh;
        }

        public frmDuyetCauHoi(int MANGANHANG, string MAHOCPHAN)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAHOCPHAN = MAHOCPHAN;

            Show_DS_CauHoi_HocPhan();
        }

        private void Show_DS_CauHoi_HocPhan()
        {
            gridDSCauHoi.DataSource = NganHangCauHoi_DAO.Get_DS_CauHoi(MANGANHANG, MAHOCPHAN);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void gridDSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sl = gridDSCauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDSCauHoi.Rows[row_sl].Cells[2].Value.ToString();
            txtA.Text = gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString();
            txtB.Text = gridDSCauHoi.Rows[row_sl].Cells[4].Value.ToString();
            txtC.Text = gridDSCauHoi.Rows[row_sl].Cells[5].Value.ToString();
            txtD.Text = gridDSCauHoi.Rows[row_sl].Cells[6].Value.ToString();
            string correct_answer = gridDSCauHoi.Rows[row_sl].Cells[7].Value.ToString().Trim();

            switch (correct_answer)
            {
                case "A": { radA.Checked = true; break; }
                case "B": { radB.Checked = true; break; }
                case "C": { radC.Checked = true; break; }
                case "D": { radD.Checked = true; break; }
            }

            // Kiểm tra nếu click checkbox thì tạo row -> thêm vào bảng bên dưới
            if (e.ColumnIndex == 0)
            {
                //KryptonMessageBox.Show(Convert.ToBoolean(gridDSCauHoi.Rows[row_sl].Cells[0].Value) + "");
                // Tạo dòng dữ liệu insert vào bảng dưới.
                string[] row = new string[]
                {
                    gridDSCauHoi.Rows[row_sl].Cells[2].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[7].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[3].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[4].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[5].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[6].Value.ToString(),
                    gridDSCauHoi.Rows[row_sl].Cells[1].Value.ToString(),
                };

                if (gridDS_CauHoi_Duyet.RowCount == 0)
                {
                    gridDS_CauHoi_Duyet.Rows.Add(row);
                }
                else
                {
                    bool status = false;
                    // Kiểm tra trong gridCauHoi_Duyet có tồn tại hay câu hỏi hay chưa
                    // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                    for (int i = 0; i < gridDS_CauHoi_Duyet.RowCount; i++)
                    {
                        if (gridDS_CauHoi_Duyet.Rows[i].Cells[6].Value.ToString().Trim()
                        .Equals(row[6].ToString().Trim()))
                        {
                            gridDS_CauHoi_Duyet.Rows.RemoveAt(i);
                            status = true;
                            return;
                        }
                    }
                    if (!status)
                    {
                        gridDS_CauHoi_Duyet.Rows.Add(row);
                    }
                }
            }
        }

    }
}
