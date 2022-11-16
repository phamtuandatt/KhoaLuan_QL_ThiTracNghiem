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

        public static bool Insert_DeThi(DeThis deThis)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO DETHI VALUES ({0}, '{1}', '{2}', {3}, {4}, {5})",
                deThis.MaDeThi, deThis.MaHocPhan, deThis.NgayTao, deThis.TGLamBai, deThis.SLCauHoi, deThis.TinhTrang);

            return data.insert_update_delete(sql) > 0;
        }
    }
}
