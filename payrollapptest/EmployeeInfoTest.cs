using payrollapp.BusinessLogic;
using payrollapp.Models;
using System;
using Xunit;

namespace payrollapptest
{
    public class EmployeeInfoTest
    {
        private ResponseModel _responseModel = new ResponseModel();

        /// <summary>
        /// False 
        /// </summary>
        [Fact]
        public void GetRegularEmployeeInfo()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                EmployeeType = EmployeeType.Regular,
                EmpRegularInfo = new RegularEmployeeModel()
                {
                    TotalAbsent = 2
                }
            };
            Employee employee = new Employee();

            this._responseModel = employee.GetEmployeeInfo(employeeModel);

            //test for totalAbsent negative value
            Assert.False(this._responseModel.Status != 1 ? false : true, this._responseModel.Message);
        }

        private double GetRegularEmpSalary(RegularEmployeeModel empRegModel)
        {
            double result = empRegModel.MonthlyRate - (empRegModel.TotalAbsent * (empRegModel.MonthlyRate / 22)) - (empRegModel.MonthlyRate * empRegModel.Tax);

            return Math.Round(result, 2);
        }

        private double GetContractualEmployeeSalary(ContractualEmployeeModel empContractualModel)
        {
            double result = empContractualModel.DailyRate * empContractualModel.RenderedDays;

            return Math.Round(result, 2);
        }
    }
}
