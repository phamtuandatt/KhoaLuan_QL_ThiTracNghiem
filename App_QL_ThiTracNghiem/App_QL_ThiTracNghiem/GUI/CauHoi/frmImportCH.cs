using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            
            }
        }
    }
}
