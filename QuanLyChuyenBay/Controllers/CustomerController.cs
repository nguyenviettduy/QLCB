using QuanLyChuyenBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuyenBay.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            InfoCustomer infoCus = new InfoCustomer();
            List<Customer> listCus = infoCus.GetCustomer(string.Empty).OrderBy(s => s.Ten).ToList();
            return View(listCus);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                InfoCustomer infoCus = new InfoCustomer();
                infoCus.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(string maKH)
        {
            InfoCustomer infoCus = new InfoCustomer();
            List<Customer> listCus = infoCus.GetCustomer(maKH);
            return View(listCus.FirstOrDefault());
        }

        public ActionResult Delete(string maKH)
        {
            InfoCustomer infoCus = new InfoCustomer();
            List<Customer> listCus = infoCus.GetCustomer(maKH);
            return View(listCus.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            InfoCustomer infoCus = new InfoCustomer();
            infoCus.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string maKH)
        {
            InfoCustomer infoCus = new InfoCustomer();
            List<Customer> listCus = infoCus.GetCustomer(maKH);
            return View(listCus.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                InfoCustomer infoCus = new InfoCustomer();
                infoCus.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}