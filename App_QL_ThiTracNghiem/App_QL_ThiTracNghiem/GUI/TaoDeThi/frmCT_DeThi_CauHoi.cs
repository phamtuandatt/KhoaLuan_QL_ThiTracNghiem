using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
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
        int MACAUHOI;
        public frmCT_DeThi_CauHoi(int MACAUHOI)
        {
            InitializeComponent();
            this.MACAUHOI = MACAUHOI;
            Show_CT_CauHoi();
        }

        public void Show_CT_CauHoi()
        {
            CauHois hois = CauHoi_DAO.GetCauHoi(MACAUHOI);
            lblNoiDungCauHoi.Text = hois.NoiDung;
            txtA.Text = hois.DapAn1;
            txtB.Text = hois.DapAn2;
            txtC.Text = hois.DapAn3;
            txtD.Text = hois.DapAn4;

            string correct_an = hois.DapAnDung.Trim();
            switch (correct_an)
            {
                case "A": { radA.Checked = true; break; }
                case "B": { radB.Checked = true; break; }
                case "C": { radC.Checked = true; break; }
                case "D": { radD.Checked = true; break; }
            }
        }
    }
}
