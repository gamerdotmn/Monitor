using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitor
{
    public class Packet
    {
        public string id;
        public int cnt;
        public string[] packets;
        public string ip;
    }

    public class PacketMonitorServerSyn
    {
        public string command = "syn";
    }

    public class PacketServerMonitorSyn
    {
        public string command = "syn";
        public DateTime now;
    }
}
