using App_QL_ThiTracNghiem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.GUI.LopHoc
{
    public partial class frmDSSinhVienLop : MetroFramework.Forms.MetroForm
    {
        public frmDSSinhVienLop(string MALOP)
        {
            InitializeComponent();
            gridDSSV.DataSource = SinhVien_DAO.GetDSSV(MALOP.Trim());
        }
    }
}
