using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LauncherEnhanced;
using Xceed.Editors;
using Xceed.UI;

namespace LaunchpadEnhanced
{
	public class mainForm : Form
	{
		private IContainer components;

		private Button closeButton;

		private Button minimizeButton;

		private Button fullScanButton;

		private Button playButton;

		private BackgroundWorker downloadWorker;

		private BackgroundWorker progressWorker;

		private Button swgEmuButton;

		private Button customizeButton;

		private Button profButton;

		private Button macroButton;

		private Button optionsButton;

		private ImageList smallButtonImages;

		private WinButton dropDownButton1;

		private WinComboBox serverCombo;

		private WinButton comboboxButton;

		private ImageList fullScanImages;

		private Button serversButton;

		private ImageList startImages;

		public Label downloadLabel;

		private Label autoplayLabel;

		private Button faqButton;

		private ImageList faqImages;

		private WebBrowser announcementsBrowser;

		private RichTextBox mainTextBox;

		private BackgroundWorker fileScanWorker;

		private Button chatButton;

		private Button gameOptionsButton;

		private BackgroundWorker pingThread;

		private ImageList bigButtonImages;

		private ImageList helpImages;

		private BackgroundWorker loadingWorker;

		private PictureBox miniProgress;

		private PictureBox mainProgress;

		private Label etaLabel;

		private BackgroundWorker autoPlayThread;

		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		private EmuInstall emu;

		private bool faqClicked;

		private bool clientCrash;

		private string[] inStatus;

		private bool updateDrop;

		private bool ran;

		private Server currentServer = new Server();

		private int miniLength;

		private int mainLength;

