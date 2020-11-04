using NUnit.Framework;
using EmployeePayrollService;
using System;
using System.Collections.Generic;

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

        [Test]
        public void RetrievePayrollDataByName()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayrollUpdate updateModel = new EmployeePayrollUpdate();
            {
                updateModel.EmployeeID = 2;
                updateModel.EmployeeName = "Priya";
                updateModel.salary = 68000;
                updateModel.department = "HR";
            };

            string department = employeeRepo.RetrieveDataByName(updateModel);
            Assert.AreEqual(updateModel.department, department);
        }

        [Test]
        public void RetrievePayrollDataByDate()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayrollUpdate updateModel = new EmployeePayrollUpdate();
            {
                DateTime dt = new DateTime(2018, 01, 01);
                updateModel.EmployeeID = 2;
                updateModel.EmployeeName = "Priya";
                updateModel.salary = 68000;
                updateModel.department = "HR";
                updateModel.Date = dt;
            };

            List<EmployeePayroll> list = employeeRepo.RetrieveDataByDate(updateModel);
            Assert.AreEqual("Akansha", list[list.Count - 1].EmployeeName);
            Assert.AreEqual("Priya", list[0].EmployeeName);
            
        }
    }
    
}