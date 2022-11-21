using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CT_DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        static DataTable table_tam = data.get_data("SELECT *FROM CT_DETHI", "TABLE_TAM");

        public static DataTable GetDS_DeThi_CauHoi(string MADETHI, string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI_CAUHOI '{0}', '{1}'", MADETHI, MAHOCPHAN);
            dt = data.get_data(sql, "DS_CAUHOI_DETHI");

            return dt;
        }

        public static List<int> GetDS_DeThi_HocPhan(string MAHOCPHAN)
        {
            DataTable dt = data.get_data(string.Format("SELECT DISTINCT(MADETHI) FROM DETHI WHERE MAHOCPHAN = '{0}'", MAHOCPHAN), "TABLE_TAM");
            List<int> lst_MaDe = new List<int>();
            foreach (DataRow item in dt.Rows)
            {
                lst_MaDe.Add(int.Parse(item[0].ToString().Trim()));
            }
            return lst_MaDe;
        }

        public static void Insert_CT_DeThi(List<CT_DeThis> lst_DeThi)
        {
            foreach (var item in lst_DeThi)
            {
                DataRow add_r = table_tam.NewRow();
                add_r[0] = item.MaDeThi;
                add_r[1] = item.MaCauHoi;
                add_r[2] = item.MaHocPhan;

                table_tam.Rows.Add(add_r);
            }
        }

        public static bool Update_Database(List<CT_DeThis> lst_DeThi)
        {
            Insert_CT_DeThi(lst_DeThi);
            try
            {
                data.update_database("SELECT *FROM CT_DETHI", table_tam);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return false;
                }
                return false;
                throw;
            }
        }
    }
}
