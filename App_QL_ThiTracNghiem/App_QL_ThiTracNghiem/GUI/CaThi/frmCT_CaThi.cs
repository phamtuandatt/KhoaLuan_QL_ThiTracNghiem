using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmCT_CaThi : Form
    {
        string MAHOCPHAN, TENHOCPHAN;
        List<string> lst_SV;
        public frmCT_CaThi()
        {
            InitializeComponent();
        }

        public frmCT_CaThi(string MAHOCPHAN, string TENHOCPHAN, List<string> lst_SV)
        {
            InitializeComponent();
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            this.lst_SV = lst_SV;

            txtMonHoc.Text = this.TENHOCPHAN;
            Load_CboDeThi();
        }

        public void Load_CboDeThi()
        {
            List<string> lst = DeThi_DAO.Get_DS_DeThi_For_CaThi(MAHOCPHAN);
            foreach (var item in lst)
            {
                txtMaDe.Items.Add(item);
            }
            txtMaDe.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CaThis caThis = new CaThis();
            caThis.MaHocPhan = MAHOCPHAN;
            caThis.MaDeThi = txtMaDe.Text.Trim();
            caThis.NgayThi = txtNgayThi.Value;
            caThis.GioLamBai = txtGioThi.Text.Trim();
            caThis.TinhTrang = 0;

            if (CaThi_DAO.Insert_CaThi(caThis))
            {
                int MACATHI = CT_CaThi_DAO.Get_MaCaThi();
                if(CT_CaThi_DAO.Insert_CT_CaThi(lst_SV, MACATHI))
                {
                    if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                    {
                        KryptonMessageBox.Show("Tạo ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        KryptonMessageBox.Show("Tạo ca thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            this.Close();
        }
    }
}
