using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Runtime.Remoting;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CaThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable Get_DS_CaThi()
        {
            DataTable dt = new DataTable();
            string sql = "EXEC GET_DS_CATHIS";
            dt = data.get_data(sql, "DS_CATHI");

            return dt;
        }

        public static DataTable Get_DS_CaThi_MaHocPhan(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DS_CATHIS_HOCPHAN '{MAHOCPHAN}'";
            dt = data.get_data(sql, "DS_CATHIHP");

            return dt;
        }

        public static bool CaThiIsExisted(string NGAYTHI, string TIET, string PHONGTHI)
        {
            string sql = $"SELECT COUNT(MAHOCPHAN) MAHP FROM CATHI WHERE NGAYTHI = '{NGAYTHI}' AND GIOLAMBAI = N'{TIET}' AND PHONGTHI = '{PHONGTHI}'";
            int rs = data.get_result_int(sql);
            
            return rs > 0;
        }

        public static bool UpdateTinhTrangCaThi(string MACATHI)
        {
            string sql = $"UPDATE CATHI SET TINHTRANG = 1 WHERE MACATHI = {MACATHI}";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool CheckTinhTrangCaThi(string MACATHI)
        {
            DataTable dt = new DataTable();
            string sql = $"SELECT TINHTRANG FROM CATHI WHERE MACATHI = {MACATHI}";
            dt = data.get_data(sql, "STATUS");
            foreach (DataRow item in dt.Rows)
            {
                return bool.Parse(item["TINHTRANG"].ToString());
            }
            return false;
        }

        public static bool Insert_CaThi(CaThis caThis)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO CATHI(MAHOCPHAN, MADETHI, MADECON, NGAYTHI, GIOLAMBAI, TINHTRANG, PHONGTHI, TINHTRANGTHI)\n" +
                                        "VALUES ('{0}', '{1}', '{2}', N'{3}', N'{4}', {5}, N'{6}', {7})", caThis.MaHocPhan, caThis.MaDeThi, "CHƯA CÓ", caThis.NgayThi,
                                        caThis.GioLamBai, caThis.TinhTrang, caThis.Phong, 0);
            return data.insert_update_delete(sql) > 0;
        }

        public static bool UpdateCaThi(CaThis ct)
        {
            string sql = string.Format("UPDATE CATHI SET MADETHI = {0}, NGAYTHI = '{1}', GIOLAMBAI = N'{2}', TINHTRANG = {3}, PHONGTHI = N'{4}' WHERE MACATHI = {5}",
                ct.MaDeThi, ct.NgayThi, ct.GioLamBai, ct.TinhTrang, ct.Phong, ct.MaCaThi);

            return data.insert_update_delete(sql) > 0;
        }

        public static bool Update_DeThi_CaThi(string MADECON, int MACATHI)
        {
            string sql = string.Format("UPDATE CATHI SET MADECON = '{0}', NGAYTHI = '{2}'  WHERE MACATHI = {1}", MADECON, MACATHI, DateTime.UtcNow.Date);

            return data.insert_update_delete(sql) > 0;
        }

        public static DataTable GetDSCaThi()
        {
            DataTable dt = new DataTable();
            string sql = "EXEC GETDSCATHI";
            dt = data.get_data(sql, "DSCT");

            return dt;
        }

        public static DataTable GetDSCaThiCbo()
        {
            DataTable dt = new DataTable();
            DataTable dataCbo = new DataTable();
            //string sql = $"EXEC GETDSCATHINGAY '{DateTime.UtcNow.ToString()}'"; - Khi chạy thì mở hàm lấy dòng này để lấy các ca thi trong ngày
            string sql = $"EXEC GETDSCATHI";
            dt = data.get_data(sql, "DSCT");
            dataCbo = dt.Copy();
            dataCbo.Clear();
            foreach (DataRow item in dt.Rows)
            {
                DataRow r = dataCbo.NewRow();
                r["MACATHI"] = item["MACATHI"];
                r["TENHOCPHAN"] = item["TENHOCPHAN"] + " - PHÒNG - " + item["PHONGTHI"] + " - GIỜ LÀM BÀI - " + item["GIOLAMBAI"];

                dataCbo.Rows.Add(r);
            }

            return dataCbo;
        }

        public static DataTable GetDSCaThiPhongTietNgay(string PHONG, string TIET, DateTime NGAYTHI)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GETDSCATHI_PHONG_TIET_NGAY N'{PHONG}', N'{TIET}', '{NGAYTHI}'";
            dt = data.get_data(sql, "DSCTPHONGTIETNGAY");

            return dt;
        }

        public static DataTable GetDSCaThiPhongTiet(string PHONG, string TIET)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GETDSCATHI_PHONG_TIET N'{PHONG}', N'{TIET}'";
            dt = data.get_data(sql, "DSCTPHONGTIETNGAY");

            return dt;
        }

        public static CaThis GetCaThi(int MACATHI)
        {
            CaThis caThis = new CaThis();
            DataTable dt = new DataTable();
            string sql = $"SELECT *FROM CATHI WHERE MACATHI = {MACATHI}";
            dt = data.get_data(sql, "CATHI");

            foreach (DataRow item in dt.Rows)
            {
                caThis.Phong = item["PHONGTHI"].ToString();
                caThis.NgayThi = DateTime.Parse(item["NGAYTHI"].ToString());
                caThis.GioLamBai = item["GIOLAMBAI"].ToString();

                return caThis;
            }
            return caThis;
        }
    }
}
