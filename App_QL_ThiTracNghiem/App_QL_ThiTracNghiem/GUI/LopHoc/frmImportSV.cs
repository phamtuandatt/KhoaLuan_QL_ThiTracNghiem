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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.LopHoc
{
    public partial class frmImportSV : MetroFramework.Forms.MetroForm
    {
        public frmImportSV()
        {
            InitializeComponent();
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;

            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string strfileName = "";

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files (.xls*)|*.xls*|All Files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            strfileName = dlg.FileName;

            if (strfileName != string.Empty)
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strfileName);
                xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                xlRange = xlWorkSheet.UsedRange;

                int i = 0;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    i++;
                    gridDSSV.Rows.Add(i, xlRange.Cells[xlRow, 1].Text,
                        xlRange.Cells[xlRow, 2].Text,
                        xlRange.Cells[xlRow, 3].Text,
                        xlRange.Cells[xlRow, 4].Text,
                        xlRange.Cells[xlRow, 5].Text,
                        xlRange.Cells[xlRow, 6].Text,
                        xlRange.Cells[xlRow, 7].Text,
                        xlRange.Cells[xlRow, 8].Text,
                        xlRange.Cells[xlRow, 9].Text);
                }
                xlWorkBook.Close();
                xlApp.Quit();
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (gridDSSV.RowCount <= 0)
            {
                KryptonMessageBox.Show($"Chưa có danh sách sinh viên !", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KryptonMessageBox.Show($"Bạn có muôn thêm danh sách sinh viên KHOA [{cboKhoa.Text.Trim()}] thành công !", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            List<SinhViens> lstSv = new List<SinhViens>();
            for (int i = 0; i < gridDSSV.RowCount; i++)
            {
                //Tạo tài khoản mật khẩu giống tên của nhân viên
                string mk;
                string[] ten = gridDSSV.Rows[i].Cells[2].Value.ToString().Trim().Split(' ');
                if (ten.Length == 1)
                    mk = chuyen_khong_dau(ten[0]);
                else
                    mk = chuyen_khong_dau((ten[(ten.Length - 1) - 1] + ten[ten.Length - 1]).ToLower());

                SinhViens sv = new SinhViens();
                sv.MaSV = gridDSSV.Rows[i].Cells[1].Value.ToString().Trim();
                sv.TenSV = gridDSSV.Rows[i].Cells[2].Value.ToString().Trim();
                sv.MatKhau = mk;
                sv.GioiTinh = gridDSSV.Rows[i].Cells[3].Value.ToString().Trim();
                sv.NgaySinh = DateTime.Parse(gridDSSV.Rows[i].Cells[4].Value.ToString().Trim());
                sv.Email = gridDSSV.Rows[i].Cells[8].Value.ToString().Trim();
                sv.Sdt = gridDSSV.Rows[i].Cells[9].Value.ToString().Trim();
                sv.DiaChi = gridDSSV.Rows[i].Cells[6].Value.ToString().Trim();
                sv.QueQuan = gridDSSV.Rows[i].Cells[7].Value.ToString().Trim();
                sv.MaLop = gridDSSV.Rows[i].Cells[5].Value.ToString().Trim();

                lstSv.Add(sv);
            }
            // Kiểm tra mã lớp đã có trong DB chưa 
            // Thêm lớp trước khi thêm sinh viên
            foreach (DataGridViewRow item in gridDSSV.Rows)
            {
                if (Lop_DAO.LopIsExisted(item.Cells[5].Value.ToString().Trim()) == false)
                {
                    Lops lopp = new Lops();
                    lopp.MaLop = item.Cells[5].Value.ToString().Trim();
                    lopp.TenLop = "";
                    lopp.MaKhoa = cboKhoa.SelectedValue.ToString();
                    bool rs = Lop_DAO.InsertLop(lopp);
                }
            }

            if (SinhVien_DAO.UpdateDBSinhVien(lstSv))
            {
                KryptonMessageBox.Show("Thêm danh sách sinh viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Thêm danh sách sinh viên KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private string chuyen_khong_dau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
