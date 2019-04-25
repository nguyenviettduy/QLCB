using QuanLyChuyenBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuyenBay.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult InformationEmployee()
        {
            InfoEmployee infoEmp = new InfoEmployee();
            List<Employee> listEmp = infoEmp.GetEmployee(string.Empty).OrderBy(s=>s.Ten).ToList();
            return View(listEmp);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                InfoEmployee infoEmp = new InfoEmployee();
                infoEmp.AddEmployee(employee);
                return RedirectToAction("InformationEmployee");
            }
            return View();
        }

        public ActionResult Delete(string maNV)
        {
            InfoEmployee infoEmp = new InfoEmployee();
            List<Employee> listEmp = infoEmp.GetEmployee(maNV);
            return View(listEmp.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            InfoEmployee infoEmp = new InfoEmployee();
            infoEmp.DeleteEmployee(employee);
            return RedirectToAction("InformationEmployee");
        }

        public ActionResult Edit(string maNV)
        {
            InfoEmployee infoEmp = new InfoEmployee();
            List<Employee> listEmp = infoEmp.GetEmployee(maNV);
            return View(listEmp.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                InfoEmployee infoEmp = new InfoEmployee();
                infoEmp.UpdateEmployee(employee);
                return RedirectToAction("InformationEmployee");
            }
            return View();          
        }

        public ActionResult Details(string maNV)
        {
            InfoEmployee infoEmp = new InfoEmployee();
            List<Employee> listEmp = infoEmp.GetEmployee(maNV);
            return View(listEmp.FirstOrDefault());
        }
    }
}