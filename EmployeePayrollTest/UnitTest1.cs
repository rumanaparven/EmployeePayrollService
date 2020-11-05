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
            Assert.AreEqual("Piyush", list[list.Count - 1].EmployeeName);
            Assert.AreEqual("Priya", list[0].EmployeeName);
            
        }
        [Test]
        public void GivenSalary_FindTotalSalary()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayrollUpdate updateModel = new EmployeePayrollUpdate();
            {
                updateModel.EmployeeID = 2;
                updateModel.EmployeeName = "Priya";
                updateModel.salary = 68000;

            };
            double expected = 508000;
            double totalSalary = employeeRepo.RetrieveSumAvg(updateModel);
            Assert.AreEqual(expected, totalSalary);
        }

        [Test]
        public void AddNewEmployee()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayrollUpdate updateModel = new EmployeePayrollUpdate();
            {
                DateTime dt = new DateTime(2019, 05, 12);
               
                updateModel.DeprtmentID = 104;
                updateModel.EmployeeName = "Piyush";
                updateModel.gender = 'M';
                updateModel.salary = 68000;
                updateModel.Date = dt;
                updateModel.phoneNumber = "9089336410";
                updateModel.address = "Dmr";

            };
            EmployeePayroll employeePayroll = employeeRepo.AddNewEmployee(updateModel);
            Assert.AreEqual(updateModel.EmployeeName, employeePayroll.EmployeeName);
        }
        [Test]
        public void DeleteEmployee()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            
            string status = employeeRepo.RemoveEmployee("Akansha");
            Assert.AreEqual("false", status);
        }
    }
    
}