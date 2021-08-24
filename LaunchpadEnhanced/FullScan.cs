using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	internal class FullScan
	{
		public ArrayList checksum = new ArrayList();

		public ArrayList length = new ArrayList();

		public ArrayList file = new ArrayList();

		private ArrayList needed = new ArrayList();

		private string path;

		public bool ok;

		public int index;

		public FullScan(string inPath)
		{
			path = inPath;
			needed = filesNeeded(needed);
			makeArrays();
			ok = false;
		}

		public void next()
		{
		}

		public long getFileLength(string inFile)
		{
			try
			{
				return long.Parse(length[file.IndexOf(inFile.Replace("/", "\\"))].ToString());
			}
			catch (Exception)
			{
				return 0L;
			}
		}

		private void makeArrays()
		{
			file.Clear();
			length.Clear();
			checksum.Clear();
			for (int i = 0; i < needed.Count; i++)
			{
				string text = needed[i].ToString();
				if (text.IndexOf(';') != -1)
				{
					string value = text.Substring(0, text.IndexOf(';')).Replace('/', '\\');
					file.Add(value);
					value = text.Substring(text.IndexOf(';') + 1);
					value = value.Substring(0, value.IndexOf(';'));
					length.Add(value);
					value = text.Substring(text.LastIndexOf(';') + 1);
					checksum.Add(value);
				}
			}
		}

		private string createMD5Checksum(string fileString)
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

		private ArrayList filesNeeded(ArrayList allFiles)
		{
			if (!File.Exists(LPE.commonFiles + "required.cfg"))
			{
				LPE.download(LPE.requiredLocation, LPE.commonFiles + "required.cfg");
			}
			return LPE.readFileToString(LPE.commonFiles + "required.cfg");
		}

		public string check(string p)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path + "\\" + file[index].ToString());
				if (index < file.Count)
				{
					if (p.Equals(checksum[index].ToString()) && fileInfo.Length.ToString().Equals(length[index].ToString()))
					{
						file.RemoveAt(index);
						length.RemoveAt(index);
						checksum.RemoveAt(index);
						return "";
					}
					if (File.Exists(path + "\\" + file[index].ToString()))
					{
						File.Delete(path + "\\" + file[index].ToString());
					}
					file.RemoveAt(index);
					length.RemoveAt(index);
					checksum.RemoveAt(index);
					return file[index - 1].ToString() + "\n";
				}
				ok = true;
				return "";
			}
			catch (Exception ex)
			{
				mainForm.writeCrashLog("Error in 'check' \n Trying to check " + p + "\n" + ex.Message, ex.StackTrace, ex.Source);
				return "";
			}
		}

		public bool checkFile(string p)
		{
			try
			{
				int num = file.IndexOf(p.Replace(path, "").Replace('\\', '/').Substring(1));
				if (num > -1)
				{
					FileInfo fileInfo = new FileInfo(path + "\\" + file[num].ToString());
					string text = createMD5Checksum(p);
					if (!text.Equals(checksum[num].ToString()) || !fileInfo.Length.ToString().Equals(length[num].ToString()))
					{
						if (File.Exists(path + "\\" + file[num].ToString()))
						{
							File.Delete(path + "\\" + file[num].ToString());
						}
						return false;
					}
					return true;
				}
				return true;
			}
			catch (Exception ex)
			{
				mainForm.writeCrashLog("Error in 'checkFile' " + ex.Message, ex.StackTrace, ex.Source);
				return false;
			}
		}
	}
}
