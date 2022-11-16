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
    public class CT_DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        static DataTable table_tam = data.get_data("SELECT *FROM CT_DETHI", "TABLE_TAM");

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
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
