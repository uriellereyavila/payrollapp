using payrollapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payrollapp.BusinessLogic
{
    public class Employee
    {
        List<EmployeeModel> EmployeeList = new List<EmployeeModel>();


        public List<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            EmployeeList.Add(employee);

            return EmployeeList;
        }

        //public double GetMonthlySaray(string employeeType)
        //{

        //}


    }
}
