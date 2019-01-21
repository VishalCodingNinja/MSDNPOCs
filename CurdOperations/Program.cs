using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CurdOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
			csb.DataSource = "localhost/SQLEXPRESS";
			csb.InitialCatalog = "firstDatabase";
			csb.IntegratedSecurity = true;

			string connString = csb.ToString();

			//Be sure to replace <YourTable> with the actual name of the Table
			string queryString = "select * from employee";

			using (SqlConnection connection = new SqlConnection(connString))
			using (SqlCommand command = connection.CreateCommand())
			{
				command.CommandText = queryString;

				connection.Open();

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						//Send these to your WinForms textboxes
						string nameValue = reader["name"].ToString();
						string classValue = reader["address"].ToString();
						
					}
				}
			}
		
		}
	}
}
