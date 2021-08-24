using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	public class StartLoadscreen : Form
	{
		private IContainer components;

		private BackgroundWorker progressMainThread;

		public SmoothProgressBar progressBar;

		public Label label1;

		private SmoothProgressBar miniProgess;

		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		//protected override void Dispose(bool disposing)
		//{
			//if (disposing && components != null)
			//{
			//	components.Dispose();
			//}
			//base.Dispose(disposing);
		//}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.StartLoadscreen));
			progressBar = new LaunchpadEnhanced.SmoothProgressBar();
			label1 = new System.Windows.Forms.Label();
			progressMainThread = new System.ComponentModel.BackgroundWorker();
			miniProgess = new LaunchpadEnhanced.SmoothProgressBar();
			SuspendLayout();
			progressBar.BackColor = System.Drawing.SystemColors.Control;
			progressBar.Location = new System.Drawing.Point(10, 210);
			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Name = "progressBar";
			progressBar.ProgressBarColor = System.Drawing.Color.Green;
			progressBar.Size = new System.Drawing.Size(284, 18);
			progressBar.TabIndex = 0;
			progressBar.Value = 0;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(12, 178);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 18);
			label1.TabIndex = 1;
			label1.Text = "Loading...";
			progressMainThread.WorkerSupportsCancellation = true;
			progressMainThread.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
			progressMainThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
			miniProgess.BackColor = System.Drawing.SystemColors.Control;
			miniProgess.Location = new System.Drawing.Point(10, 198);
			miniProgess.Maximum = 100;
			miniProgess.Minimum = 0;
			miniProgess.Name = "miniProgess";
			miniProgess.ProgressBarColor = System.Drawing.Color.Green;
			miniProgess.Size = new System.Drawing.Size(284, 10);
			miniProgess.TabIndex = 2;
			miniProgess.Value = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Red;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(300, 235);
			base.Controls.Add(miniProgess);
			base.Controls.Add(label1);
			base.Controls.Add(progressBar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximumSize = new System.Drawing.Size(300, 235);
			MinimumSize = new System.Drawing.Size(300, 235);
			base.Name = "StartLoadscreen";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "StartLoadscreen";
			base.TopMost = true;
			base.TransparencyKey = System.Drawing.Color.Red;
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(Load_MouseUp);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(Load_MouseMove);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Load_MouseDown);
			base.Load += new System.EventHandler(StartLoadscreen_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public StartLoadscreen()
		{
			InitializeComponent();
		}

		private void StartLoadscreen_Load(object sender, EventArgs e)
		{
			progressMainThread.RunWorkerAsync();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				while (progressBar.Value < 100)
				{
					miniProgess.Value = LPE.downloadPercentProgress;
					progressBar.Value = LPE.loadingStatusPercentage;
					if (progressBar.Value == 100)
					{
						break;
					}
					label1.Text = LPE.loadingStatus;
				}
				Thread.Sleep(100);
			}
			catch
			{
			}
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Hide();
		}

		private void progressThread_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		private void progressThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				mainForm mainForm2 = new mainForm();
				mainForm2.Show();
				progressMainThread.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void Load_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void Load_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void Load_MouseMove(object sender, MouseEventArgs e)
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
