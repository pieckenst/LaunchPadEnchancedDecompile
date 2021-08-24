using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Windows.Forms;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	internal class BuildInstall
	{
		public string path;

		public string sourcePath;

		public ArrayList missingFiles = new ArrayList();

		private ArrayList allFiles = new ArrayList();

		public ArrayList unresolvedFiles = new ArrayList();

		public bool ok;

		public bool local;

		public bool stuck;

		public bool clientCrash;

		public string error = "";

		public ArrayList patchLocations = new ArrayList();

		public ArrayList filesToCopy = new ArrayList();

		public ArrayList filesToDownload = new ArrayList();

		public BuildInstall(string inPath, string inSourcePath)
		{
			ok = false;
			local = false;
			stuck = false;
			path = inPath;
			sourcePath = inSourcePath;
			getPatchLocations();
			detectClientCrash();
			checkUICase();
			makeLocationArrays();
			update();
			if (missingFiles.Count == 0)
			{
				ok = true;
			}
		}

		private void makeLocationArrays()
		{
			try
			{
				for (int i = 0; i < missingFiles.Count; i++)
				{
					string text = ((!missingFiles[i].ToString().Contains(".tre")) ? getPatchLocation(missingFiles[i].ToString(), ignoreLocal: true) : getPatchLocation(missingFiles[i].ToString(), ignoreLocal: false));
					if (text.Contains(sourcePath) && text.Contains(".tre"))
					{
						filesToCopy.Add(text);
					}
					else
					{
						filesToDownload.Add(text);
					}
				}
			}
			catch
			{
			}
		}

		private void getPatchLocations()
		{
			patchLocations.Clear();
			patchLocations.Add(sourcePath);
			try
			{
				File.Delete(LPE.commonFiles + "PatchLinks.cfg");
			}
			catch
			{
			}
			LPE.download(LPE.patchLinks, LPE.commonFiles + "PatchLinks.cfg");
			try
			{
				TextReader textReader = new StreamReader(LPE.commonFiles + "PatchLinks.cfg");
				for (string text = textReader.ReadLine(); text != null; text = textReader.ReadLine())
				{
					if (text.Length > 1)
					{
						patchLocations.Add(text);
					}
				}
				textReader.Close();
			}
			catch (Exception)
			{
			}
		}

		private void checkUICase()
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					if (directories[i].ToString().Contains("UI") || directories[i].ToString().Contains("uI") || directories[i].ToString().Contains("Ui"))
					{
						Directory.Delete(directories[i].FullName, recursive: true);
					}
				}
			}
			catch
			{
				Directory.Delete(path + "\\ui", recursive: true);
			}
		}

		private void detectClientCrash()
		{
			try
			{
				ArrayList allFilesInDir = new ArrayList();
				allFilesInDir = LPE.listContents(path, allFilesInDir);
				for (int i = 0; i < allFilesInDir.Count; i++)
				{
					if (!allFilesInDir[i].ToString().Contains("SWGEmu.exe-stage"))
					{
						continue;
					}
					ArrayList arrayList = LPE.readFileToString(allFilesInDir[i].ToString());
					if (arrayList.Contains("unknown location : FATAL 55fd64d9: SetVertexShaderConstantF failed 2156"))
					{
						MessageBox.Show("Please open SWGEmu_setup.exe, Click the Graphics Tab, and set \"Vertex/Pixel Shader Version\" to \"Disabled\"\nOpening folder for you");
						Process.Start(path);
					}
					else if (arrayList.Contains("[SwgCuiQuestJournal]"))
					{
						LPE.configReset(path);
					}
					try
					{
						if (allFilesInDir[i].ToString().Contains("txt"))
						{
							sendCrashLog(allFilesInDir[i].ToString());
						}
					}
					catch
					{
					}
					File.Delete(allFilesInDir[i].ToString());
					clientCrash = true;
				}
			}
			catch (Exception)
			{
			}
		}

		private void sendCrashLog(string inFile)
		{
			try
			{
				MailAddress from = new MailAddress("LPEerrors@gmail.com");
				MailMessage mailMessage = new MailMessage("LPEerrors@gmail.com", "firehammer@thewildclan.com");
				mailMessage.Subject = "SWGCrash Log";
				mailMessage.Body = "Emu Crash log\n" + WindowsIdentity.GetCurrent().Name.ToString() + "\nTimes Run: " + LPE.getConfigItem("timesRun");
				mailMessage.From = from;
				if (File.Exists("bootlog.txt"))
				{
					Attachment item = new Attachment(inFile);
					mailMessage.Attachments.Add(item);
				}
				SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new NetworkCredential("lpeerrors@gmail.com", "scrappy");
				smtpClient.Timeout = 20000;
				smtpClient.Send(mailMessage);
				mailMessage.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ?? "");
			}
		}

		public void update()
		{
			try
			{
				allFiles.Clear();
				missingFiles.Clear();
				allFiles = removeParentDir(LPE.listContents(path, allFiles));
				missingFiles = filesNeeded(allFiles);
				if (missingFiles.Count == 0 && unresolvedFiles.Count == 0)
				{
					ok = true;
					return;
				}
				LPE.downloadString = "";
				LPE.downloadStatus = "Calculating file sizes...";
				makeLocationArrays();
				LPE.downloadString = " Done";
			}
			catch (Exception)
			{
				MessageBox.Show("Error in update");
			}
		}

		private ArrayList filesNeeded(ArrayList allFiles)
		{
			try
			{
				if (File.Exists(LPE.commonFiles + "required.cfg"))
				{
					File.Delete(LPE.commonFiles + "required.cfg");
				}
				LPE.download(LPE.requiredLocation, LPE.commonFiles + "required.cfg");
				ArrayList arrayList = LPE.readFileToString(LPE.commonFiles + "required.cfg");
				ArrayList arrayList2 = new ArrayList();
				for (int i = 0; i < arrayList.Count; i++)
				{
					string[] array = arrayList[i].ToString().Replace("/", "\\").Split(';');
					try
					{
						if (!string.IsNullOrEmpty(array[2]))
						{
							if (!allFiles.Contains(array[0]) && !unresolvedFiles.Contains(array[0]))
							{
								arrayList2.Add(array[0]);
								continue;
							}
							try
							{
								FileInfo fileInfo = new FileInfo(path + "\\" + array[0]);
								string s = array[1];
								if (int.Parse(fileInfo.Length.ToString()) != int.Parse(s))
								{
									arrayList2.Add(array[0]);
								}
							}
							catch
							{
							}
							continue;
						}
						try
						{
							if (!allFiles.Contains(array[0]) && !unresolvedFiles.Contains(array[0]))
							{
								arrayList2.Add(array[0]);
							}
						}
						catch
						{
						}
					}
					catch
					{
						try
						{
							if (!allFiles.Contains(array[0]) && !unresolvedFiles.Contains(array[0]))
							{
								arrayList2.Add(array[0]);
							}
						}
						catch
						{
						}
					}
				}
				for (int j = 0; j < arrayList2.Count; j++)
				{
					if (File.Exists(path + "\\" + arrayList2[j].ToString()))
					{
						DialogResult dialogResult = MessageBox.Show("Launchpad thinks " + arrayList2[j].ToString() + " is corrupt for some reason, do you want to delete and redownload?", "Warning!", MessageBoxButtons.YesNo);
						if (dialogResult.ToString().Equals("Yes"))
						{
							File.Delete(path + "\\" + arrayList2[j].ToString());
							continue;
						}
						arrayList2.RemoveAt(j);
						j--;
					}
				}
				return arrayList2;
			}
			catch (Exception)
			{
				MessageBox.Show("Error in next");
			}
			return null;
		}

		private ArrayList removeParentDir(ArrayList allFiles)
		{
			for (int i = 0; i < allFiles.Count; i++)
			{
				string text = allFiles[i].ToString().Replace(path, "");
				if (text[0] == '\\')
				{
					text = text.Substring(1);
				}
				allFiles[i] = text;
			}
			return allFiles;
		}

		private string getPatchLocation(string inString, bool ignoreLocal)
		{
			try
			{
				randomizePatchLocations();
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < patchLocations.Count; j++)
					{
						try
						{
							LPE.downloadStatus = "Checking ";
							LPE.downloadString = inString;
							HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create((string)patchLocations[j] + inString);
							httpWebRequest.Timeout = 6000;
							HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
							httpWebRequest.Abort();
							httpWebResponse.Close();
							return (string)patchLocations[j] + inString;
						}
						catch (Exception)
						{
							if (File.Exists(string.Concat(patchLocations[j], "\\", inString)) && !ignoreLocal)
							{
								return string.Concat(patchLocations[j], "\\", inString);
							}
						}
					}
				}
				return null;
			}
			catch
			{
				LPE.unfixableError = true;
				mainForm.writeCrashLog("Error with patch string: " + inString, "If you see this", "You suck");
				return null;
			}
		}

		private void randomizePatchLocations()
		{
			ArrayList arrayList = new ArrayList();
			Random random = new Random();
			patchLocations.RemoveAt(0);
			arrayList.Add(sourcePath);
			while (patchLocations.Count != 0)
			{
				int index = random.Next(patchLocations.Count);
				arrayList.Add(patchLocations[index].ToString());
				patchLocations.RemoveAt(index);
			}
			patchLocations = arrayList;
		}

		public string changeToRemoteLocation(string inString)
		{
			return getPatchLocation(inString.Replace(sourcePath, "").Substring(1), ignoreLocal: true);
		}
	}
}
