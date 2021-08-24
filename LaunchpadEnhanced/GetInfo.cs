using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace LaunchpadEnhanced
{
	public class GetInfo : Form
	{
		private const int ICMP_ECHO = 8;

		private IContainer components;

		private TextBox userBox;

		private Label label1;

		private Label label2;

		private TextBox passBox;

		private Label label3;

		private TextBox pass2Box;

		private Label label4;

		private TextBox emailBox;

		private Button button1;

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
			userBox = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			passBox = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			pass2Box = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			emailBox = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			userBox.Location = new System.Drawing.Point(139, 46);
			userBox.Margin = new System.Windows.Forms.Padding(4);
			userBox.Name = "userBox";
			userBox.Size = new System.Drawing.Size(187, 22);
			userBox.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(51, 49);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(79, 17);
			label1.TabIndex = 1;
			label1.Text = "User Name";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(60, 94);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(69, 17);
			label2.TabIndex = 3;
			label2.Text = "Password";
			passBox.Location = new System.Drawing.Point(139, 90);
			passBox.Margin = new System.Windows.Forms.Padding(4);
			passBox.Name = "passBox";
			passBox.PasswordChar = '*';
			passBox.Size = new System.Drawing.Size(187, 22);
			passBox.TabIndex = 2;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 139);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(109, 17);
			label3.TabIndex = 5;
			label3.Text = "Password Again";
			pass2Box.Location = new System.Drawing.Point(139, 135);
			pass2Box.Margin = new System.Windows.Forms.Padding(4);
			pass2Box.Name = "pass2Box";
			pass2Box.PasswordChar = '*';
			pass2Box.Size = new System.Drawing.Size(187, 22);
			pass2Box.TabIndex = 4;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(88, 186);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 17);
			label4.TabIndex = 7;
			label4.Text = "Email";
			emailBox.Location = new System.Drawing.Point(139, 182);
			emailBox.Margin = new System.Windows.Forms.Padding(4);
			emailBox.Name = "emailBox";
			emailBox.Size = new System.Drawing.Size(187, 22);
			emailBox.TabIndex = 6;
			button1.Location = new System.Drawing.Point(139, 234);
			button1.Margin = new System.Windows.Forms.Padding(4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(100, 28);
			button1.TabIndex = 8;
			button1.Text = "Ok";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(354, 285);
			base.Controls.Add(button1);
			base.Controls.Add(label4);
			base.Controls.Add(emailBox);
			base.Controls.Add(label3);
			base.Controls.Add(pass2Box);
			base.Controls.Add(label2);
			base.Controls.Add(passBox);
			base.Controls.Add(label1);
			base.Controls.Add(userBox);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "GetInfo";
			Text = "Information";
			ResumeLayout(false);
			PerformLayout();
		}

		public GetInfo()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IPHostEntry hostEntry = Dns.GetHostEntry("chicago.swgemu.com");
			IPAddress address = IPAddress.Parse(hostEntry.AddressList[0].ToString());
			Ping ping = new Ping();
			PingReply pingReply = ping.Send(address, 5000);
			MessageBox.Show(string.Concat(pingReply.Buffer));
		}
	}
}
