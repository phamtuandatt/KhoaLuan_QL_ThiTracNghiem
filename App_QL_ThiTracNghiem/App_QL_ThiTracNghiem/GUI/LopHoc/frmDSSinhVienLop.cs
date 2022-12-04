using App_QL_ThiTracNghiem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace App_QL_ThiTracNghiem.GUI.LopHoc
{
    public partial class frmDSSinhVienLop : MetroFramework.Forms.MetroForm
    {
        public frmDSSinhVienLop(string MALOP, string TENLOP)
        {
            InitializeComponent();
            gridDSSV.DataSource = SinhVien_DAO.GetDSSV(MALOP.Trim());
        }
    }
}
