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

        /// <summary>
        /// initialize employee model list
        /// </summary>
        private List<EmployeeModel> _employeeList = new List<EmployeeModel>();

        /// <summary>
        /// initialize response model
        /// </summary>
        private ResponseModel _responseModel = new ResponseModel();


        /// <summary>
        /// Initialize get employee
        /// </summary>
        /// <returns></returns>
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
        public ResponseModel GetEmployeeInfo(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel.EmployeeType == EmployeeType.Regular) //check employee type
                {
                    if (employeeModel.EmpRegularInfo.TotalAbsent >= 0) //check if total absent inputted is greater than or equal to 0
                    {
                        employeeModel.EmpRegularInfo.Salary = GetRegularEmpSalary(employeeModel.EmpRegularInfo);

                        this._responseModel.Status = 1; //success
                        this._responseModel.Data = employeeModel;
                        this._responseModel.Message = "Data was successfully loaded.";
                    }
                    else
                    {
                        this._responseModel.Status = 0;
                        this._responseModel.Message = "Invalid input of absent/absences";
                    }
                }
                else
                {
                    if (employeeModel.EmpContractualInfo.RenderedDays >= 0)
                    {
                        employeeModel.EmpContractualInfo.Salary = GetContractualEmployeeSalary(employeeModel.EmpContractualInfo);

                        this._responseModel.Status = 1; //success
                        this._responseModel.Data = employeeModel;
                        this._responseModel.Message = "Data was successfully loaded.";
                    }
                    else
                    {
                        this._responseModel.Status = 0;
                        this._responseModel.Message = "Invalid input of rendered day(s)";
                    }

                }
            }
            catch (Exception ex)
            {
                this._responseModel.Status = 2;
                this._responseModel.Message = ex.Message;
            }


            return this._responseModel;
        }

        /// <summary>
        /// Get regular employee's salary
        /// </summary>
        /// <param name="absent"></param>
        /// <returns></returns>
        private double GetRegularEmpSalary(RegularEmployeeModel empRegModel)
        {
            double result = empRegModel.MonthlyRate - (empRegModel.TotalAbsent * (empRegModel.MonthlyRate / 22)) - (empRegModel.MonthlyRate * empRegModel.Tax);

            return Math.Round(result, 2);
        }

        /// <summary>
        /// get contractual employee's salary
        /// </summary>
        /// <param name="renderedDays"></param>
        /// <returns></returns>
        private double GetContractualEmployeeSalary(ContractualEmployeeModel empContractualModel)
        {
            double result = empContractualModel.DailyRate * empContractualModel.RenderedDays;

            return Math.Round(result, 2);
        }
    }


}
