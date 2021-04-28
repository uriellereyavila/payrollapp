using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payrollapp.Models
{
    public class ContractualEmployeeModel
    {
        /// <summary>
        /// gets or sets employee daily rate
        /// </summary>
        public double DailyRate { get; set; } = 500.00;

        /// <summary>
        /// gets or set employee rendered days
        /// </summary>
        public double RenderedDays { get; set; }

        /// <summary>
        /// gets or sets employee's salary
        /// </summary>
        public double Salary { get; set; }
    }
}
