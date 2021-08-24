using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	public class InitialEmuSetup : Form
	{
		private IContainer components;

		private RichTextBox richTextBox1;

		private Label label1;

		private TextBox swgInstalledTextbox;

		private Button swgInstalledButton;

		private TextBox sourceTextbox;

		private Label label2;

		private Button firewallTestButton;

		private TextBox firewallTextBox;

		private Label label4;

		private Label label3;

		private TextBox installLocation;

		private Button button2;

		private TextBox locationOkTextBox;

		private Button okButton;

		private Button button1;

		private Label label6;

		private Button button3;

		private BackgroundWorker findSWGWorker;

		private string soeRegPath = "Software\\Sony Online Entertainment\\Station LaunchPad\\BkMrks";

		private string soeRegKey = "Lp18starwars4main";

		private string emuRegPath = "Software\\SWGEmuLPE";

		private string[] rootDrive = Environment.GetEnvironmentVariable("windir").Split('\\');

		private bool failed;

		private string SWGLocation;

		public bool show;

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
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			label1 = new System.Windows.Forms.Label();
			swgInstalledTextbox = new System.Windows.Forms.TextBox();
			swgInstalledButton = new System.Windows.Forms.Button();
			sourceTextbox = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			firewallTestButton = new System.Windows.Forms.Button();
			firewallTextBox = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			installLocation = new System.Windows.Forms.TextBox();
			button2 = new System.Windows.Forms.Button();
			locationOkTextBox = new System.Windows.Forms.TextBox();
			okButton = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			findSWGWorker = new System.ComponentModel.BackgroundWorker();
			SuspendLayout();
			richTextBox1.BackColor = System.Drawing.SystemColors.Control;
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			richTextBox1.Location = new System.Drawing.Point(33, 27);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new System.Drawing.Size(343, 113);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = "Welcome to the SWG Emu Setup Wizard.  This application is designed to help you painlessly get the emulator setup.  Please read the instructions and you will soon be able to log on and play.";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 143);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(153, 17);
			label1.TabIndex = 1;
			label1.Text = "SWG Installed..............";
			swgInstalledTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			swgInstalledTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			swgInstalledTextbox.ForeColor = System.Drawing.Color.White;
			swgInstalledTextbox.Location = new System.Drawing.Point(185, 144);
			swgInstalledTextbox.Name = "swgInstalledTextbox";
			swgInstalledTextbox.Size = new System.Drawing.Size(100, 17);
			swgInstalledTextbox.TabIndex = 2;
			swgInstalledTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			swgInstalledButton.Location = new System.Drawing.Point(298, 135);
			swgInstalledButton.Name = "swgInstalledButton";
			swgInstalledButton.Size = new System.Drawing.Size(75, 23);
			swgInstalledButton.TabIndex = 3;
			swgInstalledButton.Text = "Change";
			swgInstalledButton.UseVisualStyleBackColor = true;
			swgInstalledButton.Click += new System.EventHandler(swgInstalledButton_Click);
			sourceTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			sourceTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			sourceTextbox.ForeColor = System.Drawing.Color.White;
			sourceTextbox.Location = new System.Drawing.Point(185, 207);
			sourceTextbox.Name = "sourceTextbox";
			sourceTextbox.Size = new System.Drawing.Size(100, 17);
			sourceTextbox.TabIndex = 5;
			sourceTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 207);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(152, 17);
			label2.TabIndex = 4;
			label2.Text = "Location to install EMU";
			firewallTestButton.Location = new System.Drawing.Point(298, 168);
			firewallTestButton.Name = "firewallTestButton";
			firewallTestButton.Size = new System.Drawing.Size(75, 23);
			firewallTestButton.TabIndex = 11;
			firewallTestButton.Text = "Fix";
			firewallTestButton.UseVisualStyleBackColor = true;
			firewallTestButton.Click += new System.EventHandler(firewallTestButton_Click);
			firewallTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			firewallTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			firewallTextBox.ForeColor = System.Drawing.Color.White;
			firewallTextBox.Location = new System.Drawing.Point(185, 175);
			firewallTextBox.Name = "firewallTextBox";
			firewallTextBox.Size = new System.Drawing.Size(100, 17);
			firewallTextBox.TabIndex = 10;
			firewallTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(27, 175);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(155, 17);
			label4.TabIndex = 9;
			label4.Text = "Firewall.........................";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(27, 253);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(81, 17);
			label3.TabIndex = 13;
			label3.Text = "Location ok";
			installLocation.BackColor = System.Drawing.SystemColors.Control;
			installLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			installLocation.Location = new System.Drawing.Point(30, 342);
			installLocation.Name = "installLocation";
			installLocation.Size = new System.Drawing.Size(343, 15);
			installLocation.TabIndex = 16;
			installLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			button2.Location = new System.Drawing.Point(298, 204);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 17;
			button2.Text = "Change";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			locationOkTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			locationOkTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			locationOkTextBox.ForeColor = System.Drawing.Color.White;
			locationOkTextBox.Location = new System.Drawing.Point(185, 254);
			locationOkTextBox.Name = "locationOkTextBox";
			locationOkTextBox.Size = new System.Drawing.Size(100, 17);
			locationOkTextBox.TabIndex = 18;
			locationOkTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			okButton.Location = new System.Drawing.Point(211, 284);
			okButton.Name = "okButton";
			okButton.Size = new System.Drawing.Size(74, 24);
			okButton.TabIndex = 21;
			okButton.Text = "Continue";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += new System.EventHandler(okButton_Click);
			button1.Location = new System.Drawing.Point(108, 284);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 24);
			button1.TabIndex = 22;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(30, 231);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(0, 17);
			label6.TabIndex = 23;
			button3.Location = new System.Drawing.Point(298, 248);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 23);
			button3.TabIndex = 24;
			button3.Text = "Why?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			findSWGWorker.WorkerSupportsCancellation = true;
			findSWGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(findSWGWorker_DoWork);
			findSWGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(findSWGWorker_RunWorkerCompleted);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(385, 334);
			base.Controls.Add(button3);
			base.Controls.Add(label6);
			base.Controls.Add(button1);
			base.Controls.Add(okButton);
			base.Controls.Add(locationOkTextBox);
			base.Controls.Add(button2);
			base.Controls.Add(installLocation);
			base.Controls.Add(label3);
			base.Controls.Add(firewallTestButton);
			base.Controls.Add(firewallTextBox);
			base.Controls.Add(label4);
			base.Controls.Add(sourceTextbox);
			base.Controls.Add(label2);
			base.Controls.Add(swgInstalledButton);
			base.Controls.Add(swgInstalledTextbox);
			base.Controls.Add(label1);
			base.Controls.Add(richTextBox1);
			base.Name = "InitialEmuSetup";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "EMU Setup Wizard";
			base.TopMost = true;
			base.Load += new System.EventHandler(InitialEmuSetup_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public InitialEmuSetup()
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			if (!doesInstallExist())
			{
				LPE.checkForUpdates();
				show = true;
			}
			InitializeComponent();
		}

		private void InitialEmuSetup_Load(object sender, EventArgs e)
		{
			try
			{
				findSWGWorker.WorkerSupportsCancellation = true;
				if (!doesInstallExist())
				{
					base.Visible = true;
					okButton.Enabled = false;
					SWGLocation = LPE.getRegKey(soeRegPath, soeRegKey);
					createConfigFile();
					if (!Directory.Exists(rootDrive[0] + "\\SWGEmu\\"))
					{
						Directory.CreateDirectory(rootDrive[0] + "\\SWGEmu\\");
					}
					findSWGWorker.RunWorkerAsync();
					LPE.setConfigItem("path", rootDrive[0] + "\\SWGEmu\\");
					updateControls();
				}
				else
				{
					base.DialogResult = DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				LPE.unfixableError = true;
				mainForm.writeCrashLog("Error creating reg keys\n" + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private string findSWG(string root)
		{
			string[] directories = Directory.GetDirectories(root + "\\");
			string text = "";
			text = doIHaveSWG("c:\\Program Files\\StarWarsGalaxies\\");
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			string[] array = directories;
			foreach (string dir in array)
			{
				text = doIHaveSWG(dir);
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			return text;
		}

		private string doIHaveSWG(string dir)
		{
			string text = "";
			try
			{
				string[] directories = Directory.GetDirectories(dir);
				string[] files = Directory.GetFiles(dir);
				string[] array = files;
				foreach (string text2 in array)
				{
					if (text2.Contains("bottom.tre"))
					{
						return dir;
					}
				}
				string[] array2 = directories;
				foreach (string dir2 in array2)
				{
					text = doIHaveSWG(dir2);
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
			}
			catch
			{
			}
			return "";
		}

		private void updateControls()
		{
			failed = false;
			if (!string.IsNullOrEmpty(LPE.getConfigItem("sourcePath")) || Directory.Exists(SWGLocation))
			{
				swgInstalledTextbox.BackColor = Color.Green;
				swgInstalledTextbox.Text = "Passed";
				swgInstalledButton.Visible = true;
				if (string.IsNullOrEmpty(LPE.getConfigItem("sourcePath")))
				{
					LPE.setConfigItem("sourcePath", SWGLocation);
				}
			}
			else
			{
				swgInstalledTextbox.BackColor = Color.Red;
				swgInstalledTextbox.Text = "Failed";
				swgInstalledButton.Visible = true;
				failed = true;
			}
			if (LPE.download("http://www.thewildclan.com/1.jpg", LPE.commonFiles + "1.jpg") && LPE.download("http://www.thewildclan.com/2.jpg", LPE.commonFiles + "1.jpg") && LPE.download("http://www.thewildclan.com/3.jpg", LPE.commonFiles + "1.jpg") && LPE.download("http://www.thewildclan.com/4.jpg", LPE.commonFiles + "1.jpg"))
			{
				firewallTextBox.BackColor = Color.Green;
				firewallTextBox.Text = "Passed";
				firewallTestButton.Visible = false;
			}
			else
			{
				firewallTextBox.BackColor = Color.Green;
				firewallTextBox.Text = "Passed";
				firewallTestButton.Visible = false;
			}
			try
			{
				if (string.IsNullOrEmpty(LPE.getConfigItem("path")))
				{
					sourceTextbox.BackColor = Color.Red;
					label6.Text = "Use an empty folder for best results";
					sourceTextbox.Text = "Failed";
					failed = true;
				}
				else
				{
					sourceTextbox.BackColor = Color.Green;
					label6.Text = LPE.getConfigItem("path");
					sourceTextbox.Text = "Passed";
				}
			}
			catch
			{
				sourceTextbox.BackColor = Color.Red;
				sourceTextbox.Text = "Failed";
				failed = true;
			}
			try
			{
				StreamWriter streamWriter = File.CreateText(label6.Text + "test.txt");
				streamWriter.WriteLine("test");
				streamWriter.Close();
				File.Delete(label6.Text + "test.txt");
				locationOkTextBox.BackColor = Color.Green;
				locationOkTextBox.Text = "Passed";
				button3.Visible = false;
			}
			catch
			{
				locationOkTextBox.BackColor = Color.Red;
				locationOkTextBox.Text = "Failed";
				failed = true;
				button3.Visible = true;
			}
			if (!failed)
			{
				okButton.Enabled = true;
			}
		}

		private bool doesInstallExist()
		{
			try
			{
				if (string.IsNullOrEmpty(LPE.getConfigItem("path")) || string.IsNullOrEmpty(LPE.getConfigItem("sourcePath")))
				{
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error checking if Emu install exists: " + ex.Message);
				return false;
			}
		}

		private void createConfigFile()
		{
			try
			{
				LPE.makeSureDirectoryExists(LPE.commonFiles);
				if (File.Exists(LPE.commonFiles + "config.cfg"))
				{
					File.Delete(LPE.commonFiles + "config.cfg");
				}
				StreamWriter streamWriter = File.CreateText(LPE.commonFiles + "config.cfg");
				streamWriter.WriteLine("autoplay = 0");
				streamWriter.WriteLine("lastServer = ");
				streamWriter.WriteLine("path = ");
				streamWriter.WriteLine("skin = Classic");
				streamWriter.WriteLine("sourcePath = ");
				streamWriter.WriteLine("timesRun = 0");
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				LPE.unfixableError = true;
				mainForm.writeCrashLog("Error in 'createConfigFile'\n" + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private void swgInstalledButton_Click(object sender, EventArgs e)
		{
			string text = "";
			string text2 = "";
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			try
			{
				folderBrowserDialog.Description = "Please Locate Existing SWG Install";
				folderBrowserDialog.ShowNewFolderButton = false;
				text2 = "Show Dialog";
				if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
				{
					text = folderBrowserDialog.SelectedPath;
					if (Directory.Exists(text))
					{
						text2 = "Files found";
						if (File.Exists(text + "\\bottom.tre") || File.Exists(text + "\\data_animation_00.tre") || File.Exists(text + "\\data_texture_04.tre"))
						{
							LPE.setConfigItem("sourcePath", text);
							findSWGWorker.CancelAsync();
						}
						else
						{
							text2 = "Files Not found";
							if (File.Exists(text + "\\bottom.tre"))
							{
								LPE.setConfigItem("sourcePath", text);
							}
							else if (File.Exists(text + "\\data_animation_00.tre"))
							{
								LPE.setConfigItem("sourcePath", text);
							}
							else if (File.Exists(text + "\\data_texture_04.tre"))
							{
								LPE.setConfigItem("sourcePath", text);
							}
							else
							{
								MessageBox.Show("The folder you chose does not contain SWG.  Try again", "Missing Files");
							}
						}
					}
				}
				folderBrowserDialog.Dispose();
			}
			catch (Exception ex)
			{
				LPE.unfixableError = true;
				mainForm.writeCrashLog("Error in 'locateSourceInstall'\nChosen Folder = " + text + "\nLocation Found = Error Location = " + text2 + "\n" + ex.Message, ex.StackTrace, ex.Source);
			}
			updateControls();
		}

		private void firewallTestButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Something is blocking this program from accessing the internet.  Or your internet connection is down.\n\nCommon Firewalls:\n\nWindows Firewall\nNorton\nMcAfee\nEtrust\nAnd a thousand more.\n\nOpen access to get this program to work properly");
			updateControls();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			updateControls();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			updateControls();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.ShowNewFolderButton = true;
				folderBrowserDialog.Description = "Choose/Create the folder for Emu install";
				folderBrowserDialog.ShowDialog();
				LPE.makeSureDirectoryExists(folderBrowserDialog.SelectedPath);
				if (Directory.GetDirectories(folderBrowserDialog.SelectedPath).Length == 0 && Directory.GetFiles(folderBrowserDialog.SelectedPath).Length == 0)
				{
					LPE.setConfigItem("path", folderBrowserDialog.SelectedPath);
				}
				else
				{
					DialogResult dialogResult = MessageBox.Show("Folder is not empty, Do you want to use this folder anyways?  (ONLY click 'yes' if you know what you are doing.  IF YOU HAVE NEVER SETUP THE EMU BEFORE, ARE TECHNICALLY CHALLENGED, OR WANT THE EMU TO WORK, CLICK 'NO' AND CREATE AN EMPTY FOLDER!", "Warning!", MessageBoxButtons.YesNo);
					if (dialogResult.ToString().Equals("Yes"))
					{
						LPE.setConfigItem("path", folderBrowserDialog.SelectedPath);
					}
					else
					{
						LPE.setConfigItem("path", "");
					}
				}
				folderBrowserDialog.Dispose();
			}
			catch (Exception)
			{
			}
			updateControls();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (findSWGWorker.IsBusy)
			{
				findSWGWorker.CancelAsync();
			}
			base.DialogResult = DialogResult.OK;
			string configItem = LPE.getConfigItem("path");
			string[] files = Directory.GetFiles(configItem);
			foreach (string text in files)
			{
				FileInfo fileInfo = new FileInfo(text);
				if (!text.Contains(".tre") && !text.Contains("screenshot") && fileInfo.Length < 30000000)
				{
					File.Delete(text);
				}
			}
			string[] directories = Directory.GetDirectories(configItem);
			foreach (string path in directories)
			{
				Directory.Delete(path, recursive: true);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This happens for 2 reasons generally.  A.  You do not have write access to the directory, and B.  You are trying to install the the program files directory on windows vista.  Choose a new location");
		}

		private void findSWGWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			swgInstalledTextbox.Text = "Searching...";
			LPE.setConfigItem("sourcePath", findSWG(rootDrive[0]));
		}

		private void findSWGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			updateControls();
		}
	}
}
