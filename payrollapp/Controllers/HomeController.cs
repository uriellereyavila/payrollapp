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
        private static Employee _employee = new Employee();
        //static List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

        /// <summary>
        /// return index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.EmployeeList = _employee.GetEmployee();
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
            ViewBag.EmployeeList = _employee.AddEmployee(employee);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public object GetEmployeeInfo(string employeeType, double numOfDays)
        {
            //initialize employee bus. logic
            Employee employee = new Employee();

            employee.GetEmployeeInfo(employeeType, numOfDays);

            return employee;
        }
    }
}
