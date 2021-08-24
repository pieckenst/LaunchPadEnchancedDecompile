using LauncherEnhanced;

namespace LaunchpadEnhanced
{
	internal class EmuInstall
	{
		public string path;

		public string sourcePath;

		public bool error;

		public EmuInstall()
		{
			path = LPE.getConfigItem("path");
			sourcePath = LPE.getConfigItem("sourcePath");
			if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(sourcePath))
			{
				error = false;
			}
			else
			{
				error = true;
			}
		}
	}
}
