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

namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    public partial class frmTaoCaThi : UserControl
    {
        KryptonPanel content;
        bool check_create_edit;
        public frmTaoCaThi()
        {
            InitializeComponent();
        }
        public frmTaoCaThi(KryptonPanel content, bool check_create_edit)
        {
            InitializeComponent();
            this.content = content;
            this.check_create_edit = check_create_edit;
            // Nếu là true -> Tạo mới ca thi
            if (this.check_create_edit)
            {
                btnThemSV.Visible = false;
            }
            // Nếu là false -> Cập nhật sửa đổi ca thi
            else
            {
                btnThemSV.Visible = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmCT_CaThi frmCTCaThi = new frmCT_CaThi();
            frmCTCaThi.ShowDialog();
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            // Truyền môn học vào form để hiển thị danh sách sinh viên đang theo học môn học đó
            frmThemSV frmThemSV = new frmThemSV(5);
            frmThemSV.ShowDialog();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

        }
    }
}
