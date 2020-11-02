using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeePayroll
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public char gender { get; set; }
        public double salary { get; set; }
        public double BasicPay { get; set; }
        public double deductions { get; set; }
        public double taxablePay { get; set; }
        public double tax { get; set; }
        public double netPay { get; set; }
        public DateTime startDate { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}
