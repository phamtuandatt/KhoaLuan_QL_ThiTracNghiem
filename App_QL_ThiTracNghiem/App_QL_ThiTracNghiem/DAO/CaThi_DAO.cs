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
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO CATHI(MAHOCPHAN, MADETHI, NGAYTHI, GIOLAMBAI, TINHTRANG)\n" +
                                        "VALUES ('{0}', '{1}', N'{2}', N'{3}', {4})", caThis.MaHocPhan, caThis.MaDeThi, caThis.NgayThi,
                                        caThis.GioLamBai, caThis.TinhTrang);
            return data.insert_update_delete(sql) > 0;
        }
    }
}
