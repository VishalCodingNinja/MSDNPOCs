using System.Configuration;
using System.Data.SqlClient;

namespace Data_Layer
{
	public class DB
    {
		public static string ConnectionString
		{
			get
			{
			    string connStr=ConfigurationManager.ConnectionStrings["AWConnection"].ToString();
				SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);//we can change its property easily
				sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
				sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;
				return sb.ToString();
		    } 
        }
		//override  the application name
		public static SqlConnection GetSqlConnection//this method returns a connection to teh coller
		{
			get
			{
				SqlConnection _sqlConn = new SqlConnection(ConnectionString);
				_sqlConn.Open();
				return _sqlConn;
			}
		}
		public static string ApplicationName { get; set; }
		public static int ConnectionTimeout { get; set; }
	}
}
