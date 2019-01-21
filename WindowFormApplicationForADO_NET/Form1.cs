using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowFormApplicationForADO_NET
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//string _connString = Data_Layer.DB.ConnectionString;
			Data_Layer.DB.ApplicationName = "Window COnsole Application";
			Data_Layer.DB.ConnectionTimeout = 30; 
			SqlConnection _sqlConnection = Data_Layer.DB.GetSqlConnection;

			DataTable tableLog = Data_Layer.ApplicationLog.GetLogs("Window COnsole Application");
			dataGridView2.DataSource = tableLog;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				Data_Layer.Employees es = new Data_Layer.Employees();
				Data_Layer.Employee _employee = es.GetEmployee(int.Parse(textBox1.Text));
				textBox2.Text = _employee.EmployeeName.ToString();
				textBox3.Text = _employee.Salary.ToString();
				textBox4.Text = _employee.HireDate.ToString();
				Data_Layer.ApplicationLog.Add5("serched for user id" + textBox1.Text);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			try
			{
				Data_Layer.ApplicationLog.DeleteCommentsForApp("Window COnsole Application");
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.StackTrace);
			}


		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (label2.Text == "Enter the new Salary" && label2.Text.Length>0 && label1.Text.Length>0)
			{
				
				Data_Layer.Employees _employees = new Data_Layer.Employees();
				
				_employees.UpdateSalary(int.Parse(textBox2.Text),int.Parse(textBox3.Text));


			}
			textBox2.Text = "";
			textBox3.Text = "";
			label1.Text = "Enter the Employee Id you want to update the salary";
			label2.Text = "Enter the new Salary";
			label3.Hide();
			label4.Hide();
			textBox1.Hide();
			textBox4.Hide();
			button1.Hide();
			button2.Hide();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				string xml = Data_Layer.ApplicationLog.GetLogAsXML("Window COnsole Application");
				System.Windows.Forms.MessageBox.Show(this, xml, "XML Logging");
			}
			catch (Exception)
			{

				throw;
			}

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		
	}
}
