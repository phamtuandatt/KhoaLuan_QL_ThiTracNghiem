using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    public partial class frmThemSV : Form
    {
        int maMh;
        public frmThemSV()
        {
            InitializeComponent();
        }

        public frmThemSV(int maMh)
        {
            InitializeComponent();
            this.maMh = maMh;
            txtMonHoc.Text = "" + maMh;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

        }
    }
}
