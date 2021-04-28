namespace payrollapp.Models
{
    public class RegularEmployeeModel
    {
        /// <summary>
        /// gets or sets monthly rate
        /// </summary>
        public double MonthlyRate { get; set; } = 20000.00;
        
        /// <summary>
        /// gets or sets employee absent
        /// </summary>
        public double TotalAbsent { get; set; } = 0;

        /// <summary>
        /// gets or sets employee working days
        /// </summary>
        public double WorkingDays { get; set; } = 22;

        /// <summary>
        /// gets or sets tax
        /// </summary>
        public double Tax { get; set; } = 0.12;

        /// <summary>
        /// gets or sets employee salary
        /// </summary>
        public double Salary { get; set; }
    }
}
