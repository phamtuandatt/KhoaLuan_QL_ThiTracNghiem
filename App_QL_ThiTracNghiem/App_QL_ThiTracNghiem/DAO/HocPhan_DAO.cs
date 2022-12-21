using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace App_QL_ThiTracNghiem.DAO
{
    public class HocPhan_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static HocPhans GetHP(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT *FROM HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";
            dt = data.get_data(sql, "HP");
            HocPhans hp = new HocPhans();
            foreach (DataRow item in dt.Rows)
            {
                hp.MaHocPhan = item["MAHOCPHAN"].ToString();
                hp.TenHocPhan= item["TENHOCPHAN"].ToString();
                hp.SoTC = int.Parse(item["SOTC"].ToString());
                hp.SoTietLT = int.Parse(item["SOTIET_LT"].ToString());
                hp.SoTietTH = int.Parse(item["SOTIET_TH"].ToString());
                hp.MaKhoa = item["MAKHOA"].ToString();

                return hp;
            }
            return null;
        }

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
            // Lấy danh sách học phần đã CÓ ĐỀ THIS
            DataTable dt_HocPhan = new DataTable();
            string sql = $"SELECT *FROM HOCPHAN WHERE MAHOCPHAN IN (SELECT MAHOCPHAN FROM DETHI)";
            dt_HocPhan = data.get_data(sql, "GetAllHocPhans");

            return dt_HocPhan;
        }

        public static DataTable GetDSHP(string MAKHOA)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DSHOCPHAN_KHOA '{MAKHOA}'";
            dt = data.get_data(sql, "DSHP");

            return dt;
        }

        public static string GetMHPMax()
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT MAX(MAHOCPHAN) AS MAHP FROM HOCPHAN";
            dt = data.get_data(sql, "MHPMAX");
            foreach (DataRow item in dt.Rows)
            {
                return item["MAHP"].ToString();
            }
            return null;
        }

        // Kiểm tra học phần chuẩn bị tạo đã tồn tại chưa
        public static bool HPIsExisted(string TIET, string PHONG, int THU)
        {
            string sql = $"SELECT COUNT(MAHOCPHAN) FROM CT_HOCPHAN " +
                $"WHERE THU = {THU} AND TIET = '{TIET}' AND PHONG = '{PHONG}'";

            return data.get_result_int(sql) > 0;
        }

        public static string GetTietOfThuPhong(string PHONG, int THU)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT *FROM CT_HOCPHAN WHERE THU = {THU} AND PHONG = '{PHONG}'";
            dt = data.get_data(sql, "TOTTP");

            foreach (DataRow item in dt.Rows)
            {
                return item["TIET"].ToString();
            }
            return "";
        }

        public static bool UpdateHP(HocPhans hp)
        {
            string sql = $"UPDATE HOCPHAN SET TENHOCPHAN = N'{hp.TenHocPhan}', SOTC = {hp.SoTC} , SOTIET_LT = {hp.SoTietLT} , SOTIET_TH = {hp.SoTietTH} WHERE MAHOCPHAN = '{hp.MaHocPhan}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool InsertHP(HocPhans hp)
        {
            string sql = $"INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'{hp.TenHocPhan}', {hp.SoTC}, {hp.SoTietLT}, {hp.SoTietTH}, '{hp.MaKhoa}')";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool DeleteHP(string MAHOCPHAN)
        {
            // Kiểm tra có CT_HOCPHAN nào có MAHOCPHAN hay không
            if (CT_HPIsExisted(MAHOCPHAN))
            {
                if (DeleteCT_HP(MAHOCPHAN))
                {
                    if (CT_GiangDay_DAO.DeleteCT_GiangDay(MAHOCPHAN))
                    {
                        string sql = $"DELETE FROM HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";
                        return data.insert_update_delete(sql) > 0;
                    }
                }
            }
            else
            {
                string sql = $"DELETE FROM HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";
                return data.insert_update_delete(sql) > 0;
            }

            return false;
        }

        public static bool DeleteCT_HP(string MAHOCPHAN)
        {
            string sql = $"DELETE FROM CT_HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool CT_HPIsExisted(string MAHOCPHAN)
        {
            string sql = $"SELECT COUNT(MAHOCPHAN) FROM CT_HOCPHAN WHERE MAHOCPHAN = '{MAHOCPHAN}'";

            return data.get_result_int(sql) > 0;
        }
    }
}
