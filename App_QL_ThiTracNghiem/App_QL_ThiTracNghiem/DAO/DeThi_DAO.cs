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
    public class DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetDS_DeThi(string MAHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI '{0}'", MAHOCPHAN);
            dt = data.get_data(sql, "GetDSDeThi");

            return dt;
        }

        public static List<string> Get_DS_DeThi_For_CaThi(string MAHOCPHAN)
        {
            List<string> lst = new List<string>();
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI '{0}'", MAHOCPHAN);
            dt = data.get_data(sql, "GetDSDeThi");
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(item["MADETHI"].ToString().Trim());
            }

            return lst;
        }

        public static bool UpdateDeThi(DeThis deThis, string MADETHI, string MAHOCPHAN)
        {
            string sql = string.Format("UPDATE DETHI\n " +
                            "SET TGLAMBAI = '{0}', NGAYTAO = N'{1}', SLCAUHOI = {2}, TINHTRANG = {3}\n " +
                            "WHERE MADETHI = '{4}' AND MAHOCPHAN = '{5}'",
                            deThis.TGLamBai, deThis.NgayTao, deThis.SLCauHoi, deThis.TinhTrang, MADETHI, MAHOCPHAN);

            return data.insert_update_delete(sql) > 0;
        }

        public static bool Insert_DeThi(DeThis deThis)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO DETHI VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5})",
                deThis.MaDeThi, deThis.MaHocPhan, deThis.NgayTao, deThis.TGLamBai, deThis.SLCauHoi, deThis.TinhTrang);
            if (data.insert_update_delete(sql) == -1)
            {
                return false;
            }
            return true;
        }
    }
}
