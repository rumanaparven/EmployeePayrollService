using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo er = new EmployeeRepo();
            er.GetAllEmployee();
        }
    }
}