		//protected override void Dispose(bool disposing)
		//{
			//if (disposing && components != null)
			//{
				//components.Dispose();
			//}
			//base.Dispose(disposing);
		//}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.mainForm));
			closeButton = new System.Windows.Forms.Button();
			minimizeButton = new System.Windows.Forms.Button();
			fullScanButton = new System.Windows.Forms.Button();
			fullScanImages = new System.Windows.Forms.ImageList(components);
			playButton = new System.Windows.Forms.Button();
			startImages = new System.Windows.Forms.ImageList(components);
			downloadWorker = new System.ComponentModel.BackgroundWorker();
			progressWorker = new System.ComponentModel.BackgroundWorker();
			swgEmuButton = new System.Windows.Forms.Button();
			smallButtonImages = new System.Windows.Forms.ImageList(components);
			customizeButton = new System.Windows.Forms.Button();
			bigButtonImages = new System.Windows.Forms.ImageList(components);
			profButton = new System.Windows.Forms.Button();
			macroButton = new System.Windows.Forms.Button();
			optionsButton = new System.Windows.Forms.Button();
			serverCombo = new Xceed.Editors.WinComboBox();
			comboboxButton = new Xceed.Editors.WinButton();
			serversButton = new System.Windows.Forms.Button();
			downloadLabel = new System.Windows.Forms.Label();
			autoplayLabel = new System.Windows.Forms.Label();
			faqButton = new System.Windows.Forms.Button();
			faqImages = new System.Windows.Forms.ImageList(components);
			announcementsBrowser = new System.Windows.Forms.WebBrowser();
			mainTextBox = new System.Windows.Forms.RichTextBox();
			fileScanWorker = new System.ComponentModel.BackgroundWorker();
			chatButton = new System.Windows.Forms.Button();
			gameOptionsButton = new System.Windows.Forms.Button();
			pingThread = new System.ComponentModel.BackgroundWorker();
			helpImages = new System.Windows.Forms.ImageList(components);
			loadingWorker = new System.ComponentModel.BackgroundWorker();
			miniProgress = new System.Windows.Forms.PictureBox();
			mainProgress = new System.Windows.Forms.PictureBox();
			etaLabel = new System.Windows.Forms.Label();
			autoPlayThread = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)serverCombo).BeginInit();
			((System.ComponentModel.ISupportInitialize)serverCombo.DropDownControl).BeginInit();
			serverCombo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)miniProgress).BeginInit();
			((System.ComponentModel.ISupportInitialize)mainProgress).BeginInit();
			SuspendLayout();
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.ForeColor = System.Drawing.Color.Transparent;
			closeButton.Location = new System.Drawing.Point(689, 9);
			closeButton.Margin = new System.Windows.Forms.Padding(0);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(35, 35);
			closeButton.TabIndex = 0;
			closeButton.TabStop = false;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
			minimizeButton.BackColor = System.Drawing.Color.Transparent;
			minimizeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("minimizeButton.BackgroundImage");
			minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			minimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			minimizeButton.FlatAppearance.BorderSize = 0;
			minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			minimizeButton.ForeColor = System.Drawing.Color.Transparent;
			minimizeButton.Location = new System.Drawing.Point(658, 16);
			minimizeButton.Margin = new System.Windows.Forms.Padding(0);
			minimizeButton.Name = "minimizeButton";
			minimizeButton.Size = new System.Drawing.Size(36, 29);
			minimizeButton.TabIndex = 1;
			minimizeButton.TabStop = false;
			minimizeButton.UseVisualStyleBackColor = false;
			minimizeButton.Click += new System.EventHandler(minimizeButton_Click);
			fullScanButton.BackColor = System.Drawing.Color.Transparent;
			fullScanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			fullScanButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			fullScanButton.FlatAppearance.BorderSize = 0;
			fullScanButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			fullScanButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			fullScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			fullScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			fullScanButton.ForeColor = System.Drawing.SystemColors.WindowText;
			fullScanButton.ImageIndex = 0;
			fullScanButton.ImageList = fullScanImages;
			fullScanButton.Location = new System.Drawing.Point(637, 557);
			fullScanButton.Margin = new System.Windows.Forms.Padding(0);
			fullScanButton.Name = "fullScanButton";
			fullScanButton.Size = new System.Drawing.Size(78, 29);
			fullScanButton.TabIndex = 2;
			fullScanButton.TabStop = false;
			fullScanButton.Text = "full scan";
			fullScanButton.UseVisualStyleBackColor = false;
			fullScanButton.MouseLeave += new System.EventHandler(fileScanButton_MouseLeave);
			fullScanButton.Click += new System.EventHandler(fileScanButton_Click);
			fullScanButton.MouseDown += new System.Windows.Forms.MouseEventHandler(fileScanButton_MouseDown);
			fullScanButton.MouseUp += new System.Windows.Forms.MouseEventHandler(fileScanButton_MouseUp);
			fullScanButton.MouseEnter += new System.EventHandler(fileScanButton_MouseEnter);
			fullScanImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("fullScanImages.ImageStream");
			fullScanImages.TransparentColor = System.Drawing.Color.Transparent;
			fullScanImages.Images.SetKeyName(0, "fullscan_base.png");
			fullScanImages.Images.SetKeyName(1, "fullscan_mouseover.png");
			fullScanImages.Images.SetKeyName(2, "fullscan_base.png");
			playButton.BackColor = System.Drawing.Color.Transparent;
			playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			playButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			playButton.FlatAppearance.BorderSize = 0;
			playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			playButton.ForeColor = System.Drawing.Color.Transparent;
			playButton.ImageIndex = 0;
			playButton.ImageList = startImages;
			playButton.Location = new System.Drawing.Point(22, 181);
			playButton.Margin = new System.Windows.Forms.Padding(0);
			playButton.Name = "playButton";
			playButton.Size = new System.Drawing.Size(221, 85);
			playButton.TabIndex = 3;
			playButton.TabStop = false;
			playButton.UseVisualStyleBackColor = false;
			playButton.MouseLeave += new System.EventHandler(playButton_MouseLeave);
			playButton.Click += new System.EventHandler(playButton_Click);
			playButton.MouseDown += new System.Windows.Forms.MouseEventHandler(playButton_MouseDown);
			playButton.MouseUp += new System.Windows.Forms.MouseEventHandler(playButton_MouseUp);
			playButton.MouseEnter += new System.EventHandler(playButton_MouseEnter);
			startImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("startImages.ImageStream");
			startImages.TransparentColor = System.Drawing.Color.Transparent;
			startImages.Images.SetKeyName(0, "play_base.png");
			startImages.Images.SetKeyName(1, "play_mouseover.png");
			startImages.Images.SetKeyName(2, "play_mousedown.png");
			downloadWorker.WorkerReportsProgress = true;
			downloadWorker.WorkerSupportsCancellation = true;
			downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(downloadWorker_DoWork);
			downloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(downloadWorker_RunWorkerCompleted);
			progressWorker.WorkerReportsProgress = true;
			progressWorker.WorkerSupportsCancellation = true;
			progressWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(progressWorker_DoWork);
			progressWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(progressWorker_RunWorkerCompleted);
			swgEmuButton.BackColor = System.Drawing.Color.Transparent;
			swgEmuButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			swgEmuButton.FlatAppearance.BorderSize = 0;
			swgEmuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			swgEmuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			swgEmuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			swgEmuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			swgEmuButton.ForeColor = System.Drawing.SystemColors.WindowText;
			swgEmuButton.ImageIndex = 0;
			swgEmuButton.ImageList = smallButtonImages;
			swgEmuButton.Location = new System.Drawing.Point(421, 557);
			swgEmuButton.Name = "swgEmuButton";
			swgEmuButton.Size = new System.Drawing.Size(97, 29);
			swgEmuButton.TabIndex = 6;
			swgEmuButton.TabStop = false;
			swgEmuButton.Text = "swgemu";
			swgEmuButton.UseVisualStyleBackColor = false;
			swgEmuButton.MouseLeave += new System.EventHandler(swgEmuButton_MouseLeave);
			swgEmuButton.Click += new System.EventHandler(swgEmuButton_Click);
			swgEmuButton.MouseDown += new System.Windows.Forms.MouseEventHandler(swgEmuButton_MouseDown);
			swgEmuButton.MouseUp += new System.Windows.Forms.MouseEventHandler(swgEmuButton_MouseUp);
			swgEmuButton.MouseEnter += new System.EventHandler(swgEmuButton_MouseEnter);
			smallButtonImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("smallButtonImages.ImageStream");
			smallButtonImages.TransparentColor = System.Drawing.Color.Transparent;
			smallButtonImages.Images.SetKeyName(0, "smallButton_base.png");
			smallButtonImages.Images.SetKeyName(1, "smallButton_mouseover.png");
			smallButtonImages.Images.SetKeyName(2, "smallButton_mousedown.png");
			customizeButton.BackColor = System.Drawing.Color.Transparent;
			customizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			customizeButton.FlatAppearance.BorderSize = 0;
			customizeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			customizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			customizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			customizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			customizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			customizeButton.ForeColor = System.Drawing.Color.White;
			customizeButton.ImageIndex = 0;
			customizeButton.ImageList = bigButtonImages;
			customizeButton.Location = new System.Drawing.Point(54, 368);
			customizeButton.Name = "customizeButton";
			customizeButton.Size = new System.Drawing.Size(187, 32);
			customizeButton.TabIndex = 7;
			customizeButton.TabStop = false;
			customizeButton.Text = "customize galaxies";
			customizeButton.UseVisualStyleBackColor = false;
			customizeButton.MouseLeave += new System.EventHandler(customizeButton_MouseLeave);
			customizeButton.Click += new System.EventHandler(customizeButton_Click);
			customizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(customizeButton_MouseDown);
			customizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(customizeButton_MouseUp);
			customizeButton.MouseEnter += new System.EventHandler(customizeButton_MouseEnter);
			bigButtonImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("bigButtonImages.ImageStream");
			bigButtonImages.TransparentColor = System.Drawing.Color.Transparent;
			bigButtonImages.Images.SetKeyName(0, "big_base.png");
			bigButtonImages.Images.SetKeyName(1, "big_mouseover.png");
			bigButtonImages.Images.SetKeyName(2, "big_mousedown.png");
			profButton.BackColor = System.Drawing.Color.Transparent;
			profButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			profButton.FlatAppearance.BorderSize = 0;
			profButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			profButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			profButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			profButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			profButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			profButton.ForeColor = System.Drawing.Color.White;
			profButton.ImageIndex = 0;
			profButton.ImageList = bigButtonImages;
			profButton.Location = new System.Drawing.Point(54, 400);
			profButton.Name = "profButton";
			profButton.Size = new System.Drawing.Size(187, 32);
			profButton.TabIndex = 8;
			profButton.TabStop = false;
			profButton.Text = "character builder";
			profButton.UseVisualStyleBackColor = false;
			profButton.MouseLeave += new System.EventHandler(profButton_MouseLeave);
			profButton.Click += new System.EventHandler(profButton_Click);
			profButton.MouseDown += new System.Windows.Forms.MouseEventHandler(profButton_MouseDown);
			profButton.MouseUp += new System.Windows.Forms.MouseEventHandler(profButton_MouseUp);
			profButton.MouseEnter += new System.EventHandler(profButton_MouseEnter);
			macroButton.BackColor = System.Drawing.Color.Transparent;
			macroButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			macroButton.FlatAppearance.BorderSize = 0;
			macroButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			macroButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			macroButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			macroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			macroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			macroButton.ForeColor = System.Drawing.Color.White;
			macroButton.ImageIndex = 0;
			macroButton.ImageList = bigButtonImages;
			macroButton.Location = new System.Drawing.Point(55, 433);
			macroButton.Name = "macroButton";
			macroButton.Size = new System.Drawing.Size(187, 32);
			macroButton.TabIndex = 9;
			macroButton.TabStop = false;
			macroButton.Text = "macro management";
			macroButton.UseVisualStyleBackColor = false;
			macroButton.MouseLeave += new System.EventHandler(macroButton_MouseLeave);
			macroButton.Click += new System.EventHandler(macroButton_Click);
			macroButton.MouseDown += new System.Windows.Forms.MouseEventHandler(macroButton_MouseDown);
			macroButton.MouseUp += new System.Windows.Forms.MouseEventHandler(macroButton_MouseUp);
			macroButton.MouseEnter += new System.EventHandler(macroButton_MouseEnter);
			optionsButton.BackColor = System.Drawing.Color.Transparent;
			optionsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			optionsButton.FlatAppearance.BorderSize = 0;
			optionsButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			optionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			optionsButton.ForeColor = System.Drawing.Color.White;
			optionsButton.ImageIndex = 0;
			optionsButton.ImageList = bigButtonImages;
			optionsButton.Location = new System.Drawing.Point(54, 465);
			optionsButton.Name = "optionsButton";
			optionsButton.Size = new System.Drawing.Size(187, 32);
			optionsButton.TabIndex = 10;
			optionsButton.TabStop = false;
			optionsButton.Text = "options";
			optionsButton.UseVisualStyleBackColor = false;
			optionsButton.MouseLeave += new System.EventHandler(optionsButton_MouseLeave);
			optionsButton.Click += new System.EventHandler(optionsButton_Click);
			optionsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(optionsButton_MouseDown);
			optionsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(optionsButton_MouseUp);
			optionsButton.MouseEnter += new System.EventHandler(optionsButton_MouseEnter);
			serverCombo.BackColor = System.Drawing.Color.FromArgb(123, 155, 171);
			serverCombo.BorderStyle = Xceed.Editors.EnhancedBorderStyle.None;
			serverCombo.CanSelect = false;
			serverCombo.CausesValidation = false;
			serverCombo.Controls.Add(serverCombo.TextBoxArea);
			serverCombo.Controls.Add(comboboxButton);
			serverCombo.DropDownButton = null;
			serverCombo.DropDownControl.BackColor = System.Drawing.Color.FromArgb(123, 155, 171);
			serverCombo.DropDownControl.Font = new System.Drawing.Font("Trebuchet MS", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverCombo.DropDownControl.ForeColor = System.Drawing.Color.White;
			serverCombo.DropDownControl.InactiveSelectionBackColor = System.Drawing.Color.Transparent;
			serverCombo.DropDownControl.InactiveSelectionForeColor = System.Drawing.Color.Black;
			serverCombo.DropDownControl.SelectionBackColor = System.Drawing.Color.Black;
			serverCombo.DropDownControl.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			serverCombo.DropDownControl.TabIndex = 0;
			serverCombo.DropDownControl.TabStop = false;
			serverCombo.DropDownControl.Trimming = System.Drawing.StringTrimming.None;
			serverCombo.DropDownControl.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			serverCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serverCombo.ForeColor = System.Drawing.Color.White;
			serverCombo.ItemHeight = 25;
			serverCombo.Location = new System.Drawing.Point(269, 31);
			serverCombo.Name = "serverCombo";
			serverCombo.PreserveImageAspectRatio = true;
			serverCombo.Size = new System.Drawing.Size(235, 20);
			serverCombo.TabIndex = 20;
			serverCombo.ValueMember = "";
			serverCombo.SelectedItemChanged += new System.EventHandler(serverCombo_SelectedItemChanged);
			comboboxButton.BackColor = System.Drawing.Color.Transparent;
			comboboxButton.CanSelect = false;
			comboboxButton.CausesValidation = false;
			comboboxButton.Dock = System.Windows.Forms.DockStyle.Right;
			comboboxButton.ForeColor = System.Drawing.SystemColors.ControlText;
			comboboxButton.Image = (System.Drawing.Image)resources.GetObject("comboboxButton.Image");
			comboboxButton.Location = new System.Drawing.Point(214, 0);
			comboboxButton.Name = "comboboxButton";
			comboboxButton.Size = new System.Drawing.Size(21, 20);
			comboboxButton.TabIndex = 1;
			comboboxButton.MouseEnter += new System.EventHandler(serverCombo_MouseEnter);
			serversButton.BackColor = System.Drawing.Color.Transparent;
			serversButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			serversButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			serversButton.FlatAppearance.BorderSize = 0;
			serversButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			serversButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			serversButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			serversButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			serversButton.ForeColor = System.Drawing.SystemColors.WindowText;
			serversButton.ImageIndex = 0;
			serversButton.ImageList = smallButtonImages;
			serversButton.Location = new System.Drawing.Point(528, 557);
			serversButton.Name = "serversButton";
			serversButton.Size = new System.Drawing.Size(97, 29);
			serversButton.TabIndex = 23;
			serversButton.TabStop = false;
			serversButton.Text = "servers";
			serversButton.UseVisualStyleBackColor = false;
			serversButton.MouseLeave += new System.EventHandler(serversButton_MouseLeave);
			serversButton.Click += new System.EventHandler(serversButton_Click);
			serversButton.MouseDown += new System.Windows.Forms.MouseEventHandler(serversButton_MouseDown);
			serversButton.MouseUp += new System.Windows.Forms.MouseEventHandler(serversButton_MouseUp);
			serversButton.MouseEnter += new System.EventHandler(serversButton_MouseEnter);
			downloadLabel.AutoSize = true;
			downloadLabel.BackColor = System.Drawing.Color.Transparent;
			downloadLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			downloadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			downloadLabel.ForeColor = System.Drawing.Color.White;
			downloadLabel.Location = new System.Drawing.Point(60, 264);
			downloadLabel.Name = "downloadLabel";
			downloadLabel.Size = new System.Drawing.Size(0, 13);
			downloadLabel.TabIndex = 14;
			downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			autoplayLabel.AutoSize = true;
			autoplayLabel.BackColor = System.Drawing.Color.Transparent;
			autoplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			autoplayLabel.ForeColor = System.Drawing.Color.White;
			autoplayLabel.Location = new System.Drawing.Point(89, 534);
			autoplayLabel.Name = "autoplayLabel";
			autoplayLabel.Size = new System.Drawing.Size(62, 17);
			autoplayLabel.TabIndex = 14;
			autoplayLabel.Text = "autoplay";
			autoplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			faqButton.BackColor = System.Drawing.Color.Transparent;
			faqButton.FlatAppearance.BorderSize = 0;
			faqButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			faqButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			faqButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			faqButton.ImageIndex = 0;
			faqButton.ImageList = faqImages;
			faqButton.Location = new System.Drawing.Point(62, 531);
			faqButton.Name = "faqButton";
			faqButton.Size = new System.Drawing.Size(24, 22);
			faqButton.TabIndex = 15;
			faqButton.TabStop = false;
			faqButton.UseVisualStyleBackColor = false;
			faqButton.MouseLeave += new System.EventHandler(faqButton_MouseLeave);
			faqButton.Click += new System.EventHandler(faqButton_Click);
			faqButton.MouseEnter += new System.EventHandler(faqButton_MouseEnter);
			faqImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("faqImages.ImageStream");
			faqImages.TransparentColor = System.Drawing.Color.Transparent;
			faqImages.Images.SetKeyName(0, "faqButton_base.png");
			faqImages.Images.SetKeyName(1, "faqButton_mouseover.png");
			faqImages.Images.SetKeyName(2, "faqButton_clicked.png");
			announcementsBrowser.AllowWebBrowserDrop = false;
			announcementsBrowser.Location = new System.Drawing.Point(247, 314);
			announcementsBrowser.Margin = new System.Windows.Forms.Padding(0);
			announcementsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			announcementsBrowser.Name = "announcementsBrowser";
			announcementsBrowser.Size = new System.Drawing.Size(478, 237);
			announcementsBrowser.TabIndex = 24;
			announcementsBrowser.Url = new System.Uri("", System.UriKind.Relative);
			announcementsBrowser.WebBrowserShortcutsEnabled = false;
			mainTextBox.BackColor = System.Drawing.Color.FromArgb(1, 21, 32);
			mainTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			mainTextBox.ForeColor = System.Drawing.SystemColors.Window;
			mainTextBox.Location = new System.Drawing.Point(247, 60);
			mainTextBox.Name = "mainTextBox";
			mainTextBox.ReadOnly = true;
			mainTextBox.ShowSelectionMargin = true;
			mainTextBox.Size = new System.Drawing.Size(478, 253);
			mainTextBox.TabIndex = 25;
			mainTextBox.Text = "";
			mainTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(mainTextBox_LinkClicked);
			fileScanWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(fileScanWorker_DoWork);
			fileScanWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(fileScanWorker_RunWorkerCompleted);
			chatButton.BackColor = System.Drawing.Color.Transparent;
			chatButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			chatButton.FlatAppearance.BorderSize = 0;
			chatButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			chatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			chatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			chatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			chatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			chatButton.ForeColor = System.Drawing.Color.White;
			chatButton.ImageIndex = 0;
			chatButton.ImageList = bigButtonImages;
			chatButton.Location = new System.Drawing.Point(54, 337);
			chatButton.Margin = new System.Windows.Forms.Padding(0);
			chatButton.Name = "chatButton";
			chatButton.Size = new System.Drawing.Size(187, 32);
			chatButton.TabIndex = 27;
			chatButton.TabStop = false;
			chatButton.Text = "chat";
			chatButton.UseVisualStyleBackColor = false;
			chatButton.MouseLeave += new System.EventHandler(chatButton_MouseLeave);
			chatButton.Click += new System.EventHandler(chatButton_Click);
			chatButton.MouseDown += new System.Windows.Forms.MouseEventHandler(chatButton_MouseDown);
			chatButton.MouseUp += new System.Windows.Forms.MouseEventHandler(chatButton_MouseUp);
			chatButton.MouseEnter += new System.EventHandler(chatButton_MouseEnter);
			gameOptionsButton.BackColor = System.Drawing.Color.Transparent;
			gameOptionsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			gameOptionsButton.FlatAppearance.BorderSize = 0;
			gameOptionsButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			gameOptionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			gameOptionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			gameOptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			gameOptionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			gameOptionsButton.ForeColor = System.Drawing.Color.White;
			gameOptionsButton.ImageIndex = 0;
			gameOptionsButton.ImageList = bigButtonImages;
			gameOptionsButton.Location = new System.Drawing.Point(55, 496);
			gameOptionsButton.Name = "gameOptionsButton";
			gameOptionsButton.Size = new System.Drawing.Size(187, 32);
			gameOptionsButton.TabIndex = 28;
			gameOptionsButton.TabStop = false;
			gameOptionsButton.Text = "help";
			gameOptionsButton.UseVisualStyleBackColor = false;
			gameOptionsButton.MouseLeave += new System.EventHandler(gameOptionsButton_MouseLeave);
			gameOptionsButton.Click += new System.EventHandler(gameOptionsButton_Click);
			gameOptionsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(gameOptionsButton_MouseDown);
			gameOptionsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(gameOptionsButton_MouseUp);
			gameOptionsButton.MouseEnter += new System.EventHandler(gameOptionsButton_MouseEnter);
			pingThread.WorkerSupportsCancellation = true;
			pingThread.DoWork += new System.ComponentModel.DoWorkEventHandler(pingThread_DoWork);
			pingThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(pingThread_RunWorkerCompleted);
			helpImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("helpImages.ImageStream");
			helpImages.TransparentColor = System.Drawing.Color.Transparent;
			helpImages.Images.SetKeyName(0, "help2.png");
			helpImages.Images.SetKeyName(1, "help2_mouseover.png");
			loadingWorker.WorkerReportsProgress = true;
			loadingWorker.WorkerSupportsCancellation = true;
			miniProgress.BackColor = System.Drawing.Color.Transparent;
			miniProgress.BackgroundImage = (System.Drawing.Image)resources.GetObject("miniProgress.BackgroundImage");
			miniProgress.Location = new System.Drawing.Point(60, 282);
			miniProgress.Name = "miniProgress";
			miniProgress.Size = new System.Drawing.Size(166, 6);
			miniProgress.TabIndex = 29;
			miniProgress.TabStop = false;
			mainProgress.BackColor = System.Drawing.Color.Transparent;
			mainProgress.BackgroundImage = (System.Drawing.Image)resources.GetObject("mainProgress.BackgroundImage");
			mainProgress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			mainProgress.Location = new System.Drawing.Point(71, 299);
			mainProgress.Name = "mainProgress";
			mainProgress.Size = new System.Drawing.Size(151, 14);
			mainProgress.TabIndex = 30;
			mainProgress.TabStop = false;
			etaLabel.AutoSize = true;
			etaLabel.BackColor = System.Drawing.Color.Transparent;
			etaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			etaLabel.ForeColor = System.Drawing.Color.White;
			etaLabel.Location = new System.Drawing.Point(68, 317);
			etaLabel.Name = "etaLabel";
			etaLabel.Size = new System.Drawing.Size(0, 13);
			etaLabel.TabIndex = 31;
			autoPlayThread.WorkerSupportsCancellation = true;
			autoPlayThread.DoWork += new System.ComponentModel.DoWorkEventHandler(autoPlayThread_DoWork);
			base.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(732, 590);
			base.Controls.Add(mainTextBox);
			base.Controls.Add(downloadLabel);
			base.Controls.Add(etaLabel);
			base.Controls.Add(mainProgress);
			base.Controls.Add(chatButton);
			base.Controls.Add(miniProgress);
			base.Controls.Add(gameOptionsButton);
			base.Controls.Add(faqButton);
			base.Controls.Add(autoplayLabel);
			base.Controls.Add(announcementsBrowser);
			base.Controls.Add(serverCombo);
			base.Controls.Add(serversButton);
			base.Controls.Add(macroButton);
			base.Controls.Add(optionsButton);
			base.Controls.Add(profButton);
			base.Controls.Add(customizeButton);
			base.Controls.Add(swgEmuButton);
			base.Controls.Add(playButton);
			base.Controls.Add(minimizeButton);
			base.Controls.Add(fullScanButton);
			base.Controls.Add(closeButton);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "mainForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "LaunchpadEnhanced";
			base.TransparencyKey = System.Drawing.Color.Red;
			base.Load += new System.EventHandler(mainForm_Load);
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(mainForm_MouseUp);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(mainForm_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(mainForm_MouseMove);
			((System.ComponentModel.ISupportInitialize)serverCombo.DropDownControl).EndInit();
			((System.ComponentModel.ISupportInitialize)serverCombo).EndInit();
			serverCombo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)miniProgress).EndInit();
			((System.ComponentModel.ISupportInitialize)mainProgress).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public mainForm()
		{
			try
			{
				Licenser.LicenseKey = "EDN22-PU350-HY66H-C75A";
				Control.CheckForIllegalCrossThreadCalls = false;
				InitializeComponent();
				base.TransparencyKey = Color.Red;
				serverCombo.DropDownButton = comboboxButton;
				LPE.currentSkin = LPE.getConfigItem("skin");
				LPE.lastServer = LPE.getConfigItem("lastServer");
			}
			catch (Exception ex)
			{
				try
				{
					LPE.download(LPE.installerLocation + "/LaunchpadEnhanced.exe", "_LaunchpadEnhanced.exe");
					LPE.fileCopy("_LaunchpadEnhanced.exe", "LaunchpadEnhanced.exe");
					File.Delete("_LaunchpadEnhanced.exe");
				}
				catch
				{
					MessageBox.Show("Installation is possibly corrupt.  Please uninstall, download new installer (http://www.launchpadenhanced.com), and try again");
				}
				LPE.unfixableError = true;
				writeCrashLog("\nError starting Launchpad: " + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private void mainForm_Load(object sender, EventArgs e)
		{
			try
			{
				progressWorker.RunWorkerAsync();
				clientCrash = false;
				updateDrop = true;
				announcementsBrowser.Url = new Uri(LPE.announcementLink);
				LPE.loadingStatus = "Checking for Updates";
				Thread.Sleep(50);
				LPE.loadingStatusPercentage = 0;
				bool flag = LPE.checkForUpdates();
				etaLabel.Visible = false;
				if (!flag && !LPE.unfixableError)
				{
					LPE.loadingStatus = "Locating EMU";
					LPE.loadingStatusPercentage = 20;
					Thread.Sleep(50);
					initializeControls();
					LPE.loadingStatusPercentage = 40;
					Thread.Sleep(50);
					emu = new EmuInstall();
					LPE.loadingStatus = "Retrieving Skin Info";
					LPE.loadingStatusPercentage = 50;
					ran = firstRun();
					if (!emu.error)
					{
						LPE.loadingStatus = "Updating Server Info";
						LPE.loadingStatusPercentage = 60;
						Thread.Sleep(50);
						updateServerInfo();
						LPE.loadingStatus = "Downloading Interface";
						LPE.loadingStatusPercentage = 80;
						syncSkins();
						applySkin(LPE.currentSkin);
						LPE.checkLoadingIntegrity();
						setLoadingScreen();
						Thread.Sleep(50);
						buildServersObject();
						updateDropDown();
						serverCombo.TextBoxArea.Text = LPE.getConfigItem("lastServer");
						if (string.IsNullOrEmpty(serverCombo.TextBoxArea.Text))
						{
							serverCombo.TextBoxArea.Text = "Click here for servers --->";
						}
						currentServer = LPE.getServerFromArrayList(serverCombo.TextBoxArea.Text);
						checkForCustomFolders();
						if (string.Equals(serverCombo.TextBoxArea.Text, "Click here for servers --->"))
						{
							miniProgress.Width = 0;
							mainProgress.Width = 0;
							LPE.downloadPercentProgress = 0;
							serverCombo.TextBoxArea.Text = "Click here for servers --->";
							LPE.downloadStatus = "Please Select Server";
							LPE.downloadString = "";
						}
					}
					else
					{
						Close();
					}
				}
				else
				{
					Close();
				}
				LPE.loadingStatusPercentage = 100;
				Thread.Sleep(200);
				BringToFront();
			}
			catch (Exception ex)
			{
				LPE.unfixableError = true;
				if (LPE.loadingStatus.Contains("Downloading Interface"))
				{
					MessageBox.Show("Is your firewall blocking downloads?");
				}
				if (ex.Message.Contains("registry access"))
				{
					MessageBox.Show("You do not have access to the registry - do you have admin access on this computer account?");
				}
				writeCrashLog("Version: " + LPE.exeVersion + "\nMethod: " + LPE.loadingStatus + "\nError in mainForm_Load: " + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private bool firstRun()
		{
			try
			{
				long.Parse(LPE.getConfigItem("timesRun"));
				_ = 0;
				return false;
			}
			catch
			{
				return true;
			}
		}

		private void deleteThemes()
		{
			try
			{
				if (Directory.Exists("themes"))
				{
					Directory.Delete("themes", recursive: true);
				}
				if (Directory.Exists(emu.path + "\\ui"))
				{
					Directory.Delete(emu.path + "\\ui", recursive: true);
				}
				if (Directory.Exists(emu.path + "\\texture"))
				{
					Directory.Delete(emu.path + "\\texture", recursive: true);
				}
				if (Directory.Exists(emu.path + "\\string"))
				{
					Directory.Delete(emu.path + "\\string", recursive: true);
				}
				if (Directory.Exists(emu.path + "\\music"))
				{
					Directory.Delete(emu.path + "\\music", recursive: true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void setLoadingScreen()
		{
			try
			{
				string text = LPE.commonFiles + "themes\\loading\\";
				string text2 = "";
				ArrayList arrayList = LPE.readFileToString(text + "check.cfg");
				ArrayList arrayList2 = new ArrayList();
				for (int i = 1; i < arrayList.Count; i++)
				{
					string text3 = arrayList[i].ToString().Substring(0, arrayList[i].ToString().IndexOf('/'));
					if (!alreadyHas(arrayList2, text3))
					{
						arrayList2.Add(text3);
					}
				}
				string text4 = arrayList[0].ToString().Replace("FORCED=", "");
				string[] array = text4.Split(',');
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
				directoryInfo.GetDirectories();
				if (string.IsNullOrEmpty(text4))
				{
					Random random = new Random();
					int index = random.Next(arrayList.Count);
					text2 = arrayList[index].ToString();
				}
				else
				{
					Random random2 = new Random();
					int num = random2.Next(array.Length);
					text2 = array[num].Trim();
				}
				try
				{
					File.Delete(emu.path + "\\string\\en\\live_motd.stf");
					File.Delete(emu.path + "\\string\\en\\test_motd.stf");
					File.Delete(emu.path + "\\texture\\loading\\space\\images\\space_load_pvp.dds");
					File.Delete(emu.path + "\\music\\mus_title_2_lp.mp3");
				}
				catch
				{
				}
				LPE.fileCopy(text + text2 + "\\string\\en\\live_motd.stf", emu.path + "\\string\\en\\live_motd.stf");
				LPE.fileCopy(text + text2 + "\\string\\en\\test_motd.stf", emu.path + "\\string\\en\\test_motd.stf");
				LPE.fileCopy(text + text2 + "\\texture\\loading\\space\\images\\space_load_pvp.dds", emu.path + "\\texture\\loading\\space\\images\\space_load_pvp.dds");
				LPE.fileCopy(text + text2 + "music\\mus_title_2_lp.mp3", emu.path + "\\music\\mus_title_2_lp.mp3");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private bool alreadyHas(ArrayList availableScreens, string inString)
		{
			for (int i = 0; i < availableScreens.Count; i++)
			{
				string text = availableScreens[i].ToString();
				if (text.Equals(inString))
				{
					return true;
				}
			}
			return false;
		}

		private void updateServerInfo()
		{
			try
			{
				LPE.download(LPE.installerLocation + "servers.cfg", LPE.commonFiles + "servers.cfg");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Problem: Failed to Update from SQL - " + ex.Message + "\nmySQL server is sucking I guess, maybe it will work next time");
				writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex.StackTrace, ex.Source);
			}
		}

		private void initializeControls()
		{
			playButton.Hide();
			playButton.Enabled = false;
		}

		private void syncSkins()
		{
			try
			{
				LPE.download(LPE.themeLocation + "skins.txt", LPE.commonFiles + "skins.txt");
				ArrayList arrayList = LPE.readFileToString(LPE.commonFiles + "skins.txt");
				for (int i = 0; i < arrayList.Count; i++)
				{
					makeDirectoryInLauncherFolder("skins");
					makeDirectoryInLauncherFolder("skins\\" + arrayList[i].ToString());
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\gui.cfg", "skins/" + arrayList[i].ToString(), "/gui.cfg");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\check.cfg", "skins/" + arrayList[i].ToString(), "/check.cfg");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\background.png", "skins/" + arrayList[i].ToString(), "/background.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\big_base.png", "skins/" + arrayList[i].ToString(), "/big_base.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\big_mouseover.png", "skins/" + arrayList[i].ToString(), "/big_mouseover.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\big_mousedown.png", "skins/" + arrayList[i].ToString(), "/big_mousedown.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\faq_base.png", "skins/" + arrayList[i].ToString(), "/faq_base.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\faq_mouseover.png", "skins/" + arrayList[i].ToString(), "/faq_mouseover.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\faq_mousedown.png", "skins/" + arrayList[i].ToString(), "/faq_mousedown.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\closeButton.png", "skins/" + arrayList[i].ToString(), "/closeButton.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\comboboxbutton.png", "skins/" + arrayList[i].ToString(), "/comboboxbutton.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\fullscan_base.png", "skins/" + arrayList[i].ToString(), "/fullscan_base.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\fullscan_mouseover.png", "skins/" + arrayList[i].ToString(), "/fullscan_mouseover.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\fullscan_mousedown.png", "skins/" + arrayList[i].ToString(), "/fullscan_mousedown.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\mainprogress.png", "skins/" + arrayList[i].ToString(), "/mainprogress.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\minimizeButton.png", "skins/" + arrayList[i].ToString(), "/minimizeButton.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\miniprogress.png", "skins/" + arrayList[i].ToString(), "/miniprogress.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\play_base.png", "skins/" + arrayList[i].ToString(), "/play_base.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\play_mouseover.png", "skins/" + arrayList[i].ToString(), "/play_mouseover.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\play_mousedown.png", "skins/" + arrayList[i].ToString(), "/play_mousedown.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\smallButton_base.png", "skins/" + arrayList[i].ToString(), "/smallButton_base.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\smallButton_mouseover.png", "skins/" + arrayList[i].ToString(), "/smallButton_mouseover.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\smallButton_mousedown.png", "skins/" + arrayList[i].ToString(), "/smallButton_mousedown.png");
					makeFileInHomeDir("skins\\" + arrayList[i].ToString() + "\\", "\\preview.jpg", "skins/" + arrayList[i].ToString(), "/preview.jpg");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error retrieving skins: " + ex.Message);
			}
		}

		private void applySkin(string skinName)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				arrayList = getSkinProperty("form", skinName);
				base.ClientSize = new Size(int.Parse("732"), int.Parse("600"));
				base.TransparencyKey = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString("black");
				BackgroundImage = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\background.png");
				arrayList = getSkinProperty("closeButton", skinName);
				closeButton.Location = new Point(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				closeButton.Size = new Size(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				closeButton.BackgroundImage = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\closeButton.png");
				arrayList = getSkinProperty("minimizeButton", skinName);
				minimizeButton.Location = new Point(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				minimizeButton.Size = new Size(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				minimizeButton.BackgroundImage = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\minimizeButton.png");
				fullScanImages.Images.Clear();
				fullScanImages.ImageSize = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\fullscan_base.png").Size;
				fullScanImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\fullscan_base.png"));
				fullScanImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\fullscan_mouseover.png"));
				fullScanImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\fullscan_mousedown.png"));
				arrayList = getSkinProperty("fullScanButton", skinName);
				fullScanButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				fullScanButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				fullScanButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				fullScanButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				fullScanButton.Text = arrayList[6].ToString();
				fullScanButton.Image = fullScanImages.Images[0];
				startImages.Images.Clear();
				startImages.ImageSize = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\play_base.png").Size;
				startImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\play_base.png"));
				startImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\play_mouseover.png"));
				startImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\play_mousedown.png"));
				smallButtonImages.Images.Clear();
				smallButtonImages.ImageSize = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\smallButton_base.png").Size;
				smallButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\smallButton_base.png"));
				smallButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\smallButton_mouseover.png"));
				smallButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\smallButton_mousedown.png"));
				bigButtonImages.Images.Clear();
				bigButtonImages.ImageSize = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\big_base.png").Size;
				bigButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\big_base.png"));
				bigButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\big_mouseover.png"));
				bigButtonImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\big_mousedown.png"));
				faqImages.Images.Clear();
				faqImages.ImageSize = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\faq_base.png").Size;
				faqImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\faq_base.png"));
				faqImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\faq_mouseover.png"));
				faqImages.Images.Add(Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\faq_mousedown.png"));
				arrayList = getSkinProperty("playButton", skinName);
				playButton.Location = new Point(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				playButton.Size = new Size(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				playButton.Refresh();
				playButton.Image = startImages.Images[0];
				arrayList = getSkinProperty("swgEmuButton", skinName);
				swgEmuButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				swgEmuButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				swgEmuButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				swgEmuButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				swgEmuButton.Text = arrayList[6].ToString();
				swgEmuButton.Image = smallButtonImages.Images[0];
				arrayList = getSkinProperty("customizeButton", skinName);
				customizeButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				customizeButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				customizeButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				customizeButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				customizeButton.Text = arrayList[6].ToString();
				customizeButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				customizeButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("profButton", skinName);
				profButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				profButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				profButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				profButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				profButton.Text = arrayList[6].ToString();
				profButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				profButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("macroButton", skinName);
				macroButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				macroButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				macroButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				macroButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				macroButton.Text = arrayList[6].ToString();
				macroButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				macroButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("optionsButton", skinName);
				optionsButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				optionsButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				optionsButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				optionsButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				optionsButton.Text = arrayList[6].ToString();
				optionsButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				optionsButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("serverCombo", skinName);
				serverCombo.BackColor = Color.FromArgb((byte)int.Parse(arrayList[0].ToString()), (byte)int.Parse(arrayList[1].ToString()), (byte)int.Parse(arrayList[2].ToString()));
				serverCombo.DropDownControl.BackColor = Color.FromArgb((byte)int.Parse(arrayList[0].ToString()), (byte)int.Parse(arrayList[1].ToString()), (byte)int.Parse(arrayList[2].ToString()));
				serverCombo.DropDownControl.Font = new Font(arrayList[3].ToString(), float.Parse(arrayList[4].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				serverCombo.DropDownControl.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[6].ToString());
				serverCombo.DropDownControl.SelectionBackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[7].ToString());
				serverCombo.DropDownControl.InactiveSelectionForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[8].ToString());
				serverCombo.Font = new Font(arrayList[3].ToString(), float.Parse(arrayList[4].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				serverCombo.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[6].ToString());
				serverCombo.Location = new Point(int.Parse(arrayList[11].ToString()), int.Parse(arrayList[12].ToString()));
				serverCombo.Size = new Size(int.Parse(arrayList[9].ToString()), int.Parse(arrayList[10].ToString()));
				serverCombo.TextBoxArea.Font = new Font(arrayList[3].ToString(), float.Parse(arrayList[4].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				serverCombo.TextBoxArea.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[6].ToString());
				serverCombo.TextBoxArea.RawText = "Choose Server";
				comboboxButton.Image = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\comboboxbutton.png");
				comboboxButton.Location = new Point(int.Parse(arrayList[11].ToString()), int.Parse(arrayList[12].ToString()));
				comboboxButton.Size = new Size(int.Parse(arrayList[13].ToString()), int.Parse(arrayList[14].ToString()));
				arrayList = getSkinProperty("serversButton", skinName);
				serversButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				serversButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				serversButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				serversButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				serversButton.Text = arrayList[6].ToString();
				serversButton.Image = smallButtonImages.Images[0];
				arrayList = getSkinProperty("downloadLabel", skinName);
				downloadLabel.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Regular, GraphicsUnit.Point, 0);
				downloadLabel.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				downloadLabel.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				downloadLabel.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				downloadLabel.Text = arrayList[6].ToString();
				arrayList = getSkinProperty("autoplayLabel", skinName);
				autoplayLabel.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				autoplayLabel.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				autoplayLabel.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				autoplayLabel.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				autoplayLabel.Text = arrayList[6].ToString();
				arrayList = getSkinProperty("faqButton", skinName);
				faqButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				faqButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				faqButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				faqButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				faqButton.Text = arrayList[6].ToString();
				faqButton.Image = faqImages.Images[0];
				arrayList = getSkinProperty("autoplayLabel", skinName);
				autoplayLabel.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Regular, GraphicsUnit.Point, 0);
				autoplayLabel.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				autoplayLabel.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				autoplayLabel.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				autoplayLabel.Text = arrayList[6].ToString();
				arrayList = getSkinProperty("announcementsBrowser", skinName);
				announcementsBrowser.Location = new Point(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				announcementsBrowser.Size = new Size(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				arrayList = getSkinProperty("mainTextBox", skinName);
				mainTextBox.BackColor = Color.FromArgb((byte)int.Parse(arrayList[0].ToString()), (byte)int.Parse(arrayList[1].ToString()), (byte)int.Parse(arrayList[2].ToString()));
				mainTextBox.Font = new Font(arrayList[4].ToString(), float.Parse(arrayList[5].ToString()), FontStyle.Regular, GraphicsUnit.Point, 0);
				mainTextBox.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				mainTextBox.Location = new Point(int.Parse(arrayList[8].ToString()), int.Parse(arrayList[9].ToString()));
				mainTextBox.Size = new Size(int.Parse(arrayList[6].ToString()), int.Parse(arrayList[7].ToString()));
				arrayList = getSkinProperty("chatButton", skinName);
				chatButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				chatButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				chatButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				chatButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				chatButton.Text = arrayList[6].ToString();
				chatButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				chatButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("helpButton", skinName);
				gameOptionsButton.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Bold, GraphicsUnit.Point, 0);
				gameOptionsButton.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				gameOptionsButton.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				gameOptionsButton.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				gameOptionsButton.Text = arrayList[6].ToString();
				gameOptionsButton.TextAlign = (ContentAlignment)TypeDescriptor.GetConverter(typeof(ContentAlignment)).ConvertFromString(arrayList[9].ToString());
				gameOptionsButton.Image = bigButtonImages.Images[0];
				arrayList = getSkinProperty("miniProgress", skinName);
				miniProgress.Location = new Point(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				miniProgress.Size = new Size(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				miniProgress.Image = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\miniprogress.png");
				miniLength = int.Parse(arrayList[0].ToString());
				arrayList = getSkinProperty("mainProgress", skinName);
				mainProgress.Location = new Point(int.Parse(arrayList[2].ToString()), int.Parse(arrayList[3].ToString()));
				mainProgress.Size = new Size(int.Parse(arrayList[0].ToString()), int.Parse(arrayList[1].ToString()));
				mainProgress.Image = Image.FromFile(LPE.commonFiles + "skins\\" + skinName + "\\mainprogress.png");
				mainLength = int.Parse(arrayList[0].ToString());
				arrayList = getSkinProperty("etaLabel", skinName);
				etaLabel.Font = new Font(arrayList[0].ToString(), float.Parse(arrayList[1].ToString()), FontStyle.Regular, GraphicsUnit.Point, 0);
				etaLabel.ForeColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(arrayList[3].ToString());
				etaLabel.Location = new Point(int.Parse(arrayList[7].ToString()), int.Parse(arrayList[8].ToString()));
				etaLabel.Size = new Size(int.Parse(arrayList[4].ToString()), int.Parse(arrayList[5].ToString()));
				etaLabel.Text = arrayList[6].ToString();
				Thread.Sleep(500);
				Refresh();
			}
			catch (Exception)
			{
				Application.Restart();
			}
		}

		private string getFileStatusForSkins(string inString)
		{
			string text = "";
			try
			{
				if (!File.Exists(inString + "background.png"))
				{
					text += "background.png\n";
				}
				if (!File.Exists(inString + "big_base.png"))
				{
					text += "big_base.png\n";
				}
				if (!File.Exists(inString + "big_mousedown.png"))
				{
					text += "big_mousedown.png\n";
				}
				if (!File.Exists(inString + "big_mouseover.png"))
				{
					text += "big_mouseover.png\n";
				}
				if (!File.Exists(inString + "closeButton.png"))
				{
					text += "closeButton.png\n";
				}
				if (!File.Exists(inString + "comboboxbutton.png"))
				{
					text += "comboboxbutton.png\n";
				}
				if (!File.Exists(inString + "faq_base.png"))
				{
					text += "faq_base.png\n";
				}
				if (!File.Exists(inString + "faq_mousedown.png"))
				{
					text += "faq_mousedown.png\n";
				}
				if (!File.Exists(inString + "faq_mouseover.png"))
				{
					text += "faq_mouseover.png\n";
				}
				if (!File.Exists(inString + "fullscan_base.png"))
				{
					text += "fullscan_base.png\n";
				}
				if (!File.Exists(inString + "fullscan_mousedown.png"))
				{
					text += "fullscan_mousedown.png\n";
				}
				if (!File.Exists(inString + "fullscan_mouseover.png"))
				{
					text += "fullscan_mouseover.png\n";
				}
				if (!File.Exists(inString + "mainprogress.png"))
				{
					text += "mainprogress.png\n";
				}
				if (!File.Exists(inString + "minimizeButton.png"))
				{
					text += "minimizeButton.png\n";
				}
				if (!File.Exists(inString + "miniprogress.png"))
				{
					text += "miniprogress.png\n";
				}
				if (!File.Exists(inString + "play_base.png"))
				{
					text += "play_base.png\n";
				}
				if (!File.Exists(inString + "play_mousedown.png"))
				{
					text += "play_mousedown.png\n";
				}
				if (!File.Exists(inString + "play_mouseover.png"))
				{
					text += "play_mouseover.png\n";
				}
				if (!File.Exists(inString + "smallButton_base.png"))
				{
					text += "smallButton_base.png\n";
				}
				if (!File.Exists(inString + "smallButton_mousedown.png"))
				{
					text += "smallButton_mousedown.png";
				}
				if (!File.Exists(inString + "smallButton_mouseover.png"))
				{
					text += "smallButton_mouseover.png\n";
				}
				if (!File.Exists(inString + "check.cfg"))
				{
					text += "check.cfg\n";
				}
				if (!File.Exists(inString + "gui.cfg"))
				{
					text += "gui.cfg\n";
				}
				if (!File.Exists(inString + "preview.jpg"))
				{
					text += "preview.jpg\n";
					return text;
				}
				return text;
			}
			catch (Exception)
			{
				return text;
			}
		}

		private ArrayList getSkinProperty(string inProperty, string skinName)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				bool flag = false;
				TextReader textReader = new StreamReader(LPE.commonFiles + "skins\\" + skinName + "\\gui.cfg");
				string text = textReader.ReadLine();
				int num = 0;
				while (text != null)
				{
					if (text.Length > 1)
					{
						if (text.Contains("/" + inProperty))
						{
							break;
						}
						if (flag)
						{
							arrayList.Add(text.Substring(text.IndexOf("=") + 1));
						}
						if (text.Contains(inProperty))
						{
							flag = true;
						}
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
				return null;
			}
		}

		private void buildServersObject()
		{
			try
			{
				LPE.serverArrayList.Clear();
				ArrayList arrayList;
				if (File.Exists(LPE.commonFiles + "servers.cfg"))
				{
					arrayList = LPE.readFileToString(LPE.commonFiles + "servers.cfg");
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
				if (!File.Exists(LPE.commonFiles + "customservers.cfg"))
				{
					return;
				}
				arrayList = LPE.readFileToString(LPE.commonFiles + "customservers.cfg");
				for (int j = 0; j < arrayList.Count; j++)
				{
					if (arrayList[j].ToString().Contains("[Server]"))
					{
						Server server = new Server();
						j++;
						server.sname = arrayList[j].ToString();
						j++;
						server.saddress = arrayList[j].ToString();
						j++;
						server.sport = arrayList[j].ToString();
						j++;
						server.standard = arrayList[j].ToString();
						j++;
						server.downloadLink = arrayList[j].ToString();
						LPE.serverArrayList.Add(server);
					}
				}
			}
			catch (Exception ex)
			{
				writeCrashLog("Problem: Error building server object\nSolution: Ignored\n" + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private void updateDropDown()
		{
			try
			{
				serverCombo.Items.Clear();
				for (int i = 0; i < LPE.serverArrayList.Count; i++)
				{
					serverCombo.Items.Add(((Server)LPE.serverArrayList[i]).sname);
				}
			}
			catch (Exception ex)
			{
				writeCrashLog("Problem: Error updating drop down\nSolution: Ignored\n" + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private void checkForCustomFolders()
		{
			LPE.makeSureDirectoryExists(emu.path + "music");
			LPE.makeSureDirectoryExists(emu.path + "\\texture\\loading\\space\\images");
			LPE.makeSureDirectoryExists(emu.path + "\\string\\en");
			LPE.makeSureDirectoryExists(LPE.commonFiles + "themes");
		}

		private void doBackgroundWork()
		{
			Refresh();
			if (downloadWorker == null)
			{
				downloadWorker = new BackgroundWorker();
				downloadWorker.WorkerReportsProgress = true;
				downloadWorker.WorkerSupportsCancellation = true;
				downloadWorker.DoWork += downloadWorker_DoWork;
				downloadWorker.RunWorkerCompleted += downloadWorker_RunWorkerCompleted;
			}
			downloadWorker.RunWorkerAsync();
		}

		private string ping(IPAddress ip)
		{
			try
			{
				IPEndPoint remoteEP = new IPEndPoint(ip, 44453);
				new IPEndPoint(IPAddress.Any, 0);
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.SendTimeout = 1000;
				socket.ReceiveTimeout = 1000;
				byte[] buffer = new byte[14]
				{
					0, 1, 0, 0, 0, 2, 88, 176, 38, 202,
					0, 0, 1, 240
				};
				byte[] buffer2 = new byte[43]
				{
					0, 9, 0, 0, 4, 0, 150, 31, 19, 65,
					6, 0, 115, 116, 97, 116, 117, 115, 4, 0,
					112, 97, 115, 115, 14, 0, 50, 48, 48, 53,
					48, 52, 48, 56, 45, 49, 56, 58, 48, 48,
					0, 14, 179
				};
				byte[] buffer3 = new byte[10] { 0, 9, 0, 0, 4, 0, 18, 52, 86, 120 };
				byte[] array = new byte[100];
				try
				{
					socket.Connect(remoteEP);
					socket.Send(buffer);
					socket.Send(buffer2);
					socket.Send(buffer3);
					socket.Receive(array);
					Encoding.ASCII.GetString(array);
					return "up";
				}
				catch (Exception ex)
				{
					if (ex.Message.Contains("forcibly"))
					{
						return "up";
					}
					if (ex.Message.Contains("failed to respond"))
					{
						return "down";
					}
					return "down";
				}
			}
			catch (Exception ex2)
			{
				return "error: " + ex2.Message;
			}
		}

		private string[] getStatus(string inString)
		{
			string[] array = new string[2];
			try
			{
				IPAddress iPAddress;
				try
				{
					iPAddress = IPAddress.Parse(inString);
				}
				catch
				{
					IPHostEntry hostEntry = Dns.GetHostEntry(inString);
					iPAddress = IPAddress.Parse(hostEntry.AddressList[0].ToString());
				}
				mainTextBox.Clear();
				array[0] = "Contacting server, please wait....";
				mainTextBox.Lines = array;
				try
				{
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < 4; i++)
					{
						string text = this.ping(iPAddress);
						if (text.Contains("up"))
						{
							num++;
							break;
						}
						if (text.Contains("error"))
						{
							array[0] = "Bad server info: ";
							array[1] = text;
							return array;
						}
						if (text.Contains("down"))
						{
							num2++;
						}
						Thread.Sleep(400);
					}
					if (num > 0)
					{
						array[0] = "Ping server up";
					}
					else
					{
						array[0] = "Ping server down";
					}
					Ping ping = new Ping();
					long num3 = 0L;
					int num4 = 0;
					PingReply pingReply = ping.Send(iPAddress, 100);
					Thread.Sleep(50);
					PingReply pingReply2 = ping.Send(iPAddress, 200);
					Thread.Sleep(50);
					PingReply pingReply3 = ping.Send(iPAddress, 300);
					Thread.Sleep(50);
					PingReply pingReply4 = ping.Send(iPAddress, 600);
					if (pingReply.RoundtripTime == 0 && pingReply2.RoundtripTime == 0 && pingReply3.RoundtripTime == 0 && pingReply4.RoundtripTime == 0)
					{
						array[1] = "No Response";
					}
					else
					{
						if (pingReply.RoundtripTime != 0)
						{
							num4++;
							num3 += pingReply.RoundtripTime;
						}
						if (pingReply2.RoundtripTime != 0)
						{
							num4++;
							num3 += pingReply2.RoundtripTime;
						}
						if (pingReply3.RoundtripTime != 0)
						{
							num4++;
							num3 += pingReply3.RoundtripTime;
						}
						if (pingReply4.RoundtripTime != 0)
						{
							num4++;
							num3 += pingReply4.RoundtripTime;
						}
						array[1] = "Ping: " + num3 / num4;
					}
					return array;
				}
				catch (Exception)
				{
					return null;
				}
			}
			catch (Exception ex2)
			{
				array[0] = "Bad server info:\n" + ex2.Message;
				array[1] = "";
				return array;
			}
		}

		private void writeServerFile()
		{
			try
			{
				if (File.Exists(LPE.commonFiles + "servers.cfg"))
				{
					File.Delete(LPE.commonFiles + "customservers.cfg");
				}
				StreamWriter streamWriter = File.CreateText(LPE.commonFiles + "servers.cfg");
				for (int i = 0; i < LPE.serverArrayList.Count; i++)
				{
					Server server = (Server)LPE.serverArrayList[i];
					streamWriter.WriteLine("[Server]");
					streamWriter.WriteLine(server.sname);
					streamWriter.WriteLine(server.saddress);
					streamWriter.WriteLine(server.sport);
					streamWriter.WriteLine(server.standard);
					streamWriter.WriteLine(server.downloadLink);
					streamWriter.WriteLine("[/Server]");
				}
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing 'servers.cfg' File: " + ex);
				MessageBox.Show("Application Must Close");
				base.Owner.Close();
			}
		}

		private void writeCFG()
		{
			try
			{
				ArrayList arrayList;
				if (File.Exists(emu.path + "\\swgemu_login.cfg"))
				{
					arrayList = LPE.readFileToString(emu.path + "\\swgemu_login.cfg");
					for (int i = 0; i < arrayList.Count; i++)
					{
						if (arrayList[i].ToString().Contains("loginServerPort0"))
						{
							arrayList[i] = "        loginServerPort0=" + currentServer.sport;
						}
						if (arrayList[i].ToString().Contains("loginServerAddress0="))
						{
							arrayList[i] = "        loginServerAddress0=" + currentServer.saddress;
						}
					}
				}
				else
				{
					arrayList = new ArrayList();
					arrayList.Add("[ClientGame]");
					arrayList.Add("        loginServerPort0=" + currentServer.sport);
					arrayList.Add("        loginServerAddress0=" + currentServer.saddress);
					arrayList.Add("[Station]");
					arrayList.Add("        subscriptionFeatures=1");
					arrayList.Add("        gameFeatures=65535");
				}
				StreamWriter streamWriter = File.CreateText(emu.path + "\\swgemu_login.cfg");
				for (int j = 0; j < arrayList.Count; j++)
				{
					streamWriter.WriteLine(arrayList[j].ToString());
				}
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing 'swgemu_login.cfg' File: " + ex);
				MessageBox.Show("Application Must Close");
				Close();
			}
		}

		private void makeDirectoryInEmuFolder(string inString)
		{
			try
			{
				if (!Directory.Exists(emu.path + inString))
				{
					Directory.CreateDirectory(emu.path + inString);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Unable to create folder '" + emu.path + inString + ", do you have administrator access?  Choose a new location for the emu");
				try
				{
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					folderBrowserDialog.ShowNewFolderButton = true;
					folderBrowserDialog.Description = "Choose/Create the folder for Emu install";
					folderBrowserDialog.ShowDialog();
					if (Directory.GetDirectories(folderBrowserDialog.SelectedPath).Length == 0 && Directory.GetFiles(folderBrowserDialog.SelectedPath).Length == 0)
					{
						LPE.setConfigItem("path", folderBrowserDialog.SelectedPath);
					}
					else
					{
						DialogResult dialogResult = MessageBox.Show("Folder is not empty, Do you want to use this folder anyways? ", "Warning!", MessageBoxButtons.YesNo);
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
				MessageBox.Show("Closing launchpad, please restart");
				Application.Exit();
			}
		}

		private void makeDirectoryInLauncherFolder(string inString)
		{
			if (!Directory.Exists(LPE.commonFiles + inString))
			{
				Directory.CreateDirectory(LPE.commonFiles + inString);
			}
		}

		private void makeFileInHomeDir(string inPath, string inFileName, string remotePath, string remoteFileName)
		{
			inPath = LPE.commonFiles + inPath;
			if (!File.Exists(inPath + inFileName))
			{
				LPE.download(LPE.themeLocation + remotePath + remoteFileName, inPath + remoteFileName + ".dat");
				FileInfo fileInfo = new FileInfo(inPath + "\\" + remoteFileName + ".dat");
				fileInfo.MoveTo(inPath + inFileName);
			}
		}

		public static void writeCrashLog(string myString, string inStack, string inSource)
		{
			try
			{
				if (LPE.unfixableError)
				{
					ErrorReportMail errorReportMail = new ErrorReportMail(myString, inStack, inSource);
					errorReportMail.ShowDialog();
					Application.Exit();
				}
				if (File.Exists(LPE.commonFiles + "crashlog.txt"))
				{
					FileInfo fileInfo = new FileInfo(LPE.commonFiles + "crashlog.txt");
					if (fileInfo.Length > 1000)
					{
						File.Delete(LPE.commonFiles + "crashlog.txt");
					}
				}
				StreamWriter streamWriter = File.AppendText(LPE.commonFiles + "crashlog.txt");
				streamWriter.WriteLine(DateTime.Now.ToString());
				streamWriter.WriteLine("Version: " + LPE.exeVersion);
				streamWriter.WriteLine(myString);
				streamWriter.WriteLine(inStack);
				streamWriter.WriteLine(inSource);
				streamWriter.WriteLine("-----------------------------");
				streamWriter.WriteLine();
				streamWriter.WriteLine();
				streamWriter.Close();
				if (LPE.unfixableError)
				{
					MessageBox.Show("Application forced to close");
					Application.Exit();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing 'crashlog' File: " + ex);
			}
		}

		private void writeBootLog(string inString)
		{
			try
			{
				StreamWriter streamWriter = (File.Exists(LPE.commonFiles + "bootlog.txt") ? File.AppendText(LPE.commonFiles + "bootlog.txt") : File.CreateText(LPE.commonFiles + "bootlog.txt"));
				streamWriter.WriteLine(inString);
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing 'bootlog' File: " + ex);
			}
		}

		private void mainTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		private void launchGame()
		{
			try
			{
				try
				{
					buildServersObject();
					updateDropDown();
				}
				catch
				{
					MessageBox.Show("Error with selected server, please choose another");
				}
				if (!string.IsNullOrEmpty(currentServer.sname))
				{
					try
					{
						LPE.setConfigItem("lastServer", serverCombo.TextBoxArea.Text);
						if (!string.Equals(emu.path, emu.sourcePath))
						{
							LPE.setConfigItem("sourcePath", emu.path);
						}
					}
					catch
					{
					}
					writeCFG();
					if (File.Exists(emu.path + "\\SWGEmu.exe"))
					{
						ProcessStartInfo processStartInfo = new ProcessStartInfo(emu.path + "\\SWGEmu.exe");
						processStartInfo.WorkingDirectory = emu.path;
						processStartInfo.UseShellExecute = false;
						Process.Start(processStartInfo);
						GC.Collect();
						Close();
					}
					else
					{
						MessageBox.Show("Configuration error, please reconfigure when launchpad restarts");
						LPE.partialReset(emu.path);
						Directory.Delete(LPE.commonFiles, recursive: true);
						Application.Restart();
					}
				}
				else
				{
					MessageBox.Show("No server selected, Server information not found");
				}
			}
			catch (Exception ex)
			{
				writeCrashLog("Error Launching game: " + ex.Message, ex.StackTrace, ex.Source + "\nExe Exists: " + File.Exists(emu.path + "\\SWGEmu.exe"));
				if (File.Exists(emu.path + "\\SWGEmu.exe"))
				{
					File.Delete(emu.path + "\\SWGEmu.exe");
				}
				Application.Restart();
			}
		}

		private void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			mainProgress.Width = 0;
			try
			{
				faqButton.Image = faqImages.Images[int.Parse(LPE.getConfigItem("autoplay"))];
				if (int.Parse(LPE.getConfigItem("autoplay")) == 2)
				{
					faqClicked = true;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(emu.path + "Emu_opt.cfg"))
				{
					File.Move(emu.path + "Emu_opt.cfg", emu.path + "options.cfg");
				}
			}
			catch
			{
			}
			etaLabel.Visible = true;
			fullScanButton.Enabled = false;
			mainProgress.Width = 0;
			FullScan fullScan = new FullScan(emu.path);
			BuildInstall buildInstall = new BuildInstall(emu.path, emu.sourcePath);
			LPE.totalBytesToGet = 0L;
			LPE.totalBytesRecieved = 0L;
			for (int i = 0; i < buildInstall.filesToDownload.Count; i++)
			{
				LPE.totalBytesToGet += fullScan.getFileLength(LPE.removeDownloadPath(buildInstall.filesToDownload[i].ToString(), buildInstall.patchLocations));
			}
			LPE.bytesLeft = LPE.totalBytesToGet;
			LPE.totalBytesRecieved = 0L;
			try
			{
				for (int j = 0; j < buildInstall.filesToCopy.Count; j++)
				{
					string text = buildInstall.filesToCopy[j].ToString();
					string text2 = buildInstall.path + buildInstall.filesToCopy[j].ToString().Replace("/", "\\").Replace(buildInstall.sourcePath, "");
					FileInfo fileInfo = new FileInfo(text2);
					LPE.makeSureDirectoryExists(fileInfo.DirectoryName);
					LPE.fileCopy(text, text2);
					if (!fullScan.checkFile(text2))
					{
						buildInstall.filesToDownload.Add(buildInstall.changeToRemoteLocation(text));
					}
				}
				for (int k = 0; k < buildInstall.filesToDownload.Count; k++)
				{
					string text = buildInstall.filesToDownload[k].ToString();
					string text2 = buildInstall.path + "\\" + LPE.removeDownloadPath(buildInstall.filesToDownload[k].ToString(), buildInstall.patchLocations).Replace("/", "\\");
					FileInfo fileInfo = new FileInfo(text2);
					LPE.makeSureDirectoryExists(fileInfo.DirectoryName);
					LPE.download(text, text2);
					if (!fullScan.checkFile(text2))
					{
						buildInstall.unresolvedFiles.Add(buildInstall.changeToRemoteLocation(text));
						continue;
					}
					LPE.bytesCompleted += fileInfo.Length;
					LPE.totalBytesRecieved = LPE.bytesCompleted;
					LPE.bytesLeft = LPE.totalBytesToGet - LPE.totalBytesRecieved;
				}
			}
			catch (Exception ex)
			{
				LPE.unfixableError = true;
				writeCrashLog(ex.Message, ex.StackTrace, ex.Source);
			}
			GC.Collect();
			clientCrash = buildInstall.clientCrash;
		}

		private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				int num = int.Parse(LPE.getConfigItem("timesRun"));
				if (!emu.path.Equals(emu.sourcePath))
				{
					LPE.setConfigItem("sourcePath", emu.path);
				}
				if (num == 0 && !fileScanWorker.IsBusy)
				{
					fileScanWorker.RunWorkerAsync();
				}
				LPE.setConfigItem("timesRun", (num + 1).ToString());
			}
			catch
			{
				fullScanButton.Enabled = false;
				LPE.setConfigItem("timesRun", "1");
			}
			if (clientCrash)
			{
				DialogResult dialogResult = MessageBox.Show("Detected client crash, Do you want to repair?", "Warning!", MessageBoxButtons.YesNo);
				if (dialogResult.ToString().Equals("Yes"))
				{
					LPE.themeReset(emu.path);
					fileScanWorker.RunWorkerAsync();
				}
				else
				{
					string text = serverCombo.TextBoxArea.Text;
					serverCombo.TextBoxArea.Text = "temp";
					serverCombo.TextBoxArea.Text = text;
				}
			}
			else if (!fileScanWorker.IsBusy)
			{
				if (!LPE.unfixableError)
				{
					etaLabel.Visible = false;
					LPE.bytesLeft = 0L;
					playButton.Visible = true;
					playButton.Enabled = true;
					fullScanButton.Enabled = true;
					miniProgress.Width = 0;
					mainProgress.Width = mainLength;
					if (faqClicked)
					{
						autoPlayThread.RunWorkerAsync();
					}
					else
					{
						LPE.downloadStatus = "Download Complete!";
						LPE.downloadString = "";
					}
				}
				else
				{
					MessageBox.Show("Application cannot recover, try restarting launchpad");
					Close();
				}
			}
			try
			{
				if (ran)
				{
					StreamWriter streamWriter = File.CreateText("run.txt");
					streamWriter.WriteLine("False");
					streamWriter.Close();
				}
			}
			catch
			{
			}
		}

		private void progressWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				int num6 = 0;
				bool flag = false;
				ArrayList arrayList = new ArrayList();
				while (!LPE.unfixableError)
				{
					Invalidate();
					Refresh();
					if (LPE.bytesLeft != 0)
					{
						miniProgress.Width = (int)((double)(LPE.downloadPercentProgress * miniLength) * 0.01);
						mainProgress.Width = (int)((double)mainLength * ((double)LPE.totalBytesRecieved / (double)LPE.totalBytesToGet));
						if (flag)
						{
							if (num6 == 0)
							{
								etaLabel.Text = "Remaining: less than one minute";
							}
							else
							{
								etaLabel.Text = (int)(num2 / 1000.0) + " KB/s @" + num6 + " m " + (int)(LPE.totalBytesRecieved / 1000000) + "/" + (int)(LPE.totalBytesToGet / 1000000) + " MB";
							}
						}
						else
						{
							etaLabel.Text = "Estimating time remaining...";
						}
						if (num6 < 0)
						{
							etaLabel.Text = "";
						}
					}
					else
					{
						etaLabel.Text = "Estimating time remaining...";
					}
					string text = LPE.downloadStatus + " " + LPE.downloadString;
					if (text.Length > 28)
					{
						try
						{
							text = text.Substring(0, 28) + "...";
							downloadLabel.Text = text;
						}
						catch
						{
						}
					}
					else
					{
						downloadLabel.Text = text;
					}
					num3 = Math.Abs(LPE.totalBytesRecieved);
					Thread.Sleep(500);
					num4 = Math.Abs(LPE.totalBytesRecieved);
					num = (num4 - num3) * 2.0;
					if (num != 0.0)
					{
						arrayList.Add(num);
					}
					if (arrayList.Count > 60)
					{
						flag = true;
					}
					if (arrayList.Count > 6000)
					{
						arrayList.RemoveAt(0);
					}
					double num7 = 0.0;
					for (int i = 0; i < arrayList.Count; i++)
					{
						double.TryParse(arrayList[i].ToString(), out num);
						num7 += num;
						if (arrayList.Count - i < 10)
						{
							double.TryParse(arrayList[i].ToString(), out num);
							num2 += num;
						}
					}
					num2 /= 10.0;
					num = num7 / (double)arrayList.Count;
					num5 = (double)(LPE.totalBytesToGet - LPE.totalBytesRecieved) / num;
					num6 = (int)(num5 / 60.0);
				}
			}
			catch (Exception ex)
			{
				writeCrashLog("Error in Progress Thread: " + ex.Message, ex.StackTrace, ex.Source);
			}
		}

		private void progressWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void autoPlayThread_DoWork(object sender, DoWorkEventArgs e)
		{
			int num;
			for (num = 10; num > 0; num--)
			{
				LPE.downloadStatus = "Autoplay Enabled - " + num;
				LPE.downloadString = "";
				Thread.Sleep(1000);
				if (!faqClicked)
				{
					break;
				}
			}
			if (num == 0)
			{
				launchGame();
				return;
			}
			LPE.downloadStatus = "Download Complete!";
			LPE.downloadString = "";
		}

		private void pingThread_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				inStatus = getStatus(currentServer.saddress);
			}
			catch
			{
			}
		}

		private void pingThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			string[] array = new string[10];
			if (!string.IsNullOrEmpty(inStatus[1]))
			{
				array[0] = inStatus[0];
				array[1] = inStatus[1];
				array[3] = serverCombo.Text;
				mainTextBox.Lines = array;
			}
			else
			{
				array[0] = inStatus[0];
				array[1] = inStatus[1];
				mainTextBox.Lines = array;
			}
			serverCombo.Enabled = true;
		}

		private void fileScanWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			playButton.Enabled = false;
			playButton.Visible = false;
			fullScanButton.Enabled = false;
			string text = "";
			FullScan fullScan = new FullScan(emu.path);
			Thread.Sleep(1000);
			while (!fullScan.ok)
			{
				try
				{
					LPE.downloadStatus = "Analyzing: ";
					if (fullScan.file[fullScan.index].ToString().Length > 20)
					{
						downloadLabel.Font = new Font(downloadLabel.Font.FontFamily, 4f);
					}
					else
					{
						downloadLabel.Font = new Font(downloadLabel.Font.FontFamily, 6f);
					}
					LPE.downloadString = fullScan.file[fullScan.index].ToString();
					if (File.Exists(emu.path + "\\" + fullScan.file[fullScan.index].ToString()))
					{
						text += fullScan.check(LPE.createMD5Checksum(emu.path + "\\" + fullScan.file[fullScan.index].ToString()));
					}
					else
					{
						fullScan.file.RemoveAt(0);
						fullScan.length.RemoveAt(0);
						fullScan.checksum.RemoveAt(0);
					}
					LPE.downloadStatus = "Waiting: ";
					LPE.downloadString = "Finished";
					if (fullScan.file.Count == 0)
					{
						fullScan.ok = true;
					}
				}
				catch (Exception)
				{
					if (fullScan.file.Count == 0)
					{
						fullScan.ok = true;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				MessageBox.Show("Files are corrupt:\n" + text + "\nFixing now");
			}
			GC.Collect();
		}

		private void fileScanWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			downloadWorker.RunWorkerAsync();
		}

		private void mainForm_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void mainForm_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void mainForm_MouseMove(object sender, MouseEventArgs e)
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
			try
			{
				GC.Collect();
				Close();
			}
			catch (Exception)
			{
				Close();
			}
		}

		private void minimizeButton_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void fileScanButton_MouseEnter(object sender, EventArgs e)
		{
			fullScanButton.Image = fullScanImages.Images[1];
			GC.Collect();
		}

		private void fileScanButton_MouseLeave(object sender, EventArgs e)
		{
			fullScanButton.Image = fullScanImages.Images[0];
			GC.Collect();
		}

		private void fileScanButton_Click(object sender, EventArgs e)
		{
			try
			{
				fullScanButton.Enabled = false;
				if (!fileScanWorker.IsBusy)
				{
					fileScanWorker.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void fileScanButton_MouseUp(object sender, MouseEventArgs e)
		{
			fullScanButton.Image = fullScanImages.Images[1];
			GC.Collect();
		}

		private void fileScanButton_MouseDown(object sender, MouseEventArgs e)
		{
			fullScanButton.Image = fullScanImages.Images[2];
			GC.Collect();
		}

		private void swgEmuButton_MouseEnter(object sender, EventArgs e)
		{
			swgEmuButton.Image = smallButtonImages.Images[1];
			GC.Collect();
		}

		private void swgEmuButton_MouseLeave(object sender, EventArgs e)
		{
			swgEmuButton.Image = smallButtonImages.Images[0];
			GC.Collect();
		}

		private void swgEmuButton_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("http://www.swgemu.com");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void swgEmuButton_MouseDown(object sender, MouseEventArgs e)
		{
			swgEmuButton.Image = smallButtonImages.Images[2];
			GC.Collect();
		}

		private void swgEmuButton_MouseUp(object sender, MouseEventArgs e)
		{
			swgEmuButton.Image = smallButtonImages.Images[1];
			GC.Collect();
		}

		private void customizeButton_MouseEnter(object sender, EventArgs e)
		{
			customizeButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void customizeButton_MouseLeave(object sender, EventArgs e)
		{
			customizeButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void customizeButton_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = false;
				if (base.OwnedForms.Length == 1 && base.OwnedForms[0].ToString().Contains("Xceed"))
				{
					flag = true;
				}
				if (base.OwnedForms.Length == 0)
				{
					flag = true;
				}
				if (flag)
				{
					ThemeBrowser themeBrowser = new ThemeBrowser(emu.path);
					AddOwnedForm(themeBrowser);
					themeBrowser.Show();
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void customizeButton_MouseDown(object sender, MouseEventArgs e)
		{
			customizeButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void customizeButton_MouseUp(object sender, MouseEventArgs e)
		{
			customizeButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void profButton_MouseEnter(object sender, EventArgs e)
		{
			profButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void profButton_MouseLeave(object sender, EventArgs e)
		{
			profButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void profButton_Click(object sender, EventArgs e)
		{
			try
			{
				LPE.checkFileForIntegrity(LPE.commonFiles, "KSWGProfCalcEditor.exe", LPE.kodanExe);
				LPE.checkFileForIntegrity(LPE.commonFiles, "KSWGProfCalc.dat", LPE.kodanData);
				if (!File.Exists(LPE.commonFiles + "KSWGProfCalcEditor.exe"))
				{
					LPE.download(LPE.installerLocation + "KSWGProfCalcEditor.exe", LPE.commonFiles + "KSWGProfCalcEditor.exe");
				}
				if (!File.Exists(LPE.commonFiles + "KSWGProfCalc.dat"))
				{
					LPE.download(LPE.installerLocation + "KSWGProfCalc.dat", LPE.commonFiles + "KSWGProfCalc.dat");
				}
				ProcessStartInfo processStartInfo = new ProcessStartInfo(LPE.commonFiles + "KSWGProfCalcEditor.exe");
				processStartInfo.WorkingDirectory = LPE.commonFiles;
				processStartInfo.UseShellExecute = true;
				Process.Start(processStartInfo);
				GC.Collect();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Launching profession calculator\n" + ex.Message);
			}
		}

		private void profButton_MouseDown(object sender, MouseEventArgs e)
		{
			profButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void profButton_MouseUp(object sender, MouseEventArgs e)
		{
			profButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void macroButton_MouseEnter(object sender, EventArgs e)
		{
			macroButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void macroButton_MouseLeave(object sender, EventArgs e)
		{
			macroButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void macroButton_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = false;
				if (base.OwnedForms.Length == 1 && base.OwnedForms[0].ToString().Contains("Xceed"))
				{
					flag = true;
				}
				if (base.OwnedForms.Length == 0)
				{
					flag = true;
				}
				if (flag)
				{
					MacroSharing macroSharing = new MacroSharing(emu.path, emu.sourcePath);
					AddOwnedForm(macroSharing);
					macroSharing.Show();
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void macroButton_MouseDown(object sender, MouseEventArgs e)
		{
			macroButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void macroButton_MouseUp(object sender, MouseEventArgs e)
		{
			macroButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void optionsButton_MouseEnter(object sender, EventArgs e)
		{
			optionsButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void optionsButton_MouseLeave(object sender, EventArgs e)
		{
			optionsButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void optionsButton_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = false;
				if (base.OwnedForms.Length == 1 && base.OwnedForms[0].ToString().Contains("Xceed"))
				{
					flag = true;
				}
				if (base.OwnedForms.Length == 0)
				{
					flag = true;
				}
				if (flag)
				{
					Options options = new Options(emu.path, emu.sourcePath);
					AddOwnedForm(options);
					options.Show();
					GC.Collect();
				}
				updateDrop = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void optionsButton_MouseDown(object sender, MouseEventArgs e)
		{
			optionsButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void optionsButton_MouseUp(object sender, MouseEventArgs e)
		{
			optionsButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void gameOptionsButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (File.Exists(emu.path + "\\swgemu_setup.exe"))
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo(emu.path + "\\swgemu_setup.exe");
					processStartInfo.WorkingDirectory = emu.path;
					processStartInfo.UseShellExecute = false;
					Process.Start(processStartInfo);
					GC.Collect();
				}
				else
				{
					MessageBox.Show("Configuration utility missing.  Are you finished downloading all the files yet?");
				}
			}
			catch (Exception ex)
			{
				writeCrashLog("Error Launching config: " + ex.Message, ex.StackTrace, ex.Source + "\nExe Exists: " + File.Exists(emu.path + "\\SWGEmu.exe"));
			}
		}

		private void gameOptionsButton_MouseEnter(object sender, EventArgs e)
		{
			gameOptionsButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void gameOptionsButton_MouseLeave(object sender, EventArgs e)
		{
			gameOptionsButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void gameOptionsButton_MouseDown(object sender, MouseEventArgs e)
		{
			gameOptionsButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void gameOptionsButton_MouseUp(object sender, MouseEventArgs e)
		{
			gameOptionsButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			try
			{
				launchGame();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void playButton_MouseEnter(object sender, EventArgs e)
		{
			playButton.Image = startImages.Images[1];
			GC.Collect();
		}

		private void playButton_MouseLeave(object sender, EventArgs e)
		{
			if (!startImages.Images.Empty)
			{
				playButton.Image = startImages.Images[0];
			}
			GC.Collect();
		}

		private void playButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (!startImages.Images.Empty)
			{
				playButton.Image = startImages.Images[2];
			}
			GC.Collect();
		}

		private void playButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (!startImages.Images.Empty)
			{
				playButton.Image = startImages.Images[1];
			}
			GC.Collect();
		}

		private void serverCombo_MouseEnter(object sender, EventArgs e)
		{
			if (updateDrop)
			{
				buildServersObject();
				updateDropDown();
			}
			updateDrop = false;
		}

		private void serverCombo_SelectedItemChanged(object sender, EventArgs e)
		{
			try
			{
				if (pingThread.IsBusy)
				{
					pingThread.CancelAsync();
				}
				if (downloadWorker == null)
				{
					downloadWorker = new BackgroundWorker();
				}
				if (downloadWorker.IsBusy)
				{
					downloadWorker.CancelAsync();
				}
				faqButton.Image = faqImages.Images[0];
				faqClicked = false;
				LPE.setConfigItem("autoplay", "0");
				if (!string.Equals(serverCombo.TextBoxArea.Text, "Click here for servers --->"))
				{
					currentServer = LPE.getServerFromArrayList(serverCombo.TextBoxArea.Text);
					mainTextBox.Clear();
					if (!downloadWorker.IsBusy)
					{
						downloadWorker.RunWorkerAsync();
						pingThread.RunWorkerAsync();
					}
				}
			}
			catch
			{
			}
			GC.Collect();
		}

		private void serversButton_MouseEnter(object sender, EventArgs e)
		{
			serversButton.Image = smallButtonImages.Images[1];
			GC.Collect();
		}

		private void serversButton_MouseLeave(object sender, EventArgs e)
		{
			serversButton.Image = smallButtonImages.Images[0];
			GC.Collect();
		}

		private void serversButton_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (base.OwnedForms.Length == 1 && base.OwnedForms[0].ToString().Contains("Xceed"))
			{
				flag = true;
			}
			if (base.OwnedForms.Length == 0)
			{
				flag = true;
			}
			if (flag)
			{
				ServerChoose serverChoose = new ServerChoose();
				AddOwnedForm(serverChoose);
				serverChoose.Show();
				GC.Collect();
			}
			updateDrop = true;
		}

		private void serversButton_MouseDown(object sender, MouseEventArgs e)
		{
			serversButton.Image = smallButtonImages.Images[2];
			GC.Collect();
		}

		private void serversButton_MouseUp(object sender, MouseEventArgs e)
		{
			serversButton.Image = smallButtonImages.Images[1];
			GC.Collect();
		}

		private void chatButton_MouseEnter(object sender, EventArgs e)
		{
			chatButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void chatButton_MouseLeave(object sender, EventArgs e)
		{
			chatButton.Image = bigButtonImages.Images[0];
			GC.Collect();
		}

		private void chatButton_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.thewildclan.com/launchpad/chat/main.php");
		}

		private void chatButton_MouseDown(object sender, MouseEventArgs e)
		{
			chatButton.Image = bigButtonImages.Images[2];
			GC.Collect();
		}

		private void chatButton_MouseUp(object sender, MouseEventArgs e)
		{
			chatButton.Image = bigButtonImages.Images[1];
			GC.Collect();
		}

		private void faqButton_MouseEnter(object sender, EventArgs e)
		{
			if (!faqClicked)
			{
				faqButton.Image = faqImages.Images[1];
			}
			GC.Collect();
		}

		private void faqButton_MouseLeave(object sender, EventArgs e)
		{
			if (!faqClicked)
			{
				faqButton.Image = faqImages.Images[0];
			}
			GC.Collect();
		}

		private void faqButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (!faqClicked)
				{
					faqButton.Image = faqImages.Images[2];
					faqClicked = true;
					LPE.setConfigItem("autoplay", "2");
				}
				else
				{
					faqButton.Image = faqImages.Images[0];
					faqClicked = false;
					LPE.setConfigItem("autoplay", "0");
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
