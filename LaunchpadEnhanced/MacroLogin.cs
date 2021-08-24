using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;
using MySql.Data.MySqlClient;

namespace LaunchpadEnhanced
{
	public class MacroLogin : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Button button1;

		private TextBox user;

		private TextBox pass;

		private RichTextBox richTextBox1;

		private Button closeButton;

		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		public string username;

		public string password;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.MacroLogin));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			user = new System.Windows.Forms.TextBox();
			pass = new System.Windows.Forms.TextBox();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			closeButton = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Trebuchet MS", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(21, 266);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(93, 23);
			label1.TabIndex = 0;
			label1.Text = "User Name";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Trebuchet MS", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(32, 300);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(82, 23);
			label2.TabIndex = 1;
			label2.Text = "Password";
			button1.Location = new System.Drawing.Point(109, 351);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Submit";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			user.Location = new System.Drawing.Point(120, 267);
			user.Name = "user";
			user.Size = new System.Drawing.Size(145, 22);
			user.TabIndex = 3;
			pass.Location = new System.Drawing.Point(120, 301);
			pass.Name = "pass";
			pass.Size = new System.Drawing.Size(145, 22);
			pass.TabIndex = 4;
			richTextBox1.BackColor = System.Drawing.SystemColors.ControlText;
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox1.ForeColor = System.Drawing.Color.Yellow;
			richTextBox1.Location = new System.Drawing.Point(36, 95);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			richTextBox1.Size = new System.Drawing.Size(227, 147);
			richTextBox1.TabIndex = 5;
			richTextBox1.Text = resources.GetString("richTextBox1.Text");
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.Location = new System.Drawing.Point(261, 29);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(16, 14);
			closeButton.TabIndex = 6;
			closeButton.Text = "button1";
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Red;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(289, 404);
			base.Controls.Add(closeButton);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(pass);
			base.Controls.Add(user);
			base.Controls.Add(button1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "MacroLogin";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "MacroLogin";
			base.TopMost = true;
			base.TransparencyKey = System.Drawing.Color.Red;
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(MacroLogin_MouseUp);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(MacroLogin_MouseMove);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(MacroLogin_MouseDown);
			ResumeLayout(false);
			PerformLayout();
		}

		public MacroLogin()
		{
			InitializeComponent();
			getInfo();
		}

		private void getInfo()
		{
			ArrayList arrayList = new ArrayList();
			if (File.Exists(LPE.commonFiles + "macrologininfo.cfg"))
			{
				arrayList = readFileToString(LPE.commonFiles + "macrologininfo.cfg");
				username = arrayList[0].ToString().Replace("user=", "");
				password = arrayList[1].ToString().Replace("pass=", "");
			}
			else
			{
				username = null;
				password = null;
			}
		}

		private ArrayList readFileToString(string fileName)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				TextReader textReader = new StreamReader(fileName);
				string text = textReader.ReadLine();
				int num = 0;
				while (text != null)
				{
					if (text.Length > 1)
					{
						arrayList.Add(text);
						num++;
					}
					text = textReader.ReadLine();
				}
				textReader.Close();
				return arrayList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Reading File: " + ex.Message);
				return arrayList;
			}
		}

		private void MacroLogin_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void MacroLogin_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void MacroLogin_MouseMove(object sender, MouseEventArgs e)
		{
			if (!bProcessingEvent && bMouseDown)
			{
				bProcessingEvent = true;
				base.DesktopLocation = new Point(base.Location.X + e.X - pntMousePosition.X, base.Location.Y + e.Y - pntMousePosition.Y);
				bProcessingEvent = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (checkUserName(user.Text, pass.Text))
			{
				writeUserFile();
				username = user.Text;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("User Name already taken or wrong password, try again");
			}
		}

		private bool checkUserName(string inName, string inPass)
		{
			try
			{
				string connectionString = "Server=lpedb.ocdsoft.com;Database=lpedb;Uid=lpeuser;Pwd=lpeuser;";
				MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM users WHERE user='" + inName + "' AND pass='" + inPass + "'", mySqlConnection);
				mySqlConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				if (mySqlDataReader.HasRows)
				{
					mySqlDataReader.Close();
					mySqlConnection.Close();
					return true;
				}
				mySqlDataReader.Close();
				mySqlCommand = new MySqlCommand("SELECT * FROM users WHERE user='" + inName + "'", mySqlConnection);
				mySqlDataReader = mySqlCommand.ExecuteReader();
				if (mySqlDataReader.HasRows)
				{
					mySqlDataReader.Close();
					mySqlConnection.Close();
					return false;
				}
				mySqlDataReader.Close();
				mySqlCommand = new MySqlCommand("INSERT INTO users (user, pass) VALUES('" + inName + "', '" + inPass + "')", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlConnection.Close();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex.StackTrace, ex.Source);
			}
			return false;
		}

		private void writeUserFile()
		{
			try
			{
				StreamWriter streamWriter = File.CreateText(LPE.commonFiles + "macrologininfo.cfg");
				streamWriter.WriteLine("user=" + user.Text);
				streamWriter.WriteLine("pass=" + pass.Text);
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing macro config File: " + ex.Message + "\nClosing macro manager");
				Close();
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Abort;
			GC.Collect();
			Close();
		}
	}
}
