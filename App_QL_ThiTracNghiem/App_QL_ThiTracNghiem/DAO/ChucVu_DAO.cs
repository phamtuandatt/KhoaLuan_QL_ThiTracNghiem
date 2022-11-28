using App_QL_ThiTracNghiem.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class ChucVu_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetChucVu()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT *FROM CHUCVU";
            dt = data.get_data(sql, "DScv");

            return dt;
        }
    }
}
