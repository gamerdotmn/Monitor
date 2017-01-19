using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitor
{
    public class gconfig
    {
        public bool load = false;
        public int version;
        public string speedtesturl;
        public int speedtestsize;
    }

    public class Packet
    {
        public string id;
        public int cnt;
        public string[] packets;
        public string ip;
    }

    public class PacketMonitorServerLogin
    {
        public string command = "login";
        public string name;
        public string password;
    }

    public class PacketServerMonitorLoginok
    {
        public string command = "loginok";
        public string name;
        public bool isadmin;
    }

    public class PacketMonitorServerSyn
    {
        public string command = "syn";
    }
}
