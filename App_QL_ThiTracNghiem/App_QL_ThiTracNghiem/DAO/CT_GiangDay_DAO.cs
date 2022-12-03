using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CT_GiangDay_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static bool GVIsExisted(CT_GiangDays ct)
        {
            string sql = $"SELECT COUNT(MAHOCPHAN) FROM CT_GIANGDAY WHERE MAHOCPHAN = '{ct.MaHocPhan}' AND MAGV = '{ct.MaGV}'";

            return data.get_result_int(sql) > 0;
        }

        public static bool InsertCT_GiangDay (CT_GiangDays ct)
        {
            string sql = $"INSERT INTO CT_GIANGDAY VALUES('{ct.MaHocPhan}', '{ct.MaGV}')";

            return data.insert_update_delete(sql) > 0;
        }
    }
}
