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
    public partial class frmTaoCauHoi : Form
    {
        int maMh;
        public frmTaoCauHoi(int maMh)
        {
            InitializeComponent();
            this.maMh = maMh;
            if (maMh != 0)
            {
                // Hiển thị tên môn học dựa vào ID môn học
            }
        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            // Kiểm tra cbo Môn học đã được chọn hay chưa
        }
    }
}
