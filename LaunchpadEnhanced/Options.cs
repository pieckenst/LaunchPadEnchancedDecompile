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
	public class Options : Form
	{
		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		private bool multiInstances;

		private string path;

		private string sourcePath;

		private string skin;

		private bool restart;

		private IContainer components;

		private Button minimizeButton;

		private Button closeButton;

		private Label label1;

		private Label label2;

		private Button instanceButton;

		private Label label3;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label4;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private Button classicButton;

		private Button jtlButton;

		private Label label5;

		private Button button5;

		private Button button6;

		private Label label6;

		private Label label7;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private Button button7;

		public Options(string inPath, string inSource)
		{
			path = inPath;
			skin = LPE.getConfigItem("skin");
			sourcePath = inSource;
			InitializeComponent();
			multiInstances = checkMultipleInstances();
			textBox1.Text = path;
			textBox2.Text = sourcePath;
			if (File.Exists(path + "\\object\\creature\\player\\base\\shared_base_player.iff"))
			{
				radioButton1.Checked = true;
				radioButton2.Checked = false;
			}
			else
			{
				radioButton1.Checked = false;
				radioButton2.Checked = true;
			}
		}

		private bool checkMultipleInstances()
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			arrayList = LPE.readFileToString(path + "\\swgemu.cfg");
			arrayList2 = LPE.readFileToString(path + "\\user.cfg");
			if (arrayList.Contains(".include \"user.cfg\"") && arrayList2.Contains("allowMultipleInstances=true"))
			{
				label2.BackColor = Color.Green;
				label2.Text = "True";
				return true;
			}
			label2.BackColor = Color.Crimson;
			label2.Text = "False";
			return false;
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			GC.Collect();
			Close();
		}

		private void minimizeButton_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void Options_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void Options_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void Options_MouseMove(object sender, MouseEventArgs e)
		{
			if (!bProcessingEvent && bMouseDown)
			{
				bProcessingEvent = true;
				base.DesktopLocation = new Point(base.Location.X + e.X - pntMousePosition.X, base.Location.Y + e.Y - pntMousePosition.Y);
				bProcessingEvent = false;
			}
		}

		private void writeNoMultiSWGemucfg()
		{
			try
			{
				StreamWriter streamWriter = File.CreateText(path + "\\swgemu.cfg");
				streamWriter.WriteLine(".include \"swgemu_login.cfg\"");
				streamWriter.WriteLine(".include \"swgemu_live.cfg\"");
				streamWriter.WriteLine(".include \"swgemu_preload.cfg\"");
				streamWriter.WriteLine(".include \"options.cfg\"");
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}

		private void writeYesMultiSWGemucfg()
		{
			try
			{
				StreamWriter streamWriter = File.CreateText(path + "\\swgemu.cfg");
				streamWriter.WriteLine(".include \"swgemu_login.cfg\"");
				streamWriter.WriteLine(".include \"swgemu_live.cfg\"");
				streamWriter.WriteLine(".include \"swgemu_preload.cfg\"");
				streamWriter.WriteLine(".include \"options.cfg\"");
				streamWriter.WriteLine(".include \"user.cfg\"");
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}

		private void writeNoMultiusercfg()
		{
			try
			{
				if (File.Exists(path + "\\user.cfg"))
				{
					File.Delete(path + "\\user.cfg");
				}
			}
			catch (Exception)
			{
			}
		}

		private void writeYesMultiusercfg()
		{
			try
			{
				StreamWriter streamWriter = File.CreateText(path + "\\user.cfg");
				streamWriter.WriteLine("[SwgClient]");
				streamWriter.WriteLine("allowMultipleInstances=true");
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}

		private void instanceButton_Click(object sender, EventArgs e)
		{
			if (!multiInstances)
			{
				writeYesMultiSWGemucfg();
				writeYesMultiusercfg();
			}
			else
			{
				writeNoMultiSWGemucfg();
				writeNoMultiusercfg();
			}
			multiInstances = checkMultipleInstances();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Select new EMU path";
			folderBrowserDialog.ShowDialog();
			if (Directory.Exists(textBox2.Text) && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
			{
				textBox1.Text = folderBrowserDialog.SelectedPath;
				writeFile();
				restart = true;
			}
		}

		private void writeFile()
		{
			try
			{
				LPE.setConfigItem("path", textBox1.Text);
				LPE.setConfigItem("sourcePath", textBox2.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in writing to registry: " + ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Select new SOURCE path";
			folderBrowserDialog.ShowDialog();
			if (Directory.Exists(folderBrowserDialog.SelectedPath))
			{
				if (File.Exists(folderBrowserDialog.SelectedPath + "\\bottom.tre") || File.Exists(folderBrowserDialog.SelectedPath + "\\data_animation_00.tre") || File.Exists(folderBrowserDialog.SelectedPath + "\\data_texture_04.tre"))
				{
					textBox2.Text = folderBrowserDialog.SelectedPath;
					writeFile();
					restart = true;
				}
				else
				{
					MessageBox.Show("This folder does not have SWG installed to it");
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(textBox1.Text);
			}
			catch
			{
				MessageBox.Show("Error opening: " + textBox1.Text);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(textBox2.Text);
			}
			catch
			{
				MessageBox.Show("Error opening: " + textBox2.Text);
			}
		}

		private void Options_Load(object sender, EventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				LPE.setConfigItem("skin", "Classic");
				restart = true;
				MessageBox.Show("Classic skin chosen, close options to continue");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in writing to registry: " + ex.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				LPE.setConfigItem("skin", "JTL");
				restart = true;
				MessageBox.Show("JTL skin chosen, close options to continue");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in writing to registry: " + ex.Message);
			}
		}

		private void Options_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (restart)
			{
				restart = false;
				MessageBox.Show("Changes made require Launchpad to restart");
				Application.Restart();
			}
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			textBox2.Text = textBox1.Text;
			writeFile();
			LPE.totalReset(textBox1.Text);
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("This will delete everything but TRE file and everything will download from the server. IF you still have errors after this hit the 'Complete Repair' buttonThere is no reversing this.  CLick yes if you are having trouble with crashes", "Warning!", MessageBoxButtons.YesNo);
			if (dialogResult.ToString().Equals("Yes"))
			{
				textBox2.Text = textBox1.Text;
				writeFile();
				LPE.partialReset(textBox1.Text);
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				File.Delete(path + "\\object\\creature\\player\\base\\shared_base_player.iff");
			}
			catch
			{
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				LPE.makeSureDirectoryExists(path, "object\\creature\\player\\base\\");
				LPE.download(LPE.patchLocation + "object/creature/player/base/shared_base_player.iff", path + "\\object\\creature\\player\\base\\shared_base_player.iff");
			}
			catch
			{
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("This will delete your config file and replace them with default ones", "Warning!", MessageBoxButtons.YesNo);
			if (!dialogResult.ToString().Equals("Yes"))
			{
				return;
			}
			string[] files = Directory.GetFiles(path);
			foreach (string text in files)
			{
				new FileInfo(text);
				if (text.Contains(".cfg"))
				{
					File.Delete(text);
				}
			}
			Application.Restart();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.Options));
			minimizeButton = new System.Windows.Forms.Button();
			closeButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			instanceButton = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			classicButton = new System.Windows.Forms.Button();
			jtlButton = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			button7 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			minimizeButton.BackColor = System.Drawing.Color.Transparent;
			minimizeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("minimizeButton.BackgroundImage");
			minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			minimizeButton.FlatAppearance.BorderSize = 0;
			minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			minimizeButton.Location = new System.Drawing.Point(612, 1);
			minimizeButton.Name = "minimizeButton";
			minimizeButton.Size = new System.Drawing.Size(16, 14);
			minimizeButton.TabIndex = 3;
			minimizeButton.Text = "button1";
			minimizeButton.UseVisualStyleBackColor = false;
			minimizeButton.Click += new System.EventHandler(minimizeButton_Click);
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.Location = new System.Drawing.Point(628, 1);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(16, 14);
			closeButton.TabIndex = 2;
			closeButton.Text = "button1";
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Trebuchet MS", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(69, 386);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(178, 22);
			label1.TabIndex = 4;
			label1.Text = "Allow Multiple Instances";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Trebuchet MS", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(307, 386);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(45, 22);
			label2.TabIndex = 5;
			label2.Text = "False";
			instanceButton.BackColor = System.Drawing.SystemColors.Control;
			instanceButton.Location = new System.Drawing.Point(372, 384);
			instanceButton.Name = "instanceButton";
			instanceButton.Size = new System.Drawing.Size(84, 28);
			instanceButton.TabIndex = 6;
			instanceButton.Text = "Toggle";
			instanceButton.UseVisualStyleBackColor = false;
			instanceButton.Click += new System.EventHandler(instanceButton_Click);
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.White;
			label3.Location = new System.Drawing.Point(31, 48);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(107, 20);
			label3.TabIndex = 7;
			label3.Text = "Emu Location";
			textBox1.Font = new System.Drawing.Font("Trebuchet MS", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.Location = new System.Drawing.Point(168, 45);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(341, 26);
			textBox1.TabIndex = 8;
			textBox2.Font = new System.Drawing.Font("Trebuchet MS", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox2.Location = new System.Drawing.Point(168, 84);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(341, 26);
			textBox2.TabIndex = 10;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.White;
			label4.Location = new System.Drawing.Point(12, 88);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(125, 20);
			label4.TabIndex = 9;
			label4.Text = "Source Location";
			button1.BackColor = System.Drawing.SystemColors.Control;
			button1.Location = new System.Drawing.Point(515, 45);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 30);
			button1.TabIndex = 11;
			button1.Text = "Change";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			button2.BackColor = System.Drawing.SystemColors.Control;
			button2.Location = new System.Drawing.Point(515, 85);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 30);
			button2.TabIndex = 12;
			button2.Text = "Change";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(button2_Click);
			button3.BackColor = System.Drawing.SystemColors.Control;
			button3.Location = new System.Drawing.Point(596, 85);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(56, 30);
			button3.TabIndex = 14;
			button3.Text = "Open";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click);
			button4.BackColor = System.Drawing.SystemColors.Control;
			button4.Location = new System.Drawing.Point(596, 45);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(56, 30);
			button4.TabIndex = 15;
			button4.Text = "Open";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new System.EventHandler(button4_Click);
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
			pictureBox1.Location = new System.Drawing.Point(25, 144);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(200, 200);
			pictureBox1.TabIndex = 16;
			pictureBox1.TabStop = false;
			pictureBox2.BackColor = System.Drawing.Color.Transparent;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox2.InitialImage");
			pictureBox2.Location = new System.Drawing.Point(296, 144);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(200, 200);
			pictureBox2.TabIndex = 17;
			pictureBox2.TabStop = false;
			classicButton.BackColor = System.Drawing.SystemColors.Control;
			classicButton.Location = new System.Drawing.Point(85, 334);
			classicButton.Name = "classicButton";
			classicButton.Size = new System.Drawing.Size(75, 23);
			classicButton.TabIndex = 18;
			classicButton.Text = "Pick Me";
			classicButton.UseVisualStyleBackColor = false;
			classicButton.Click += new System.EventHandler(button5_Click);
			jtlButton.BackColor = System.Drawing.SystemColors.Control;
			jtlButton.Location = new System.Drawing.Point(379, 336);
			jtlButton.Name = "jtlButton";
			jtlButton.Size = new System.Drawing.Size(75, 23);
			jtlButton.TabIndex = 19;
			jtlButton.Text = "Pick Me";
			jtlButton.UseVisualStyleBackColor = false;
			jtlButton.Click += new System.EventHandler(button6_Click);
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.ForeColor = System.Drawing.Color.White;
			label5.Location = new System.Drawing.Point(111, 124);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(227, 13);
			label5.TabIndex = 20;
			label5.Text = "Just press the button and close to change skin";
			button5.BackColor = System.Drawing.SystemColors.Control;
			button5.Location = new System.Drawing.Point(520, 205);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(116, 36);
			button5.TabIndex = 21;
			button5.Text = "Complete Repair";
			button5.UseVisualStyleBackColor = false;
			button5.Click += new System.EventHandler(button5_Click_1);
			button6.BackColor = System.Drawing.SystemColors.Control;
			button6.Location = new System.Drawing.Point(520, 163);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(116, 36);
			button6.TabIndex = 22;
			button6.Text = "Fast Repair";
			button6.UseVisualStyleBackColor = false;
			button6.Click += new System.EventHandler(button6_Click_1);
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.White;
			label6.Location = new System.Drawing.Point(530, 135);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(98, 16);
			label6.TabIndex = 23;
			label6.Text = "Repair Options";
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.ForeColor = System.Drawing.Color.White;
			label7.Location = new System.Drawing.Point(530, 328);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(104, 16);
			label7.TabIndex = 24;
			label7.Text = "Movement Style";
			radioButton1.AutoSize = true;
			radioButton1.BackColor = System.Drawing.Color.Transparent;
			radioButton1.ForeColor = System.Drawing.Color.White;
			radioButton1.Location = new System.Drawing.Point(533, 355);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(80, 17);
			radioButton1.TabIndex = 25;
			radioButton1.TabStop = true;
			radioButton1.Text = "Old Smooth";
			radioButton1.UseVisualStyleBackColor = false;
			radioButton1.Click += new System.EventHandler(radioButton1_CheckedChanged);
			radioButton2.AutoSize = true;
			radioButton2.BackColor = System.Drawing.Color.Transparent;
			radioButton2.ForeColor = System.Drawing.Color.White;
			radioButton2.Location = new System.Drawing.Point(533, 389);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(86, 17);
			radioButton2.TabIndex = 26;
			radioButton2.TabStop = true;
			radioButton2.Text = "New Snappy";
			radioButton2.UseVisualStyleBackColor = false;
			radioButton2.Click += new System.EventHandler(radioButton2_CheckedChanged);
			button7.BackColor = System.Drawing.SystemColors.Control;
			button7.Location = new System.Drawing.Point(520, 247);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(116, 36);
			button7.TabIndex = 27;
			button7.Text = "Config Repair";
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Red;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new System.Drawing.Size(664, 450);
			base.Controls.Add(button7);
			base.Controls.Add(radioButton2);
			base.Controls.Add(radioButton1);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(button6);
			base.Controls.Add(button5);
			base.Controls.Add(label5);
			base.Controls.Add(jtlButton);
			base.Controls.Add(classicButton);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(button4);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label4);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(instanceButton);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(minimizeButton);
			base.Controls.Add(closeButton);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Options";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Options";
			base.TransparencyKey = System.Drawing.Color.Red;
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(Options_MouseUp);
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Options_FormClosing);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(Options_MouseMove);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Options_MouseDown);
			base.Load += new System.EventHandler(Options_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
