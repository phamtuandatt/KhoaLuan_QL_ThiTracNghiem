using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_ThiTracNghiem.Models;

namespace Web_ThiTracNghiem.Controllers
{
    public class ThiController : Controller
    {
        QL_HETHONGTHITRACNGHIEMEntities7 data = new QL_HETHONGTHITRACNGHIEMEntities7();
        // GET: Thi
        [HttpGet]
        public ActionResult Thi(int MACATHI)
        {
            // Lấy MADETHI, MADECON từ CATHI
            var cathi = data.CATHIs.Find(MACATHI);
            var MADETHI = cathi.MADETHI;
            var MADECON = cathi.MADECON;

            // Lấy CT_DETHI
            var ctdt = data.CT_DETHI.Where(ct => ct.MADETHI == MADETHI && ct.MADECON == MADECON).ToList();

            // Lấy thông tin câu hỏi từ CT_DETHI
            List<CAUHOI> dsCauHoi = new List<CAUHOI>();
            foreach (var item in ctdt)
            {
                var ch = data.CAUHOIs.Find(item.MACAUHOI);
                
                dsCauHoi.Add(ch);
            }

            return View(dsCauHoi);
        }
    }
}