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
    public partial class frmCT_DeThi_CauHoi : Form
    {
        int idCauHoi;
        public frmCT_DeThi_CauHoi(int idCauHoi)
        {
            InitializeComponent();
            this.idCauHoi = idCauHoi;

        }
    }
}
