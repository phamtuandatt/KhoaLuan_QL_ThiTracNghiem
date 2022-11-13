using App_QL_ThiTracNghiem.DataProvider;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_QL_ThiTracNghiem.DTO;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CT_NganHangCauHoi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static int Insert(CT_NganHangCauHois cT_NganHangCauHois)
        {
            string sql = string.Format("INSERT INTO CT_NGANHANGCAUHOI VALUES ({0}, '{1}', '{2}')", 
                cT_NganHangCauHois.MaNganHang, cT_NganHangCauHois.MaGV, cT_NganHangCauHois.MaHocPhan);
            return data.insert_update_delete(sql);
        }

        public static DataTable Get_DS_HocPhan(int MANGANHANG)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_HOCPHAN_NGANHANG {0}", MANGANHANG);
            dt = data.get_data(sql, "Get_DS_HocPhan");

            return dt;
        }

        public static bool Check_MahocPhan_Exists(string MAHOCPHAN)
        {
            string sql = string.Format("SELECT COUNT(*) FROM CT_NGANHANGCAUHOI WHERE MAHOCPHAN = '{0}'", MAHOCPHAN);

            return data.get_result_int(sql) > 0;
        }
    }
}
