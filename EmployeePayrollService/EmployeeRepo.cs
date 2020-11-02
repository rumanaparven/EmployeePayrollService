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
                    string query = @"select id,name,salary,start_Date,gender,employee_phone,address,department,basic_pay,deductions,taxable_pay,income_tax,
                                    net_pay from employee_payroll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.EmployeeID = dr.GetInt32(0);
                            employeePayroll.EmployeeName = dr.GetString(1);

                            Console.WriteLine("{0},{1}", employeePayroll.EmployeeID, employeePayroll.EmployeeName);
                            Console.WriteLine();
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
