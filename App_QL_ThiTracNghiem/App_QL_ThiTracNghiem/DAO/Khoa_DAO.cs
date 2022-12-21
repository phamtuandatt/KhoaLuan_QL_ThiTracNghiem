using App_QL_ThiTracNghiem.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class Khoa_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetKhoas()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MAKHOA, TENKHOA FROM KHOA";
            dt = data.get_data(sql, "DSGV");

            return dt;
        }

        public static DataTable GetDSKhoa()
        {
            DataTable dt = new DataTable();
            string sql = "EXEC GET_DSKHOA";
            dt = data.get_data(sql, "DSGV");

            return dt;
        }


        public static bool DeleteKhoa(string MAKHOA)
        {
            string sql = $"DELETE FROM KHOA WHERE MAKHOA = '{MAKHOA}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool CheckKhoa(string MAKHOA)
        {
            string sql = $"SELECT COUNT(MAKHOA) FROM LOPHOC WHERE MAKHOA = '{MAKHOA}'";

            return data.get_result_int(sql) > 0;
        }

        public static bool UpdateKhoa(string MAKHOA, string TENKHOA)
        {
            string sql = $"UPDATE KHOA SET TENKHOA = N'{TENKHOA}' WHERE MAKHOA = '{MAKHOA}'";

            return data.insert_update_delete(sql) > 0;
        }
        
        public static bool InsertKhoa(string TENKHOA)
        {
            string sql = $"INSERT INTO KHOA(TENKHOA) VALUES (N'{TENKHOA}')";

            return data.insert_update_delete(sql) > 0;
        }
    }
}
