using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Monitor
{
    public static class WOL
    {
        public static void WakeUp(string macAddress)
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    string ipbrd = addr[i].ToString();
                    ipbrd = ipbrd.Substring(0, ipbrd.LastIndexOf(".") + 1);
                    ipbrd += "255";
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                    Byte[] datagram = new byte[102];

                    for (int s = 0; s <= 5; s++)
                    {
                        datagram[s] = 0xff;
                    }

                    string[] macDigits = new string[6];
                    macDigits[0] = macAddress.Substring(0, 2);
                    macDigits[1] = macAddress.Substring(2, 2);
                    macDigits[2] = macAddress.Substring(4, 2);
                    macDigits[3] = macAddress.Substring(6, 2);
                    macDigits[4] = macAddress.Substring(8, 2);
                    macDigits[5] = macAddress.Substring(10, 2);

                    int start = 6;
                    for (int j = 0; j < 16; j++)
                    {
                        for (int x = 0; x < 6; x++)
                        {
                            datagram[start + j * 6 + x] = (byte)Convert.ToInt32(macDigits[x], 16);
                        }
                    }

                    IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ipbrd), 9);
                    sock.SendTo(datagram, iep);

                    sock.Close();
                }
            }
        }
    }
}
