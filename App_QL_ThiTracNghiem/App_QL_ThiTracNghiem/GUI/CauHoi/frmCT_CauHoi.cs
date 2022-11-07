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
        public frmCT_CauHoi()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = true;
            btnOk.Visible = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = false;
            btnOk.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = false;
            btnOk.Visible = false;
        }
    }
}
