using App_QL_ThiTracNghiem.DAO;
using App_QL_ThiTracNghiem.DTO;
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

namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    public partial class frmDS_HocPhan : UserControl
    {
        public frmDS_HocPhan()
        {
            InitializeComponent();

            Show_DSHP();
            cboKhoa.SelectedValue = "01";

            frmDSHP ds = new frmDSHP(pnND, cboKhoa.SelectedValue.ToString());
            ds.Dock = DockStyle.Fill;
            pnND.Controls.Add(ds);
            ds.BringToFront();
        }

        public void Show_DSHP()
        {
            cboKhoa.DataSource = Khoa_DAO.GetKhoas();
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_HocPhan edit = new frmAdd_Edit_HocPhan(false, null, null, "");
            edit.ShowDialog();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmDSHP ds = new frmDSHP(pnND, cboKhoa.SelectedValue.ToString());
            ds.Dock = DockStyle.Fill;
            pnND.Controls.Add(ds);
            ds.BringToFront();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frmDSHP ds = new frmDSHP(pnND, cboKhoa.SelectedValue.ToString());
            ds.Dock = DockStyle.Fill;
            pnND.Controls.Add(ds);
            ds.BringToFront();
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            frmDSHP ds = new frmDSHP(pnND, cboKhoa.SelectedValue.ToString());
            ds.Dock = DockStyle.Fill;
            pnND.Controls.Add(ds);
            ds.BringToFront();
        }
    }
}
