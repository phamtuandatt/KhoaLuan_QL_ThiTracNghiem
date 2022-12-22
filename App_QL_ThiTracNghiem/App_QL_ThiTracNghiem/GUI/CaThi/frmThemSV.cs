using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
using App_QL_ThiTracNghiem.GUI.TaoDeThi;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    public partial class frmThemSV : MetroFramework.Forms.MetroForm
    { 
        int MACATHI;
        bool add_sv_hocphan = false;
        string MAKHOA, MALOPHOCPHAN, MAHOCPHAN, TENHOCPHAN;
        List<string> lst_SinhVien;
        int SLSVThem = 0;
        bool ClickOne = false;
        public bool check { get; set; }

        public List<SinhViens> svs { get; set; }

        public frmThemSV(int THU, string TIET, string TENHOCPHAN, bool themHocPhan, string MAKHOA, bool add_sv_hocphan)
        {
            InitializeComponent();
            this.add_sv_hocphan = add_sv_hocphan;

            txtMonHoc.Text = TENHOCPHAN;
            cboDKLocSinhVien.SelectedIndex = 0;

            // Hiển thị danh sách sinh viên của khoa, nhưng chưa tham gia lớp học phần
            // Kiểm tra sinh viên vào THƯ đó - TIẾT đó đã có lịch hay chưa
            // Có rồi thì k hiển thị
            gridDSSinhVien.DataSource = SinhVien_DAO.GetDSKhoaLopHP(MAKHOA, THU, TIET);

            lst_SinhVien = new List<string>();
            svs = new List<SinhViens>();
        }

        public frmThemSV(bool add_sv_hocphan, string MAKHOA, string MALOPHOCPHAN, string TENHOCPHAN)
        {
            // true
            InitializeComponent();
            this.MAKHOA = MAKHOA;
            this.MALOPHOCPHAN = MALOPHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            this.add_sv_hocphan = add_sv_hocphan;

            txtMonHoc.Text = TENHOCPHAN;
            cboDKLocSinhVien.SelectedIndex = 0;
            btnOK.Text = "THÊM";

            svs = new List<SinhViens>();
            gridDSSinhVien.DataSource = SinhVien_DAO.GetDSSV_Chua_ThamGia_HocPhan_Khoa(MAKHOA, MALOPHOCPHAN);
        }

        public frmThemSV(int MACATHI, string MAHOCPHAN, string TENHOCPHAN)
        {
            InitializeComponent();
            this.MACATHI = MACATHI;
            this.MAHOCPHAN = MAHOCPHAN;
            this.TENHOCPHAN = TENHOCPHAN;
            
            txtMonHoc.Text = TENHOCPHAN;
            cboDKLocSinhVien.SelectedIndex = 0;

            gridDSSinhVien.DataSource = CT_CaThi_DAO.GetDSSV_ChuaThi(this.MAHOCPHAN);

            lst_SinhVien = new List<string>();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (add_sv_hocphan == false)
            {
                if (SLSVThem > 0)
                {
                    if (CT_CaThi_DAO.Insert_CT_CaThi(lst_SinhVien, MACATHI))
                    {
                        if (CT_CaThi_DAO.Up_DB_CT_CaThi())
                        {
                            KryptonMessageBox.Show("Cập nhật danh sách sinh viên tham gia ca thi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            KryptonMessageBox.Show("Cập nhật danh sách sinh viên tham gia ca thi KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                // Thêm danh sách sinh viên tham gia học phần
                check = true;
                this.Close();
            }

        }

        private void gridDSSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (add_sv_hocphan == false)
            {
                int rsl = gridDSSinhVien.CurrentRow.Index;
                string MASV = gridDSSinhVien.Rows[rsl].Cells[1].Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    if (lst_SinhVien.Count == 0)
                    {
                        lst_SinhVien.Add(MASV);
                        gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                        SLSVThem++;
                    }
                    else
                    {
                        bool status = false;
                        // Kiểm tra trong lst_SinhVien có tồn tại hay sinh vien hay chưa
                        // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                        for (int i = 0; i < lst_SinhVien.Count; i++)
                        {
                            if (lst_SinhVien[i].Equals(MASV))
                            {
                                lst_SinhVien.RemoveAt(i);
                                status = true;
                                gridDSSinhVien.Rows[rsl].Cells[0].Value = false;
                                SLSVThem--;
                                return;
                            }
                        }
                        if (!status)
                        {
                            lst_SinhVien.Add(MASV);
                            gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                            SLSVThem++;
                        }
                    }
                }
            }
            else
            {
                int rsl = gridDSSinhVien.CurrentRow.Index;
                SinhViens sv = new SinhViens();
                sv.MaSV = gridDSSinhVien.Rows[rsl].Cells[1].Value.ToString();
                sv.TenSV = gridDSSinhVien.Rows[rsl].Cells[2].Value.ToString();
                sv.GioiTinh = gridDSSinhVien.Rows[rsl].Cells[3].Value.ToString();
                sv.NgaySinh = DateTime.Parse(gridDSSinhVien.Rows[rsl].Cells[4].Value.ToString());
                sv.Email = gridDSSinhVien.Rows[rsl].Cells[5].Value.ToString();
                sv.Sdt = gridDSSinhVien.Rows[rsl].Cells[6].Value.ToString();
                sv.DiaChi = gridDSSinhVien.Rows[rsl].Cells[7].Value.ToString();
                sv.QueQuan = gridDSSinhVien.Rows[rsl].Cells[8].Value.ToString();
                sv.MaLop = gridDSSinhVien.Rows[rsl].Cells[9].Value.ToString();
                sv.HocPhi = gridDSSinhVien.Rows[rsl].Cells[10].Value.ToString();

                string MASV = gridDSSinhVien.Rows[rsl].Cells[1].Value.ToString().Trim();
                if (e.ColumnIndex == 0)
                {
                    if (svs.Count == 0)
                    {
                        gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                        svs.Add(sv);
                        SLSVThem++;
                    }
                    else
                    {
                        bool status = false;
                        // Kiểm tra trong lst_SinhVien có tồn tại hay sinh vien hay chưa
                        // -> Nếu rồi thì xóa dòng (Do click lần 2 là bỏ check -> Nên xóa)
                        for (int i = 0; i < svs.Count; i++)
                        {
                            if (svs[i].MaSV.Equals(MASV))
                            {
                                svs.RemoveAt(i);
                                status = true;
                                gridDSSinhVien.Rows[rsl].Cells[0].Value = false;
                                SLSVThem--;
                                return;
                            }
                        }
                        if (!status)
                        {
                            gridDSSinhVien.Rows[rsl].Cells[0].Value = true;
                            svs.Add(sv);
                            SLSVThem++;
                        }
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (ClickOne == false)
            {
                frmChon_SL_CauHoi sl = new frmChon_SL_CauHoi(true, false);
                sl.ShowDialog();
                if (sl.Check == false)
                {
                    return;
                }
                int soLuong = sl.SoLuong;

                if (soLuong > gridDSSinhVien.RowCount)
                {
                    KryptonMessageBox.Show("Số lượng sinh viên muốn chọn vượt quá số lượng đang có !\nHãy chọn lại hoặc bổ sung sinh viên.", "Cảnh báo",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (add_sv_hocphan == false)
                {
                    for (int i = 0; i < soLuong; i++)
                    {
                        gridDSSinhVien.Rows[i].Cells[0].Value = true;
                        lst_SinhVien.Add(gridDSSinhVien.Rows[i].Cells[1].Value.ToString());
                    }
                    ClickOne = true;
                }
                else
                {
                    for (int i = 0; i < soLuong; i++)
                    {
                        gridDSSinhVien.Rows[i].Cells[0].Value = true;
                        SinhViens sv = new SinhViens();
                        sv.MaSV = gridDSSinhVien.Rows[i].Cells[1].Value.ToString();
                        sv.TenSV = gridDSSinhVien.Rows[i].Cells[2].Value.ToString();
                        sv.GioiTinh = gridDSSinhVien.Rows[i].Cells[3].Value.ToString();
                        sv.NgaySinh = DateTime.Parse(gridDSSinhVien.Rows[i].Cells[4].Value.ToString());
                        sv.Email = gridDSSinhVien.Rows[i].Cells[5].Value.ToString();
                        sv.Sdt = gridDSSinhVien.Rows[i].Cells[6].Value.ToString();
                        sv.DiaChi = gridDSSinhVien.Rows[i].Cells[7].Value.ToString();
                        sv.QueQuan = gridDSSinhVien.Rows[i].Cells[8].Value.ToString();
                        sv.MaLop = gridDSSinhVien.Rows[i].Cells[10].Value.ToString().Trim();
                        sv.HocPhi = gridDSSinhVien.Rows[i].Cells[9].Value.ToString();

                        svs.Add(sv);
                    }
                    ClickOne = true;
                }
            }
        }
    }
}
