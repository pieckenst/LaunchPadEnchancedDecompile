using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaunchpadEnhanced
{
	public class GetCategory : Form
	{
		public string category;

		private IContainer components;

		private ComboBox comboBox1;

		private Button button1;

		private Button button2;

		private TextBox textBox1;

		private Label label1;

		public GetCategory()
		{
			InitializeComponent();
		}

		private void GetCategory_Load(object sender, EventArgs e)
		{
			try
			{
				string connectionString = "Server=lpedb.ocdsoft.com;Database=lpedb;Uid=lpeuser;Pwd=lpeuser;";
				MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM categories", mySqlConnection);
				mySqlConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				try
				{
					while (mySqlDataReader.Read())
					{
						comboBox1.Items.Add(mySqlDataReader.GetString("categories"));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Retrieving data, Closing window.\nTry again");
					mainForm.writeCrashLog("Problem: Failed to get Remote macro categories\nSolution: Closing Window\n" + ex.Message, ex.StackTrace, ex.Source);
					Close();
				}
				mySqlDataReader.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex2.StackTrace, ex2.Source);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(comboBox1.Text))
			{
				if (string.IsNullOrEmpty(textBox1.Text))
				{
					MessageBox.Show("Pick something");
					return;
				}
				category = textBox1.Text;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				category = comboBox1.Text;
				base.DialogResult = DialogResult.OK;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			comboBox1.Text = "";
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			comboBox1 = new System.Windows.Forms.ComboBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(49, 28);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(247, 24);
			comboBox1.TabIndex = 0;
			comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			button1.Location = new System.Drawing.Point(203, 120);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Ok";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button2.Location = new System.Drawing.Point(68, 120);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 2;
			button2.Text = "Cancel";
			button2.UseVisualStyleBackColor = true;
			textBox1.Location = new System.Drawing.Point(148, 69);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(148, 22);
			textBox1.TabIndex = 3;
			textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(46, 72);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(96, 17);
			label1.TabIndex = 4;
			label1.Text = "New Category";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = button2;
			base.ClientSize = new System.Drawing.Size(339, 155);
			base.ControlBox = false;
			base.Controls.Add(label1);
			base.Controls.Add(textBox1);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(comboBox1);
			base.Name = "GetCategory";
			Text = "Choose Category";
			base.Load += new System.EventHandler(GetCategory_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
