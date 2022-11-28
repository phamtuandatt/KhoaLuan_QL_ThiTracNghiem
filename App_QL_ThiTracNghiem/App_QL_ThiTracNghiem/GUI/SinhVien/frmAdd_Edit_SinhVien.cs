using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.SinhVien
{
    public partial class frmAdd_Edit_SinhVien : MetroFramework.Forms.MetroForm
    {
        bool check_edit;
        SinhViens sinhVien;
        public frmAdd_Edit_SinhVien(bool check_edit, SinhViens sinhViens)
        {
            InitializeComponent();
            this.check_edit = check_edit;
            this.sinhVien = sinhViens;

            if (check_edit)
            {

            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
