using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitor
{

    public class clientstat
    {
        public string name;
        public string group;
        public string member;
        public string used;
        public string remain;
        public string money;
        public string start;
        public string app;
        public string title;
        public string ip;
        public string mac;
        public int status;
    }

    public class clientstats
    {
        public List<clientstat> clients_list = new List<clientstat>();
    }

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

    public class PacketMonitorServerLogin
    {
        public string command = "login";
        public string name;
    }

    public class PacketServerMonitorLoginok
    {
        public string command = "loginok";
        public string name;
        public bool isadmin;
    }

    public class PacketMonitorServerLogout
    {
        public string command = "logout";
        public string name;
    }
}
