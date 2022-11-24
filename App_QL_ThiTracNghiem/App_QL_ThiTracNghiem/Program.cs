using App_QL_ThiTracNghiem.GUI;
using App_QL_ThiTracNghiem.GUI.CaThi;
using App_QL_ThiTracNghiem.GUI.CauHoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
