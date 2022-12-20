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

namespace App_QL_ThiTracNghiem.GUI.BaiThi
{
    public partial class frmBaiThi : Form
    {
        int MABAITHI = 0;
        public frmBaiThi(int MABAITHI)
        {
            InitializeComponent();
            this.MABAITHI = MABAITHI;

            ShowDSCauHoi();
        }

        public void ShowDSCauHoi()
        {
            DataTable dt = BaiThi_DAO.GetDSCauHoiBaiThi(MABAITHI);
            // Kiểm tra sinh viên đã nộp bài rồi mới GetCT Bài thi
            if (dt != null)
            {
                double diem = 10 / (dt.Rows.Count);
                int cauDung = 0;
                int cauSai = 0;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    CauHois ch = new CauHois();
                    ch.NoiDung = dt.Rows[i][1].ToString();
                    ch.DapAn1 = dt.Rows[i][2].ToString();
                    ch.DapAn2 = dt.Rows[i][3].ToString();
                    ch.DapAn3 = dt.Rows[i][4].ToString();
                    ch.DapAn4 = dt.Rows[i][5].ToString();
                    ch.DapAnDung = dt.Rows[i][6].ToString().Trim();

                    frmCH cauhoi = new frmCH(ch, dt.Rows[i][7].ToString().Trim(), i + 1);
                    cauhoi.Dock = DockStyle.Top;
                    krpContent.Controls.Add(cauhoi);

                    if (dt.Rows[i][6].ToString().Trim().Equals(dt.Rows[i][7].ToString().Trim()))
                    {
                        cauDung++;
                    }
                    else
                    {
                        cauSai++;
                    }
                }
                //txtCauDUng.Text = cauDung + "";
                //txtCauSai.Text = cauSai + "";
                //txtDiem.Text = cauDung * diem + "";
            }
        }
    }
}
