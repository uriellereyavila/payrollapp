using Newtonsoft.Json;
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
        private double _monthlySalary = 20000;
        private double _dailySalary = 500;

        public List<EmployeeModel> GetEmployee()
        {
            return _employeeList;
        }

        /// <summary>
        /// Adds employee to the list
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public List<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            _employeeList.Add(employee);

            return _employeeList;
        }

        /// <summary>
        /// gets employee info
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="numOfDays"></param>
        /// <returns></returns>
        public object GetEmployeeInfo(string employeeType, double numOfDays)
        {
            object result = new object();

            if (employeeType == "Regular")
            {
                RegularEmployeeModel regularEmployee = new RegularEmployeeModel()
                {
                    Absent = numOfDays,
                    Salary = GetRegularEmployeeSalary(numOfDays)
                };

                result = JsonConvert.SerializeObject(regularEmployee, Formatting.None);
            }
            else
            {
                ContractualEmployeeModel contractualEmployee = new ContractualEmployeeModel()
                {
                    RenderedDays = numOfDays,
                    Salary = GetContractualEmployeeSalary(numOfDays)
                };

                result = JsonConvert.SerializeObject(contractualEmployee, Formatting.None);
            }

            return result;
        }

        /// <summary>
        /// Get regular employee's salary
        /// </summary>
        /// <param name="absent"></param>
        /// <returns></returns>
        private double GetRegularEmployeeSalary(double absent)
        {
            return _monthlySalary - (absent * (_monthlySalary / 22)) - (_monthlySalary * 0.12);
        }

        /// <summary>
        /// get contractual employee's salary
        /// </summary>
        /// <param name="renderedDays"></param>
        /// <returns></returns>
        private double GetContractualEmployeeSalary(double renderedDays)
        {
            return _dailySalary * renderedDays;
        }
    }


}
