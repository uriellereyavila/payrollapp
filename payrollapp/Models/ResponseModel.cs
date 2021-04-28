using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payrollapp.Models
{

    /// <summary>
    /// custom model that handles data and response states
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// gets or sets response status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// gets or sets response message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// gets or sets response data
        /// </summary>
        public object Data { get; set; }
    }
}
