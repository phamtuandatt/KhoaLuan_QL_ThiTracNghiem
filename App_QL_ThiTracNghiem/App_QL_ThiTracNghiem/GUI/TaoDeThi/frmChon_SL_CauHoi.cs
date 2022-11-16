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
    public partial class frmChon_SL_CauHoi : Form
    {
        public int SoLuongCauHoi { get; set; }
        public frmChon_SL_CauHoi()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuongCauHoi = int.Parse(txtSL.Text.Trim());
            this.Close();
        }
    }
}
