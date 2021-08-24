using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace LaunchpadEnhanced
{
	internal class Downloader
	{
		public string Status;

		private string IncomingFile;

		private string IncomingFileTrunc;

		public int Progress;

		public void download(string inAddress)
		{
			int num = inAddress.LastIndexOf('/');
			if (num >= 0 && num < inAddress.Length - 1)
			{
				download(inAddress, inAddress.Substring(num + 1));
			}
		}

		public void download(string inAddress, string inFileName)
		{
			for (int i = 0; i < 5; i++)
			{
				try
				{
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(inAddress);
					httpWebRequest.Timeout = 8000;
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					Stream responseStream = httpWebResponse.GetResponseStream();
					IncomingFile = inFileName.Substring(inFileName.LastIndexOf("\\") + 1);
					Status = "Downloading: ";
					long contentLength = httpWebResponse.ContentLength;
					byte[] array = new byte[contentLength];
					int num = array.Length;
					int num2 = 0;
					Progress = 0;
					while (num > 0)
					{
						int num3 = responseStream.Read(array, num2, num);
						if (num3 == 0)
						{
							break;
						}
						num2 += num3;
						num -= num3;
						Progress = (int)((double)num2 / (double)contentLength * 100.0);
					}
					FileStream fileStream = new FileStream(inFileName, FileMode.OpenOrCreate, FileAccess.Write);
					fileStream.Write(array, 0, num2);
					responseStream.Close();
					fileStream.Close();
					i = 10;
					Status = "Waiting: ";
					IncomingFile = "Finished";
					GC.Collect();
				}
				catch (Exception ex)
				{
					if (ex.Message.Contains("Unable to read data from the transport connection"))
					{
						MessageBox.Show("Buffer error in main download method, using backup\nProgress Bar will not reflect status for this file");
						try
						{
							WebClient webClient = new WebClient();
							webClient.DownloadFile(new Uri(inAddress), inFileName);
							webClient.Dispose();
						}
						catch (Exception)
						{
							MessageBox.Show("Super Error:  You are Fubared - Restart your PC");
						}
					}
					else
					{
						GC.Collect();
						Thread.Sleep(500);
					}
				}
				if (i == 4)
				{
					try
					{
						WebClient webClient2 = new WebClient();
						webClient2.DownloadFile(new Uri(inAddress), inFileName);
						webClient2.Dispose();
					}
					catch (Exception)
					{
						MessageBox.Show("THIS IS NOT A PROGRAM BUG:\n\nEither your internet is down, or the server that holds this files is down. Bypassing Launchpad Update: Error downloading " + inAddress);
					}
				}
			}
		}
	}
}
