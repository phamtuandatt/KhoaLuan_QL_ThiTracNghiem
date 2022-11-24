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
        public int SoLuong { get; set; }
        bool check = false;

        public frmChon_SL_CauHoi()
        {
            InitializeComponent();
        }

        public frmChon_SL_CauHoi(bool check)
        {
            InitializeComponent();
            this.check = check;
            if (check)
            {
                lblbTieuDe.Text = "Số lượng sinh viên:";
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuong = int.Parse(txtSL.Text.Trim());
            this.Close();
        }
    }
}
