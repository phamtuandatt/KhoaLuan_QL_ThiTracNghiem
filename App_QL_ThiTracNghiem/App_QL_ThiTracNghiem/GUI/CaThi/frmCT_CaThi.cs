using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            txtGioThi.Text = this.CaThis.GioLamBai.ToString().Trim();
            txtNgayThi.Value = this.CaThis.NgayThi;
            cboPhong.Text = this.CaThis.Phong.ToString().Trim();


            // Tạo mới
            if (this.check_edit)
            {

            }
            // Cập nhật
            else
            {
                txtMonHoc.Text = this.TENHOCPHAN;
                txtMaDe.Enabled = false;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
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
                caThis.Phong = cboPhong.Text.Trim();

                // Kiểm tra Học phần đó, ngày đó, tiết đó, phòng đó - đã có hay chưa   
                //                 HP1 - 1 - 1 - A1
                //                 HP1 - 1 - 1 - A1 -> K ĐƯỢC
                //                 HP1 - 1 - 1 - A2 -> ĐƯỢC
                //                 HP2 - 1 - 1 - A1 -> K ĐƯỢC
                //                 HP2 - 1 - 1 - A3 -> ĐƯỢC
                // NGÀY ĐÓ - PHÒNG ĐÓ - TIẾT ĐÓ -> CHỈ ĐƯỢC THUỘC VỀ 1 HỌC PHẦN
                if (CaThi_DAO.CaThiIsExisted(caThis.NgayThi.ToString(), caThis.GioLamBai, caThis.Phong))
                {
                    KryptonMessageBox.Show("Phòng thi đã được sử dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra sinh viên có tồn tại trong ca thi hay không
                // Nếu tôn tại trong ca thi đó
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
                            this.Close();
                        }
                    }
                }
            }
            // Cập nhật
            else
            {
                CaThis caThi = new CaThis();
                caThi.MaCaThi = CaThis.MaCaThi;
                caThi.MaHocPhan = MAHOCPHAN;
                caThi.MaDeThi = txtMaDe.Text.Trim();
                caThi.NgayThi = txtNgayThi.Value;
                caThi.GioLamBai = txtGioThi.Text.Trim();
                caThi.TinhTrang = 0;
                caThi.Phong = cboPhong.Text.Trim();

                // Kiểm tra thông tin ca thi có bị trùng với thông tin cũ hãy không
                var cathi = CaThi_DAO.GetCaThi(caThi.MaCaThi);
                if (caThi.NgayThi == cathi.NgayThi &&
                    caThi.Phong == cathi.Phong &&
                    caThi.GioLamBai == cathi.GioLamBai)
                {
                    KryptonMessageBox.Show("Cập nhật thông tin ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }    
                else
                {
                    // NGÀY ĐÓ - PHÒNG ĐÓ - TIẾT ĐÓ -> CHỈ ĐƯỢC THUỘC VỀ 1 HỌC PHẦN
                    if (CaThi_DAO.CaThiIsExisted(caThi.NgayThi.ToString(), caThi.GioLamBai, caThi.Phong))
                    {
                        KryptonMessageBox.Show("Phòng thi đã được sử dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (CaThi_DAO.UpdateCaThi(caThi))
                {
                    if (CT_CaThi_DAO.DeleteCT_CaThi(caThi.MaCaThi))
                    {
                        if (CT_CaThi_DAO.Insert_CT_CaThi(lst_SV, caThi.MaCaThi))
                        {
                            if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                            {
                                KryptonMessageBox.Show("Cập nhật thông tin ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
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
