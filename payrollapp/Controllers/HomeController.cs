using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using payrollapp.Models;
using payrollapp.BusinessLogic;
using System.Dynamic;

namespace payrollapp.Controllers
{
    public class HomeController : Controller
    {
        private Employee _employee = new Employee();

        public IActionResult Index()
        {
            ViewBag.EmployeeList = null;

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            ViewBag.EmployeeList = _employee.AddEmployee(employee);
            //ViewBag.EmployeeList.Add(employee);
            //.EmployeeList.Add(employee);
            return View("Home");
        }
    }
}
