using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	public class ErrorReportMail : Form
	{
		private string error;

		private string stack;

		private string source;

		private IContainer components;

		private TextBox textBox1;

		private Label label1;

		private RichTextBox richTextBox1;

		private Label label2;

		private Button button1;

		private Button button2;

		private RichTextBox richTextBox2;

		private RichTextBox richTextBox3;

		private RichTextBox richTextBox4;

		private RichTextBox richTextBox5;

		private RichTextBox richTextBox6;

		private LinkLabel linkLabel1;

		public ErrorReportMail(string inString, string inStack, string inSource)
		{
			error = inString;
			stack = inStack;
			source = inSource;
			InitializeComponent();
		}

		private void ErrorReportMail_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				button1.Text = "Sending...";
				MailAddress from = new MailAddress("LPEerrors@gmail.com");
				MailMessage mailMessage = new MailMessage("LPEerrors@gmail.com", "getcutco@bellsouth.net");
				mailMessage.Subject = "Launchpad Error Report";
				mailMessage.Body = WindowsIdentity.GetCurrent().Name.ToString() + "\nTimes Run: " + LPE.getConfigItem("timesRun") + "\nFrom: " + textBox1.Text + "\n\nVersion: " + LPE.exeVersion + "\n\n" + richTextBox1.Text + "\n\n\n" + error + "\n\nStack\n" + stack + "\n\nSource\n" + source;
				mailMessage.From = from;
				if (File.Exists("bootlog.txt"))
				{
					Attachment item = new Attachment("bootlog.txt");
					mailMessage.Attachments.Add(item);
				}
				SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new NetworkCredential("lpeerrors@gmail.com", "scrappy");
				smtpClient.Timeout = 20000;
				smtpClient.Send(mailMessage);
				mailMessage.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ?? "");
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				MailAddress from = new MailAddress("LPEerrors@gmail.com");
				MailMessage mailMessage = new MailMessage("LPEerrors@gmail.com", "getcutco@bellsouth.net");
				mailMessage.Subject = "Launchpad Error Report";
				mailMessage.Body = WindowsIdentity.GetCurrent().Name.ToString() + "\nTimes Run: " + LPE.getConfigItem("timesRun") + "\nVersion: " + LPE.exeVersion + "\n\n" + richTextBox1.Text + "\n\n\n" + error + "\n\nStack\n" + stack + "\n\nSource\n" + source;
				mailMessage.From = from;
				if (File.Exists("bootlog.txt"))
				{
					Attachment item = new Attachment("bootlog.txt");
					mailMessage.Attachments.Add(item);
				}
				SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new NetworkCredential("lpeerrors@gmail.com", "scrappy");
				smtpClient.Timeout = 20000;
				smtpClient.Send(mailMessage);
				mailMessage.Dispose();
				base.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			base.DialogResult = DialogResult.OK;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkLabel1.Text);
		}

		private void richTextBox2_TextChanged(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.ErrorReportMail));
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			richTextBox2 = new System.Windows.Forms.RichTextBox();
			richTextBox3 = new System.Windows.Forms.RichTextBox();
			richTextBox4 = new System.Windows.Forms.RichTextBox();
			richTextBox5 = new System.Windows.Forms.RichTextBox();
			richTextBox6 = new System.Windows.Forms.RichTextBox();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(154, 274);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(202, 22);
			textBox1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 274);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(132, 17);
			label1.TabIndex = 1;
			label1.Text = "Your Email Address";
			richTextBox1.Location = new System.Drawing.Point(19, 337);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new System.Drawing.Size(337, 93);
			richTextBox1.TabIndex = 2;
			richTextBox1.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(116, 308);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(141, 17);
			label2.TabIndex = 3;
			label2.Text = "What you were doing";
			button1.Location = new System.Drawing.Point(35, 456);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(137, 44);
			button1.TabIndex = 4;
			button1.Text = "Submit Error Report";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(208, 456);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(137, 44);
			button2.TabIndex = 5;
			button2.Text = "Close";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			richTextBox2.BackColor = System.Drawing.SystemColors.Control;
			richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox2.Location = new System.Drawing.Point(19, 26);
			richTextBox2.Name = "richTextBox2";
			richTextBox2.Size = new System.Drawing.Size(337, 88);
			richTextBox2.TabIndex = 6;
			richTextBox2.Text = resources.GetString("richTextBox2.Text");
			richTextBox2.TextChanged += new System.EventHandler(richTextBox2_TextChanged);
			richTextBox3.BackColor = System.Drawing.SystemColors.Control;
			richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox3.Location = new System.Drawing.Point(19, 120);
			richTextBox3.Name = "richTextBox3";
			richTextBox3.Size = new System.Drawing.Size(337, 20);
			richTextBox3.TabIndex = 7;
			richTextBox3.Text = "Common Errors";
			richTextBox4.BackColor = System.Drawing.SystemColors.Control;
			richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox4.Location = new System.Drawing.Point(35, 146);
			richTextBox4.Name = "richTextBox4";
			richTextBox4.Size = new System.Drawing.Size(289, 21);
			richTextBox4.TabIndex = 8;
			richTextBox4.Text = "#1 - Firewall blocking downloads";
			richTextBox5.BackColor = System.Drawing.SystemColors.Control;
			richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox5.Location = new System.Drawing.Point(35, 173);
			richTextBox5.Name = "richTextBox5";
			richTextBox5.Size = new System.Drawing.Size(289, 21);
			richTextBox5.TabIndex = 9;
			richTextBox5.Text = "#2 - No administrator access";
			richTextBox6.BackColor = System.Drawing.SystemColors.Control;
			richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox6.Location = new System.Drawing.Point(35, 200);
			richTextBox6.Name = "richTextBox6";
			richTextBox6.Size = new System.Drawing.Size(289, 21);
			richTextBox6.TabIndex = 10;
			richTextBox6.Text = "#3 - Download new Installer";
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(67, 224);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(234, 17);
			linkLabel1.TabIndex = 11;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://www.launchpadenhanced.com";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(392, 512);
			base.ControlBox = false;
			base.Controls.Add(linkLabel1);
			base.Controls.Add(richTextBox6);
			base.Controls.Add(richTextBox5);
			base.Controls.Add(richTextBox4);
			base.Controls.Add(richTextBox3);
			base.Controls.Add(richTextBox2);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(label2);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(label1);
			base.Controls.Add(textBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ErrorReportMail";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Error Report";
			base.Load += new System.EventHandler(ErrorReportMail_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
