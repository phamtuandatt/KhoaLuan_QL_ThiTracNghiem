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
    public partial class frmTaoCauHoi : MetroFramework.Forms.MetroForm
    {
        int MANGANHANG;
        string MAGV;
        public frmTaoCauHoi(int MANGANHANG, string MAGV)
        {
            InitializeComponent();
            this.MANGANHANG = MANGANHANG;
            this.MAGV = MAGV;

            // Lấy danh sách tất cả học phần của Giảng viên phụ trách
            Show_DS_HocPhan();

            // Khi thực hiện thêm câu hỏi thì kiểm tra 
            // Học phần đó đã có trong kho chưa
            //  -> Có rồi thì insert câu hỏi
            //  -> Chưa có thì insert học phần vào CT_NganHangCauHoi -> insert câu hỏi
        }

        private void Show_DS_HocPhan()
        {
            cboMonHoc.DataSource = HocPhan_DAO.GetHocPhans(MAGV);
            cboMonHoc.DisplayMember = "TENHOCPHAN";
            cboMonHoc.ValueMember = "MAHOCPHAN";
        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            CauHois cauHois = new CauHois();
            cauHois.NoiDung = txtNoiDung.Text;
            cauHois.DapAn1 = txtA.Text;
            cauHois.DapAn2 = txtB.Text;
            cauHois.DapAn3 = txtC.Text;
            cauHois.DapAn4 = txtD.Text;
            
            if (radA.Checked) { cauHois.DapAnDung = "A"; }
            if (radB.Checked) { cauHois.DapAnDung = "B"; }
            if (radC.Checked) { cauHois.DapAnDung = "C"; }
            if (radD.Checked) { cauHois.DapAnDung = "D"; }

            cauHois.MaNganHang = MANGANHANG;
            cauHois.MaHocPhan = cboMonHoc.SelectedValue.ToString();
            cauHois.NgayTao = DateTime.UtcNow;
            cauHois.NgayCapNhat = DateTime.UtcNow;
             
            // Kiểm tra môn học đã được tạo trong ngân hàng chưa
            if (!CT_NganHangCauHoi_DAO.Check_MahocPhan_Exists(cboMonHoc.SelectedValue.ToString()))
            {
                // Thêm học phần vào CT_NganHangCauHoi
                CT_NganHangCauHois ct = new CT_NganHangCauHois();
                ct.MaNganHang = MANGANHANG;
                ct.MaGV = MAGV;
                ct.MaHocPhan = cboMonHoc.SelectedValue.ToString();
                if (CT_NganHangCauHoi_DAO.Insert(ct) > 0)
                {
                    // Tạo câu hỏi
                    if (CauHoi_DAO.Insert_Single_Question(cauHois))
                    {
                        KryptonMessageBox.Show("Thêm danh sách câu hỏi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                // Tạo câu hỏi
                if (CauHoi_DAO.Insert_Single_Question(cauHois))
                {
                    KryptonMessageBox.Show("Thêm danh sách câu hỏi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }
    }
}
