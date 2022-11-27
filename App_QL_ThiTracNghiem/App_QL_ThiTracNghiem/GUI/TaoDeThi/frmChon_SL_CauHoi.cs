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
    public partial class frmChon_SL_CauHoi : MetroFramework.Forms.MetroForm
    {
        public int SoLuong { get; set; }
        public List<string> ds_DeThi { get; set; }

        bool check = false;
        bool check_tao_de = false;

        public frmChon_SL_CauHoi()
        {
            InitializeComponent();
        }

        public frmChon_SL_CauHoi(bool check, bool check_tao_de)
        {
            InitializeComponent();
            this.check = check;
            this.check_tao_de = check_tao_de;
            if (check)
            {
                lblbTieuDe.Text = "Số lượng sinh viên:";
            }
            if (check_tao_de)
            {
                // Tạo danh sách đề thi từ số lượng đã nhập
                ds_DeThi = new List<string>();
                lblbTieuDe.Text = "Số lượng đề muốn tạo:";
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuong = int.Parse(txtSL.Text.Trim());
            if (check_tao_de)
            {
                for (int i = 0; i < SoLuong; i++)
                {
                    ds_DeThi.Add($"0{i + 1}");
                }
            }

            this.Close();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
