using App_QL_ThiTracNghiem.DataProvider;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class SinhVien_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetSinhViens(string MAHOCPHAN)
        {
            DataTable dT = new DataTable();
            string sql = string.Format("EXEC GET_DS_SV_LOPHOCPHAN '{0}'", MAHOCPHAN);
            dT = data.get_data(sql, "GETSINHVIEN");

            return dT;
        }
    }
}
