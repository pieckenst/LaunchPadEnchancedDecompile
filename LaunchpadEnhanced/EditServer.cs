using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;
using Xceed.Editors;
using Xceed.UI;

namespace LaunchpadEnhanced
{
	public class EditServer : Form
	{
		private IContainer components;

		private Label label4;

		private TextBox linkBox;

		private Label label3;

		private TextBox portBox;

		private Label label2;

		private TextBox addressBox;

		private Label label1;

		private TextBox serverBox;

		private Button closeButton;

		private WinComboBox serverCombo;

		private WinButton dropDownButton2;

		private Button updateButton;

		private Button removeButton;

		private ImageList buttonImages;

		private Label label5;

		private CheckBox checkBox1;

		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.EditServer));
			label4 = new System.Windows.Forms.Label();
			linkBox = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			portBox = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			addressBox = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			serverBox = new System.Windows.Forms.TextBox();
			closeButton = new System.Windows.Forms.Button();
			serverCombo = new Xceed.Editors.WinComboBox();
			dropDownButton2 = new Xceed.Editors.WinButton();
			updateButton = new System.Windows.Forms.Button();
			buttonImages = new System.Windows.Forms.ImageList(components);
			removeButton = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)serverCombo).BeginInit();
			((System.ComponentModel.ISupportInitialize)serverCombo.DropDownControl).BeginInit();
			serverCombo.SuspendLayout();
			SuspendLayout();
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(9, 375);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(60, 17);
			label4.TabIndex = 21;
			label4.Text = "Address";
			linkBox.BackColor = System.Drawing.Color.DimGray;
			linkBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			linkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			linkBox.ForeColor = System.Drawing.Color.White;
			linkBox.Location = new System.Drawing.Point(78, 372);
			linkBox.MaxLength = 100;
			linkBox.Name = "linkBox";
			linkBox.Size = new System.Drawing.Size(185, 22);
			linkBox.TabIndex = 20;
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(44, 236);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(34, 17);
			label3.TabIndex = 19;
			label3.Text = "Port";
			portBox.BackColor = System.Drawing.Color.DimGray;
			portBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			portBox.ForeColor = System.Drawing.Color.White;
			portBox.Location = new System.Drawing.Point(78, 231);
			portBox.MaxLength = 100;
			portBox.Name = "portBox";
			portBox.Size = new System.Drawing.Size(185, 22);
			portBox.TabIndex = 18;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(18, 187);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 17);
			label2.TabIndex = 17;
			label2.Text = "Address";
			addressBox.BackColor = System.Drawing.Color.DimGray;
			addressBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			addressBox.ForeColor = System.Drawing.Color.White;
			addressBox.Location = new System.Drawing.Point(78, 184);
			addressBox.MaxLength = 100;
			addressBox.Name = "addressBox";
			addressBox.Size = new System.Drawing.Size(185, 22);
			addressBox.TabIndex = 16;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(26, 140);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(50, 17);
			label1.TabIndex = 15;
			label1.Text = "Server";
			serverBox.BackColor = System.Drawing.Color.DimGray;
			serverBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			serverBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverBox.ForeColor = System.Drawing.Color.White;
			serverBox.Location = new System.Drawing.Point(78, 137);
			serverBox.MaxLength = 100;
			serverBox.Name = "serverBox";
			serverBox.Size = new System.Drawing.Size(185, 22);
			serverBox.TabIndex = 14;
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.Location = new System.Drawing.Point(266, 27);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(16, 14);
			closeButton.TabIndex = 28;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
			serverCombo.BackColor = System.Drawing.Color.FromArgb(123, 155, 171);
			serverCombo.BorderStyle = Xceed.Editors.EnhancedBorderStyle.None;
			serverCombo.CanSelect = false;
			serverCombo.Controls.Add(serverCombo.TextBoxArea);
			serverCombo.Controls.Add(dropDownButton2);
			serverCombo.DropDownButton = dropDownButton2;
			serverCombo.DropDownControl.BackColor = System.Drawing.Color.FromArgb(123, 155, 171);
			serverCombo.DropDownControl.Font = new System.Drawing.Font("Trebuchet MS", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverCombo.DropDownControl.ForeColor = System.Drawing.SystemColors.Window;
			serverCombo.DropDownControl.InactiveSelectionBackColor = System.Drawing.Color.Transparent;
			serverCombo.DropDownControl.InactiveSelectionForeColor = System.Drawing.Color.Black;
			serverCombo.DropDownControl.SelectionBackColor = System.Drawing.Color.Black;
			serverCombo.DropDownControl.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			serverCombo.DropDownControl.TabIndex = 0;
			serverCombo.DropDownControl.TabStop = false;
			serverCombo.DropDownControl.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			serverCombo.DropDownResizable = false;
			serverCombo.Font = new System.Drawing.Font("Trebuchet MS", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverCombo.ForeColor = System.Drawing.Color.White;
			serverCombo.Location = new System.Drawing.Point(37, 93);
			serverCombo.Name = "serverCombo";
			serverCombo.Size = new System.Drawing.Size(235, 20);
			serverCombo.TabIndex = 29;
			serverCombo.SelectedItemChanged += new System.EventHandler(serverCombo_SelectedItemChanged);
			dropDownButton2.BackColor = System.Drawing.Color.Transparent;
			dropDownButton2.CanSelect = false;
			dropDownButton2.CausesValidation = false;
			dropDownButton2.Dock = System.Windows.Forms.DockStyle.Right;
			dropDownButton2.ForeColor = System.Drawing.SystemColors.ControlText;
			dropDownButton2.Image = (System.Drawing.Image)resources.GetObject("dropDownButton2.Image");
			dropDownButton2.Location = new System.Drawing.Point(214, 0);
			dropDownButton2.Name = "dropDownButton2";
			dropDownButton2.Size = new System.Drawing.Size(21, 20);
			dropDownButton2.TabIndex = 1;
			updateButton.BackColor = System.Drawing.Color.Transparent;
			updateButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			updateButton.FlatAppearance.BorderSize = 0;
			updateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			updateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			updateButton.ImageIndex = 0;
			updateButton.ImageList = buttonImages;
			updateButton.Location = new System.Drawing.Point(37, 420);
			updateButton.Name = "updateButton";
			updateButton.Size = new System.Drawing.Size(97, 22);
			updateButton.TabIndex = 30;
			updateButton.UseVisualStyleBackColor = false;
			updateButton.MouseLeave += new System.EventHandler(updateButton_MouseLeave);
			updateButton.Click += new System.EventHandler(updateButton_Click);
			updateButton.MouseEnter += new System.EventHandler(updateButton_MouseEnter);
			buttonImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("buttonImages.ImageStream");
			buttonImages.TransparentColor = System.Drawing.Color.Transparent;
			buttonImages.Images.SetKeyName(0, "update_base.png");
			buttonImages.Images.SetKeyName(1, "update_mouseover.png");
			buttonImages.Images.SetKeyName(2, "remove_base.png");
			buttonImages.Images.SetKeyName(3, "remove_mouseover.png");
			removeButton.BackColor = System.Drawing.Color.Transparent;
			removeButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			removeButton.FlatAppearance.BorderSize = 0;
			removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			removeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			removeButton.ImageIndex = 2;
			removeButton.ImageList = buttonImages;
			removeButton.Location = new System.Drawing.Point(158, 415);
			removeButton.Name = "removeButton";
			removeButton.Size = new System.Drawing.Size(105, 32);
			removeButton.TabIndex = 31;
			removeButton.UseVisualStyleBackColor = false;
			removeButton.MouseLeave += new System.EventHandler(removeButton_MouseLeave);
			removeButton.Click += new System.EventHandler(removeButton_Click);
			removeButton.MouseEnter += new System.EventHandler(removeButton_MouseEnter);
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.ForeColor = System.Drawing.Color.White;
			label5.Location = new System.Drawing.Point(90, 279);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(124, 17);
			label5.TabIndex = 33;
			label5.Text = "Advanced Options";
			checkBox1.AutoSize = true;
			checkBox1.BackColor = System.Drawing.Color.Transparent;
			checkBox1.ForeColor = System.Drawing.Color.White;
			checkBox1.Location = new System.Drawing.Point(93, 321);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(123, 21);
			checkBox1.TabIndex = 34;
			checkBox1.Text = "Custom Server";
			checkBox1.UseVisualStyleBackColor = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(290, 475);
			base.Controls.Add(checkBox1);
			base.Controls.Add(label5);
			base.Controls.Add(removeButton);
			base.Controls.Add(updateButton);
			base.Controls.Add(serverCombo);
			base.Controls.Add(closeButton);
			base.Controls.Add(label4);
			base.Controls.Add(linkBox);
			base.Controls.Add(label3);
			base.Controls.Add(portBox);
			base.Controls.Add(label2);
			base.Controls.Add(addressBox);
			base.Controls.Add(label1);
			base.Controls.Add(serverBox);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "EditServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "EditServer";
			base.TopMost = true;
			base.TransparencyKey = System.Drawing.Color.Red;
			base.Load += new System.EventHandler(EditServer_Load);
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(EditServer_MouseUp);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(EditServer_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(EditServer_MouseMove);
			((System.ComponentModel.ISupportInitialize)serverCombo.DropDownControl).EndInit();
			((System.ComponentModel.ISupportInitialize)serverCombo).EndInit();
			serverCombo.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public EditServer()
		{
			InitializeComponent();
		}

		private void EditServer_Load(object sender, EventArgs e)
		{
			buildServersObject();
			updateDropDown();
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
					if (server.downloadLink == "null")
					{
						server.downloadLink = "";
					}
					LPE.serverArrayList.Add(server);
				}
			}
		}

		public void updateDropDown()
		{
			serverCombo.Items.Clear();
			for (int i = 0; i < LPE.serverArrayList.Count; i++)
			{
				serverCombo.Items.Add(((Server)LPE.serverArrayList[i]).sname);
			}
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

		private void closeButton_Click(object sender, EventArgs e)
		{
			base.Owner.Close();
		}

		private void serverCombo_SelectedItemChanged(object sender, EventArgs e)
		{
			Server serverFromArrayList = LPE.getServerFromArrayList(serverCombo.TextBoxArea.Text);
			serverBox.Text = serverFromArrayList.sname;
			addressBox.Text = serverFromArrayList.saddress;
			portBox.Text = serverFromArrayList.sport;
			if (serverFromArrayList.standard == "1")
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
			linkBox.Text = serverFromArrayList.downloadLink;
			GC.Collect();
		}

		private void updateButton_MouseEnter(object sender, EventArgs e)
		{
			updateButton.Image = buttonImages.Images[1];
			GC.Collect();
		}

		private void updateButton_MouseLeave(object sender, EventArgs e)
		{
			if (!buttonImages.Images.Empty)
			{
				updateButton.Image = buttonImages.Images[0];
			}
			GC.Collect();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			try
			{
				Server serverFromArrayList = LPE.getServerFromArrayList(serverCombo.TextBoxArea.Text);
				if (serverFromArrayList != null)
				{
					serverFromArrayList.sname = serverBox.Text;
					serverFromArrayList.saddress = addressBox.Text;
					serverFromArrayList.sport = portBox.Text;
					serverFromArrayList.standard = checkBox1.Checked.ToString();
					if (checkBox1.Checked)
					{
						serverFromArrayList.downloadLink = linkBox.Text;
					}
					else
					{
						serverFromArrayList.downloadLink = "null";
					}
					writeCustomServerFile();
					buildServersObject();
					updateDropDown();
					base.Owner.Close();
				}
				else
				{
					MessageBox.Show("Error in Entry");
				}
			}
			catch (Exception)
			{
			}
		}

		private void removeButton_MouseEnter(object sender, EventArgs e)
		{
			removeButton.Image = buttonImages.Images[3];
			GC.Collect();
		}

		private void removeButton_MouseLeave(object sender, EventArgs e)
		{
			if (buttonImages.Images.Count > 2)
			{
				removeButton.Image = buttonImages.Images[2];
				GC.Collect();
			}
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			Server serverFromArrayList = LPE.getServerFromArrayList(serverCombo.TextBoxArea.Text);
			if (serverFromArrayList != null)
			{
				LPE.serverArrayList.Remove(serverFromArrayList);
				writeCustomServerFile();
				buildServersObject();
				updateDropDown();
			}
			base.Owner.Close();
		}

		private void EditServer_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void EditServer_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void EditServer_MouseMove(object sender, MouseEventArgs e)
		{
			if (!bProcessingEvent && bMouseDown)
			{
				bProcessingEvent = true;
				base.DesktopLocation = new Point(base.Location.X + e.X - pntMousePosition.X, base.Location.Y + e.Y - pntMousePosition.Y);
				bProcessingEvent = false;
			}
		}
	}
}
