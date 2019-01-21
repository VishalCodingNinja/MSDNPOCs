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

namespace CurdOperations_cSharp
{
	public partial class Form1 : Form
	{
		static private SqlConnection _sql = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=firstDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
				_sql.Open();
				SqlCommand cmd = _sql.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "insert into TableExample values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
				cmd.ExecuteNonQuery();
				MessageBox.Show("Employee sucessfully updated");
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			_sql.Close();
			DisplayData();
		}

		private void DisplayData()
		{
			_sql.Open();
			SqlCommand cmd = _sql.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from TableExample";
			cmd.ExecuteNonQuery();
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);
			dataGridView1.DataSource = dt;
			_sql.Close();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			_sql.Open();
			SqlCommand cmd = _sql.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "delete from TableExample where name='" + textBox1.Text + "'";
			textBox2.Hide();
			textBox3.Hide();
			cmd.ExecuteNonQuery();
			MessageBox.Show("Record deleted Sucessfuly");
			_sql.Close();
			DisplayData();
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DisplayData();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			_sql.Open();
			SqlCommand cmd = _sql.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "update  TableExample set name='" + textBox2.Text + "'where name='"+textBox1.Text+"'";
			label1.Text = "Old name";
			label2.Text = "New Name";
			cmd.ExecuteNonQuery();
			MessageBox.Show("Record updated Sucessfuly");
			_sql.Close();
			DisplayData();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DisplayData();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			_sql.Open();
			SqlCommand cmd = _sql.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from  TableExample  where name='" + textBox1.Text;
			label1.Text = "Old name";
			label2.Text = "New Name";
			cmd.ExecuteNonQuery();
			MessageBox.Show("Record updated Sucessfuly");
			_sql.Close();
			DisplayData();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			
			if(label1.Text== "Enter XML Name")
			{
				MessageBox.Show("inside");
				_sql.Open();
				SqlCommand cmd = _sql.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText= "INSERT INTO T(XmlCol) SELECT * FROM OPENROWSET( BULK 'D:\\$EuroTraining\\Training\\Day50_31_10_2018_.Net\\C#Training\\MSDNPOCS\\CurdOperations_cSharp\\file.txt',SINGLE_BLOB) AS x; ";
				//cmd.CommandText = "insert into TableExample values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
				cmd.ExecuteNonQuery();
				//MessageBox.Show("Employee sucessfully updated");
				//textBox1.Text = "";
				//textBox2.Text = "";
				//textBox3.Text = "";
				_sql.Close();
				//DisplayData();
				MessageBox.Show("sucessfully updated");
			}
			label1.Text = "Enter XML Name";
			label2.Hide();
			label3.Hide();

			textBox2.Hide();
			textBox3.Hide();
			button1.Hide();
			button2.Hide();
			button3.Hide();
			button4.Hide();
			button4.Hide();
			button5.Hide();
			dataGridView1.Hide();
			button6.Text = "Insert XMl";
		}
	}
}
