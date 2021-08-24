using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			try
			{
				Thread.Sleep(700);
				string processName = Process.GetCurrentProcess().ProcessName;
				Process[] processesByName = Process.GetProcessesByName(processName);
				if (processesByName.Length > 1 && processName.Equals("LaunchpadEnhanced"))
				{
					MessageBox.Show("Application is already running.  Use control alt delete, to stop if you can't see it, or just restart your computer.");
					return;
				}
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				if (checkLauncherFiles())
				{
					LPE.makeSureDirectoryExists(LPE.commonFiles);
					InitialEmuSetup initialEmuSetup = new InitialEmuSetup();
					DialogResult dialogResult = ((!initialEmuSetup.show) ? DialogResult.OK : initialEmuSetup.ShowDialog());
					if (dialogResult == DialogResult.OK)
					{
						BackgroundWorker backgroundWorker = new BackgroundWorker();
						backgroundWorker.DoWork += loading_DoWork;
						backgroundWorker.RunWorkerAsync();
						Application.Run(new mainForm());
					}
				}
				else
				{
					DialogResult dialogResult2 = MessageBox.Show("Error getting files from internet, Try again?\n\nIf this persists, your internet may suck.", "Warning!", MessageBoxButtons.YesNo);
					if (dialogResult2.ToString().Equals("Yes"))
					{
						Application.Restart();
					}
					else
					{
						Application.Exit();
					}
				}
			}
			catch (Exception ex)
			{
				File.Delete(LPE.installerLocation + "Vista Api.dll");
				File.Delete(LPE.installerLocation + "Xceed.Editors.dll");
				File.Delete(LPE.installerLocation + "Xceed.Grid.dll");
				File.Delete(LPE.installerLocation + "Xceed.UI.dll");
				MessageBox.Show("Big ass error: " + ex.Message);
				ErrorReportMail errorReportMail = new ErrorReportMail("Big ass error: " + ex.Message, ex.StackTrace, ex.Source);
				errorReportMail.ShowDialog();
				Application.Exit();
			}
		}

		public static bool checkLauncherFiles()
		{
			try
			{
				LPE.checkFileForIntegrity("", "MySql.Data.dll", "85F4C79570DD8F71AC6DAFF97778CBF");
				LPE.checkFileForIntegrity("", "Xceed.Editors.dll", "F313FCA4276776CE9A6F242A6B78CDAF");
				LPE.checkFileForIntegrity("", "Xceed.Grid.dll", "D5B3CB541899B6D4FF46F3AA6988742");
				LPE.checkFileForIntegrity("", "Xceed.UI.dll", "C26B46A0DD25BA6B38A7423EFDA21860");
				if (!File.Exists("Xceed.Editors.dll"))
				{
					LPE.download(LPE.installerLocation + "Xceed.Editors.dll");
				}
				if (!File.Exists("Xceed.Grid.dll"))
				{
					LPE.download(LPE.installerLocation + "Xceed.Grid.dll");
				}
				if (!File.Exists("MySql.Data.dll"))
				{
					LPE.download(LPE.installerLocation + "MySql.Data.dll");
				}
				if (!File.Exists("Xceed.UI.dll"))
				{
					LPE.download(LPE.installerLocation + "Xceed.UI.dll");
				}
				if (File.Exists("Xceed.Editors.dll") || File.Exists("Xceed.Grid.dll") || File.Exists("MySql.Data.dll") || File.Exists("Xceed.UI.dll"))
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private static void loading_DoWork(object sender, DoWorkEventArgs e)
		{
			Application.Run(new StartLoadscreen());
		}
	}
}
