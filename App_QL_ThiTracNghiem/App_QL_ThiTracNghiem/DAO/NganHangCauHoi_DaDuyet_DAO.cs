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

        public static DataTable table_tam = data.get_data("EXEC GET_DS_CAUHOI_DADUYET", "table");

        public static DataTable Get_DS_CauHoi_DaDuyet(string MAHOCPHAN)
        {
            DataTable table_DS_CauHoiDaDuocDuyet = new DataTable();
            table_DS_CauHoiDaDuocDuyet = table_tam.Copy();
            table_DS_CauHoiDaDuocDuyet.Clear();
            foreach (DataRow item in table_tam.Rows)
            {
                if (item["MAHOCPHAN"].ToString() == MAHOCPHAN)
                { 
                    DataRow new_r = table_DS_CauHoiDaDuocDuyet.NewRow();
                    new_r[0] = item["MANH"];
                    new_r[1] = item["MAHOCPHAN"];
                    new_r[2] = item["MACAUHOI"];
                    new_r[3] = item["NOIDUNG"];
                    new_r[4] = item["DAPAN1"];
                    new_r[5] = item["DAPAN2"];
                    new_r[6] = item["DAPAN3"];
                    new_r[7] = item["DAPAN4"];
                    new_r[8] = item["DAPANDUNG"];

                    table_DS_CauHoiDaDuocDuyet.Rows.Add(new_r);
                }
            }
            return table_DS_CauHoiDaDuocDuyet;
        }

        public static bool Update_Databae(List<NganHangCauHoi_DaDuyets> lst_qs)
        {
            Insert_Question(lst_qs);
            try
            {
                data.update_database("SELECT *FROM NGANHANGCAUHOI_DADUYET", table);
                table_tam = data.get_data("EXEC GET_DS_CAUHOI_DADUYET", "table");
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
