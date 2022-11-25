﻿using App_QL_ThiTracNghiem.DAO;
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

namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    public partial class frmShowDS_DeThiCon : Form
    {
        int MADETHI, MACATHI;
        public frmShowDS_DeThiCon(int MADETHI, int MACATHI)
        {
            InitializeComponent();
            this.MADETHI = MADETHI;
            this.MACATHI = MACATHI;

            cboDSDeThi.DataSource = CT_DeThi_DAO.Get_DS_DeCon(MADETHI);
            cboDSDeThi.DisplayMember = "MADECON";
            cboDSDeThi.ValueMember = "MADECON";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CaThi_DAO.Update_DeThi_CaThi(cboDSDeThi.SelectedValue.ToString(), MACATHI))
            {
                KryptonMessageBox.Show("Cập nhật ĐỀ THI cho CA THI thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                KryptonMessageBox.Show("Cập nhật ĐỀ THI cho CA THI KHÔNG thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
