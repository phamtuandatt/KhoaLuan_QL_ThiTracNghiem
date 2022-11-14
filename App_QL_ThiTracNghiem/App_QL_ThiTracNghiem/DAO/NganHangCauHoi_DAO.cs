using App_QL_ThiTracNghiem.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace App_QL_ThiTracNghiem.DAO
{
    public class NganHangCauHoi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable Get_CT_NganHangCauHoi(int MANGANHANG)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_CT_NGANHANGCAUHOI {0}", MANGANHANG);
            dt = data.get_data(sql, "Get_CT_NganHangCauHoi");

            return dt;
        }

        public static DataTable Get_DS_CauHoi(int MANGANHANG, string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_CAUHOI_NGANHANG {0}, '{1}'", MANGANHANG, MAHOCPHAN);
            dt = data.get_data(sql, "Get_DS_CauHoi");

            return dt;
        }

        public static DataTable Get_DS_NganHangCauHoi_GiangVien()
        {
            DataTable dt = new DataTable();
            string sql = "EXEC GET_DS_NGANHANGCAUHOI_GIANGVIEN";
            dt = data.get_data(sql, "GET_DS_NGANHANGCAUHOI_GIANGVIEN");

            return dt;
        }
    }
}
