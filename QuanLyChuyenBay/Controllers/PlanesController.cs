using QuanLyChuyenBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuyenBay.Controllers
{
    public class PlanesController : Controller
    {
        // GET: Planes
        public ActionResult InfoPlanes()
        {
            ManagerPlanes managerPlanes = new ManagerPlanes();
            List<Planes> listPlanes = managerPlanes.GetPlanes(string.Empty).OrderBy(s => s.MaloaiMB).ToList();
            return View(listPlanes);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Planes planes)
        {
            if (ModelState.IsValid)
            {
                ManagerPlanes managerPlanes = new ManagerPlanes();
                managerPlanes.AddPlanes(planes);
                return RedirectToAction("InfoPlanes");
            }
            return View();
        }

        public ActionResult Delete(string soHieu)
        {
            ManagerPlanes managerPlanes = new ManagerPlanes();
            List<Planes> listPlanes = managerPlanes.GetPlanes(soHieu);
            return View(listPlanes.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Planes planes)
        {
            ManagerPlanes managerPlanes = new ManagerPlanes();
            managerPlanes.DeletePlanes(planes);
            return View("InfoPlanes");
        }

        public ActionResult Details(string soHieu)
        {

            ManagerPlanes managerPlanes = new ManagerPlanes();
            List<Planes> listPlanes = managerPlanes.GetPlanes(soHieu);          
            return View(listPlanes.FirstOrDefault());
        }
    }
}