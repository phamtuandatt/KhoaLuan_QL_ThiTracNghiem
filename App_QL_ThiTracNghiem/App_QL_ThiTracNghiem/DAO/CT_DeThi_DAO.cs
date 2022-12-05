using App_QL_ThiTracNghiem.DataProvider;
using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QL_ThiTracNghiem.DAO
{
    public class CT_DeThi_DAO
    {
        static SqlProvider data = new SqlProvider();

        static DataTable table_tam = data.get_data("SELECT *FROM CT_DETHI", "TABLE_TAM");

        public static bool DeleteCT_DeThi(int MADETHI, string MADECON)
        {
            string sql = string.Format("DELETE FROM CT_DETHI WHERE MADETHI = {0} AND MADECON = '{1}'", MADETHI, MADECON);

            return data.insert_update_delete(sql) > 0;
        }

        public static DataTable GetDS_DeThi_CauHoi(int MADETHI, string MADECON)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("EXEC GET_DS_DETHI_CAUHOI '{0}', '{1}'", MADETHI, MADECON);
            dt = data.get_data(sql, "DS_CAUHOI_DETHI");

            return dt;
        }

        public static List<int> GetDS_DeThi_HocPhan(string MAHOCPHAN)
        {
            DataTable dt = data.get_data(string.Format("SELECT DISTINCT(MADETHI) FROM DETHI WHERE MAHOCPHAN = '{0}'", MAHOCPHAN), "TABLE_TAM");
            List<int> lst_MaDe = new List<int>();
            foreach (DataRow item in dt.Rows)
            {
                lst_MaDe.Add(int.Parse(item[0].ToString().Trim()));
            }
            return lst_MaDe;
        }

        public static int GetMaDeThi_MAX()
        {
            string sql = "SELECT MAX(MADETHI) FROM DETHI";
            int rs = data.get_result_int(sql);

            return rs;
        }

        public static DataTable Get_DS_DeCon(int MADETHI)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("SELECT DISTINCT(MADECON) FROM CT_DETHI WHERE MADETHI = {0}", MADETHI);
            dt = data.get_data(sql, "DSMADECON");

            return dt;
        }

        public static CauHois TronDapAnCH2DapAnDung(CauHois ch)
        {
            List<int> vtriMoi = new List<int>();
            string[] dsDapAn = new string[]
            {
                ch.DapAn1, ch.DapAn2, ch.DapAn3, ch.DapAn4
            };
            int vtriDung = 0;
            switch (ch.DapAnDung.Trim())
            {
                case "A": { vtriDung = 0; break; }
                case "B": { vtriDung = 1; break; }
                case "C": { vtriDung = 2; break; }
                case "D": { vtriDung = 3; break; }
            }
            string ndDapAnDung = dsDapAn[vtriDung];

            if (dsDapAn[vtriDung].ToUpper().Contains("A & B Đúng".ToUpper()))
            {
                Swap(ref dsDapAn[vtriDung], ref dsDapAn[2]);
                vtriDung = 2;
            }
            else if (dsDapAn[vtriDung].ToUpper().Contains("A & C Đúng".ToUpper()))
            {
                Swap(ref dsDapAn[vtriDung], ref dsDapAn[1]);
                vtriDung = 1;
            }
            else if (dsDapAn[vtriDung].ToUpper().Contains("B & C Đúng".ToUpper()))
            {
                Swap(ref dsDapAn[vtriDung], ref dsDapAn[0]);
                vtriDung = 2;
            }

            CauHois ch_new = new CauHois();
            ch_new.NoiDung = ch.NoiDung;
            ch_new.DapAn1 = dsDapAn[0];
            ch_new.DapAn2 = dsDapAn[1];
            ch_new.DapAn3 = dsDapAn[2];
            ch_new.DapAn4 = dsDapAn[3];
            switch (vtriDung)
            {
                case 0: { ch_new.DapAnDung = "A"; break; }
                case 1: { ch_new.DapAnDung = "B"; break; }
                case 2: { ch_new.DapAnDung = "C"; break; }
                case 3: { ch_new.DapAnDung = "D"; break; }
            }
            ch_new.MaNganHang = ch.MaNganHang;
            return ch_new;
        }

        public static CauHois TronDapAnCauHoiBth(CauHois ch)
        {
            List<int> lst_rd = new List<int> { 1, 2, 3, 4 };
            List<int> vtriMoi = new List<int>();
            Random rd = new Random();
            string[] dsDapAn = new string[]
            {
                ch.DapAn1, ch.DapAn2, ch.DapAn3, ch.DapAn4
            };
            int vtriDung = 0;
            switch (ch.DapAnDung.Trim())
            {
                case "A": { vtriDung = 0; break; }
                case "B": { vtriDung = 1; break; }
                case "C": { vtriDung = 2; break; }
                case "D": { vtriDung = 3; break; }
            }

            string ndDapAnDung = dsDapAn[vtriDung];

            int temp = 0;
            int num = 4;
            List<int> list = new List<int>();
            for (int i = 0; i < num; i++)
            {
                list.Add(i);
            }
            //random
            for (int i = 0; i < num; i++)
            {
                temp = rd.Next(list.Count);
                vtriMoi.Add(list[temp]);
                list.RemoveAt(temp);
            }

            Swap(ref dsDapAn[0], ref dsDapAn[vtriMoi[0]]);
            Swap(ref dsDapAn[1], ref dsDapAn[vtriMoi[1]]);
            Swap(ref dsDapAn[2], ref dsDapAn[vtriMoi[2]]);
            Swap(ref dsDapAn[3], ref dsDapAn[vtriMoi[3]]);

            for (int i = 0; i < 4; i++)
            {
                if (dsDapAn[i].ToUpper().Equals(ndDapAnDung.ToUpper()))
                {
                    vtriDung = i;
                    break;
                }
            }
            CauHois ch_new = new CauHois();
            ch_new.NoiDung = ch.NoiDung;
            ch_new.DapAn1 = dsDapAn[0];
            ch_new.DapAn2 = dsDapAn[1];
            ch_new.DapAn3 = dsDapAn[2];
            ch_new.DapAn4 = dsDapAn[3];
            switch (vtriDung)
            {
                case 0: { ch_new.DapAnDung = "A"; break; }
                case 1: { ch_new.DapAnDung = "B"; break; }
                case 2: { ch_new.DapAnDung = "C"; break; }
                case 3: { ch_new.DapAnDung = "D"; break; }
            }
            ch_new.MaNganHang = ch.MaNganHang;
            return ch_new;
        }

        public static void Swap(ref string a, ref string b)
        {
            string tam = a;
            a = b;
            b = tam;
        }

        public static void InsertCTDeThi(List<CauHois> lstCauHoi, List<string> soluongde, int MADETHI, string MAHOCPHAN)
        {
            foreach (var item in soluongde)
            {
                // Tạo chi tiết đề thi từ danh sách câu hỏi đã được tạo 
                List<CauHois> dsCauHoi = TronCauDACauHoi(lstCauHoi, MAHOCPHAN);
                for (int i = 0; i < dsCauHoi.Count; i++)
                {
                    DataRow add_r = table_tam.NewRow();
                    add_r[1] = MADETHI;
                    add_r[2] = item;
                    add_r[3] = dsCauHoi[i].MaCauHoi;

                    table_tam.Rows.Add(add_r);
                }
            }
        }

        public static void Insert_CT_DeThi(List<CT_DeThis> lst_DeThi, List<string> soluongde)
        {
            if (soluongde == null)
            {
                foreach (var ct in lst_DeThi)
                {
                    DataRow add_r = table_tam.NewRow();
                    add_r[1] = ct.MaDeThi;
                    add_r[2] = ct.MaDeCon;
                    add_r[3] = ct.MaCauHoi;

                    table_tam.Rows.Add(add_r);
                }
            }
            else
            {
                foreach (var item in soluongde)
                {
                    List<CT_DeThis> list = TronCauHoi(lst_DeThi);
                    foreach (var ct in list)
                    {
                        DataRow add_r = table_tam.NewRow();
                        add_r[1] = ct.MaDeThi;
                        add_r[2] = item;
                        add_r[3] = ct.MaCauHoi;

                        table_tam.Rows.Add(add_r);
                    }
                }
            }
        }

        private static List<CauHois> TronCauDACauHoi(List<CauHois> lstCauHois, string MAHOCPHAN)
        {
            // Tạo danh sách câu hỏi mới với các đáp án đã được trộn từ DS câu hỏi được chọn
            List<CauHois> lstCauHoi = new List<CauHois>();
            for (int i = 0; i < lstCauHois.Count; i++)
            {
                CauHois ch = new CauHois();
                ch.NoiDung = lstCauHois[i].NoiDung;
                ch.DapAn1 = lstCauHois[i].DapAn1;
                ch.DapAn2 = lstCauHois[i].DapAn2;
                ch.DapAn3 = lstCauHois[i].DapAn3;
                ch.DapAn4 = lstCauHois[i].DapAn4;
                ch.DapAnDung = lstCauHois[i].DapAnDung;
                ch.MaNganHang = lstCauHois[i].MaNganHang;

                // Kiểm tra câu hỏi có phải loại có 2 đáp án đúng hay không
                CauHois chNew = new CauHois();
                if (ch.DapAn4.ToUpper().Contains("A & B") || ch.DapAn4.ToUpper().Contains("A & C") || ch.DapAn4.ToUpper().Contains("B & C"))
                {
                    chNew = CT_DeThi_DAO.TronDapAnCH2DapAnDung(ch);
                }
                else
                {
                    chNew = CT_DeThi_DAO.TronDapAnCauHoiBth(ch);
                }
                lstCauHoi.Add(chNew);
            }
            // Insert Danh sách câu hỏi vào CSDL
            List<CauHois> lstCauHoiIns = CauHoi_DAO.InsertQuestions(lstCauHoi, MAHOCPHAN.Trim());

            // Trộn thứ tự câu hỏi
            List<CauHois> dsCauHoiMoi = TronCH(lstCauHoiIns);

            return dsCauHoiMoi;
        }

        public static List<CauHois> TronCH(List<CauHois> lstCauHoiIns)
        {
            // random vị trí
            Random r = new Random();

            for (int i = 0; i < lstCauHoiIns.Count / 2; i++)
            {
                int vt = r.Next(1, lstCauHoiIns.Count); // Tạo vị trí ngẫu nhiên
                var ct = lstCauHoiIns[i];
                lstCauHoiIns[i] = lstCauHoiIns[vt];
                lstCauHoiIns[vt] = ct;
            }

            List<CauHois> new_lst = lstCauHoiIns;

            return new_lst;
        }

        public static List<CT_DeThis> TronCauHoi(List<CT_DeThis> lstCTDeThi)
        {
            // random vị trí
            Random r = new Random();

            for (int i = 0; i < lstCTDeThi.Count / 2; i++)
            {
                int vt = r.Next(1, lstCTDeThi.Count); // Tạo vị trí ngẫu nhiên
                var ct = lstCTDeThi[i];
                lstCTDeThi[i] = lstCTDeThi[vt];
                lstCTDeThi[vt] = ct;
            }

            List<CT_DeThis> new_lst = lstCTDeThi;

            return new_lst;
        }

        public static bool UpdateDatabase(List<CauHois> lstCauHoi, List<string> soluongde, int MADETHI, string MAHOCPHAN)
        {
            InsertCTDeThi(lstCauHoi, soluongde, MADETHI, MAHOCPHAN);
            try
            {
                data.update_database("SELECT *FROM CT_DETHI", table_tam);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return false;
                }
                return false;
                throw;
            }
        }

        public static bool Update_Database(List<CT_DeThis> lst_DeThi, List<string> soluongde)
        {
            Insert_CT_DeThi(lst_DeThi, soluongde);
            try
            {
                data.update_database("SELECT *FROM CT_DETHI", table_tam);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return false;
                }
                return false;
                throw;
            }
        }
    }
}
