using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DAO
{
    public class NganHangCauHoi_DaDuyet_DAO
    {
        public static SqlProvider data = new SqlProvider();

        public static DataTable table = data.get_data("SELECT *FROM NGANHANGCAUHOI_DADUYET", "table");

        public static bool Update_Databae(List<NganHangCauHoi_DaDuyets> lst_qs)
        {
            Insert_Question(lst_qs);
            try
            {
                data.update_database("SELECT *FROM NGANHANGCAUHOI_DADUYET", table);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static void Insert_Question(List<NganHangCauHoi_DaDuyets> lst_qs)
        {
            foreach (var item in lst_qs)
            {
                DataRow add_r = table.NewRow();
                add_r[0] = item.MaNH;
                add_r[1] = item.MaHocPhan;
                add_r[2] = item.MaCaiuHoi;

                table.Rows.Add(add_r);
            }
        }
        
    }
}
