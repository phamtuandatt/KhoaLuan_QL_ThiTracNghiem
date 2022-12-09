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
        QL_HETHONGTHITRACNGHIEMEntities7 dt = new QL_HETHONGTHITRACNGHIEMEntities7();

        public ActionResult KetQua()
        {
            return RedirectToAction("KetQua", "Home");
        }
    }
}