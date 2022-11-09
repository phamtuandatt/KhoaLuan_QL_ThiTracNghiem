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
            dialogChonFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
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
                richTextBox1.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);

                // Read content
                char[] content = richTextBox1.Text.ToCharArray();
                string number_question = "";
                string content_question = "";
                string a = "";
                string b = "";
                string c = "";
                string d = "";

                // Get number_question
                int i = 0;
                while (content[i] != '.')
                {
                    number_question += content[i];
                    i++;
                }

                // Skip char '.'
                i += 2;

                // Get content_question
                while (content[i] != '\n')
                {
                    content_question += content[i];
                    i++;
                }

                i++;

                // Get content A
                while (content[i] != '\n')
                {
                    if (content[i] == '*')
                    {
                        radA.Checked = true;
                    }
                    a += content[i];
                    i++;
                }
                i++;
                // Get content B
                while (content[i] != '\n')
                {
                    if (content[i] == '*')
                    {
                        radB.Checked = true;
                    }
                    b += content[i];
                    i++;
                }
                i++;
                // Get content C
                while (content[i] != '\n')
                {
                    if (content[i] == '*')
                    {
                        radC.Checked = true;
                    }
                    c += content[i];
                    i++;
                }
                i++;
                // Get content D
                while (content[i] != '\n')
                {
                    if (content[i] == '*')
                    {
                        radD.Checked = true;
                    }
                    d += content[i];
                    i++;
                }
                radA.Text = a;
                radB.Text = b;
                radC.Text = c;
                radD.Text = d;



                lblNoiDungCauHoi.Text = content_question;
            }

        }
    }
}
