using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	public class AddServer : Form
	{
		private IContainer components;

		private Button closeButton;

		private TextBox serverBox;

		private LinkLabel linkLabel1;

		private Label label1;

		private Label label2;

		private TextBox addressBox;

		private Label label3;

		private TextBox portBox;

		private Label label4;

		private TextBox linkBox;

		private Button addButton;

		private ImageList imageList1;

		private CheckBox checkBox1;

		private Label label5;

		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		private Server newServer = new Server();

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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.AddServer));
			closeButton = new System.Windows.Forms.Button();
			serverBox = new System.Windows.Forms.TextBox();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			addressBox = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			portBox = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			linkBox = new System.Windows.Forms.TextBox();
			addButton = new System.Windows.Forms.Button();
			imageList1 = new System.Windows.Forms.ImageList(components);
			checkBox1 = new System.Windows.Forms.CheckBox();
			label5 = new System.Windows.Forms.Label();
			SuspendLayout();
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.Location = new System.Drawing.Point(264, 28);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(16, 14);
			closeButton.TabIndex = 0;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(AddServer_MouseMove);
			closeButton.Click += new System.EventHandler(closeButton_Click);
			closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(AddServer_MouseDown);
			closeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(AddServer_MouseUp);
			serverBox.BackColor = System.Drawing.Color.DimGray;
			serverBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			serverBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverBox.ForeColor = System.Drawing.Color.White;
			serverBox.Location = new System.Drawing.Point(90, 95);
			serverBox.MaxLength = 100;
			serverBox.Name = "serverBox";
			serverBox.Size = new System.Drawing.Size(179, 22);
			serverBox.TabIndex = 1;
			linkLabel1.ActiveLinkColor = System.Drawing.Color.Yellow;
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = System.Drawing.Color.Transparent;
			linkLabel1.LinkColor = System.Drawing.Color.White;
			linkLabel1.Location = new System.Drawing.Point(91, 370);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(122, 17);
			linkLabel1.TabIndex = 2;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Server Admin Add";
			linkLabel1.Visible = false;
			linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(39, 98);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(50, 17);
			label1.TabIndex = 3;
			label1.Text = "Server";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(30, 143);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 17);
			label2.TabIndex = 5;
			label2.Text = "Address";
			addressBox.BackColor = System.Drawing.Color.DimGray;
			addressBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			addressBox.ForeColor = System.Drawing.Color.White;
			addressBox.Location = new System.Drawing.Point(90, 140);
			addressBox.MaxLength = 100;
			addressBox.Name = "addressBox";
			addressBox.Size = new System.Drawing.Size(179, 22);
			addressBox.TabIndex = 4;
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(56, 188);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(34, 17);
			label3.TabIndex = 7;
			label3.Text = "Port";
			portBox.BackColor = System.Drawing.Color.DimGray;
			portBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			portBox.ForeColor = System.Drawing.Color.White;
			portBox.Location = new System.Drawing.Point(90, 183);
			portBox.MaxLength = 100;
			portBox.Name = "portBox";
			portBox.Size = new System.Drawing.Size(179, 22);
			portBox.TabIndex = 6;
			portBox.Text = "44453";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(23, 297);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(60, 17);
			label4.TabIndex = 9;
			label4.Text = "Address";
			linkBox.BackColor = System.Drawing.Color.DimGray;
			linkBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			linkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			linkBox.ForeColor = System.Drawing.Color.White;
			linkBox.Location = new System.Drawing.Point(89, 294);
			linkBox.MaxLength = 100;
			linkBox.Name = "linkBox";
			linkBox.Size = new System.Drawing.Size(179, 22);
			linkBox.TabIndex = 8;
			linkBox.Text = "Address to Custom Files";
			addButton.BackColor = System.Drawing.Color.Transparent;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			addButton.ImageIndex = 0;
			addButton.ImageList = imageList1;
			addButton.Location = new System.Drawing.Point(104, 330);
			addButton.Name = "addButton";
			addButton.Size = new System.Drawing.Size(97, 22);
			addButton.TabIndex = 14;
			addButton.UseVisualStyleBackColor = false;
			addButton.MouseLeave += new System.EventHandler(addButton_MouseLeave);
			addButton.Click += new System.EventHandler(addButton_Click);
			addButton.MouseEnter += new System.EventHandler(addButton_MouseEnter);
			imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = System.Drawing.Color.Transparent;
			imageList1.Images.SetKeyName(0, "add_base.png");
			imageList1.Images.SetKeyName(1, "add_mouseover.png");
			checkBox1.AutoSize = true;
			checkBox1.BackColor = System.Drawing.Color.Transparent;
			checkBox1.ForeColor = System.Drawing.Color.White;
			checkBox1.Location = new System.Drawing.Point(89, 255);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(123, 21);
			checkBox1.TabIndex = 15;
			checkBox1.Text = "Custom Server";
			checkBox1.UseVisualStyleBackColor = false;
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.ForeColor = System.Drawing.Color.White;
			label5.Location = new System.Drawing.Point(101, 224);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(124, 17);
			label5.TabIndex = 16;
			label5.Text = "Advanced Options";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(289, 404);
			base.Controls.Add(label5);
			base.Controls.Add(checkBox1);
			base.Controls.Add(addButton);
			base.Controls.Add(label4);
			base.Controls.Add(linkBox);
			base.Controls.Add(label3);
			base.Controls.Add(portBox);
			base.Controls.Add(label2);
			base.Controls.Add(addressBox);
			base.Controls.Add(label1);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(serverBox);
			base.Controls.Add(closeButton);
			Cursor = System.Windows.Forms.Cursors.Default;
			ForeColor = System.Drawing.Color.Black;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "AddServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AddServer";
			base.TransparencyKey = System.Drawing.Color.Red;
			base.Load += new System.EventHandler(AddServer_Load);
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(AddServer_MouseUp);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(AddServer_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(AddServer_MouseMove);
			ResumeLayout(false);
			PerformLayout();
		}

		public AddServer()
		{
			InitializeComponent();
		}

		private void AddServer_Load(object sender, EventArgs e)
		{
			buildServersObject();
			serverBox.Text = "";
		}

		private void writeCustomServerFile()
		{
			try
			{
				if (File.Exists(LPE.commonFiles + "customservers.cfg"))
				{
					File.Delete(LPE.commonFiles + "customservers.cfg");
				}
				StreamWriter streamWriter = File.CreateText(LPE.commonFiles + "customservers.cfg");
				for (int i = 0; i < LPE.serverArrayList.Count; i++)
				{
					Server server = (Server)LPE.serverArrayList[i];
					streamWriter.WriteLine("[Server]");
					streamWriter.WriteLine(server.sname);
					streamWriter.WriteLine(server.saddress);
					streamWriter.WriteLine(server.sport);
					streamWriter.WriteLine(server.standard);
					if (server.downloadLink == "")
					{
						server.downloadLink = "null";
					}
					streamWriter.WriteLine(server.downloadLink);
					streamWriter.WriteLine("[/Server]");
				}
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing 'customservers.cfg' File: " + ex);
				MessageBox.Show("Application Must Close");
				base.Owner.Close();
			}
		}

		private void buildServersObject()
		{
			LPE.serverArrayList.Clear();
			if (!File.Exists(LPE.commonFiles + "customservers.cfg"))
			{
				return;
			}
			ArrayList arrayList = LPE.readFileToString(LPE.commonFiles + "customservers.cfg");
			for (int i = 0; i < arrayList.Count; i++)
			{
				if (arrayList[i].ToString().Contains("[Server]"))
				{
					Server server = new Server();
					i++;
					server.sname = arrayList[i].ToString();
					i++;
					server.saddress = arrayList[i].ToString();
					i++;
					server.sport = arrayList[i].ToString();
					i++;
					server.standard = arrayList[i].ToString();
					i++;
					server.downloadLink = arrayList[i].ToString();
					LPE.serverArrayList.Add(server);
				}
			}
		}

		private void AddServer_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void AddServer_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void AddServer_MouseMove(object sender, MouseEventArgs e)
		{
			if (!bProcessingEvent && bMouseDown)
			{
				bProcessingEvent = true;
				base.DesktopLocation = new Point(base.Location.X + e.X - pntMousePosition.X, base.Location.Y + e.Y - pntMousePosition.Y);
				bProcessingEvent = false;
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			base.Owner.Close();
			GC.Collect();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(LPE.baseLocation + "servers2.php");
			Close();
		}

		private void addButton_MouseEnter(object sender, EventArgs e)
		{
			if (!imageList1.Images.Empty)
			{
				addButton.Image = imageList1.Images[1];
			}
			GC.Collect();
		}

		private void addButton_MouseLeave(object sender, EventArgs e)
		{
			if (!imageList1.Images.Empty)
			{
				addButton.Image = imageList1.Images[0];
			}
			GC.Collect();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			Server server = new Server();
			if (serverBox.Text.Length > 1 && addressBox.Text.Length > 1 && portBox.Text.Length > 1 && portBox.Text.Length < 6)
			{
				server.sname = serverBox.Text;
				server.saddress = addressBox.Text;
				server.sport = portBox.Text;
				server.standard = checkBox1.Checked.ToString();
				if (checkBox1.Checked)
				{
					server.downloadLink = linkBox.Text;
				}
				else
				{
					server.downloadLink = "null";
				}
				LPE.serverArrayList.Add(server);
				writeCustomServerFile();
				base.Owner.Close();
			}
			else
			{
				MessageBox.Show("Error in Entry");
			}
		}
	}
}
