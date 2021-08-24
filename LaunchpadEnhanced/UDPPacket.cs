namespace LaunchpadEnhanced
{
	public class UDPPacket
	{
		public byte SourcePort;

		public byte DestPort;

		public ushort Length;

		public ushort CheckSum;

		public byte[] Data;
	}
}
