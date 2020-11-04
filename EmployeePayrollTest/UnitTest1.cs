using NUnit.Framework;
using EmployeePayrollService;

namespace EmployeePayrollTest
{
    
    public class UnitTest1
    {
        [Test]
        public void GivenSalaryDetails_UpdateSalaryDetails()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayrollUpdate updateModel = new EmployeePayrollUpdate();
            {
                updateModel.EmployeeID = 2;
                updateModel.EmployeeName = "Priya";
                updateModel.salary = 68000;
               
            };

            double EmpSalary = employeeRepo.UpdateEmployeeSalary(updateModel);
            Assert.AreEqual(updateModel.salary, EmpSalary);
        }
    }
}