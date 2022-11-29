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
    public class Lop_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetDSLH()
        {
            DataTable dt = new DataTable();
            string sql = "EXEC GET_DSLOPHOC";
            dt = data.get_data(sql, "DSLH");

            return dt;
        }

        public static DataTable GetDSLH_Khoa(string MAKHOA)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DSLOPHOC_KHOA '{MAKHOA}'";
            dt = data.get_data(sql, "DSLH");

            return dt;
        }

        public static DataTable GetDSLop_Khoa(string MAKHOA)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT *FROM LOPHOC WHERE MAKHOA = '{MAKHOA}'";
            dt = data.get_data(sql, "DSLH_KHOA");

            return dt;
        }

        public static bool UpdateLop(Lops lop)
        {
            string sql = $"UPDATE LOPHOC SET TENLOP = N'{lop.TenLop}' WHERE MALOP = '{lop.MaLop}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool InsertLop(Lops lops)
        {
            string sql = $"INSERT INTO LOPHOC VALUES ('{lops.MaLop}', N'{lops.TenLop}', '{lops.Siso}', '{lops.MaKhoa}')";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool DeleteLop(string MALOP)
        {
            string sql = $"DELETE FROM LOPHOC WHERE MALOP = '{MALOP}'";

            return data.insert_update_delete(sql) > 0;
        }
    }
}
