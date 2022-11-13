using App_QL_ThiTracNghiem.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using App_QL_ThiTracNghiem.DTO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CauHoi_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static bool Insert_Questions(List<CauHois> lst_Question, int MANGANHANG, string MAHOCPHAN)
        {
            bool check = false;
            foreach (var item in lst_Question)
            {
                string sql = string.Format("SET DATEFORMAT DMY INSERT INTO CAUHOI(NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, NGAYTAO, NGAYCAPNHAT, MANGANHANG, MAHOCPHAN)" +
                    "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}', {8}, '{9}')", 
                    item.NoiDung, item.DapAn1, item.DapAn2, item.DapAn3, item.DapAn4, item.DapAnDung, DateTime.UtcNow, DateTime.UtcNow, MANGANHANG, MAHOCPHAN);
                if (data.insert_update_delete(sql) > -1) { check = true; }
            }
            return check;
        }

        public static bool Insert_Single_Question(CauHois cauHois)
        {
            string sql = string.Format("SET DATEFORMAT DMY INSERT INTO CAUHOI(NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, NGAYTAO, NGAYCAPNHAT, MANGANHANG, MAHOCPHAN)" +
                     "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}', {8}, '{9}')",
                     cauHois.NoiDung, cauHois.DapAn1, cauHois.DapAn2, cauHois.DapAn3, cauHois.DapAn4, cauHois.DapAnDung, cauHois.NgayTao, cauHois.NgayCapNhat, cauHois.MaNganHang, cauHois.MaHocPhan);
            return data.insert_update_delete(sql) > 0;
        }

        static DataTable dt_CauHoi = data.get_data("SELECT *FROM CAUHOI", "TABLE_CAUHOI");
        public static void Edit_CauHoi(List<CauHois> lst_CauHoi)
        {
            foreach (DataRow item in dt_CauHoi.Rows)
            {
                foreach (var c in lst_CauHoi)
                {
                    if (item[0].ToString().Trim() == c.MaCauHoi.ToString().Trim())
                    {
                        item[1] = c.NoiDung;
                        item[2] = c.DapAn1;
                        item[3] = c.DapAn2;
                        item[4] = c.DapAn3;
                        item[5] = c.DapAn4;
                        item[6] = c.DapAnDung;

                        break;
                    }
                }
            }
        }

        public static bool Update_DB_CauHoi()
        {
            try
            {
                data.update_database("SELECT *FROM CAUHOI", dt_CauHoi);
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
