using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payrollapp.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// gets or sets employee name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// get or sets employee birthdate
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// get or sets employee TIN
        /// </summary>
        public string TIN { get; set; }

        /// <summary>
        /// get or sets employee type
        /// </summary>
        public EmployeeType EmployeeType { get; set; }

        //public List<EmployeeModel> EmployeeList { get; set; }


    }

}
