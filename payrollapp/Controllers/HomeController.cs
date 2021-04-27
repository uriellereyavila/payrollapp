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
        /// <summary>
        /// instantiate static business logic employee class
        /// </summary>
        //private static Employee _employee = new Employee();
        static List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

        /// <summary>
        /// return index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.EmployeeList = null;
            ViewBag.EmployeeId = 0;
            return View();
        }

        /// <summary>
        /// returns View
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            EmployeeList.Add(employee);
            ViewBag.EmployeeList = EmployeeList;
            //ViewBag.EmployeeList = _employee.AddEmployee(employee);
            //ViewData["EmployeeList"] = _employee.AddEmployee(employee);
            return View("~/home/index");
        }
    }
}
