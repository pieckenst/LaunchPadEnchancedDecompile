namespace LaunchpadEnhanced
{
	internal struct ICMP
	{
		public byte type;

		public byte code;

		public ushort checksum;

		public ushort id;

		public ushort seq;
	}
}
