using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace App_QL_ThiTracNghiem.DAO
{
    public class HocPhan_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetHocPhans(string MAGV)
        {
            DataTable data_HocPhan = new DataTable();
            string sql =  String.Format("EXEC GET_DS_HOCPHAN_GIANGVIEN '{0}'", MAGV);
            data_HocPhan = data.get_data(sql, "data_HocPhan");

            return data_HocPhan;
        }

        public static DataTable GetHocPhan_NganHang(int MANGANHANG, string MAGV)
        {
            // Lấy danh sách các học phần chưa được tạo trong ngân hàng câu hỏi
            DataTable dt_HocPhan = new DataTable();
            string sql = String.Format("EXEC GET_DS_HOCPHAN_NGANHANG {0}, '{1}'", MANGANHANG, MAGV) ;
            dt_HocPhan = data.get_data(sql, "data_HocPhan");

            return dt_HocPhan;
        }

        public static DataTable GetAllHocPhans()
        {
            DataTable dt_HocPhan = new DataTable();
            string sql = "SELECT *FROM HOCPHAN";
            dt_HocPhan = data.get_data(sql, "GetAllHocPhans");

            return dt_HocPhan;
        }
    }
}
