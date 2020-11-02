﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
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
                    string query = @"update payroll set basic_pay=8000000.00 where empID=(select empID from employee where name=@name) ";
                    SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.VarChar, 0);
                    nameParam.Value = "Priya";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.Add(nameParam);
                    this.connection.Open();

                    int rows = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rows > 0)
                    {
                        Console.WriteLine(rows + " row(s) affected");
                    }
                    else
                    {
                        Console.WriteLine("Please check your query");
                    }
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
