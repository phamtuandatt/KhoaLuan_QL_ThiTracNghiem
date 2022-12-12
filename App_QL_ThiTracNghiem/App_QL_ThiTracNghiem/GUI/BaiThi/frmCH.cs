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

namespace App_QL_ThiTracNghiem.GUI.BaiThi
{
    public partial class frmCH : UserControl
    {
        public frmCH(CauHois ch, string DAPANCHON, int numberQuestion)
        {
            InitializeComponent();
            groupCH.Values.Heading = $"CÂU {numberQuestion}";
            txtNoiDung.Text = ch.NoiDung;
            txtA.Text = ch.DapAn1;
            txtB.Text = ch.DapAn2;
            txtC.Text = ch.DapAn3;
            txtD.Text = ch.DapAn4;
            string dad = ch.DapAnDung;
            string dapAnChon = DAPANCHON;
            if (dad == dapAnChon)
            {
                switch (dad)
                {
                    case "A": { radA.Checked = true; txtA.ForeColor = Color.DarkGreen; break; }
                    case "B": { radB.Checked = true; txtB.ForeColor = Color.DarkGreen; break; }
                    case "C": { radC.Checked = true; txtC.ForeColor = Color.DarkGreen; break; }
                    case "D": { radD.Checked = true; txtD.ForeColor = Color.DarkGreen; break; }
                }
            }
            else
            {
                switch (dad)
                {
                    case "A": { txtA.ForeColor = Color.DarkGreen; break; }
                    case "B": { txtB.ForeColor = Color.DarkGreen; break; }
                    case "C": { txtC.ForeColor = Color.DarkGreen; break; }
                    case "D": { txtD.ForeColor = Color.DarkGreen; break; }
                }
                // Đáp án chọn màu đỏ
                switch (dapAnChon)
                {
                    case "A": { radA.Checked = true; txtA.ForeColor = Color.Red; break; }
                    case "B": { radB.Checked = true; txtB.ForeColor = Color.Red; break; }
                    case "C": { radC.Checked = true; txtC.ForeColor = Color.Red; break; }
                    case "D": { radD.Checked = true; txtD.ForeColor = Color.Red; break; }
                }
            }
        }
    }
}
