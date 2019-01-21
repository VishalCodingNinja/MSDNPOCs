using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Data_Layer
{
	public class ApplicationLog
	{
		public static void Add(string comment)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"AddAppLog";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = comment;
					cmd.Parameters.Add(p1);
					//cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
					int res = cmd.ExecuteNonQuery();

				}
			}

		}
		public static void Add2(string comment)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"AddAppLog1";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = comment;
					cmd.Parameters.Add(p1);
					//cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
					object res = cmd.ExecuteScalar();//it will return the first column of first row of last select query
													 //it is returning the last id generated

				}
			}

		}

		/// <summary>
		/// Add a comment and use a output paramter
		/// </summary>
		/// <param name="comment"></param>
		public static void Add3(string comment)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"AddAppLog1";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = comment;
					cmd.Parameters.Add(p1);


					SqlParameter p2 = new SqlParameter("outid", System.Data.SqlDbType.Int);
					p2.Direction = System.Data.ParameterDirection.Output;
					cmd.Parameters.Add(p2);
					//cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
					cmd.ExecuteNonQuery();//it will return the first column of first row of last select query
										  //it is returning the last id generated
					object res = p2.Value;
				}
			}
		}



		public static void Add4(string comment)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"AddAppLog4";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = comment;
					cmd.Parameters.Add(p1);


					SqlParameter p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
					p2.Direction = System.Data.ParameterDirection.ReturnValue;
					cmd.Parameters.Add(p2);
					
					cmd.ExecuteNonQuery();

					object res = p2.Value;
				}
			}
		}

		

		public static void Add5(string comment)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"AddAppLog5";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = comment;
					cmd.Parameters.Add(p1);


					SqlParameter p2 = new SqlParameter("extra_data", System.Data.SqlDbType.Xml);
					string xml = @"<data username=""{0}""/>";//it should ne well formated XML
					string usr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
					xml = string.Format(xml, usr);
					p2.Value = xml;
					
					cmd.Parameters.Add(p2);
						
					
					SqlParameter p3 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
					p3.Direction = System.Data.ParameterDirection.ReturnValue;
					cmd.Parameters.Add(p3);

					cmd.ExecuteNonQuery();
					object res = p2.Value;
				}
			}
		}



		public static DataTable GetLogs(string appName)
		{
			DataTable table = new DataTable("ApplicationLog");
			SqlDataAdapter da = null;
			using (SqlConnection conn=DB.GetSqlConnection)
			{
				SqlCommand cmd = new SqlCommand("select * from ApplicationLog where application_name=@appname",conn);//we are using the parameter so it will make us free form SqlINjection
				cmd.Parameters.Add(new SqlParameter("appname", System.Data.SqlDbType.NVarChar, 100));
				cmd.Parameters["appname"].Value = appName;
				da = new SqlDataAdapter(cmd);
				int res = da.Fill(table);//it will fill the table from the table
			}
			return table;
		}
		public static string GetLogAsXML(string appName)
		{
			string res = "";
			using (SqlConnection conn=DB.GetSqlConnection)
			{
				SqlCommand cmd = new SqlCommand(@"Select id,date_added,comment,application_name,extra_data.value('(/data/@username)[1]','nvarchar(100)') as username from ApplicationLog
				where application_name=@appname FOR XML AUTO ,XMLDATA",conn);
				cmd.Parameters.Add(new SqlParameter("appname", System.Data.SqlDbType.NChar));
				cmd.Parameters["appname"].Value = appName;
				XmlReader _xmlread= cmd.ExecuteXmlReader();//its a method that allow us to consume the XML 
														   //the xml reader has similar methods that data reader
				while (_xmlread.Read())
				{
					res += _xmlread.ReadOuterXml();
				}

				return res;
			}
		}

		public static void DeleteCommentsForApp(string appName)
		{
			using (SqlConnection conn = DB.GetSqlConnection)
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = @"DeleteAppLog";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					SqlParameter p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100);
					p1.Value = appName;
					cmd.Parameters.Add(p1);
					cmd.ExecuteNonQuery();
					//delete all comments for specific application
				}
			}
		}
	}
}
