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
    public partial class frmCT_CaThi : MetroFramework.Forms.MetroForm
    {
        bool check_edit = false;
        string MAHOCPHAN, TENHOCPHAN;
        List<string> lst_SV;
        CaThis CaThis;
        public frmCT_CaThi()
        {
            InitializeComponent();
        }

        public frmCT_CaThi(bool check_edit, string MAHOCPHAN, string TENHOCPHAN, List<string> lst_SV, CaThis CaThis)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            this.lst_SV = lst_SV;
            this.CaThis = CaThis;

            // Tạo mới
            if (this.check_edit)
            {

            }
            // Cập nhật
            else
            {
                txtMonHoc.Text = this.TENHOCPHAN;
                txtNgayThi.Value = DateTime.Parse(this.CaThis.NgayThi.ToString());
                txtGioThi.Text = this.CaThis.GioLamBai;
            }

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
            if (check_edit)
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
                    if (CT_CaThi_DAO.Insert_CT_CaThi(lst_SV, MACATHI))
                    {
                        if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                        {
                            KryptonMessageBox.Show("Tạo ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            KryptonMessageBox.Show("Tạo ca thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                this.Close();
            }
            // Cập nhật
            else
            {
                CaThis caThi = new CaThis();
                caThi.MaCaThi = CaThis.MaCaThi;
                caThi.MaHocPhan = MAHOCPHAN;
                caThi.MaDeThi = txtMaDe.Text.Trim();
                caThi.MaDeCon = txtMaDe.SelectedValue.ToString();
                caThi.NgayThi = txtNgayThi.Value;
                caThi.GioLamBai = txtGioThi.Text.Trim();
                caThi.TinhTrang = 0;

                if (CaThi_DAO.UpdateCaThi(caThi))
                {
                    if (CT_CaThi_DAO.DeleteCT_CaThi(caThi.MaCaThi))
                    {
                        if (CT_CaThi_DAO.Insert_CT_CaThi(lst_SV, caThi.MaCaThi))
                        {
                            if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                            {
                                KryptonMessageBox.Show("Cập nhật thông tin ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                KryptonMessageBox.Show("Cập nhật thông tin ca thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }
    }
}
