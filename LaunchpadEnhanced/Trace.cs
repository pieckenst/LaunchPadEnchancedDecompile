using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LaunchpadEnhanced
{
	internal class Trace
	{
		private const int PACKET_SIZE = 32;

		public Trace(string args)
		{
			try
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
				IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry(args).AddressList[0], 80);
				IPEndPoint iPEndPoint = new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 80);
				EndPoint remoteEP2 = iPEndPoint;
				ICMP icmp = new ICMP
				{
					type = 8,
					code = 0,
					checksum = 0,
					id = (ushort)DateTime.Now.Millisecond,
					seq = 0
				};
				REQUEST req = new REQUEST
				{
					m_icmp = icmp,
					m_data = new byte[32]
				};
				for (int i = 0; i < req.m_data.Length; i++)
				{
					req.m_data[i] = 83;
				}
				byte[] array = CreatePacket(req);
				string text = "Results";
				for (int j = 1; j <= 256; j++)
				{
					byte[] array2 = new byte[256];
					socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, j);
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 10000);
					socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);
					DateTime now = DateTime.Now;
					int num = socket.SendTo(array, array.Length, SocketFlags.None, remoteEP);
					if (num == -1)
					{
						MessageBox.Show("error sending data");
					}
					num = socket.ReceiveFrom(array2, array2.Length, SocketFlags.None, ref remoteEP2);
					TimeSpan timeSpan = DateTime.Now - now;
					if (num == -1)
					{
						MessageBox.Show("error getting data");
					}
					text += string.Format("\nTTL= {0,-5} IP= {1,-20} Time= {2,3}ms", j, ((IPEndPoint)remoteEP2).Address, timeSpan.Milliseconds);
					if (num == 60 && BitConverter.ToInt16(array2, 24) == BitConverter.ToInt16(array, 4) && array2[20] == 0)
					{
						break;
					}
					if (array2[20] != 11)
					{
						MessageBox.Show("unexpected reply, quitting...");
						break;
					}
				}
				MessageBox.Show(text ?? "");
			}
			catch (SocketException ex)
			{
				MessageBox.Show(ex.Message);
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
			}
		}

		public static byte[] CreatePacket(REQUEST req)
		{
			byte[] array = new byte[40];
			array[0] = req.m_icmp.type;
			array[1] = req.m_icmp.code;
			Array.Copy(BitConverter.GetBytes(req.m_icmp.checksum), 0, array, 2, 2);
			Array.Copy(BitConverter.GetBytes(req.m_icmp.id), 0, array, 4, 2);
			Array.Copy(BitConverter.GetBytes(req.m_icmp.seq), 0, array, 6, 2);
			for (int i = 0; i < req.m_data.Length; i++)
			{
				array[i + 8] = req.m_data[i];
			}
			int num = 0;
			for (int j = 0; j < array.Length; j += 2)
			{
				num += Convert.ToInt32(BitConverter.ToUInt16(array, j));
			}
			num = (num >> 16) + (num & 0xFFFF);
			num += num >> 16;
			Array.Copy(BitConverter.GetBytes((ushort)(~num)), 0, array, 2, 2);
			return array;
		}
	}
}
