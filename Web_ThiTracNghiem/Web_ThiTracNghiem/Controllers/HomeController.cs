using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_ThiTracNghiem.Models;

namespace Web_ThiTracNghiem.Controllers
{
    public class HomeController : Controller
    {
        QL_HETHONGTHITRACNGHIEMEntities11 dt = new QL_HETHONGTHITRACNGHIEMEntities11();
        static string[] dsCauTL = new string[] { };
        static List<CAUHOI> dsCH = new List<CAUHOI>();
        static CATHI cathi = new CATHI();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public  ActionResult ThongTinCaThiPartial()
        {
            // Kiểm tra đã đăng nhập chưa -> Chưa thì k hiển thị tên môn học và thời gian làm bài
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var model = await dt.SINHVIENs.FirstOrDefaultAsync(sv => sv.MASV == username && sv.MAKHAU == password);
            if (model != null)
            {
                Session["MASV"] = model.MASV;
                Session["TENSV"] = model.TENSV;

                return RedirectToAction("InfoSVLichThi", "Home");
            }
            Session["LOGIN"] = "TÀI KHOẢN HOẶC MẬT KHẨU SAI";
            return RedirectToAction("Login", "Home");
        }

        public async Task<ActionResult> InfoSVLichThi()
        {
            // Lấy MASV
            string MASV = Session["MASV"].ToString();
            int MACATHI = 0;

            // Khi update TINHTRANG -> UPDATE ngày thì là ngày hiện tại
            // Lấy danh sách ca thi được kích hoạt trong ngày hôm đó
            DateTime ngay = DateTime.UtcNow.Date;
            var cts = dt.CATHIs.Where(ct => ct.TINHTRANG == true && ct.TINHTRANGTHI == false && ct.NGAYTHI == ngay).ToList();

            // Lấy CT_CATHI của CATHI
            foreach (var item in cts)
            {
                var ctct = dt.CT_CATHI.Where(c => c.MACATHI == item.MACATHI).ToList();
                foreach (var s in ctct)
                {
                    if (s.MASV.Trim().Equals(MASV.Trim()))
                    {
                        MACATHI = s.MACATHI;
                        break;
                    } 
                }
                break;
            }

            var sv = await dt.SINHVIENs.FirstOrDefaultAsync(s => s.MASV == MASV);
            var lop = await dt.LOPHOCs.FirstOrDefaultAsync(l => l.MALOP == sv.MALOP);
            ViewBag.TenLop = lop.TENLOP;
            ViewData["SINHVIEN"] = new SINHVIEN
            {
                MASV = sv.MASV,
                TENSV = sv.TENSV,
                NGAYSINH = sv.NGAYSINH,
                DIACHI = sv.DIACHI,
                EMAIL = sv.EMAIL,
                GIOITINH = sv.GIOITINH,
            };

            // Lấy mã ca thi
            CATHI caThi = await dt.CATHIs.FirstOrDefaultAsync(ca => ca.MACATHI == MACATHI && ca.TINHTRANG == true);
            
            if (caThi != null)
            {
                // Lấy ct ca thi của cathi
                var ctCaThi = await dt.CT_CATHI.FirstOrDefaultAsync(ctct => ctct.MASV == MASV && ctct.MACATHI == caThi.MACATHI);

                // Lấy học phần
                var hp = await dt.HOCPHANs.FirstOrDefaultAsync(h => h.MAHOCPHAN == caThi.MAHOCPHAN);

                List<CaThiModel> modelCaThi = new List<CaThiModel>();
                // Tạo model cathi
                CaThiModel modelCT = new CaThiModel();
                modelCT.MACATHI = caThi.MACATHI;
                modelCT.MAHOCPHAN = caThi.MAHOCPHAN;
                modelCT.TENHOCPHAN = hp.TENHOCPHAN;
                modelCT.MADECON = caThi.MADECON;
                modelCT.NGAYTHI = caThi.NGAYTHI;
                modelCT.PHONGTHI = caThi.PHONGTHI;
                modelCT.GIOLAMBAI = caThi.GIOLAMBAI;
                modelCaThi.Add(modelCT);

                Session["TENMONHOC"] = hp.TENHOCPHAN;
                if (modelCaThi != null) 
                {
                    ViewBag.SLCATHI = "1";
                }
                
                return View(modelCaThi);
            }
            List<CaThiModel> modelCaThis = new List<CaThiModel>();
            return View(modelCaThis);
        }

