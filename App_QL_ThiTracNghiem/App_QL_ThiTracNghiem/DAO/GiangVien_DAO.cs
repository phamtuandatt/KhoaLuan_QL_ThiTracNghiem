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
    public class GiangVien_DAO
    {
        static SqlProvider data = new SqlProvider();

        public static bool Login(string MAGV, string MATKHAU)
        {
            string sql = string.Format("SELECT COUNT(MAGV) FROM GIANGVIEN WHERE MAGV = '{0}' AND MATKHAU = '{1}'", MAGV, MATKHAU);

            return data.get_result_int(sql) > 0;
        }

        public static GiangViens GetGiangVien(string MAGV, string MATKHAU)
        {
            DataTable dt = new DataTable();
            GiangViens gv = new GiangViens();
            string sql = string.Format("SELECT *FROM GIANGVIEN WHERE MAGV = '{0}' AND MATKHAU = '{1}'", MAGV, MATKHAU);
            dt = data.get_data(sql, "GIANGVIEN");
            foreach (DataRow item in dt.Rows)
            {
                gv.MaGV = item["MAGV"].ToString();
                gv.TenGV = item["TENGV"].ToString();
                gv.NgaySinh = DateTime.Parse(item["NGAYSINH"].ToString());
                gv.GioiTinh = item["GIOITINH"].ToString();
                gv.QueQuan = item["QUEQUAN"].ToString();
                gv.HocVi = item["HOCVI"].ToString();
                gv.Sdt = item["SDT"].ToString();
                gv.Email = item["EMAIL"].ToString();
                gv.DiaChi= item["DIACHI"].ToString();
                gv.Avata = item["AVATA"].ToString();
                gv.MaKhoa = item["MAKHOA"].ToString();
                gv.MaChucVu = item["MACHUCVU"].ToString();
            }

            return gv;
        }

        public static int GetNganHangOfGiangVien(string MAGV)
        {
            string sql = string.Format("SELECT DISTINCT(MANGANHANG) FROM CT_NGANHANGCAUHOI WHERE MAGV = '{0}'", MAGV);

            return data.get_result_int(sql);
        }

        public static bool ChangePassword(string MAGV, string MK)
        {
            string sql = string.Format("UPDATE GIANGVIEN SET MATKHAU = '{0}' WHERE MAGV = {1}", MK, MAGV);

            return data.insert_update_delete(sql) > 0;
        }

        public static bool Update_GV(GiangViens gv)
        {
            string sql = $"SET DATEFORMAT DMY UPDATE GIANGVIEN SET TENGV = N'{gv.TenGV}', NGAYSINH = '{gv.NgaySinh}', GIOITINH = N'{gv.GioiTinh}', " +
                            $"QUEQUAN = N'{gv.QueQuan}', HOCVI = N'{gv.HocVi}', SDT = '{gv.Sdt}', EMAIL = N'{gv.Email}', DIACHI = N'{gv.DiaChi}' WHERE MAGV = '{gv.MaGV}'";

            return data.insert_update_delete(sql) > 0;
        }

        public static DataTable GetDSGV(string MAKHOA)
        {
            DataTable dt = new DataTable();
            string sql = $"EXEC GET_DSGV_KHOA '{MAKHOA}'";
            dt = data.get_data(sql, "DSGV");

            return dt;
        }

        public static bool DeleteGV(string MAGV)
        {
            // Xóa CT_GiangDay
            string sqlCTGiangDay = $"DELETE FROM CT_GIANGDAY WHERE MAGV = '{MAGV}'";
            int rsCTGD = data.insert_update_delete(sqlCTGiangDay);

            // Xóa CT_NganHangCauHoi
            string sqlNHCH = $"DELETE FROM CT_NGANHANGCAUHOI WHERE MAGV = '{MAGV}'";
            int rsNH = data.insert_update_delete(sqlNHCH);

            // Xóa CT_HocPhan
            string sqlCTHP = $"DELETE FROM CT_HOCPHAN WHERE MAGV = '{MAGV}'";
            int rsCTHP = data.insert_update_delete(sqlCTHP);

            string sql = $"DELETE FROM GIANGVIEN WHERE MAGV = '{MAGV}'";

            return data.insert_update_delete(sql) > 0;
        }

        // Kiểm tra giảng viên có đang thực hiện giảng dạy hay không
        public static bool CheckGVGiangDay(string MAGV)
        {
            string sql = $"SELECT COUNT(MAGV) FROM CT_GIANGDAY WHERE MAGV = '{MAGV}'";

            return data.get_result_int(sql) > 0;
        }

        // Kiểm tra giảng viên có ngân hàng câu hỏi hay không
        public static bool CheckGVCT_HocPHan(string MAGV)
        {
            string sql = $"SELECT COUNT(MAGV) FROM CT_HOCPHAN WHERE MAGV = '{MAGV}'";

            return data.get_result_int(sql) > 0;
        }

        public static bool Insert(GiangViens gv)
        {
            string sql = $"SET DATEFORMAT DMY INSERT INTO GIANGVIEN VALUES ((SELECT DBO.AUTO_MAGV('010', '{gv.MaKhoa}')), '{gv.MatKhau}', N'{gv.TenGV}', '{gv.NgaySinh}'," +
                            $" N'{gv.GioiTinh}', N'{gv.QueQuan}', N'{gv.HocVi}', '{gv.Sdt}', N'{gv.Email}', N'{gv.DiaChi}', '{gv.MaKhoa}', '{gv.MaChucVu}', ' ')";

            return data.insert_update_delete(sql) > 0;
        }
    }
}
