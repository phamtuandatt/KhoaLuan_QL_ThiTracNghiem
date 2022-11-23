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
    public class CT_CaThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable dt_tam = data.get_data("SELECT *FROM CT_CATHI", "TBTAM");

        public static bool Insert_CT_CaThi(List<string> lst_SV, int MADETHI)
        {
            foreach (var item in lst_SV)
            {
                DataRow add_r = dt_tam.NewRow();
                add_r[0] = MADETHI;
                add_r[1] = item;

                dt_tam.Rows.Add(add_r);
            }
            return true;
        }

        public static int Get_MaCaThi()
        {
            string sql = "SELECT MAX(MACATHI) FROM CATHI";

            return data.get_result_int(sql);
        }

        public static bool Up_DB_CT_CaThi()
        {
            try
            {
                data.update_database("SELECT *FROM CT_CATHI", dt_tam);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
