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
        public frmImportCH()
        {
            InitializeComponent();
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
            int id_row = gridDS_CauHoi.CurrentRow.Index;
            lblNoiDungCauHoi.Text = gridDS_CauHoi.Rows[id_row].Cells[0].Value.ToString();
            radA.Text = gridDS_CauHoi.Rows[id_row].Cells[1].Value.ToString();
            radB.Text = gridDS_CauHoi.Rows[id_row].Cells[2].Value.ToString();
            radC.Text = gridDS_CauHoi.Rows[id_row].Cells[3].Value.ToString();
            radD.Text = gridDS_CauHoi.Rows[id_row].Cells[4].Value.ToString();
            string correct_answer = gridDS_CauHoi.Rows[id_row].Cells[5].Value.ToString();
            switch (correct_answer)
            {
                case "A": radA.Checked = true; break;
                case "B": radB.Checked = true; break;
                case "C": radC.Checked = true; break;
                case "D": radD.Checked = true; break;
            }
        }
    }
}
