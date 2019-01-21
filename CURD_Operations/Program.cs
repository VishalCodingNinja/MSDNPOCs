using System.Data;
using System.Data.SqlClient;
namespace CURD_Operations
{
	class Program
	{
		static void Main(string[] args)
		{
			string _sqlString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			SqlConnection con = new SqlConnection(_sqlString);
			

				}
	}
}
