using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	public class ThemeBrowser : Form
	{
		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		private ArrayList remote = new ArrayList();

		private ArrayList local = new ArrayList();

		private string pathToEmu;

		private int progress;

		private IContainer components;

		private Button closeButton;

		private Button minimizeButton;

		private ListBox availableBackgrounds;

		private PictureBox pictureBox1;

		private Button changeThemeButton;

		private Label label1;

		private Button resetButton;

		private SmoothProgressBar downloadBar;

		private BackgroundWorker downloader;

		private Label label2;

		private BackgroundWorker statusWorker;

		public ThemeBrowser(string inString)
		{
			pathToEmu = inString;
			InitializeComponent();
		}

		private void ThemeBrowser_Load(object sender, EventArgs e)
		{
			loadThemes();
			loadListBoxes();
			label2.Text = "";
			downloadBar.Value = 0;
		}

		private void loadThemes()
		{
			try
			{
				File.Delete(LPE.commonFiles + "login.txt");
				LPE.download(LPE.themeLocation + "login.txt", LPE.commonFiles + "login.txt");
				remote = LPE.readFileToString(LPE.commonFiles + "login.txt");
			}
			catch
			{
			}
		}

		private void loadListBoxes()
		{
			for (int i = 0; i < remote.Count; i++)
			{
				availableBackgrounds.Items.Add(remote[i]);
			}
		}

		private void availableBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (availableBackgrounds.SelectedItem != null)
				{
					string text = availableBackgrounds.SelectedItem.ToString();
					LPE.makeSureDirectoryExists(LPE.commonFiles + "themes\\login");
					ArrayList folders = getFolders(Directory.GetDirectories(LPE.commonFiles + "themes\\login"));
					LPE.makeSureDirectoryExists(LPE.commonFiles + "themes\\login\\" + text);
					if (!folders.Contains(text))
					{
						LPE.download(LPE.themeLocation + "login/" + text + "/preview1.jpg", LPE.commonFiles + "themes\\login\\" + text + "\\preview1.jpg");
					}
					if (!File.Exists(LPE.commonFiles + "themes\\login\\" + text + "\\preview1.jpg"))
					{
						LPE.download(LPE.themeLocation + "login/" + text + "/preview1.jpg", LPE.commonFiles + "themes\\login\\" + text + "\\preview1.jpg");
					}
					pictureBox1.Image = Image.FromFile(LPE.commonFiles + "themes\\login\\" + text + "\\preview1.jpg");
				}
			}
			catch (Exception)
			{
			}
		}

		private ArrayList getFolders(string[] inArray)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < inArray.Length; i++)
			{
				arrayList.Add(inArray[i].ToString().Substring(inArray[i].ToString().LastIndexOf('\\') + 1));
			}
			return arrayList;
		}

		private void ThemeBrowser_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void ThemeBrowser_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void ThemeBrowser_MouseMove(object sender, MouseEventArgs e)
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
			GC.Collect();
			Close();
		}

		private void minimizeButton_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void changeThemeButton_Click(object sender, EventArgs e)
		{
			File.Delete(pathToEmu + "\\music\\mus_title_lp.mp3");
			File.Delete(pathToEmu + "\\texture\\ui_background_arrow.dds");
			File.Delete(pathToEmu + "\\texture\\ui_logo_lucas.dds");
			File.Delete(pathToEmu + "\\texture\\ui_logo_soe.dds");
			File.Delete(pathToEmu + "\\texture\\ui_starwars_logo_jtl.dds");
			if (File.Exists(pathToEmu + "\\ui\\ui_loginscreen.inc"))
			{
				File.Delete(pathToEmu + "\\ui\\ui_loginscreen.inc");
			}
			changeThemeButton.Enabled = false;
			resetButton.Enabled = false;
			downloader.RunWorkerAsync();
		}

		private bool existsLocally(string inString)
		{
			try
			{
				if (!Directory.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\music"))
				{
					Directory.CreateDirectory(LPE.commonFiles + "themes\\login\\" + inString + "\\music");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\music\\mus_title_lp.mp3"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/music/mus_title_lp.mp3", LPE.commonFiles + "themes\\login\\" + inString + "\\music\\temp.mp3");
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\music\\temp.mp3");
					fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\music\\mus_title_lp.mp3");
				}
				if (!Directory.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\texture"))
				{
					Directory.CreateDirectory(LPE.commonFiles + "themes\\login\\" + inString + "\\texture");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_background_arrow.dds"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/texture/ui_background_arrow.dds", LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_background_arrow.dds");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_logo_lucas.dds"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/texture/ui_logo_lucas.dds", LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_logo_lucas.dds");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_logo_soe.dds"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/texture/ui_logo_soe.dds", LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_logo_soe.dds");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_starwars_logo_jtl.dds"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/texture/ui_starwars_logo_jtl.dds", LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\temp.dds");
					fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\texture\\ui_starwars_logo_jtl.dds");
				}
				if (!Directory.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\ui"))
				{
					Directory.CreateDirectory("themes\\login\\" + inString + "\\ui");
				}
				if (!File.Exists(LPE.commonFiles + "themes\\login\\" + inString + "\\ui\\ui_loginscreen.inc"))
				{
					LPE.download(LPE.themeLocation + "login/" + inString + "/ui/ui_loginscreen.inc", LPE.commonFiles + "themes\\login\\" + inString + "\\ui\\temp.inc");
					try
					{
						FileInfo fileInfo = new FileInfo(LPE.commonFiles + "themes\\login\\" + inString + "\\ui\\temp.inc");
						fileInfo.MoveTo(LPE.commonFiles + "themes\\login\\" + inString + "\\ui\\ui_loginscreen.inc");
					}
					catch
					{
					}
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show("Error LPE.downloading theme" + ex.Message);
				return false;
			}
			return true;
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			LPE.themeReset(pathToEmu);
			MessageBox.Show("Backgrounds and music reset to normal");
		}

		private void downloader_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				string text = availableBackgrounds.SelectedItem.ToString();
				if (existsLocally(text))
				{
					File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\music\\mus_title_lp.mp3", pathToEmu + "\\music\\mus_title_lp.mp3", overwrite: true);
					File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\texture\\ui_background_arrow.dds", pathToEmu + "\\texture\\ui_background_arrow.dds", overwrite: true);
					File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\texture\\ui_logo_lucas.dds", pathToEmu + "\\texture\\ui_logo_lucas.dds", overwrite: true);
					File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\texture\\ui_logo_soe.dds", pathToEmu + "\\texture\\ui_logo_soe.dds", overwrite: true);
					File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\texture\\ui_starwars_logo_jtl.dds", pathToEmu + "\\texture\\ui_starwars_logo_jtl.dds", overwrite: true);
					if (File.Exists(LPE.commonFiles + "themes\\login\\" + text + "\\ui\\ui_loginscreen.inc"))
					{
						File.Copy(LPE.commonFiles + "themes\\login\\" + text + "\\ui\\ui_loginscreen.inc", pathToEmu + "\\ui\\ui_loginscreen.inc", overwrite: true);
					}
				}
				else
				{
					MessageBox.Show("Error changing Login Screen");
				}
				Close();
			}
			catch (Exception ex)
			{
				if (ex.Message.ToString().Contains("Object reference not set to an instance of an object."))
				{
					MessageBox.Show("You didn't choose anything");
				}
			}
		}

		private void downloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			changeThemeButton.Enabled = true;
			resetButton.Enabled = true;
		}

		private void downloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			downloadBar.Value = LPE.downloadPercentProgress;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.ThemeBrowser));
			closeButton = new System.Windows.Forms.Button();
			minimizeButton = new System.Windows.Forms.Button();
			availableBackgrounds = new System.Windows.Forms.ListBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			changeThemeButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			resetButton = new System.Windows.Forms.Button();
			downloadBar = new LaunchpadEnhanced.SmoothProgressBar();
			downloader = new System.ComponentModel.BackgroundWorker();
			label2 = new System.Windows.Forms.Label();
			statusWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
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
			closeButton.TabIndex = 0;
			closeButton.Text = "button1";
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
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
			minimizeButton.TabIndex = 1;
			minimizeButton.Text = "button1";
			minimizeButton.UseVisualStyleBackColor = false;
			minimizeButton.Click += new System.EventHandler(minimizeButton_Click);
			availableBackgrounds.BackColor = System.Drawing.SystemColors.InactiveBorder;
			availableBackgrounds.FormattingEnabled = true;
			availableBackgrounds.Location = new System.Drawing.Point(25, 61);
			availableBackgrounds.Name = "availableBackgrounds";
			availableBackgrounds.Size = new System.Drawing.Size(162, 225);
			availableBackgrounds.TabIndex = 2;
			availableBackgrounds.SelectedIndexChanged += new System.EventHandler(availableBackgrounds_SelectedIndexChanged);
			pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
			pictureBox1.Location = new System.Drawing.Point(212, 61);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(400, 300);
			pictureBox1.TabIndex = 3;
			pictureBox1.TabStop = false;
			changeThemeButton.BackColor = System.Drawing.SystemColors.Control;
			changeThemeButton.Location = new System.Drawing.Point(41, 306);
			changeThemeButton.Name = "changeThemeButton";
			changeThemeButton.Size = new System.Drawing.Size(130, 45);
			changeThemeButton.TabIndex = 4;
			changeThemeButton.Text = "Make this my login background";
			changeThemeButton.UseVisualStyleBackColor = false;
			changeThemeButton.Click += new System.EventHandler(changeThemeButton_Click);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.SystemColors.ControlText;
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(453, 383);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(149, 13);
			label1.TabIndex = 5;
			label1.Text = "This form is a work in progress";
			resetButton.BackColor = System.Drawing.SystemColors.Control;
			resetButton.Location = new System.Drawing.Point(72, 395);
			resetButton.Name = "resetButton";
			resetButton.Size = new System.Drawing.Size(66, 23);
			resetButton.TabIndex = 6;
			resetButton.Text = "Reset";
			resetButton.UseVisualStyleBackColor = false;
			resetButton.Click += new System.EventHandler(resetButton_Click);
			downloadBar.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
			downloadBar.Location = new System.Drawing.Point(25, 375);
			downloadBar.Maximum = 100;
			downloadBar.Minimum = 0;
			downloadBar.Name = "downloadBar";
			downloadBar.ProgressBarColor = System.Drawing.Color.Yellow;
			downloadBar.Size = new System.Drawing.Size(162, 14);
			downloadBar.TabIndex = 7;
			downloadBar.Value = 0;
			downloader.DoWork += new System.ComponentModel.DoWorkEventHandler(downloader_DoWork);
			downloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(downloader_RunWorkerCompleted);
			downloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(downloader_ProgressChanged);
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label2.Location = new System.Drawing.Point(22, 355);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(0, 13);
			label2.TabIndex = 8;
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Red;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new System.Drawing.Size(667, 430);
			base.Controls.Add(label2);
			base.Controls.Add(downloadBar);
			base.Controls.Add(resetButton);
			base.Controls.Add(label1);
			base.Controls.Add(changeThemeButton);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(availableBackgrounds);
			base.Controls.Add(minimizeButton);
			base.Controls.Add(closeButton);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ThemeBrowser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ThemeBrowser";
			base.TransparencyKey = System.Drawing.Color.Red;
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(ThemeBrowser_MouseUp);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(ThemeBrowser_MouseMove);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(ThemeBrowser_MouseDown);
			base.Load += new System.EventHandler(ThemeBrowser_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
