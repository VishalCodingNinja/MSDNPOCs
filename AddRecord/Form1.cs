using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AddRecord
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string cs = "Data Source=localhost\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			SqlConnection con = new SqlConnection(cs);
			SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", cs);//to get the data from employees table
			SqlCommandBuilder cmd = new SqlCommandBuilder(da);//to generate the commands for dataadapter object 

			DataSet ds = new DataSet();
			da.Fill(ds, "Employees");//fill the dataset..convention to follow the same
			ds.Tables[0].Constraints.Add("Empno_PK", ds.Tables[0].Columns[0], true);
			DataRow row;
			row = ds.Tables[0].NewRow();
			row["Empno"] = txtEmpno.Text;
			row["Ename"] = txtEname.Text;
			row["Salary"] = txtSalary.Text;
			row["Hiredate"] = dtpHireDate.Value;
			ds.Tables[0].Rows.Add(row);
			da.Update(ds.Tables[0]);
			MessageBox.Show("Employee Record Added.",this.Text);
		}
	}
}
