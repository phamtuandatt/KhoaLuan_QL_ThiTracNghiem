﻿using System;
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
        QL_HETHONGTHITRACNGHIEMEntities6 data = new QL_HETHONGTHITRACNGHIEMEntities6();

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
            //@model IEnumerable < Web_ThiTracNghiem.Models.SINHVIEN >

            string MASV = Session["MASV"].ToString();
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
            var mact = "";
            var caThi = await data.CATHIs.FirstOrDefaultAsync(ca => ca.MACATHI == 6 && ca.TINHTRANG == false);
            
            if (caThi != null)
            {
                // Lấy ct ca thi của cathi
                var ctCaThi = await data.CT_CATHI.FirstOrDefaultAsync(ctct => ctct.MASV == MASV && ctct.MACATHI == caThi.MACATHI);

                // Lấy học phần
                var hp = await data.HOCPHANs.FirstOrDefaultAsync(h => h.MAHOCPHAN == caThi.MAHOCPHAN);

                List<CaThiModel> modelCaThi = new List<CaThiModel>();
                // Tạo model cathi
                CaThiModel modelCT = new CaThiModel();
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

        [HttpGet]
        public ActionResult Thi()
        {
            return View();
        }
    }
}