using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.CaThi;
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

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmAdd_Edit_HocPhan : MetroFramework.Forms.MetroForm
    {
        bool check_edit;
        HocPhans hp;
        CT_HocPhans ct_hp;
        public frmAdd_Edit_HocPhan(bool check_edit, HocPhans hp, CT_HocPhans ct_hp)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.hp = hp;
            this.ct_hp = ct_hp;

            ShowCboKhoa();

            if (check_edit)
            {
                // Đổi txtMaHocPhan và txtTenHocPhan thành Combobox
                // 

                // Học phần
                cboKhoa.SelectedValue = hp.MaKhoa;
                txtMHP.Text = hp.MaHocPhan;
                txtTen.Text = hp.TenHocPhan;
                txtSTC.Text = hp.SoTC + "";
                txtLT.Text = hp.SoTietLT + "";
                txtTH.Text = hp.SoTietTH + "";

                // Chi Tiết học phần
                if (ct_hp == null)
                {
                    KryptonMessageBox.Show("Hãy bổ sung thông tin học phần !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtMaLopHocPhan.Text = ct_hp.MaLopHocPhan;
                    txtTenGV.Text = ct_hp.TenGV;
                    cboThu.Text = ct_hp.Thu + "";
                    cboPhong.Text = ct_hp.Phong;
                    cboTiet.Text = ct_hp.Tiet;
                    txtNgayBD.Value = ct_hp.NgayBD;
                    txtNgayKT.Value = ct_hp.NgayKT;
                }
                

                // DS Sinh viên
                DataTable dt = CT_HocPhan_DAO.DS_SV_HocPhan(ct_hp.MaLopHocPhan);
                foreach (DataRow item in dt.Rows)
                {
                    string[] new_r = new string[]
                    {
                        item["MASV"].ToString(),
                        item["TENSV"].ToString(),
                        item["GIOITINH"].ToString(),
                        item["NGAYSINH"].ToString(),
                        item["EMAIL"].ToString(),
                        item["SDT"].ToString(),
                        item["DIACHI"].ToString(),
                        item["QUEQUAN"].ToString(),
                        item["HOCPHI"].ToString(),
                        item["MALOP"].ToString()
                    };
                    gridDSSV.Rows.Add(new_r);
                }
            }
            else
            {
                txtMHP.Visible = false;
            }
        }

        public void ShowCboKhoa()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Cập nhật = true
            if (check_edit)
            {
                // Học phần
                HocPhans hocPhan = new HocPhans();
                hocPhan.MaHocPhan = hp.MaHocPhan;
                hocPhan.TenHocPhan = txtTen.Text;
                hocPhan.SoTC = int.Parse(txtSTC.Text.Trim());
                hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
                hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());

                // CT_HocPhan
                List<CT_HocPhans> lstCT_HocPhan = new List<CT_HocPhans>();
                foreach (DataGridViewRow item in gridDSSV.Rows)
                {
                    CT_HocPhans ct_hp = new CT_HocPhans();
                    ct_hp.MaLopHocPhan = txtMaLopHocPhan.Text.Trim();
                    ct_hp.MaSV = item.Cells[0].Value.ToString().Trim();
                    ct_hp.MaHocPhan = txtMHP.Text.Trim();
                    ct_hp.MaGV = this.ct_hp.MaGV.Trim();
                    ct_hp.Thu = int.Parse(cboThu.Text.Trim());
                    ct_hp.Tiet = cboTiet.Text.Trim();
                    ct_hp.Phong = cboPhong.Text.Trim();
                    ct_hp.NgayBD = txtNgayBD.Value;
                    ct_hp.NgayKT = txtNgayKT.Value;

                    lstCT_HocPhan.Add(ct_hp);
                }
                
                if (HocPhan_DAO.UpdateHP(hocPhan) && CT_HocPhan_DAO.Update_DB_CT_HocPhan(txtMaLopHocPhan.Text.Trim(), lstCT_HocPhan))
                {
                    KryptonMessageBox.Show("Cập nhật HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Cập nhật HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            // Tạo mới
            else
            {
                HocPhans hocPhan = new HocPhans();
                hocPhan.TenHocPhan = txtTen.Text;
                hocPhan.SoTC = int.Parse(txtTH.Text.Trim());
                hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
                hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());
                hocPhan.MaKhoa = cboKhoa.SelectedValue.ToString();

                if (HocPhan_DAO.InsertHP(hocPhan))
                {
                    KryptonMessageBox.Show("Tạo HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Tạo HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSV addSv = new frmThemSV(true, cboKhoa.SelectedValue.ToString(), txtMaLopHocPhan.Text.Trim(), txtTen.Text.Trim());
            addSv.ShowDialog();
            List<SinhViens> svs = addSv.svs;
            foreach (var item in svs)
            {
                string[] new_r = new string[]
                {
                    item.MaSV, item.TenSV, item.GioiTinh, item.NgaySinh + "", item.Email, item.Sdt, item.DiaChi, item.QueQuan, item.HocPhi, item.MaLop
                };
                gridDSSV.Rows.Add(new_r);
            }
        }
    }
}
