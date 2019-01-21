namespace AddRecord
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dsf = new System.Windows.Forms.Label();
			this.asdf = new System.Windows.Forms.Label();
			this.sfdgh = new System.Windows.Forms.Label();
			this.ASDFGHJHGFD = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtEmpno = new System.Windows.Forms.TextBox();
			this.txtEname = new System.Windows.Forms.TextBox();
			this.txtSalary = new System.Windows.Forms.TextBox();
			this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// dsf
			// 
			this.dsf.AutoSize = true;
			this.dsf.Location = new System.Drawing.Point(116, 68);
			this.dsf.Name = "dsf";
			this.dsf.Size = new System.Drawing.Size(128, 17);
			this.dsf.TabIndex = 0;
			this.dsf.Text = "Employee Number:";
			// 
			// asdf
			// 
			this.asdf.AutoSize = true;
			this.asdf.Location = new System.Drawing.Point(119, 113);
			this.asdf.Name = "asdf";
			this.asdf.Size = new System.Drawing.Size(115, 17);
			this.asdf.TabIndex = 1;
			this.asdf.Text = "Employee Name:";
			// 
			// sfdgh
			// 
			this.sfdgh.AutoSize = true;
			this.sfdgh.Location = new System.Drawing.Point(122, 173);
			this.sfdgh.Name = "sfdgh";
			this.sfdgh.Size = new System.Drawing.Size(52, 17);
			this.sfdgh.TabIndex = 2;
			this.sfdgh.Text = "Salary:";
			// 
			// ASDFGHJHGFD
			// 
			this.ASDFGHJHGFD.AutoSize = true;
			this.ASDFGHJHGFD.Location = new System.Drawing.Point(122, 225);
			this.ASDFGHJHGFD.Name = "ASDFGHJHGFD";
			this.ASDFGHJHGFD.Size = new System.Drawing.Size(66, 17);
			this.ASDFGHJHGFD.TabIndex = 3;
			this.ASDFGHJHGFD.Text = "Hiredate:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(332, 294);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(196, 62);
			this.button1.TabIndex = 4;
			this.button1.Text = "AddEmployee";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtEmpno
			// 
			this.txtEmpno.Location = new System.Drawing.Point(270, 62);
			this.txtEmpno.Name = "txtEmpno";
			this.txtEmpno.Size = new System.Drawing.Size(347, 22);
			this.txtEmpno.TabIndex = 5;
			// 
			// txtEname
			// 
			this.txtEname.Location = new System.Drawing.Point(270, 113);
			this.txtEname.Name = "txtEname";
			this.txtEname.Size = new System.Drawing.Size(347, 22);
			this.txtEname.TabIndex = 6;
			// 
			// txtSalary
			// 
			this.txtSalary.Location = new System.Drawing.Point(270, 173);
			this.txtSalary.Name = "txtSalary";
			this.txtSalary.Size = new System.Drawing.Size(347, 22);
			this.txtSalary.TabIndex = 7;
			// 
			// dtpHireDate
			// 
			this.dtpHireDate.Location = new System.Drawing.Point(270, 219);
			this.dtpHireDate.Name = "dtpHireDate";
			this.dtpHireDate.Size = new System.Drawing.Size(347, 22);
			this.dtpHireDate.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dtpHireDate);
			this.Controls.Add(this.txtSalary);
			this.Controls.Add(this.txtEname);
			this.Controls.Add(this.txtEmpno);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.ASDFGHJHGFD);
			this.Controls.Add(this.sfdgh);
			this.Controls.Add(this.asdf);
			this.Controls.Add(this.dsf);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label dsf;
		private System.Windows.Forms.Label asdf;
		private System.Windows.Forms.Label sfdgh;
		private System.Windows.Forms.Label ASDFGHJHGFD;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtEmpno;
		private System.Windows.Forms.TextBox txtEname;
		private System.Windows.Forms.TextBox txtSalary;
		private System.Windows.Forms.DateTimePicker dtpHireDate;
	}
}

