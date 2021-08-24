using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LaunchpadEnhanced
{
	public class PHPTunnel : Form
	{
		private IContainer components;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox3;

		private Label label4;

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox5;

		private ListBox listBox1;

		public PHPTunnel()
		{
			InitializeComponent();
		}

		private void PHPTunnel_Load(object sender, EventArgs e)
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			listBox1 = new System.Windows.Forms.ListBox();
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(92, 15);
			textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(260, 22);
			textBox1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(33, 15);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(50, 17);
			label1.TabIndex = 1;
			label1.Text = "Server";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(33, 55);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(27, 17);
			label2.TabIndex = 3;
			label2.Text = "DB";
			textBox2.Location = new System.Drawing.Point(92, 55);
			textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(260, 22);
			textBox2.TabIndex = 2;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(33, 97);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(38, 17);
			label3.TabIndex = 5;
			label3.Text = "User";
			textBox3.Location = new System.Drawing.Point(92, 97);
			textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(260, 22);
			textBox3.TabIndex = 4;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(16, 146);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(69, 17);
			label4.TabIndex = 7;
			label4.Text = "Password";
			textBox4.Location = new System.Drawing.Point(92, 143);
			textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(260, 22);
			textBox4.TabIndex = 6;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(33, 194);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(47, 17);
			label5.TabIndex = 9;
			label5.Text = "Query";
			textBox5.Location = new System.Drawing.Point(92, 194);
			textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(260, 22);
			textBox5.TabIndex = 8;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 16;
			listBox1.Location = new System.Drawing.Point(20, 246);
			listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(344, 196);
			listBox1.TabIndex = 10;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(393, 457);
			base.Controls.Add(listBox1);
			base.Controls.Add(label5);
			base.Controls.Add(textBox5);
			base.Controls.Add(label4);
			base.Controls.Add(textBox4);
			base.Controls.Add(label3);
			base.Controls.Add(textBox3);
			base.Controls.Add(label2);
			base.Controls.Add(textBox2);
			base.Controls.Add(label1);
			base.Controls.Add(textBox1);
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "PHPTunnel";
			Text = "PHPTunnel";
			base.Load += new System.EventHandler(PHPTunnel_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
