using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using payrollapp.Models;
using payrollapp.BusinessLogic;
using System.Dynamic;
using Newtonsoft.Json;

namespace payrollapp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// instantiate static business logic employee class
        /// </summary>
        private static Employee _employee = new Employee();

        /// <summary>
        /// instantial response model 
        /// </summary>
        private ResponseModel _responseModel = new ResponseModel();

        /// <summary>
        /// return index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.EmployeeList = _employee.GetEmployee();
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
        public object GetEmployeeInfo(EmployeeModel employeeModel)
        {
            //initialize employee bus. logic
            Employee employee = new Employee();
            this._responseModel = employee.GetEmployeeInfo(employeeModel);

            return JsonConvert.SerializeObject(this._responseModel, Formatting.None);
        }
    }
}
