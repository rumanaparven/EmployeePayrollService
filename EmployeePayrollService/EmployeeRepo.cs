﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\ServerName;Initial Catalog=payroll_service;Integrated Security=True");
        }
        List<EmployeePayroll> list = new List<EmployeePayroll>();
        public List<EmployeePayroll> RetrieveDataByDate(EmployeePayrollUpdate employeePayrollUpdate)
        {
            
            SqlConnection SalaryConnection = ConnectionSetup();
            
            try
            {

                using (SalaryConnection)
                {
                   
                    SqlCommand cmd = new SqlCommand("spRetrieveByDate", SalaryConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@start_Date", employeePayrollUpdate.Date);
                    SalaryConnection.Open();

                   
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeePayroll employeePayroll = new EmployeePayroll();
                            employeePayroll.EmployeeID = dr.GetInt32(0);
                            employeePayroll.EmployeeName = dr.GetString(1);
                            employeePayroll.department = dr.GetString(2);
                            employeePayroll.salary = Convert.ToDouble(dr.GetDecimal(3));
                            employeePayroll.startDate = dr.GetDateTime(4);
                            employeePayroll.address = dr.GetString(5);
                            employeePayroll.BasicPay = Convert.ToDouble(dr.GetDecimal(6));
                            employeePayroll.tax = Convert.ToDouble(dr.GetDecimal(7));


                            Console.WriteLine(employeePayroll.EmployeeID + " " + employeePayroll.EmployeeName + " " + employeePayroll.department + " " + employeePayroll.salary +
                                " " + employeePayroll.startDate + " " + employeePayroll.address + " " + employeePayroll.BasicPay + " " + employeePayroll.tax);

                            list.Add(employeePayroll);
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return list;
        }
        public string RetrieveDataByName(EmployeePayrollUpdate employeePayrollUpdate)
        {
            EmployeePayroll employeePayroll = new EmployeePayroll();
            SqlConnection SalaryConnection = ConnectionSetup();
            
            try
            {

                using (SalaryConnection)
                {

                    SqlCommand cmd = new SqlCommand("spRetrievePayrollData", SalaryConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", employeePayrollUpdate.EmployeeName);
                    SalaryConnection.Open();


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
                            employeePayroll.BasicPay = Convert.ToDouble(dr.GetDecimal(6));
                            employeePayroll.tax = Convert.ToDouble(dr.GetDecimal(7));


                            Console.WriteLine(employeePayroll.EmployeeID + " " + employeePayroll.EmployeeName + " " + employeePayroll.department + " " + employeePayroll.salary +
                                " " + employeePayroll.startDate + " " + employeePayroll.address + " " + employeePayroll.BasicPay + " " + employeePayroll.tax);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return employeePayroll.department;
        }
        public double UpdateEmployeeSalary(EmployeePayrollUpdate employeePayrollUpdate)
        {
            EmployeePayroll employeePayroll = new EmployeePayroll();
            SqlConnection SalaryConnection = ConnectionSetup();
           
            try
            {

                using (SalaryConnection)
                {

                    SqlCommand cmd = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empID", employeePayrollUpdate.EmployeeID);
                    cmd.Parameters.AddWithValue("@name", employeePayrollUpdate.EmployeeName);
                    cmd.Parameters.AddWithValue("@salary", employeePayrollUpdate.salary);
                    SalaryConnection.Open();


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
                            employeePayroll.BasicPay = Convert.ToDouble(dr.GetDecimal(6));
                            employeePayroll.tax = Convert.ToDouble(dr.GetDecimal(7));


                            Console.WriteLine(employeePayroll.EmployeeID + " " + employeePayroll.EmployeeName + " " + employeePayroll.department + " " + employeePayroll.salary +
                                " " + employeePayroll.startDate + " " + employeePayroll.address + " " + employeePayroll.BasicPay + " " + employeePayroll.tax);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return employeePayroll.salary;
        }

    }
}
