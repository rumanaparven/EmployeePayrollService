using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(LocalDb)\ServerName;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"select e.empID,e.name,d.deptName,e.salary,e.start_Date,e.address,p.basic_pay,p.income_tax from employee e join department d
                                    on e.deptID=d.deptID join payroll p on e.empID=p.empID where e.name='Priya'";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.EmployeeID = dr.GetInt32(0);
                            employeePayroll.EmployeeName = dr.GetString(1);
                            employeePayroll.department = dr.GetString(2);
                            employeePayroll.salary = Convert.ToDouble(dr.GetDecimal(3));
                            employeePayroll.startDate = dr.GetDateTime(4);
                            employeePayroll.address = dr.GetString(5);
                            employeePayroll.BasicPay= Convert.ToDouble(dr.GetDecimal(6));
                            employeePayroll.tax= Convert.ToDouble(dr.GetDecimal(7));

                          
                            Console.WriteLine(employeePayroll.EmployeeID+" "+ employeePayroll.EmployeeName+" "+ employeePayroll.department+" "+ employeePayroll.salary+
                                " "+ employeePayroll.startDate+" "+ employeePayroll.address+" "+ employeePayroll.BasicPay+" "+ employeePayroll.tax);
                            //Console.WriteLine(employeePayroll.EmployeeName);
                            //Console.WriteLine(employeePayroll.department);
                            //Console.WriteLine(employeePayroll.salary);
                            //Console.WriteLine(employeePayroll.startDate);
                            //Console.WriteLine(employeePayroll.address);
                            //Console.WriteLine(employeePayroll.BasicPay);
                            //Console.WriteLine(employeePayroll.tax);



                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
