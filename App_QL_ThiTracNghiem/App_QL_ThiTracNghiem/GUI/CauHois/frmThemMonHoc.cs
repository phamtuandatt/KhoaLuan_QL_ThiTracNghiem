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

namespace App_QL_ThiTracNghiem.GUI.CauHoi
{
    public partial class frmThemMonHoc : MetroFramework.Forms.MetroForm
    {
        int MANGANHANG;
        string MAGV;
        public frmThemMonHoc()
        {
            InitializeComponent();
        }

        public frmThemMonHoc(int MANGANHANG, string MAGV) 
        {
            InitializeComponent();
            // Lấy mã ngân hàng & Mã giảng viên sau khi đã đăng nhập
            this.MANGANHANG = MANGANHANG;
            this.MAGV = MAGV;

            Show_DS_MonHoc_NganHang();
        }

        private void Show_DS_MonHoc_NganHang()
        {
            // Lấy danh sách nhưng môn học mà giảng viên phụ trách -> Chưa tạo câu hỏi trong kho
            cboDSMonHoc.DataSource = HocPhan_DAO.GetHocPhan_NganHang(MANGANHANG, MAGV);
            cboDSMonHoc.DisplayMember = "TENHOCPHAN";
            cboDSMonHoc.ValueMember = "MAHOCPHAN";

        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            // Sau khi tạo học phần mới -> Insert vào CT_NganHangCauHoi
            CT_NganHangCauHois ct = new CT_NganHangCauHois();
            ct.MaNganHang = MANGANHANG;
            ct.MaGV = MAGV;
            ct.MaHocPhan = cboDSMonHoc.SelectedValue.ToString();
            if (CT_NganHangCauHoi_DAO.Insert(ct) > 0)
            {
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Thêm học phần KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
