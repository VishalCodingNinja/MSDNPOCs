using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data_Layer
{
	public class Employees
	{
		public List<Employee> EmployeeList { get; set; }
		public void UpdateSalary(int employeeId, int salary)
		{

			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"UpdateSalary_";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("Empno", System.Data.SqlDbType.Int);
					p1.Value = employeeId;
					cmd.Parameters.Add(p1);

					SqlParameter p2 = new SqlParameter("Salary", System.Data.SqlDbType.Int);
					p2.Value = salary;
					cmd.Parameters.Add(p2);

					cmd.ExecuteNonQuery();
					

				}

			}
		}
		public Employee GetEmployee(int employeeId)
		{
			Employee e = new Employee();
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"GetEmployeeDetails";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("Empno",System.Data.SqlDbType.Int);
					p1.Value = employeeId;
					cmd.Parameters.Add(p1);
					//cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
					SqlDataReader reader = cmd.ExecuteReader();//it will return sql data reader
					if(reader.Read())
					{
						e.Load(reader);

					}
				}
			}
				return e;
		}
		
	}
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public int Salary { get; set; }
		public string HireDate { get; set; }
		public void Load(SqlDataReader reader)
		{
			EmployeeId = Int32.Parse(reader["Empno"].ToString());
			EmployeeName = (reader["Ename"].ToString());
			Salary = Int32.Parse(reader["Salary"].ToString());
			HireDate = reader["Hiredate"].ToString();


		}

	}
}
