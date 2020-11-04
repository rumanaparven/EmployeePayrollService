using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeePayrollUpdate
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double salary { get; set; }
        public string department { get; set; }
        public DateTime Date { get; set; }

    }
}
