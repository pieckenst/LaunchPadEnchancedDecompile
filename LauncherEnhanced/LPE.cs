using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LauncherEnhanced
{
	public class LPE
	{
		public static string commonFiles = Environment.GetEnvironmentVariable("AppData") + "\\LPECommon\\LPE\\";

		public static string regLocation = "Software\\SWGEmuLPE";

		public static string exeVersion = "0.52.0038";

		public static string baseLocation = "http://lpe.ocdsoft.com/";

		public static string appLocation = Application.StartupPath + "\\";

		public static string installerLocation = baseLocation + "installer/";

		public static string patchLocation = baseLocation + "patches/";

		public static string themeLocation = baseLocation + "themes/";

		public static string requiredLocation = installerLocation + "required.cfg";

		public static string patchLinks = installerLocation + "PatchLinks.cfg";

		public static string announcementLink = themeLocation + "announcements.php";

		public static string kodanExe = "5E38D985A6BCCE5FD274D43B7E21C";

		public static string kodanData = "6C6375BBE0DA868D1ED54467B21C11AD";

		public static string currentSkin;

		public static string lastServer;

		public static int autoPlay;

		public static int timesRun;

		public static int downloadPercentProgress = 0;

		public static int miniProgressWidth = 0;

		public static string downloadString;

		public static string downloadStatus;

		public static bool unfixableError = false;

		public static string loadingStatus;

		public static int loadingStatusPercentage = 0;

		public static long bytesLeft = 0L;

		public static long bytesCompleted = 0L;

		public static long totalBytesToGet = 0L;

		public static long totalBytesRecieved = 0L;

		public static ArrayList serverArrayList = new ArrayList();

		public static void checkFileForIntegrity(string inPath, string inMD5)
		{
			if (File.Exists(inPath) && !createMD5Checksum(inPath).Equals(inMD5))
			{
				File.Delete(inPath);
			}
		}

		public static void checkFileForIntegrity(string inPath, string inFile, string inMD5)
		{
			checkFileForIntegrity(inPath + inFile, inMD5);
		}

		public static string createMD5Checksum(string fileString)
		{
			FileStream fileStream = new FileStream(fileString, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			mD5CryptoServiceProvider.ComputeHash(fileStream);
			byte[] hash = mD5CryptoServiceProvider.Hash;
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = hash;
			foreach (byte b in array)
			{
				stringBuilder.Append($"{b:X1}");
			}
			fileStream.Close();
			return stringBuilder.ToString();
		}

		public static bool download(string inAddress)
		{
			int num = inAddress.LastIndexOf('/');
			if (num >= 0 && num < inAddress.Length - 1)
			{
				return download(inAddress, inAddress.Substring(num + 1));
			}
			return false;
		}

		public static bool download(string inAddress, string inFileName)
		{
			if (mainDownload(inAddress, inFileName))
			{
				return true;
			}
			return mainDownload(inAddress, inFileName);
		}

		public static bool backupDownload(string inAddress, string inFileName)
		{
			try
			{
				miniProgressWidth = 0;
				downloadString = inFileName.Substring(inFileName.LastIndexOf("\\") + 1);
				downloadStatus = "Getting: ";
				downloadPercentProgress = 0;
				Stream stream = null;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(inAddress);
				httpWebRequest.Timeout = 15000;
				FileStream fileStream = null;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				long contentLength = httpWebResponse.ContentLength;
				stream = httpWebResponse.GetResponseStream();
				int num = 1048576;
				byte[] array = new byte[num];
				int num2 = 0;
				int num3;
				while ((num3 = stream.Read(array, num2, array.Length)) > 0)
				{
					num2 += num3;
					bytesLeft -= num3;
					downloadPercentProgress = (int)((double)num2 / (double)contentLength * 100.0);
					if (num2 == array.Length)
					{
						int num4 = stream.ReadByte();
						if (num4 == -1)
						{
							break;
						}
						byte[] array2 = new byte[array.Length * 2];
						Array.Copy(array, array2, array.Length);
						array2[num2] = (byte)num4;
						array = array2;
						num2++;
					}
				}
				byte[] array3 = new byte[num2];
				Array.Copy(array, array3, num2);
				fileStream = new FileStream(inFileName, FileMode.OpenOrCreate, FileAccess.Write);
				fileStream.Write(array3, 0, array3.Length);
				downloadStatus = "Recieved: ";
				fileStream.Close();
				stream.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool mainDownload(string inAddress, string inFileName)
		{
			try
			{
				miniProgressWidth = 0;
				downloadString = inFileName.Substring(inFileName.LastIndexOf("\\") + 1);
				downloadStatus = "Getting: ";
				downloadPercentProgress = 0;
				Stream stream = null;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(inAddress);
				httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
				httpWebRequest.Timeout = 1500000;
				FileStream fileStream = null;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				long contentLength = httpWebResponse.ContentLength;
				stream = httpWebResponse.GetResponseStream();
				int num = 32768;
				byte[] array = new byte[num];
				int num2 = 0;
				int num3;
				while ((num3 = stream.Read(array, num2, array.Length - num2)) > 0)
				{
					num2 += num3;
					bytesLeft -= num3;
					downloadPercentProgress = (int)((double)num2 / (double)contentLength * 100.0);
					totalBytesRecieved += num3;
					if (num2 == array.Length)
					{
						int num4 = stream.ReadByte();
						if (num4 == -1)
						{
							break;
						}
						byte[] array2 = new byte[array.Length * 2];
						Array.Copy(array, array2, array.Length);
						array2[num2] = (byte)num4;
						array = array2;
						num2++;
					}
				}
				byte[] array3 = new byte[num2];
				Array.Copy(array, array3, num2);
				fileStream = new FileStream(inFileName, FileMode.OpenOrCreate, FileAccess.Write);
				fileStream.Write(array3, 0, array3.Length);
				downloadString = "";
				downloadStatus = "Download Complete!";
				fileStream.Close();
				stream.Close();
				return true;
			}
			catch (Exception ex)
			{
				if (!inFileName.Contains(".inc"))
				{
					MessageBox.Show("Main: " + ex.Message + "\nAddress: " + inAddress + "\nFile:" + inFileName);
				}
				return false;
			}
		}

		public static bool lastDownload(string inAddress, string inFileName)
		{
			try
			{
				downloadString = inFileName.Substring(inFileName.LastIndexOf("\\") + 1);
				downloadStatus = "Getting: ";
				downloadPercentProgress = 0;
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += client_DownloadProgressChanged;
				webClient.DownloadFileAsync(new Uri(inAddress), inFileName);
				while (webClient.IsBusy)
				{
					Thread.Sleep(500);
				}
				webClient.Dispose();
				downloadPercentProgress = 100;
				downloadString = "";
				downloadStatus = "Download Complete!";
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			downloadPercentProgress = e.ProgressPercentage;
			totalBytesRecieved = e.BytesReceived + bytesCompleted;
		}

		public static void fileCopy(string inAddress, string inFileName)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					FileStream fileStream = new FileStream(inAddress, FileMode.Open, FileAccess.Read);
					downloadString = inFileName.Substring(inFileName.LastIndexOf("\\") + 1);
					downloadStatus = "Copying: ";
					long length = fileStream.Length;
					byte[] array = new byte[length];
					int num = array.Length;
					int num2 = 0;
					downloadPercentProgress = 0;
					while (num > 0)
					{
						int num3 = fileStream.Read(array, num2, num);
						if (num3 == 0)
						{
							break;
						}
						bytesLeft -= num3;
						num2 += num3;
						num -= num3;
						downloadPercentProgress = (int)((double)num2 / (double)length * 100.0);
					}
					FileStream fileStream2 = new FileStream(inFileName, FileMode.OpenOrCreate, FileAccess.Write);
					fileStream2.Write(array, 0, num2);
					fileStream.Close();
					fileStream2.Close();
					i = 10;
					downloadStatus = "Waiting: ";
					downloadString = "Finished";
					GC.Collect();
				}
				catch (Exception)
				{
					Thread.Sleep(500);
				}
			}
		}

		public static bool checkForUpdates()
		{
			try
			{
				if (File.Exists(commonFiles + "version.txt"))
				{
					File.Delete(commonFiles + "version.txt");
				}
				download(installerLocation + "version.txt", commonFiles + "version.txt");
				if (!unfixableError)
				{
					ArrayList arrayList = readFileToString(commonFiles + "version.txt");
					if (!File.Exists(commonFiles + "config.cfg"))
					{
						try
						{
							themeReset(getRegKey(regLocation, "path"));
							if (File.Exists(commonFiles + "config.cfg"))
							{
								File.Delete(commonFiles + "config.cfg");
							}
							StreamWriter streamWriter = File.CreateText(commonFiles + "config.cfg");
							streamWriter.WriteLine("autoplay = 0");
							streamWriter.WriteLine("lastServer = ");
							//streamWriter.WriteLine("path = " + getRegKey(regLocation, "path"));
							streamWriter.WriteLine("skin = Classic");
							streamWriter.WriteLine("sourcePath = " + getRegKey(regLocation, "path"));
							streamWriter.WriteLine("timesRun = 1");
							streamWriter.Close();
						}
						catch
						{
						}
					}
					if (!arrayList[0].ToString().Equals(exeVersion))
					{
						try
						{
							if (File.Exists(appLocation + "LaunchpadEnhanced.exe.old"))
							{
								File.Delete(appLocation + "LaunchpadEnhanced.exe.old");
							}
						}
						catch
						{
						}
						if (!download(installerLocation + "LaunchpadEnhanced.exe", appLocation + "LaunchpadEnhanced.exe.temp"))
						{
							try
							{
								File.Move(appLocation + "LaunchpadEnhanced.exe.old", appLocation + "LaunchpadEnhanced.exe");
							}
							catch
							{
								download(installerLocation + "LaunchpadEnhanced.exe", appLocation + "LaunchpadEnhanced.exe");
							}
						}
						else
						{
							File.Move(appLocation + "LaunchpadEnhanced.exe", appLocation + "LaunchpadEnhanced.exe.old");
							File.Move(appLocation + "LaunchpadEnhanced.exe.temp", appLocation + "LaunchpadEnhanced.exe");
						}
						checkSkinIntegrity();
						checkLoadingIntegrity();
						setConfigItem("timesRun", "1");
						Application.Restart();
						return true;
					}
					return false;
				}
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Updating: " + ex.Message);
				Application.Exit();
				return false;
			}
		}

		public static void moveFolder()
		{
			try
			{
				DialogResult dialogResult = MessageBox.Show("This process is going to update the Launchpad.  All files in the folder '" + Application.StartupPath + "' will be moved to '" + commonFiles, "Warning!", MessageBoxButtons.YesNo);
				if (dialogResult.ToString().Equals("Yes"))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						if (files[i].Name.Contains(".dll") || files[i].Name.Equals("LaunchpadEnhanced.exe") || files[i].Name.Contains("install"))
						{
							continue;
						}
						try
						{
							if (File.Exists(commonFiles + files[i].Name))
							{
								File.Delete(commonFiles + files[i].Name);
							}
							files[i].MoveTo(commonFiles + files[i].Name);
						}
						catch
						{
							MessageBox.Show("Cant move " + files[i].Name);
						}
					}
					for (int j = 0; j < directories.Length; j++)
					{
						try
						{
							if (Directory.Exists(commonFiles + directories[j].Name))
							{
								Directory.Delete(commonFiles + directories[j].Name, recursive: true);
							}
							directories[j].MoveTo(commonFiles + directories[j].Name);
						}
						catch
						{
							MessageBox.Show("Cant move " + directories[j].Name);
						}
					}
				}
				else
				{
					MessageBox.Show("Files not moved, you will have to re-input your custom servers.");
				}
			}
			catch
			{
			}
		}

		public static void checkSkinIntegrity()
		{
			download(themeLocation + "/skins/" + currentSkin + "/check.cfg", commonFiles + "skins\\" + currentSkin + "\\check.cfg");
			ArrayList arrayList = readFileToString(commonFiles + "skins\\" + currentSkin + "\\check.cfg");
			for (int i = 0; i < arrayList.Count; i++)
			{
				string text = arrayList[i].ToString();
				if (text.IndexOf(';') != -1)
				{
					string inFile = text.Substring(0, text.IndexOf(';')).Replace('/', '\\');
					string text2 = text.Substring(text.IndexOf(';') + 1);
					text2 = text2.Substring(0, text2.IndexOf(';'));
					string inMD = text.Substring(text.LastIndexOf(';') + 1);
					checkFileForIntegrity(commonFiles + "\\skins\\" + currentSkin + "\\", inFile, inMD);
				}
			}
		}

		public static void checkLoadingIntegrity()
		{
			string text = commonFiles + "themes\\loading\\";
			makeSureDirectoryExists(text);
			try
			{
				if (File.Exists(text + "check.cfg"))
				{
					File.Delete(text + "check.cfg");
				}
				if (!download(themeLocation + "loading/check.cfg", text + "check.cfg"))
				{
					return;
				}
				ArrayList arrayList = readFileToString(text + "check.cfg");
				arrayList[0].ToString().Replace("FORCED=", "");
				for (int i = 1; i < arrayList.Count; i++)
				{
					string text2 = arrayList[i].ToString();
					string text3;
					string text4;
					string checkSum;
					if (text2.IndexOf(';') != -1)
					{
						text3 = text2.Substring(0, text2.IndexOf(';')).Replace('/', '\\');
						text4 = text2.Substring(0, text2.IndexOf(';'));
						string text5 = text2.Substring(text2.IndexOf(';') + 1);
						text5 = text5.Substring(0, text5.IndexOf(';'));
						checkSum = text2.Substring(text2.LastIndexOf(';') + 1);
					}
					else
					{
						text3 = text2.Replace('/', '\\');
						text4 = text2;
						checkSum = "";
					}
					string address = themeLocation + "loading/" + text4;
					string text6 = text + text3;
					makeSureDirectoryExists(text6.Substring(0, text6.LastIndexOf("\\")));
					getCustomFile(address, text6, checkSum);
				}
			}
			catch (IOException)
			{
			}
		}

		public static void checkLoginIntegrity()
		{
			try
			{
				for (int i = 0; i < Directory.GetDirectories(commonFiles + "themes\\login").Length; i++)
				{
					download(themeLocation + "/login/" + Directory.GetDirectories(commonFiles + "themes\\login")[i].Substring(Directory.GetDirectories(commonFiles + "themes\\login")[i].LastIndexOf("\\") + 1) + "/check.cfg", commonFiles + "themes\\login\\" + Directory.GetDirectories(commonFiles + "themes\\login")[i].Substring(Directory.GetDirectories(commonFiles + "themes\\login")[i].LastIndexOf("\\") + 1) + "\\check.cfg");
					ArrayList arrayList = readFileToString(commonFiles + "themes\\login\\" + Directory.GetDirectories(commonFiles + "themes\\login")[i].Substring(Directory.GetDirectories(commonFiles + "themes\\login")[i].LastIndexOf("\\") + 1) + "\\check.cfg");
					for (int j = 0; j < arrayList.Count; j++)
					{
						string text = arrayList[j].ToString();
						if (text.IndexOf(';') != -1)
						{
							string inFile = text.Substring(0, text.IndexOf(';')).Replace('/', '\\');
							string text2 = text.Substring(text.IndexOf(';') + 1);
							text2 = text2.Substring(0, text2.IndexOf(';'));
							string inMD = text.Substring(text.LastIndexOf(';') + 1);
							checkFileForIntegrity(commonFiles + "\\themes\\login\\" + Directory.GetDirectories(commonFiles + "themes\\login")[i].Substring(Directory.GetDirectories(commonFiles + "themes\\login")[i].LastIndexOf("\\") + 1) + "\\", inFile, inMD);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public static string getChecksum(string p)
		{
			if (p.IndexOf(';') != -1)
			{
				return p.Substring(p.LastIndexOf(';') + 1);
			}
			return "";
		}

		public static void getCustomFile(string address, string saveLocation, string checkSum)
		{
			if (!string.IsNullOrEmpty(checkSum))
			{
				checkFileForIntegrity(saveLocation, checkSum);
			}
			if (!File.Exists(saveLocation))
			{
				download(address, saveLocation);
			}
		}

		public static string getRegKey(string inPath, string inKey)
		{
			RegistryKey registryKey = null;
			string text = "";
			try
			{
				registryKey = Registry.LocalMachine.OpenSubKey(inPath);
				if (registryKey != null)
				{
					text = registryKey.GetValue(inKey).ToString();
					registryKey.Close();
					return text;
				}
				registryKey.Close();
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static bool setConfigItem(string inItem, string inValue)
		{
			try
			{
				ArrayList arrayList = readFileToString(commonFiles + "config.cfg");
				File.Delete(commonFiles + "config.cfg");
				StreamWriter streamWriter = File.CreateText(commonFiles + "config.cfg");
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (arrayList[i].ToString().Contains(inItem))
					{
						streamWriter.WriteLine(arrayList[i].ToString().Substring(0, arrayList[i].ToString().IndexOf('=') + 2) + inValue);
					}
					else
					{
						streamWriter.WriteLine(arrayList[i].ToString());
					}
				}
				streamWriter.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string getConfigItem(string inItem)
		{
			try
			{
				ArrayList arrayList = readFileToString(commonFiles + "config.cfg");
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (arrayList[i].ToString().Contains(inItem))
					{
						return arrayList[i].ToString().Substring(arrayList[i].ToString().IndexOf('=') + 2);
					}
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static void makeSureDirectoryExists(string inPath, string inString)
		{
			makeSureDirectoryExists(inPath + "\\" + inString);
		}

		public static void makeSureDirectoryExists(string inPath)
		{
			string[] array = inPath.Split('\\');
			string text = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				text = text + "\\" + array[i];
				if (!Directory.Exists(text) && !array[i].Contains("."))
				{
					Directory.CreateDirectory(text);
				}
			}
		}

		public static ArrayList listContents(string dir, ArrayList AllFilesInDir)
		{
			string[] files = Directory.GetFiles(dir);
			string[] directories = Directory.GetDirectories(dir);
			for (int i = 0; i < directories.Length; i++)
			{
				listContents(directories[i], AllFilesInDir);
			}
			for (int j = 0; j < files.Length; j++)
			{
				AllFilesInDir.Add(files[j]);
			}
			return AllFilesInDir;
		}

		public static ArrayList readFileToString(string fileName)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				TextReader textReader = new StreamReader(fileName);
				string text = textReader.ReadLine();
				int num = 0;
				while (text != null)
				{
					if (text.Length > 1)
					{
						arrayList.Add(text);
						num++;
					}
					text = textReader.ReadLine();
				}
				textReader.Close();
				return arrayList;
			}
			catch (Exception)
			{
				return arrayList;
			}
		}

		public static string removeDownloadPath(string p, ArrayList locations)
		{
			for (int i = 0; i < locations.Count; i++)
			{
				p = p.Replace(locations[i].ToString(), "");
			}
			return p;
		}

		public static void getIP()
		{
			string address = "http://whatismyip.com";
			string pattern = "(?<=<TITLE>.*)\\d*\\.\\d*\\.\\d*\\.\\d*(?=</TITLE>)";
			WebClient webClient = new WebClient();
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			string input = "";
			try
			{
				input = uTF8Encoding.GetString(webClient.DownloadData(address));
			}
			catch (WebException ex)
			{
				Console.Write(ex.ToString());
			}
			Regex regex = new Regex(pattern);
			Match match = regex.Match(input);
			IPAddress iPAddress = null;
			if (match.Success)
			{
				iPAddress = IPAddress.Parse(match.Value);
			}
			MessageBox.Show(string.Concat(iPAddress));
		}

		public static void totalReset(string inLocation)
		{
			DialogResult dialogResult = MessageBox.Show("This will delete your EMU folder and everything will download from the server. This will 100% ensure that you have the right files to run the game.There is no reversing this.  CLick yes if you are having trouble with crashes", "Warning!", MessageBoxButtons.YesNo);
			if (dialogResult.ToString().Equals("Yes"))
			{
				Directory.Delete(inLocation, recursive: true);
				Application.Restart();
			}
		}

		public static void partialReset(string inLocation)
		{
			try
			{
				string[] files = Directory.GetFiles(inLocation);
				foreach (string text in files)
				{
					FileInfo fileInfo = new FileInfo(text);
					if (!text.Contains(".tre") && !text.Contains("screenshot") && fileInfo.Length < 30000000)
					{
						File.Delete(text);
					}
				}
				string[] directories = Directory.GetDirectories(inLocation);
				foreach (string path in directories)
				{
					Directory.Delete(path, recursive: true);
				}
				Application.Restart();
			}
			catch
			{
			}
		}

		public static void configReset(string inLocation)
		{
			string[] files = Directory.GetFiles(inLocation);
			foreach (string text in files)
			{
				FileInfo fileInfo = new FileInfo(text);
				if ((text.Contains(".cfg") || !text.Contains(".dll")) && fileInfo.Length < 30000000)
				{
					File.Delete(text);
				}
			}
		}

		public static Server getServerFromArrayList(string inName)
		{
			foreach (Server serverArray in serverArrayList)
			{
				if (string.Equals(serverArray.sname, inName))
				{
					return serverArray;
				}
			}
			return null;
		}

		public static void themeReset(string pathToEmu)
		{
			try
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
				Directory.Delete(commonFiles + "themes\\login\\", recursive: true);
			}
			catch
			{
			}
		}

		internal static Server getServerObjectByName(string p)
		{
			throw new NotImplementedException();
		}
	}
}
