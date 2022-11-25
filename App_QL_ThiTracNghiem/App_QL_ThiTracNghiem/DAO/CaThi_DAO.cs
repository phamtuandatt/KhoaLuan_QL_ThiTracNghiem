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

        public static bool Insert_CaThi(CaThis caThis)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO CATHI(MAHOCPHAN, MADETHI, MADECON, NGAYTHI, GIOLAMBAI, TINHTRANG)\n" +
                                        "VALUES ('{0}', '{1}', '{2}', N'{3}', N'{4}', {5})", caThis.MaHocPhan, caThis.MaDeThi, "CHƯA CÓ", caThis.NgayThi,
                                        caThis.GioLamBai, caThis.TinhTrang);
            return data.insert_update_delete(sql) > 0;
        }

        public static bool UpdateCaThi(CaThis ct)
        {
            string sql = string.Format("UPDATE CATHI SET MADETHI = {0}, NGAYTHI = '{1}', GIOLAMBAI = '{2}', TINHTRANG = {3}, MADECON = '{4}' WHERE MACATHI = {5}",
                ct.MaDeThi, ct.NgayThi, ct.GioLamBai, ct.TinhTrang, ct.MaDeCon, ct.MaCaThi);

            return data.insert_update_delete(sql) > 0;
        }

        public static bool Update_DeThi_CaThi(string MADECON, int MACATHI)
        {
            string sql = string.Format("UPDATE CATHI SET MADECON = '{0}' WHERE MACATHI = {1}", MADECON, MACATHI);

            return data.insert_update_delete(sql) > 0;
        }
    }
}
