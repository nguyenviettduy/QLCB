using QuanLyChuyenBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuyenBay.Controllers
{
    public class AirlineTypeController : Controller
    {
        // GET: AirlineType
        public ActionResult ShowInfo()
        {
            ManagerAirlineType managerAT = new ManagerAirlineType();
            List<AirlineType> listAT = managerAT.GetAirlineType(string.Empty).OrderBy(s => s.MaLoaiMB).ToList();
            return View(listAT);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AirlineType airlineType)
        {
            if (ModelState.IsValid)
            {
                ManagerAirlineType managerAT = new ManagerAirlineType();
                managerAT.AddAirlineType(airlineType);
                return RedirectToAction("ShowInfo");
            }
            return View("ShowInfo");
        }

        public ActionResult Delete(string maLoaiMB)
        {
            ManagerAirlineType managerAT = new ManagerAirlineType();
            List<AirlineType> listAT = managerAT.GetAirlineType(maLoaiMB);
            return View(listAT.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(AirlineType airlineType)
        {
            ManagerAirlineType managerAT = new ManagerAirlineType();
            managerAT.DeleteAirlineType(airlineType);
            return RedirectToAction("ShowInfo");
        }

        public ActionResult Details(string maLoaiMB)
        {
            ManagerAirlineType managerAT = new ManagerAirlineType();
            List<AirlineType> listAT = managerAT.GetAirlineType(maLoaiMB);
            return View(listAT.FirstOrDefault());
        }

        //public ActionResult Edit(string maLoaiMB)
        //{
        //    ManagerAirlineType managerAT = new ManagerAirlineType();
        //    List<AirlineType> listAT = managerAT.GetAirlineType(maLoaiMB);
        //    return View(listAT.FirstOrDefault());
        //}
        //[HttpPost]
        //public ActionResult Edit(AirlineType airlineType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ManagerAirlineType managerAT = new ManagerAirlineType();
        //        managerAT.UpdateAirlineType(airlineType);
        //        return RedirectToAction("ShowInfo");
        //    }
        //    return View();
        //}
    }
}