        // Thi
        [HttpGet]
        public ActionResult Thi(int MACATHI)
        {
            // Lấy MADETHI, MADECON từ CATHI
            var cathi = dt.CATHIs.Find(MACATHI);
            HomeController.cathi = cathi;

            var MADETHI = cathi.MADETHI;
            var MADECON = cathi.MADECON;

            Session["MADETHI"] = MADETHI;
            Session["MADECON"] = MADECON;
            Session["MACATHI"] = cathi.MACATHI;

            // Lấy CT_DETHI
            var ctdt = dt.CT_DETHI.Where(ct => ct.MADETHI == MADETHI && ct.MADECON == MADECON).ToList();

            // Lấy thông tin câu hỏi từ CT_DETHI
            var dsCauHoi = new List<CAUHOI>();
            foreach (var item in ctdt)
            {
                var ch = dt.CAUHOIs.Find(item.MACAUHOI);

                dsCauHoi.Add(ch);
            }

            dsCH = dsCauHoi;

            // Lấy thời gian làm bài
            var dethi = dt.DETHIs.Find(MADETHI);
            ViewBag.TgLamBai = dethi.TGLAMBAI;

            Session["TGLAMBAI"] = dethi.TGLAMBAI + " Phút";
            ViewBag.SLCAUHOI = dsCauHoi.Count;

            return View(dsCauHoi);
        }

        public ActionResult Result()
        {
            KetQuaModel kq = new KetQuaModel();
            kq.TenMH = Session["TENMONHOC"].ToString();
            kq.SoCauDung = int.Parse(Session["SOCAUDUNG"].ToString());
            kq.SoCauSai = int.Parse(Session["SOCAUSAI"].ToString());
            kq.TongDiem = int.Parse(Session["TONGDIEM"].ToString());

            return View(kq);
        }

        public ActionResult KetQua()
        {
            string hnop = DateTime.UtcNow.Date.ToString();
            // Thêm vào BAITHI & CT_BAITHI
            var baithi = new BAITHI();
            baithi.GIONOPBAI = hnop;
            baithi.DIEM = int.Parse(Session["TONGDIEM"].ToString().Trim());
            baithi.MASV = Session["MASV"].ToString().Trim();
            baithi.MACATHI = int.Parse(Session["MACATHI"].ToString().Trim());

            // Insert BaiThi
            var modelBaiThi = dt.BAITHIs.Add(baithi);
            try
            {   
                dt.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.Write(ex);
            }

            // Insert CT_BaiThi
            var ctBaiThis = new List<CT_BAITHI>();
            for (int i = 0; i < dsCH.Count; i++)
            {
                var ctBaiThi = new CT_BAITHI();
                ctBaiThi.MABAITHI = modelBaiThi.MABAITHI;
                ctBaiThi.MACAUHOI = dsCH[i].MACAUHOI;
                ctBaiThi.CAUTRALOI = dsCauTL[i];

                ctBaiThis.Add(ctBaiThi);
            }
            
            var modelCTBaiThi = dt.CT_BAITHI.AddRange(ctBaiThis);
            try
            {
                dt.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.Write(ex);
            }

            // Cập nhật TINHTRANGTHI của ca thi = 1 -> Đã thi -> Khi hiển thị DS ca thi thì k lấy những ca thi nào có TINHTRANGTHI = 1
            var cathi = HomeController.cathi;
            cathi.TINHTRANGTHI = true;
            dt.CATHIs.AddOrUpdate(cathi);
            dt.SaveChanges();

            KetQuaModel kq = new KetQuaModel();
            kq.TenMH = Session["TENMONHOC"].ToString();
            kq.SoCauDung = int.Parse(Session["SOCAUDUNG"].ToString());
            kq.SoCauSai = int.Parse(Session["SOCAUSAI"].ToString());
            kq.TongDiem = int.Parse(Session["TONGDIEM"].ToString());
            
            return View(kq);
        }

        [HttpPost]
        public ActionResult ChamDiem(string[] cautraloi)
        {
            dsCauTL = cautraloi;

            // Lấy danh sách câu hỏi của đề thi
            int MADETHI = int.Parse(Session["MADETHI"].ToString());
            string MADECON = Session["MADECON"].ToString();

            var ctdt = dt.CT_DETHI.Where(ct => ct.MADETHI == MADETHI && ct.MADECON == MADECON).ToList();

            var dsCauHoi = new List<CAUHOI>();
            foreach (var item in ctdt)
            {
                var ch = dt.CAUHOIs.Find(item.MACAUHOI);

                dsCauHoi.Add(ch);
            }

            // So sánh câu trả lời của sinh viên với câu trả lời đúng
            var soCauDung = 0;
            var soCauSai = 0;
            for (int i = 0; i < dsCauHoi.Count; i++)
            {
                if (dsCauHoi[i].DAPANDUNG.Trim().ToUpper().Equals(cautraloi[i].Trim().ToUpper()))
                {
                    soCauDung++;
                }
                else
                {
                    soCauSai++;
                }
            }

            double diem = 10 / dsCauHoi.Count;
            var tongDiem = soCauDung * diem;

            Session["SOCAUDUNG"] = soCauDung;
            Session["SOCAUSAI"] = soCauSai;
            Session["TONGDIEM"] = tongDiem;

            Session.Remove("TGLAMBAI");

            // Cập nhật TINHTRANGTHI của CATHI = 1;

            return RedirectToAction("KetQua", "Home");
        }
    }
}
