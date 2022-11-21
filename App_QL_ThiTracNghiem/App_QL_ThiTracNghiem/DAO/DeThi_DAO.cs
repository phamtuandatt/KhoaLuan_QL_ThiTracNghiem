using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetDS_DeThi(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI '{0}'", MAHOCPHAN);
            dt = data.get_data(sql, "GetDSDeThi");

            return dt;
        }

        public static bool Insert_DeThi(DeThis deThis)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO DETHI VALUES ('{0}', '{1}', '{2}', N'{3}', N'{4}', {5}, {6}, {7})",
                deThis.MaDeThi, deThis.MaHocPhan, deThis.NgayTao, deThis.GioBatDau, deThis.NgayThi, deThis.TGLamBai, deThis.SLCauHoi, deThis.TinhTrang);
            if (data.insert_update_delete(sql) == -1)
            {
                return false;
            }
            return true;
        }
    }
}
