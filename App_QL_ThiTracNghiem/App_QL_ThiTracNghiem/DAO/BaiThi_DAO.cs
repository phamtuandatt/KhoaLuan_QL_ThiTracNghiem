using App_QL_ThiTracNghiem.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class BaiThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetDSSVLamBaiThi(int MACATHI)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GETDSSVTHAMGIA {MACATHI}";
            dt = data.get_data(sql, "DSSVTHI");

            return dt;
        }
    }
}
