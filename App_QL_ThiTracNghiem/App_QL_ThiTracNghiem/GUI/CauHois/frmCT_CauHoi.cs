using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.CauHoi
{
    public partial class frmCT_CauHoi : UserControl
    {
        int MANGANHANG;
        string MAHOCPHAN;
        List<CauHois> lst_QuestionEdited = new List<CauHois>();
        public frmCT_CauHoi()
        {
            InitializeComponent();
        }

        public frmCT_CauHoi(int MANGANHANG, string MAHOCPHAN) 
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAHOCPHAN = MAHOCPHAN;

            Show_DS_CauHoi();
            radA.Enabled = false;
            radB.Enabled = false;
            radC.Enabled = false;
            radD.Enabled = false;
        }

        private void Show_DS_CauHoi()
        {
            gridDSCauHoi.DataSource = NganHangCauHoi_DAO.Get_DS_CauHoi(MANGANHANG, MAHOCPHAN);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = true;
            btnOk.Visible = true;
            btnUpDB.Visible = true;
            lblNoiDungCauHoi.ReadOnly = false;
            txtA.ReadOnly = false;
            txtB.ReadOnly = false;
            txtC.ReadOnly = false;
            txtD.ReadOnly = false;
           
            radA.Enabled = true;
            radB.Enabled = true;
            radC.Enabled = true;
            radD.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = false;
            btnOk.Visible = false;
            lblNoiDungCauHoi.ReadOnly = true;
            txtA.ReadOnly = true;
            txtB.ReadOnly = true;
            txtC.ReadOnly = true;
            txtD.ReadOnly = true;
            radA.Enabled = false;
            radB.Enabled = false;
            radC.Enabled = false;
            radD.Enabled = false;
            int id_row = gridDSCauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDSCauHoi.Rows[id_row].Cells[1].Value.ToString();
            txtA.Text = gridDSCauHoi.Rows[id_row].Cells[2].Value.ToString();
            txtB.Text = gridDSCauHoi.Rows[id_row].Cells[3].Value.ToString();
            txtC.Text = gridDSCauHoi.Rows[id_row].Cells[4].Value.ToString();
            txtD.Text = gridDSCauHoi.Rows[id_row].Cells[5].Value.ToString();
            string correct_answer = gridDSCauHoi.Rows[id_row].Cells[6].Value.ToString().Trim();
            switch (correct_answer)
            {
                case "A": { radA.Checked = true; radB.Checked = false; radC.Checked = false; radD.Checked = false; break; }
                case "B": { radA.Checked = false; radB.Checked = true; radC.Checked = false; radD.Checked = false; break; }
                case "C": { radA.Checked = false; radB.Checked = false; radC.Checked = true; radD.Checked = false; break; }
                case "D": { radA.Checked = false; radB.Checked = false; radC.Checked = false; radD.Checked = true; break; }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int id_row = gridDSCauHoi.CurrentRow.Index;
            gridDSCauHoi.Rows[id_row].Cells[1].Value = lblNoiDungCauHoi.Text;
            gridDSCauHoi.Rows[id_row].Cells[2].Value = txtA.Text;
            gridDSCauHoi.Rows[id_row].Cells[3].Value = txtB.Text;
            gridDSCauHoi.Rows[id_row].Cells[4].Value = txtC.Text;
            gridDSCauHoi.Rows[id_row].Cells[5].Value = txtD.Text;

            if (radA.Checked) gridDSCauHoi.Rows[id_row].Cells[6].Value = "A";
            if (radB.Checked) gridDSCauHoi.Rows[id_row].Cells[6].Value = "B";
            if (radC.Checked) gridDSCauHoi.Rows[id_row].Cells[6].Value = "C";
            if (radD.Checked) gridDSCauHoi.Rows[id_row].Cells[6].Value = "D";

            btnHuy.Visible = false;
            btnOk.Visible = false;
            lblNoiDungCauHoi.ReadOnly = true;
            txtA.ReadOnly = true;
            txtB.ReadOnly = true;
            txtC.ReadOnly = true;
            txtD.ReadOnly = true;
            radA.Enabled = false;
            radB.Enabled = false;
            radC.Enabled = false;
            radD.Enabled = false;

            // Lấy danh sách câu hỏi được chỉnh sửa
            CauHois cauHois = new CauHois();
            cauHois.MaCauHoi = (int.Parse(gridDSCauHoi.Rows[id_row].Cells[0].Value.ToString().Trim()));
            cauHois.NoiDung = gridDSCauHoi.Rows[id_row].Cells[1].Value.ToString().Trim();
            cauHois.DapAn1 = gridDSCauHoi.Rows[id_row].Cells[2].Value.ToString().Trim();
            cauHois.DapAn2 = gridDSCauHoi.Rows[id_row].Cells[3].Value.ToString().Trim();
            cauHois.DapAn3 = gridDSCauHoi.Rows[id_row].Cells[4].Value.ToString().Trim();
            cauHois.DapAn4 = gridDSCauHoi.Rows[id_row].Cells[5].Value.ToString().Trim();
            cauHois.DapAnDung = gridDSCauHoi.Rows[id_row].Cells[6].Value.ToString().Trim();

            lst_QuestionEdited.Add(cauHois);
        }

        private void gridDSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_row = gridDSCauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDSCauHoi.Rows[id_row].Cells[1].Value.ToString();
            txtA.Text = gridDSCauHoi.Rows[id_row].Cells[2].Value.ToString();
            txtB.Text = gridDSCauHoi.Rows[id_row].Cells[3].Value.ToString();
            txtC.Text = gridDSCauHoi.Rows[id_row].Cells[4].Value.ToString();
            txtD.Text = gridDSCauHoi.Rows[id_row].Cells[5].Value.ToString();
            string correct_answer = gridDSCauHoi.Rows[id_row].Cells[6].Value.ToString().Trim();
            switch (correct_answer)
            {
                case "A": { radA.Checked = true; radB.Checked = false; radC.Checked = false; radD.Checked = false; break; }
                case "B": { radA.Checked = false; radB.Checked = true; radC.Checked = false; radD.Checked = false; break; }
                case "C": { radA.Checked = false; radB.Checked = false; radC.Checked = true; radD.Checked = false; break; }
                case "D": { radA.Checked = false; radB.Checked = false; radC.Checked = false; radD.Checked = true; break; }
            }

            btnHuy.Visible = false;
            btnOk.Visible = false;
            lblNoiDungCauHoi.ReadOnly = true;
            txtA.ReadOnly = true;
            txtB.ReadOnly = true;
            txtC.ReadOnly = true;
            txtD.ReadOnly = true;
            radA.Enabled = false;
            radB.Enabled = false;
            radC.Enabled = false;
            radD.Enabled = false;
        }

        private void btnUpDB_Click(object sender, EventArgs e)
        {
            // Cập nhật những câu hỏi được chỉnh sửa
            CauHoi_DAO.Edit_CauHoi(lst_QuestionEdited);
            if (CauHoi_DAO.Update_DB_CauHoi())
            {
                KryptonMessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("Cập nhật KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
