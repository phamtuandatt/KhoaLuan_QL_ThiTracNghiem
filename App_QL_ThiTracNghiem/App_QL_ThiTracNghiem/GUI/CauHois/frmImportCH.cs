using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32.SafeHandles;
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
    public partial class frmImportCH : Form
    {
        int MANGANHANG;
        string MAGV;
       
        public frmImportCH()
        {
            InitializeComponent();
            Show_Cbo_HoaPhan();
            NganHangCauHois a = new NganHangCauHois();
           
        }

        public frmImportCH(int MANGANHANG, string MAGV)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAGV = MAGV;

            Show_Cbo_HoaPhan();

            lblNoiDungCauHoi.ReadOnly = true;
            txtA.ReadOnly = true;
            txtB.ReadOnly = true;
            txtC.ReadOnly = true;
            txtD.ReadOnly = true;
            btnHuy.Visible = false;
            btnCapNhat.Visible = false;
            radA.Enabled = false;
            radB.Enabled = false;
            radC.Enabled = false;
            radD.Enabled = false;


        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            dialogChonFile.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
            dialogChonFile.FilterIndex = 1;
            dialogChonFile.RestoreDirectory = true;
            if (dialogChonFile.ShowDialog() == DialogResult.OK)
            {
                object readOnly = false;
                object visible = true;
                object save = false;
                object fileNam = dialogChonFile.FileName;
                object newTemplate = false;
                object docType = 0;
                object missing = Type.Missing;
                Microsoft.Office.Interop.Word._Document document;
                Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                document = application.Documents.Open(ref fileNam, ref missing, ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref visible, ref missing, ref missing, ref missing, ref missing);
                document.ActiveWindow.Selection.WholeStory();
                document.ActiveWindow.Selection.Copy();
                IDataObject dataObject = Clipboard.GetDataObject();
                rickContentFile.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);
                
                // Load file into RickTextBox
                char[] content = rickContentFile.Text.ToCharArray();
                
                // Get Content and Add row into Grid
                Read_Muliple_Question(content);

                // Sum row
                txtTongSoCauHoi.Text = gridDS_CauHoi.RowCount.ToString();

                lblNoiDungCauHoi.ReadOnly = false;
                txtA.ReadOnly = false;
                txtB.ReadOnly = false;
                txtC.ReadOnly = false;
                txtD.ReadOnly = false;
                btnHuy.Visible = true;
                btnCapNhat.Visible = true;
                radA.Enabled = true;
                radB.Enabled = true;
                radC.Enabled = true;
                radD.Enabled = true;
            }
        }

        public char[] Convert_string_to_charArray(string s)
        {
            char[] charArray = null;
            charArray = s.ToCharArray();
            return charArray;
        }

        // Get single question
        public void Read_Muliple_Question(char[] content)
        {
            string content_question = "";
            int entered = 0;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == '\n')
                {
                    entered++;
                }
                if (entered == 5)
                {
                    Read_single_question(Convert_string_to_charArray(content_question + '\n'));
                    entered = 0;
                    content_question = "";
                }
                content_question += content[i];
            }
        }

        // Read content single question
        public void Read_single_question(char[] single_question)
        {            
            // Read content
            string number_question = "";
            string content_question = "";
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string correct_answer = "";

            // Get number_question
            int i = 0;
            while (single_question[i] != '.')
            {
                number_question += single_question[i];
                i++;
            }

            // Skip char '.'
            i += 2;

            // Get content_question
            while (single_question[i] != '\n')
            {
                content_question += single_question[i];
                i++;
            }

            i++;

            // Get content A
            while (single_question[i] != '\n')
            {
                if (single_question[i] == '*')
                {
                    correct_answer = "A";
                }
                a += single_question[i];
                i++;
            }
            a = a.Remove(0, 3);
            i++;

            // Get content B
            while (single_question[i] != '\n')
            {
                if (single_question[i] == '*')
                {
                    correct_answer = "B";
                }
                b += single_question[i];
                i++;
            }
            b = b.Remove(0, 3);
            i++;

            // Get content C
            while (single_question[i] != '\n')
            {
                if (single_question[i] == '*')
                {
                    correct_answer = "C";
                }
                c += single_question[i];
                i++;
            }
            c = c.Remove(0, 3);
            i++;

            // Get content D
            while (single_question[i] != '\n')
            {
                if (single_question[i] == '*')
                {
                    correct_answer = "D";
                }
                d += single_question[i];
                i++;
            }
            d = d.Remove(0, 3);

            // Create row datagridView
            string[] r = new string[] { content_question.Trim(), a.Trim(), b.Trim(), c.Trim(), d.Trim(), correct_answer.Trim() };
            gridDS_CauHoi.Rows.Add(r);
        }

        private void gridDS_CauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDS_CauHoi.RowCount <= 0)
            {
                return;
            }
            int id_row = gridDS_CauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDS_CauHoi.Rows[id_row].Cells[0].Value.ToString();
            txtA.Text = gridDS_CauHoi.Rows[id_row].Cells[1].Value.ToString();
            txtB.Text = gridDS_CauHoi.Rows[id_row].Cells[2].Value.ToString();
            txtC.Text = gridDS_CauHoi.Rows[id_row].Cells[3].Value.ToString();
            txtD.Text = gridDS_CauHoi.Rows[id_row].Cells[4].Value.ToString();
            string correct_answer = gridDS_CauHoi.Rows[id_row].Cells[5].Value.ToString();
            switch (correct_answer)
            {
                case "A": { radA.Checked = true; radB.Checked = false; radC.Checked = false; radD.Checked = false; break; }
                case "B": { radA.Checked = false; radB.Checked = true; radC.Checked = false; radD.Checked = false; break; }
                case "C": { radA.Checked = false; radB.Checked = false; radC.Checked = true; radD.Checked = false; break; }
                case "D": { radA.Checked = false; radB.Checked = false; radC.Checked = false; radD.Checked = true; break; }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gridDS_CauHoi.RowCount == 0)
            {
                KryptonMessageBox.Show("Chưa có câu hỏi nào được thêm !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Create List<CauHoi>
            List<CauHois> lst_Question = new List<CauHois>();
            for (int i = 0; i < gridDS_CauHoi.RowCount - 1; i++)
            {
                CauHois question = new CauHois();
                question.NoiDung = gridDS_CauHoi.Rows[i].Cells[0].Value.ToString();
                question.DapAn1  = gridDS_CauHoi.Rows[i].Cells[1].Value.ToString();
                question.DapAn2 = gridDS_CauHoi.Rows[i].Cells[2].Value.ToString();
                question.DapAn3 = gridDS_CauHoi.Rows[i].Cells[3].Value.ToString();
                question.DapAn4 = gridDS_CauHoi.Rows[i].Cells[4].Value.ToString();
                question.DapAnDung = gridDS_CauHoi.Rows[i].Cells[5].Value.ToString();
                lst_Question.Add(question);
            }

            if (CauHoi_DAO.Insert_Questions(lst_Question, MANGANHANG, cboMonHoc.SelectedValue.ToString()))
            {
                // Kiểm tra môn học đã được tạo trong Ngân hàng hay chưa
                // Chưa thì insert vào CT_NganHangCauHoi
                if (!CT_NganHangCauHoi_DAO.Check_MahocPhan_Exists(cboMonHoc.SelectedValue.ToString()))
                {
                    CT_NganHangCauHois ct = new CT_NganHangCauHois();
                    ct.MaNganHang = MANGANHANG;
                    ct.MaGV = MAGV;
                    ct.MaHocPhan = cboMonHoc.SelectedValue.ToString();
                    if (CT_NganHangCauHoi_DAO.Insert(ct) > 0)
                    {
                        KryptonMessageBox.Show("Thêm danh sách câu hỏi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Thêm danh sách câu hỏi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                KryptonMessageBox.Show("Thêm danh sách câu hỏi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int id_row = gridDS_CauHoi.CurrentRow.Index;
            gridDS_CauHoi.Rows[id_row].Cells[0].Value = lblNoiDungCauHoi.Text;
            gridDS_CauHoi.Rows[id_row].Cells[1].Value = txtA.Text;
            gridDS_CauHoi.Rows[id_row].Cells[2].Value = txtB.Text;
            gridDS_CauHoi.Rows[id_row].Cells[3].Value = txtC.Text;
            gridDS_CauHoi.Rows[id_row].Cells[4].Value = txtD.Text;

            if (radA.Checked) gridDS_CauHoi.Rows[id_row].Cells[5].Value = "A";
            if (radB.Checked) gridDS_CauHoi.Rows[id_row].Cells[5].Value = "B";
            if (radC.Checked) gridDS_CauHoi.Rows[id_row].Cells[5].Value = "C";
            if (radD.Checked) gridDS_CauHoi.Rows[id_row].Cells[5].Value = "D";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if (KryptonMessageBox.Show("Bạn có muốn đóng cửa sổ không ?", "Thông báo",
            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    return;
            //this.Close();
            int id_row = gridDS_CauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDS_CauHoi.Rows[id_row].Cells[0].Value.ToString();
            txtA.Text = gridDS_CauHoi.Rows[id_row].Cells[1].Value.ToString();
            txtB.Text = gridDS_CauHoi.Rows[id_row].Cells[2].Value.ToString();
            txtC.Text = gridDS_CauHoi.Rows[id_row].Cells[3].Value.ToString();
            txtD.Text = gridDS_CauHoi.Rows[id_row].Cells[4].Value.ToString();
            string correct_answer = gridDS_CauHoi.Rows[id_row].Cells[5].Value.ToString();
            switch (correct_answer)
            {
                case "A": { radA.Checked = true; radB.Checked = false; radC.Checked = false; radD.Checked = false; break; }
                case "B": { radA.Checked = false; radB.Checked = true; radC.Checked = false; radD.Checked = false; break; }
                case "C": { radA.Checked = false; radB.Checked = false; radC.Checked = true; radD.Checked = false; break; }
                case "D": { radA.Checked = false; radB.Checked = false; radC.Checked = false; radD.Checked = true; break; }
            }
        }

        private void Show_Cbo_HoaPhan()
        {
            // Lấy danh sách các học phần mà giảng viên phụ trách
            cboMonHoc.DataSource = HocPhan_DAO.GetHocPhans(MAGV);
            cboMonHoc.DisplayMember = "TENHOCPHAN";
            cboMonHoc.ValueMember = "MAHOCPHAN";
        }
    }
}
