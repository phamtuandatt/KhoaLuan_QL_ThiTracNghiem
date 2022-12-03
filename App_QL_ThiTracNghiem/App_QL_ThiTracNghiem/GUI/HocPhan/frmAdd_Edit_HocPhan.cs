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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmAdd_Edit_HocPhan : MetroFramework.Forms.MetroForm
    {
        bool check_edit, checkAddLopHP;
        string MAKHOA, MAHOCPHAN;
        HocPhans hp;
        CT_HocPhans ct_hp;
        HocPhans hocPhan;

        public frmAdd_Edit_HocPhan(bool check_edit, bool checkAddLopHP, string MAKHOA, string MAHOCPHAN)
        {
            InitializeComponent();
            this.checkAddLopHP = checkAddLopHP;
            this.check_edit = check_edit;
            this.MAKHOA = MAKHOA;
            this.MAHOCPHAN = MAHOCPHAN;
            hocPhan = HocPhan_DAO.GetHP(MAHOCPHAN);

            // check_edit = false là đi thêm
            // checkAddLopHP = true là thêm lớp học phần
            ShowDSGV(MAKHOA);
            txtMHP.Visible = false;
            lblMHP.Visible = false;
            txtMaLopHocPhan.Visible = false;
            lblMLHP.Visible = false;
            pageHocPhan.Visible = false;

        }

        public frmAdd_Edit_HocPhan(bool check_edit, HocPhans hp, CT_HocPhans ct_hp)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.hp = hp;
            this.ct_hp = ct_hp;

            if (check_edit)
            {
                ShowCboKhoa();
                ShowDSGV(cboKhoa.SelectedValue.ToString());
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
                    cboGiangVien.SelectedValue = ct_hp.MaGV;
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
                ShowCboKhoa();
                ShowDSGV(cboKhoa.SelectedValue.ToString());

                txtMHP.Visible = false;
                lblMHP.Visible = false;
                txtMaLopHocPhan.Visible = false;
                lblMLHP.Visible = false;
                cboKhoa.Enabled = true;
            }
        }

        public void ShowDSGV(string MAKHOA)
        {
            cboGiangVien.DataSource = GiangVien_DAO.GetDSGV(MAKHOA);
            cboGiangVien.DisplayMember = "TENGV";
            cboGiangVien.ValueMember = "MAGV";
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
                if (txtSTC.Text == "" || txtSTC.Text.Length <= 0
                    || txtLT.Text == "" || txtLT.Text.Length <= 0
                    || txtTH.Text == "" || txtTH.Text.Length <= 0
                    || txtTen.Text == "" || txtTen.Text.Length <= 0
                    || txtMHP.Text == "" || txtMHP.Text.Length <= 0
                    || txtMaLopHocPhan.Text == "" || txtMaLopHocPhan.Text.Length <= 0
                    || gridDSSV.RowCount <= 0)
                {
                    KryptonMessageBox.Show("Hãy hoàn điền đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                    ct_hp.MaGV = cboGiangVien.SelectedValue.ToString().Trim();
                    ct_hp.Thu = int.Parse(cboThu.Text.Trim());
                    ct_hp.Tiet = cboTiet.Text.Trim();
                    ct_hp.Phong = cboPhong.Text.Trim();
                    ct_hp.NgayBD = txtNgayBD.Value;
                    ct_hp.NgayKT = txtNgayKT.Value;

                    lstCT_HocPhan.Add(ct_hp);
                }
                
                if (HocPhan_DAO.UpdateHP(hocPhan) && CT_HocPhan_DAO.Update_DB_CT_HocPhan(true, txtMaLopHocPhan.Text.Trim(), lstCT_HocPhan))
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
                if (txtSTC.Text == "" || txtSTC.Text.Length <= 0
                    || txtLT.Text == "" || txtLT.Text.Length <= 0
                    || txtTH.Text == "" || txtTH.Text.Length <= 0
                    || txtTen.Text == "" || txtTen.Text.Length <= 0
                    || gridDSSV.RowCount <= 0)
                {
                    KryptonMessageBox.Show("Hãy hoàn điền đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (checkAddLopHP)
                {
                    string MHP = this.MAHOCPHAN;
                    string MLHP = CT_HocPhan_DAO.GetMaCTHP(MHP);
                    List<CT_HocPhans> lstCT_HocPhan = new List<CT_HocPhans>();
                    foreach (DataGridViewRow item in gridDSSV.Rows)
                    {
                        CT_HocPhans ct_hp = new CT_HocPhans();
                        ct_hp.MaLopHocPhan = MLHP;
                        ct_hp.MaSV = item.Cells[0].Value.ToString().Trim();
                        ct_hp.MaHocPhan = MHP;
                        ct_hp.MaGV = cboGiangVien.SelectedValue.ToString().Trim();
                        ct_hp.Thu = int.Parse(cboThu.Text.Trim());
                        ct_hp.Tiet = cboTiet.Text.Trim();
                        ct_hp.Phong = cboPhong.Text.Trim();
                        ct_hp.NgayBD = txtNgayBD.Value;
                        ct_hp.NgayKT = txtNgayKT.Value;

                        lstCT_HocPhan.Add(ct_hp);
                    }
                    if (CT_HocPhan_DAO.Update_DB_CT_HocPhan(false, null, lstCT_HocPhan))
                    {
                        // THÊM VÀO CT_GIANGDAY -> KHI THÊM KIỂM TRA GIẢNG VIÊN ĐÃ PHỤ TRÁCH HỌC PHẦN ĐÓ CHƯA
                        // CHƯA THÌ THÊM 'MAHOCPHAN' - 'MAGV' VÀO CT_GIANGDAY
                        CT_GiangDays ct = new CT_GiangDays();
                        ct.MaHocPhan = MHP;
                        ct.MaGV = cboGiangVien.SelectedValue.ToString().Trim();
                        if (CT_GiangDay_DAO.GVIsExisted(ct))
                        {
                            KryptonMessageBox.Show("Tạo HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            if (CT_GiangDay_DAO.InsertCT_GiangDay(ct))
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
                }
                HocPhans hocPhan = new HocPhans();
                hocPhan.TenHocPhan = txtTen.Text;
                hocPhan.SoTC = int.Parse(txtTH.Text.Trim());
                hocPhan.SoTietLT = int.Parse(txtLT.Text.Trim());
                hocPhan.SoTietTH = int.Parse(txtTH.Text.Trim());
                hocPhan.MaKhoa = cboKhoa.SelectedValue.ToString();

                if (HocPhan_DAO.InsertHP(hocPhan))
                {
                    string MHP = HocPhan_DAO.GetMHPMax();
                    string MLHP = CT_HocPhan_DAO.GetMaCTHP(MHP);
                    List<CT_HocPhans> lstCT_HocPhan = new List<CT_HocPhans>();
                    foreach (DataGridViewRow item in gridDSSV.Rows)
                    {
                        CT_HocPhans ct_hp = new CT_HocPhans();
                        ct_hp.MaLopHocPhan = MLHP;
                        ct_hp.MaSV = item.Cells[0].Value.ToString().Trim();
                        ct_hp.MaHocPhan = MHP;
                        ct_hp.MaGV = cboGiangVien.SelectedValue.ToString().Trim();
                        ct_hp.Thu = int.Parse(cboThu.Text.Trim());
                        ct_hp.Tiet = cboTiet.Text.Trim();
                        ct_hp.Phong = cboPhong.Text.Trim();
                        ct_hp.NgayBD = txtNgayBD.Value;
                        ct_hp.NgayKT = txtNgayKT.Value;

                        lstCT_HocPhan.Add(ct_hp);
                    }
                    if (CT_HocPhan_DAO.Update_DB_CT_HocPhan(false, null, lstCT_HocPhan))
                    {
                        // THÊM VÀO CT_GIANGDAY -> KHI THÊM KIỂM TRA GIẢNG VIÊN ĐÃ PHỤ TRÁCH HỌC PHẦN ĐÓ CHƯA
                        // CHƯA THÌ THÊM 'MAHOCPHAN' - 'MAGV' VÀO CT_GIANGDAY
                        CT_GiangDays ct = new CT_GiangDays();
                        ct.MaHocPhan = MHP;
                        ct.MaGV = cboGiangVien.SelectedValue.ToString().Trim();
                        if (CT_GiangDay_DAO.GVIsExisted(ct))
                        {
                            KryptonMessageBox.Show("Tạo HỌC PHẦN thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            if (CT_GiangDay_DAO.InsertCT_GiangDay(ct))
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
                    else
                    {
                        KryptonMessageBox.Show("Tạo HỌC PHẦN KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            if (checkAddLopHP)
            {
                frmThemSV addSvLopHP = new frmThemSV(int.Parse(cboThu.Text.Trim()),
                                                        cboTiet.Text.Trim(), 
                                                        this.hocPhan.TenHocPhan.Trim(), true, this.MAKHOA, true);
                addSvLopHP.ShowDialog();
                if (addSvLopHP.check == false)
                {
                    return;
                }
                List<SinhViens> svs = addSvLopHP.svs;
                foreach (var item in svs)
                {
                    string[] new_r = new string[]
                    {
                    item.MaSV, item.TenSV, item.GioiTinh, item.NgaySinh + "", item.Email, item.Sdt, item.DiaChi, item.QueQuan, item.HocPhi, item.MaLop
                    };
                    gridDSSV.Rows.Add(new_r);
                }

            }
            else
            {
                frmThemSV addSv = new frmThemSV(true, cboKhoa.SelectedValue.ToString(), txtMaLopHocPhan.Text.Trim(), txtTen.Text.Trim());
                addSv.ShowDialog();
                List<SinhViens> svs = addSv.svs;
                if (addSv.check == false)
                {
                    return;
                }
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

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDSGV(cboKhoa.SelectedValue.ToString());
        }
    }
}
