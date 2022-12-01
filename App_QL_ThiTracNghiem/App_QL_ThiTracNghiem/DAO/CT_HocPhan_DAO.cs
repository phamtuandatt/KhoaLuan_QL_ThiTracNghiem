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
    public class CT_HocPhan_DAO
    {
        static SqlProvider data = new SqlProvider();

        static DataTable dt_tam = data.get_data("SELECT *FROM CT_HOCPHAN", "CT");

        public static DataTable GetDSLopHP(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT DISTINCT(MALOPHOCPHAN), MAHOCPHAN, MAGV, THU, TIET, PHONG, NGAYBD, NGAYKT FROM CT_HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";
            dt = data.get_data(sql, "DSLHP");

            return dt;
        }

        public static string GetMaCTHP(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT DBO.AUTO_MALOPHOCPHAN('{MAHOCPHAN}') AS MALHP";
            dt = data.get_data(sql, "DSLHP");
            foreach (DataRow item in dt.Rows)
            {
                return item["MALHP"].ToString();
            }
            return null;
        }

        public static CT_HocPhans CT_HocPhan(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_CT_HOCPHAN '{MAHOCPHAN}'";
            dt = data.get_data(sql, "CTHOCPHAN");
            
            foreach (DataRow item in dt.Rows)
            {
                CT_HocPhans cthp = new CT_HocPhans();
                cthp.MaLopHocPhan = item["MALOPHOCPHAN"].ToString();
                cthp.MaGV = item["MAGV"].ToString();
                cthp.Thu = int.Parse(item["THU"].ToString());
                cthp.Tiet = item["TIET"].ToString();
                cthp.Phong = item["PHONG"].ToString();
                cthp.NgayBD = DateTime.Parse(item["NGAYBD"].ToString());
                cthp.NgayKT = DateTime.Parse(item["NGAYKT"].ToString());
                cthp.TenGV = item["TENGV"].ToString();

                return cthp;
            }
            return null;
        }

        public static DataTable DS_SV_HocPhan(string MALOPHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DSSV_HOCPHAN '{MALOPHOCPHAN}'";
            dt = data.get_data(sql, "DSSVHOCPHAN");

            return dt;
        }

        public static void InsertCT_HocPhan(List<CT_HocPhans> lstCT_HocPhan)
        {
            foreach (var item in lstCT_HocPhan)
            {
                DataRow new_r = dt_tam.NewRow();
                new_r[0] = item.MaLopHocPhan;
                new_r[1] = item.MaSV;
                new_r[2] = item.MaHocPhan;
                new_r[3] = item.MaGV;
                new_r[4] = item.Thu;
                new_r[5] = item.Tiet;
                new_r[6] = item.Phong;
                new_r[7] = item.NgayBD;
                new_r[8] = item.NgayKT;

                dt_tam.Rows.Add(new_r);
            }
        }

        public static bool DeleteCT_HocPhan(string MALOPHOCPHAN)
        {
            string sql = $"DELETE FROM CT_HOCPHAN WHERE MALOPHOCPHAN = '{MALOPHOCPHAN}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool Update_DB_CT_HocPhan(bool check_update, string MALOPHOCPHAN,List<CT_HocPhans> lst)
        {
            // true -> cập nhật
            if (check_update == true)
            {
                if (DeleteCT_HocPhan(MALOPHOCPHAN))
                {
                    InsertCT_HocPhan(lst);
                }
            }
            else
            {
                InsertCT_HocPhan(lst);
            }

            try
            {
                data.update_database("SELECT *FROM CT_HOCPHAN", dt_tam);
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
