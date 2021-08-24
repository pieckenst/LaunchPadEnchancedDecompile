using System.Runtime.InteropServices;

namespace LaunchpadEnhanced
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct ICMPConstants
	{
		public const int ICMP_ECHOREPLY = 0;

		public const int ICMP_TIMEEXCEEDED = 11;

		public const int ICMP_ECHOREQ = 8;

		public const int MAX_TTL = 256;
	}
}
