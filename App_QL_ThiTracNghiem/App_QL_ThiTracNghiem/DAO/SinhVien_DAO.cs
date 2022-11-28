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
    public class SinhVien_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static DataTable GetSinhViens(string MAHOCPHAN)
        {
            DataTable dT = new DataTable();
            string sql = string.Format("EXEC GET_DS_SV_LOPHOCPHAN '{0}'", MAHOCPHAN);
            dT = data.get_data(sql, "GETSINHVIEN");

            return dT;
        }

        public static DataTable GetDSSV()
        {
            DataTable dT = new DataTable();
            string sql = "SELECT MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, MALOP, HOCPHI FROM SINHVIEN";
            dT = data.get_data(sql, "DSSV");

            return dT;
        }

        public static bool UpdateSV(SinhViens sv)
        {
            string sql = $"SET DATEFORMAT DMY UPDATE SINHVIEN SET TENSV = N'{sv.TenSV}', GIOITINH = N'{sv.GioiTinh}', NGAYSINH = '{sv.NgaySinh}', EMAIL = '{sv.Email}', SDT = '{sv.Sdt}', " +
                          $"DIACHI = N'{sv.DiaChi}', QUEQUAN = N'{sv.QueQuan}', MALOP = '{sv.MaLop}', HOCPHI = N'{sv.HocPhi}' WHERE MASV = '{sv.MaSV}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool InsertSV(SinhViens sv, string MAKHOA, int NAMVAOHOC)
        {
            string sql = $"SET DATEFORMAT DMY INSERT INTO SINHVIEN VALUES ((SELECT DBO.AUTO_STT_MASV('20', '{MAKHOA}', '{NAMVAOHOC}')), '{sv.MatKhau}', " +
                                  $"N'{sv.TenSV}', N'{sv.GioiTinh}', '{sv.NgaySinh}', '{sv.Email}', '{sv.Sdt}', N'{sv.DiaChi}', N'{sv.QueQuan}', '{sv.MaLop}', N'{sv.HocPhi}')";

            return data.insert_update_delete(sql) > 0;
        }

        public static bool DeleteSV(string MASV)
        {
            string sql = $"DELETE FROM SINHVIEN WHERE MASV = '{MASV}'";

            return data.insert_update_delete(sql) > 0;
        }
    }
}
