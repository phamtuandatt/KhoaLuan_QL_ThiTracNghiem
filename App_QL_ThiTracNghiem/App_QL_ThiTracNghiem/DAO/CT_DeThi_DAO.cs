using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CT_DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        static DataTable table_tam = data.get_data("SELECT *FROM CT_DETHI", "TABLE_TAM");

        public static bool DeleteCT_DeThi(int MADETHI, string MADECON)
        {
            string sql = string.Format("DELETE FROM CT_DETHI WHERE MADETHI = {0} AND MADECON = '{1}'", MADETHI, MADECON);

            return data.insert_update_delete(sql) > 0;
        }

        public static DataTable GetDS_DeThi_CauHoi(int MADETHI, string MADECON)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI_CAUHOI '{0}', '{1}'", MADETHI, MADECON);
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

        public static int GetMaDeThi_MAX()
        {
            string sql = "SELECT MAX(MADETHI) FROM DETHI";
            int rs = data.get_result_int(sql);

            return rs;
        }

        public static DataTable Get_DS_DeCon(int MADETHI)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("SELECT DISTINCT(MADECON) FROM CT_DETHI WHERE MADETHI = {0}", MADETHI);
            dt = data.get_data(sql, "DSMADECON");

            return dt;
        }

        public static void Insert_CT_DeThi(List<CT_DeThis> lst_DeThi, List<string> soluongde)
        {
            if (soluongde == null)
            {
                foreach (var ct in lst_DeThi)
                {
                    DataRow add_r = table_tam.NewRow();
                    add_r[1] = ct.MaDeThi;
                    add_r[2] = ct.MaDeCon;
                    add_r[3] = ct.MaCauHoi;
                    
                    table_tam.Rows.Add(add_r);
                }
            }
            else
            {
                foreach (var item in soluongde)
                {
                    List<CT_DeThis> list = TronCauHoi(lst_DeThi);
                    foreach (var ct in list)
                    {
                        DataRow add_r = table_tam.NewRow();
                        add_r[1] = ct.MaDeThi;
                        add_r[2] = item;
                        add_r[3] = ct.MaCauHoi;

                        table_tam.Rows.Add(add_r);
                    }
                }
            }
        }

        public static List<CT_DeThis> TronCauHoi(List<CT_DeThis> lstCTDeThi)
        {
            // random vị trí
            Random r = new Random();
            
            for (int i = 0; i < lstCTDeThi.Count/2; i++)
            {
                int vt = r.Next(1, lstCTDeThi.Count); // Tạo vị trí ngẫu nhiên
                var ct = lstCTDeThi[i];
                lstCTDeThi[i] = lstCTDeThi[vt];
                lstCTDeThi[vt] = ct;
            }

            List<CT_DeThis> new_lst = lstCTDeThi;

            return new_lst;
        }

        public static bool Update_Database(List<CT_DeThis> lst_DeThi, List<string> soluongde)
        {
            Insert_CT_DeThi(lst_DeThi, soluongde);
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
