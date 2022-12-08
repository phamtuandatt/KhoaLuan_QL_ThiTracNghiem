using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_ThiTracNghiem.Models;

namespace Web_ThiTracNghiem.Controllers
{
    public class HomeController : Controller
    {
        QL_HETHONGTHITRACNGHIEMEntities7 data = new QL_HETHONGTHITRACNGHIEMEntities7();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var model = await data.SINHVIENs.FirstOrDefaultAsync(sv => sv.MASV == username && sv.MAKHAU == password);
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
            var cts = data.CATHIs.Where(ct => ct.TINHTRANG == true && ct.NGAYTHI == ngay).ToList();

            // Lấy CT_CATHI của CATHI
            foreach (var item in cts)
            {
                var ctct = data.CT_CATHI.Where(c => c.MACATHI == item.MACATHI).ToList();
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

            var sv = await data.SINHVIENs.FirstOrDefaultAsync(s => s.MASV == MASV);
            var lop = await data.LOPHOCs.FirstOrDefaultAsync(l => l.MALOP == sv.MALOP);
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
            CATHI caThi = await data.CATHIs.FirstOrDefaultAsync(ca => ca.MACATHI == MACATHI && ca.TINHTRANG == true);
            
            if (caThi != null)
            {
                // Lấy ct ca thi của cathi
                var ctCaThi = await data.CT_CATHI.FirstOrDefaultAsync(ctct => ctct.MASV == MASV && ctct.MACATHI == caThi.MACATHI);

                // Lấy học phần
                var hp = await data.HOCPHANs.FirstOrDefaultAsync(h => h.MAHOCPHAN == caThi.MAHOCPHAN);

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

                return View(modelCaThi);
            }
            List<CaThiModel> modelCaThis = new List<CaThiModel>();
            return View(modelCaThis);
        }
    }
}
