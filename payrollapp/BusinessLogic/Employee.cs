using payrollapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payrollapp.BusinessLogic
{
    public class Employee
    {
        private List<EmployeeModel> _employeeList = new List<EmployeeModel>();
        public List<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            _employeeList.Add(employee);

            return _employeeList;
        }

        //public double GetMonthlySaray(string employeeType)
        //{

        //}


    }
}
