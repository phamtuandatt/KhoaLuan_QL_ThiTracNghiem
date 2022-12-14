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

        static DataTable dt_tam = data.get_data("SELECT *FROM SINHVIEN", "DSTAM");

        public static DataTable GetSinhViens(string MAHOCPHAN)
        {
            // Lấy danh sách sinh viên chưa tham gia thi học phần
            DataTable dT = new DataTable();
            string sql = string.Format("EXEC GET_DS_SV_LOPHOCPHAN '{0}'", MAHOCPHAN);
            dT = data.get_data(sql, "GETSINHVIEN");

            return dT;
        }

        public static DataTable GetDSKhoaLopHP(string MAKHOA, int THU, string TIET)
        {
            DataTable dT = new DataTable();
            string sql = $"EXEC GETDSSVKHOALOPHP '{MAKHOA}', {THU}, '{TIET}'";
            dT = data.get_data(sql, "GETDSSVKHOALOPHP");

            return dT;
        }

        public static DataTable GetDSSV(string MALOP)
        {
            DataTable dT = new DataTable();
            string sql = $"SELECT MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, HOCPHI, MALOP FROM SINHVIEN WHERE MALOP = '{MALOP}'";
            dT = data.get_data(sql, "DSSV");

            return dT;
        }

        public static DataTable GetDSSV_Chua_ThamGia_HocPhan_Khoa(string MAKHOA, string MALOPHOCPHAN)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DSSV_CHUA_THAMGIA_HOCPHAN '{MAKHOA}', '{MALOPHOCPHAN}'";
            dt = data.get_data(sql, "DSDVCHUATHAMGIA");

            return dt;
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

        public static void InsertSinhViens(List<SinhViens> lstSv)
        {
            foreach (var item in lstSv)
            {
                DataRow add_r = dt_tam.NewRow();
                add_r[0] = item.MaSV;
                add_r[1] = item.MatKhau;
                add_r[2] = item.TenSV;
                add_r[3] = item.GioiTinh;
                add_r[4] = item.NgaySinh;
                add_r[5] = item.Email;
                add_r[6] = item.Sdt;
                add_r[7] = item.DiaChi;
                add_r[8] = item.QueQuan;
                add_r[9] = item.MaLop;
                add_r[10] = item.HocPhi;

                dt_tam.Rows.Add(add_r);
            }
        }

        public static bool UpdateDBSinhVien(List<SinhViens> lstSv)
        {
            try
            {
                InsertSinhViens(lstSv);
                data.update_database("SELECT *FROM SINHVIEN", dt_tam);
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
