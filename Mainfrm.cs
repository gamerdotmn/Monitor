using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Collections;
using System.Timers;
using System.Management;
using System.Drawing.Printing;
using System.Web.Script.Serialization;
using System.Threading;

namespace Monitor
{
    public partial class Mainfrm : DevExpress.XtraEditors.XtraForm
    {
        private Login lfrm = null;
        public static string serverip = "";
        private System.Timers.Timer server_timer;
        private System.Timers.Timer client_timerstats;
        private int connecttimeout = 0;
        private bool connected = false;
        Connecting connecting;
        private Hashtable server_packets = new Hashtable();
        public static bool logged = false;
        public static bool isadmin = false;
        public static DateTime now;
        public static string name = "";
        public static Hashtable broadcast_servers = new Hashtable();
        public static bool printbill = false;
        private const int disconnecttime = 10;
        public const string host = "gamer.mn";
        public static config cfg = new config();

        private void broadcast_listen()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, Program.port_broadcast);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            byte[] data = new byte[1024];
            while (true)
            {
                int recv = sock.ReceiveFrom(data, ref ep);
                string stringData = Encoding.UTF8.GetString(data, 0, recv);
                data = new byte[1024];
                recv = sock.ReceiveFrom(data, ref ep);
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(stringData);

                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "mastercafe" && xd.ChildNodes[0].ChildNodes.Count > 0 && xd.ChildNodes[0].ChildNodes[0].Name == "cmd")
                {
                    string name = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    string ip = ep.ToString();
                    ip = ip.Substring(0, ip.IndexOf(":"));
                    name = name + "(" + ip + ")";
                    if (broadcast_servers.ContainsKey(ip) == false)
                    {
                        broadcast_servers.Add(ip, name);
                        if (lfrm != null)
                        {
                            lfrm.Refresh();
                        }
                        if (serverip == "" && ip != "127.0.0.1")
                        {
                            serverip = ip;
                            //Program.constr = @"Data Source=" + serverip + @"\MASTERCAFE;Initial Catalog=mastercafedb;Persist Security Info=True;User ID=sa;Password=pldifvzz7x;MultipleActiveResultSets=True";
                        }
                    }
                }
            }
            sock.Close();
        }

        private void server_syn(PacketServerMonitorSyn packet)
        {
            now = packet.now;
            if (connected == false)
            {
                connected = true;
                server_connect();
            }
            connecttimeout = 0;
        }

        private void server_sendsyn()
        {
            PacketMonitorServerSyn packet = new PacketMonitorServerSyn();
            Send(serverip, Program.port_monitortoserver, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
            connecttimeout++;
            if (connecttimeout > disconnecttime)
            {
                if (connected)
                {
                    connected = false;
                    server_disconnect();
                }
            }
        }

        private void server_timerelapsed(object sender, EventArgs e)
        {
            server_sendsyn();
        }

        private void lfrm_login()
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                var emps = (from e in dcm.employees where e.name.ToLower() == lfrm.login_username.Text.ToLower() && e.password.ToLower() == lfrm.login_pwd.Text.ToLower() select new { e.name, e.isadmin });
                int cnt = emps.Count();
                if (cnt == 1)
                {
                    if (lfrm.InvokeRequired)
                    {
                        lfrm.Invoke(new MethodInvoker(delegate
                        {
                            lfrm.Close();
                        }));
                    }
                    else
                    {
                        lfrm.Close();
                    }
                    name = emps.FirstOrDefault().name;
                    logged = true;
                    isadmin = emps.FirstOrDefault().isadmin;
                }
                else
                {
                    lfrm.labelerr.Settext("Та хандах эрхгүй байна.");
                }
            }
        }

        private void lfrm_login_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lfrm.login_pwd.Text.Length > 0)
                {
                    lfrm_login();
                }
            }
        }
        private void lfrm_simpleButton_ok_Click(object sender, EventArgs e)
        {
            lfrm_login();
        }


        private void server_disconnect()
        {
            if (MessageBox.Show("Сервер унтарсан байна. Программыг гаргах уу?", "Анхаар", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }
        
        private void Send(string clientip, int port, string message)
        {
            string[] param = new string[3];
            param[0] = clientip;
            param[1] = port.ToString();
            param[2] = message;
            Task.Factory.StartNew(() => _Send(param));
        }
        private void _Send(object obj)
        {
            string[] param = (string[])obj;
            string ip = param[0];
            int port = Convert.ToInt32(param[1]);
            string data = param[2];
            string id = Guid.NewGuid().ToString();
            data = Program.Compress(data);
            int cnt = data.Length / 10000;
            while (10000 * cnt < data.Length)
            {
                cnt = cnt + 1;
            }
            string[] packets = new string[cnt];
            for (int i = 0; i < cnt; i++)
            {
                int step = 10000;
                if (i + 1 == cnt)
                {
                    step = data.Length - i * step;
                }
                packets[i] = data.Substring(i * 10000, step);
                byte[] message = System.Text.Encoding.UTF8.GetBytes("<rc><id>" + id + "</id><part>" + i + "</part><count>" + cnt + "</count><data>" + packets[i] + "</data></rc>");
                try
                {
                    UdpClient sock = new UdpClient(ip, port);
                    sock.Send(message, message.Length);
                    sock.Close();
                    Thread.Sleep(10);
                }
                catch
                {
                    ;
                }
            }
        }

        public Mainfrm()
        {
            try
            {
                UdpClient listener = new UdpClient(Program.port_servertomonitor);
                listener.Close();
            }
            catch
            {
                System.Environment.Exit(0);
            }

            RegistryKey regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCMONITOR\\", true);
            if (regserver == null)
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCMONITOR\\");
                regserver = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCMONITOR\\", true);
            }
            try
            {
                printbill =bool.Parse(Program.Decompress(regserver.GetValue("printbill").ToString()));
            }
            catch
            {
                ;
            }
            regserver.Close();
            Task.Factory.StartNew(() => broadcast_listen());
            Task.Factory.StartNew(() => server_listen());
            server_timer = new System.Timers.Timer(2000);
            server_timer.Elapsed += new ElapsedEventHandler(server_timerelapsed);
            server_timer.Start();
            connecting = new Connecting();
            connecting.ShowDialog(this);
            client_timerstats = new System.Timers.Timer(500);
            client_timerstats.Elapsed += new ElapsedEventHandler(client_timerstatselapsed);
            if (connected == false)
            {
                System.Environment.Exit(0);
            }
            
            DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr);
            lfrm = new Login();
            lfrm.login_pwd.KeyDown += new KeyEventHandler(lfrm_login_pwd_KeyDown);
            lfrm.simpleButton_ok.Click += new EventHandler(lfrm_simpleButton_ok_Click);
            lfrm.ShowDialog(this);
            if (logged)
            {
                
                cfg.org_id = dcm.configs.FirstOrDefault().org_id;
                cfg.org_email = dcm.configs.FirstOrDefault().org_email;
                cfg.org_name = dcm.configs.FirstOrDefault().org_name;
                cfg.org_phone = dcm.configs.FirstOrDefault().org_phone;
                cfg.newmember_price = dcm.configs.FirstOrDefault().newmember_price;
                cfg.newmember_stock = dcm.configs.FirstOrDefault().newmember_stock;
                cfg.close_hour = dcm.configs.FirstOrDefault().close_hour;
                cfg.alert_minute = dcm.configs.FirstOrDefault().alert_minute;
                cfg.alert_message = dcm.configs.FirstOrDefault().alert_message;
                cfg.idle_minute = dcm.configs.FirstOrDefault().idle_minute;

                InitializeComponent();
                int count = (from row in dcm.hourtemplates
                             select row).Count();
                if (count > 0)
                {
                    var htemp = from g in dcm.hourtemplates select g;
                    foreach (var hte in htemp)
                    {
                        mtime.DropDownItems.Add(hte.name);
                    }
                }
                client_timerstats.Start();
                foreach (var g in dcm.groups)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(g.name);
                    tsmi.Name = g.id.ToString();
                    tsmi.Click += new EventHandler(group_click);
                    mgroup.DropDownItems.Add(tsmi);
                }
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void group_click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            using(DataContext_mastercafe dcm=new DataContext_mastercafe(Program.constr))
            {
                for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
                {
                    client cl = dcm.clients.Where(_c => _c.name == listView_clients.SelectedItems[i].Name).FirstOrDefault();
                    cl.group_id = Guid.Parse(tsmi.Name);
                }
                dcm.SubmitChanges();
            }
        }


        private void client_timerstatselapsed(object sender, ElapsedEventArgs e)
        {
            client_stats();
        }

        private void server_connect()
        {
            if (connecting.InvokeRequired)
            {
                connecting.Invoke(new MethodInvoker(delegate
                {
                    connecting.Close();
                }));
            }
            else
            {
                connecting.Close();
            }
        }
        private void users()
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                gridControl1.DataSource = (from t in ms.employees
                                           select new
                                           {
                                               Нэр = t.name,
                                               ХэрэглэгчийнЭрх = t.isadmin == true ? "Админ" : "Кашир",
                                               Засах = "",
                                               Устгах = ""
                                           }).ToList();

                RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
                ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem.Buttons[0].Tag = "edit";
                //ritem.Buttons[0].Image = Monitor.Properties.Resources.delete;
                ritem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ritem_ButtonClick);
                gridControl1.RepositoryItems.Add(ritem);
                gridView1.Columns["Засах"].ColumnEdit = ritem;
                RepositoryItemButtonEdit ritem1 = new RepositoryItemButtonEdit();
                ritem1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem1.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem1.Buttons[0].Tag = "delete";
                ritem1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ritem_ButtonClick);
                gridControl1.RepositoryItems.Add(ritem1);
                gridView1.Columns["Устгах"].ColumnEdit = ritem1;
            }
            catch { MessageBox.Show("users() алдаа гарлаа!!!"); }
        }
        public void ritem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                if (e.Button.Tag.ToString() == "delete")
                {
                    if (MessageBox.Show("Та " + gridView1.GetFocusedRowCellValue("Нэр").ToString() + " нэртэй хэрэглэгчийг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        employee _emp = ms.employees.Single(p => p.name == gridView1.GetFocusedRowCellValue("Нэр").ToString());
                        ms.employees.DeleteOnSubmit(_emp);
                        ms.SubmitChanges();
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
                if (e.Button.Tag.ToString() == "edit")
                {
                    FrmAddEmp add = new FrmAddEmp(gridView1.GetFocusedRowCellValue("Нэр").ToString());
                    add.ShowDialog(this);
                    if (add.ok)
                    {
                        users();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
        public void groups_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                if (e.Button.Tag.ToString() == "delete")
                {
                    if (MessageBox.Show("Та " + gridView_groups.GetFocusedRowCellValue("Нэр").ToString() + " нэртэй группийг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        group _g = ms.groups.Single(g => g.id == Guid.Parse(gridView_groups.GetFocusedRowCellValue("Дугаар").ToString()));
                        ms.groups.DeleteOnSubmit(_g);
                        ms.SubmitChanges();
                        gridView_groups.DeleteRow(gridView_groups.FocusedRowHandle);
                    }
                }
                if (e.Button.Tag.ToString() == "edit")
                {
                    addGroup add = new addGroup(gridView_groups.GetFocusedRowCellValue("Дугаар").ToString());
                    add.ShowDialog(this);
                    if (add.ok)
                    {
                        ngroups();
                    }
                }
            }
            catch { MessageBox.Show("group button click error"); }
        }
        private void MainTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (MainTab.SelectedTabPageIndex)
            {
                case 0:
                    users();
                    break;
                case 1:
                    ngroups();
                    break;
                case 4:
                     ban(); break;
                case 2:
                    break;
                case 3:
                    nmember();
                    break;
                case 5:
                    timez();
                    break;
                case 6:
                    nconfig();
                    break;
            }
        }

        
        public void timez_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                if (e.Button.Tag.ToString() == "delete")
                {
                    if (MessageBox.Show("Та " + gridView_timez.GetFocusedRowCellValue("Нэр").ToString() + " нэртэй группийг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        hourtemplate _g = ms.hourtemplates.Single(g => g.id == Guid.Parse(gridView_timez.GetFocusedRowCellValue("Дугаар").ToString()));
                        ms.hourtemplates.DeleteOnSubmit(_g);
                        ms.SubmitChanges();
                        gridView_timez.DeleteRow(gridView_timez.FocusedRowHandle);
                    }
                }
                if (e.Button.Tag.ToString() == "edit")
                {
                    addTimez edit = new addTimez(gridView_timez.GetFocusedRowCellValue("Дугаар").ToString());
                    edit.ShowDialog(this);
                    if (edit.ok)
                    {
                        timez();
                    }
                }
            }
            catch { ;}
            
        }
        private void timez()
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                gridControl_timez.DataSource = (from t in ms.hourtemplates
                                                 select new
                                                 {
                                                     Дугаар = t.id,
                                                     Нэр = t.name,
                                                     Хэмжээ = t.minute,
                                                     Үнэ = t.price,
                                                     ЭхлэхЦаг = t.beghour,
                                                     ДуусахЦаг = t.endhour,
                                                     Засах = "",
                                                     Устгах = ""
                                                 }).ToList();
                RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
                ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem.Buttons[0].Tag = "edit";
                ritem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(timez_ButtonClick);
                gridControl_timez.RepositoryItems.Add(ritem);
                gridView_timez.Columns["Засах"].ColumnEdit = ritem;
                RepositoryItemButtonEdit ritem1 = new RepositoryItemButtonEdit();
                ritem1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem1.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem1.Buttons[0].Tag = "delete";
                ritem1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(timez_ButtonClick);
                gridControl_timez.RepositoryItems.Add(ritem1);
                gridView_timez.Columns["Устгах"].ColumnEdit = ritem1;
            }
            catch { MessageBox.Show("time z error!!!"); }
        }
        private void nmember()
        {
            if (isadmin)
            {
                simpleButton_edit_member.Visible = true;
                simpleButton_delete_member.Visible = true;
            }
            member();
        }
        private void nconfig()
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _c = (from cli in ms.configs select cli).ToList();
                if (_c.Count > 0)
                {
                    textEdit_pcname.Text = _c.Single().org_name;
                    textEdit_pcname.Enabled = false;
                    textEdit_newmemberstock.Text = _c.Single().newmember_stock.ToString();
                    textEdit_newmemberprice.Text = _c.Single().newmember_price.ToString();
                }
            }
            catch { MessageBox.Show("config error!!!"); }
        }
        private void ngroups()
        {
            try
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                gridControl_groups.DataSource = (from t in ms.groups
                                                 select new
                                                 {
                                                     Дугаар = t.id,
                                                     Нэр = t.name,
                                                     ЦагынКод = t.timecodeprice,
                                                     Гишүүн = t.memberprice,
                                                     ЦагНээх = t.hourprice,
                                                     ДоодҮнэлгээ = t.minprice,
                                                     Засах = "",
                                                     Устгах = ""
                                                 }).ToList();
                RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
                ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem.Buttons[0].Tag = "edit";
                ritem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(groups_ButtonClick);
                gridControl_groups.RepositoryItems.Add(ritem);
                gridView_groups.Columns["Засах"].ColumnEdit = ritem;
                RepositoryItemButtonEdit ritem1 = new RepositoryItemButtonEdit();
                ritem1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem1.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem1.Buttons[0].Tag = "delete";
                ritem1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(groups_ButtonClick);
                gridControl_groups.RepositoryItems.Add(ritem1);
                gridView_groups.Columns["Устгах"].ColumnEdit = ritem1;
            }
            catch { MessageBox.Show("groups error!!!"); }
        }
        private void ban()
        {
            try
            {
                DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr);
                gridControl_ban.DataSource = (from b in dcm.bans
                                              select new
                                              {
                                                  Үг = b.word,
                                                  Устгах = ""
                                              }).ToList();
                RepositoryItemButtonEdit ritem1 = new RepositoryItemButtonEdit();
                ritem1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                ritem1.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                ritem1.Buttons[0].Tag = "delete";
                ritem1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ban_delete_ButtonClick);
                gridControl_ban.RepositoryItems.Add(ritem1);
                gridView_ban.Columns["Устгах"].ColumnEdit = ritem1;
            }
            catch { MessageBox.Show("ban error!!!"); }
        }
        public void ban_delete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr);
                ban b = dcm.bans.Single(p => p.word == gridView_ban.GetFocusedRowCellValue("Үг").ToString());
                dcm.bans.DeleteOnSubmit(b);
                dcm.SubmitChanges();
                gridView_ban.DeleteRow(gridView_ban.FocusedRowHandle);
            }
            catch { MessageBox.Show("ban delete error"); }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            FrmAddEmp add = new FrmAddEmp("");
            add.ShowDialog(this);
            if (add.ok)
            {
                users();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Screenshot b = new Screenshot();
            b.ShowDialog(this);
            if (b.ok)
            {
                ban();
            }
        }

        private void simpleButton_add_group_Click(object sender, EventArgs e)
        {
            addGroup group = new addGroup(null);
            group.ShowDialog(this);
            if (group.ok)
            {
                ngroups();
            }
        }
        private void server_listen()
        {
            UdpClient client_udp = new UdpClient(Program.port_servertomonitor);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Program.port_servertomonitor);
            while (true)
            {
                try
                {
                    byte[] allmessage = client_udp.Receive(ref groupEP);
                    string[] param = new string[2];
                    param[0] = groupEP.ToString();
                    param[1] = System.Text.Encoding.UTF8.GetString(allmessage);
                    Task.Factory.StartNew(() => server_collect(param));
                }
                catch { ;}
            }
        }
        private void server_collect(object obj)
        {
            string[] param = (string[])obj;
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(param[1]);
                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "rc")
                {

                    string id = xd.ChildNodes[0].ChildNodes[0].InnerText;
                    string spart = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    int part = Convert.ToInt32(spart);
                    string scount = xd.ChildNodes[0].ChildNodes[2].InnerText;
                    int count = Convert.ToInt32(scount);
                    string data = xd.ChildNodes[0].ChildNodes[3].InnerText;

                    if (server_packets.ContainsKey(id))
                    {
                        Packet p = (Packet)server_packets[id];
                        p.packets[part] = data;
                        server_packets[id] = p;
                    }
                    else
                    {
                        Packet p = new Packet();
                        p.packets = new string[count];
                        p.id = id;
                        p.ip = param[0];
                        p.cnt = count;
                        p.packets[part] = data;
                        server_packets.Add(id, p);
                    }
                    Packet ptotal = (Packet)server_packets[id];

                    if (part + 1 == count)
                    {
                        string total = "";
                        for (var i = 0; i < count; i++)
                        {
                            Debug.WriteLine(count + ";" + i);
                            total = total + ptotal.packets[i];
                        }
                        total = Program.Decompress(total);
                        server_management(ptotal.ip, total);
                    }
                }
            }
            catch
            {
                ;
            }
        }

        private void client_screenshot(string ip, Bitmap bmp)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                Screen screen = new Screen();
                screen.Text=dcm.clients.Where(_ip => _ip.ip == ip).FirstOrDefault().name;
                screen.Size = new System.Drawing.Size(bmp.Width, bmp.Height);
                screen.BackgroundImage = bmp;
                screen.BackgroundImageLayout = ImageLayout.Stretch;
                screen.ShowDialog();
                screen.BringToFront();
            }
        }

        private void server_management(string ip, string data)
        {
            if (data.Length == 0)
            {
                return;
            }
            ip = ip.Substring(0, ip.IndexOf(":"));
            string cmd = (string)Newtonsoft.Json.Linq.JObject.Parse(data)["command"];
            switch (cmd)
            {
                case "syn": server_syn(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketServerMonitorSyn>(data)); break;
                default: break;
            }
        }

        public int string_minute(string _string)
        {
            int ret;
            string _hour = _string.Substring(0, _string.IndexOf(":"));
            int hour = int.Parse(_hour);
            string _min = _string.Substring(_string.IndexOf(":") + 1, 2);
            int min = int.Parse(_min);
            ret = hour * 60 + min;
            return (ret);
        }

        public string minute_string(int _minute)
        {
            string ret = "";
            int hour = _minute / 60;
            int min = _minute % 60;
            string _hour = hour.ToString();
            if (_hour.Length == 1)
            {
                _hour = "0" + _hour;
            }
            string _min = min.ToString();
            if (_min.Length == 1)
            {
                _min = "0" + _min;
            }
            ret = _hour + ":" + _min;
            return (ret);
        }

        private void client_stats()
        {
            if (listView_clients == null)
            {
                return;
            }
            using (DataContext_mastercafe db = new DataContext_mastercafe(Program.constr))
            {
                foreach (var c in db.clients)
                {
                    if (listView_clients.InvokeRequired)
                    {
                        listView_clients.Invoke(new MethodInvoker(delegate
                        {
                             if (listView_clients.Items.ContainsKey(c.name))
                            {
                                listView_clients.Items[c.name].ImageIndex = c.status;
                                listView_clients.Items[c.name].SubItems[0].Text = c.name;
                                listView_clients.Items[c.name].SubItems[1].Text = c.group.name;
                                listView_clients.Items[c.name].SubItems[2].Text = c.member_name;
                                if (c.usedminute >= 0)
                                {
                                    listView_clients.Items[c.name].SubItems[3].Text = minute_string((int)c.usedminute);
                                }
                                else
                                {
                                    listView_clients.Items[c.name].SubItems[3].Text = "";
                                }
                                if (c.remainminute >= 0)
                                {
                                    listView_clients.Items[c.name].SubItems[4].Text = minute_string((int)c.remainminute);
                                }
                                else
                                {
                                    listView_clients.Items[c.name].SubItems[4].Text = "";
                                }
                                listView_clients.Items[c.name].SubItems[5].Text = "";
                                if (c.start == null)
                                {
                                    listView_clients.Items[c.name].SubItems[6].Text = "";
                                }
                                else
                                {
                                    listView_clients.Items[c.name].SubItems[6].Text = ((DateTime)c.start).ToString("yyyy.MM.dd HH:mm");
                                }
                                listView_clients.Items[c.name].SubItems[7].Text = c.app.ToString();
                                listView_clients.Items[c.name].SubItems[8].Text = c.title.ToString();
                                listView_clients.Items[c.name].SubItems[9].Text = c.ip;
                                listView_clients.Items[c.name].SubItems[10].Text = c.mac;
                            }
                            else
                            {
                                ListViewItem lvi = new ListViewItem(new string[] { c.name, c.group.name,c.member_name,c.usedminute.ToString(),c.remainminute.ToString(),"",c.start.ToString(),c.app.ToString(),c.title.ToString(),c.ip,c.mac}, c.status);
                                lvi.Name = c.name;
                                listView_clients.Items.Add(lvi);
                                int cw=listView_clients.Width/listView_clients.Columns.Count;
                                for (int i = 0; i < listView_clients.Columns.Count; i++)
                                {
                                    listView_clients.Columns[i].Width = cw;
                                }
                            }
                        }));
                    }
                    else
                    {
                        if (listView_clients.Items.ContainsKey(c.name))
                        {
                            listView_clients.Items[name].ImageIndex = c.status;
                            listView_clients.Items[name].SubItems[0].Text = c.name;
                            listView_clients.Items[name].SubItems[1].Text = c.group.name;
                            listView_clients.Items[name].SubItems[2].Text = c.member_name;
                            if (c.usedminute >= 0)
                            {
                                listView_clients.Items[c.name].SubItems[3].Text = minute_string((int)c.usedminute);
                            }
                            else
                            {
                                listView_clients.Items[c.name].SubItems[3].Text = "";
                            }
                            if (c.remainminute >= 0)
                            {
                                listView_clients.Items[c.name].SubItems[4].Text = minute_string((int)c.remainminute);
                            }
                            else
                            {
                                listView_clients.Items[c.name].SubItems[4].Text = "";
                            }
                            listView_clients.Items[c.name].SubItems[5].Text = "";
                            if (c.start==null)
                            {
                                listView_clients.Items[c.name].SubItems[6].Text = "";
                            }
                            else
                            {
                                listView_clients.Items[c.name].SubItems[6].Text = ((DateTime)c.start).ToString("yyyy.MM.dd HH:mm");
                            }
                            listView_clients.Items[name].SubItems[7].Text = c.app.ToString();
                            listView_clients.Items[name].SubItems[8].Text = c.title.ToString();
                            listView_clients.Items[name].SubItems[9].Text = c.ip;
                            listView_clients.Items[name].SubItems[10].Text = c.mac;
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { c.name, c.group.name, c.member_name, c.usedminute.ToString(), c.remainminute.ToString(), "", c.start.ToString(), c.app.ToString(), c.title.ToString(), c.ip, c.mac }, c.status);
                            lvi.Name = c.name;
                            listView_clients.Items.Add(lvi);
                            int cw = listView_clients.Width / listView_clients.Columns.Count;
                            for (int i = 0; i < listView_clients.Columns.Count; i++)
                            {
                                listView_clients.Columns[i].Width = cw;
                            }
                        }
                    }
                }
            }
        }


        private void Mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("Программыг хаах?", "Анхаар", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
        }


        private void mremote_shutdown_choose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
                {
                    string msg = "<mastercafe><cmd>shutdown</cmd></mastercafe>";
                    string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                    Send(ip, Program.port_servertoclient, msg);
                }
            }
        }

        private void mremote_shutdown_unused_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients.Where(_c => _c.status == 1);
                    foreach (var c in cls)
                    {
                        string msg = "<mastercafe><cmd>shutdown</cmd></mastercafe>";
                        string ip = c.ip;
                        Send(ip, Program.port_servertoclient, msg);
                    }
                }
            }
        }

        private void mremote_shudown_all_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients;
                    foreach (var c in cls)
                    {
                        string msg = "<mastercafe><cmd>shutdown</cmd></mastercafe>";
                        string ip = c.ip;
                        Send(ip, Program.port_servertoclient, msg);
                    }
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (listView_clients.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
            else if(listView_clients.SelectedItems.Count==1)
            {
                int status = listView_clients.SelectedItems[0].ImageIndex;
            }
            else if (listView_clients.SelectedItems.Count > 1)
            {

            }
        }

        private void mremote_reboot_choose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
                {
                    string msg = "<mastercafe><cmd>reboot</cmd></mastercafe>";
                    string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                    Send(ip, Program.port_servertoclient, msg);
                }
            }
        }

        private void mremote_reboot_unused_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients.Where(_c => _c.status == 1);
                    foreach (var c in cls)
                    {
                        string msg = "<mastercafe><cmd>reboot</cmd></mastercafe>";
                        string ip = c.ip;
                        Send(ip, Program.port_servertoclient, msg);
                    }
                }
            }
        }

        private void mremote_reboot_all_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Үйлдлийг баталгаажуулах", "Mastercafe Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients;
                    foreach (var c in cls)
                    {
                        string msg = "<mastercafe><cmd>reboot</cmd></mastercafe>";
                        string ip = c.ip;
                        Send(ip, Program.port_servertoclient, msg);
                    }
                }
            }
        }

        private void mremote_wakeup_choose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string m = listView_clients.SelectedItems[i].SubItems[10].Text;
                string[] macs = m.Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
                foreach (string mac in macs)
                {
                    WOL.WakeUp(mac);
                }
            }
        }

        private void mremote_wakeup_unused_Click(object sender, EventArgs e)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                var cls = dcm.clients.Where(_c => _c.status == 0);
                foreach (var c in cls)
                {
                    string m = c.mac;
                    string[] macs = m.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string mac in macs)
                    {
                        WOL.WakeUp(mac);
                    }
                }
            }
        }

        private void mremote_wakeup_all_Click(object sender, EventArgs e)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                var cls = dcm.clients;
                foreach (var c in cls)
                {
                    string m = c.mac;
                    string[] macs = m.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string mac in macs)
                    {
                        WOL.WakeUp(mac);
                    }
                }
            }
        }

        private void mremote_close_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string msg = "<mastercafe><cmd>exit</cmd></mastercafe>";
                string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                Send(ip, Program.port_servertoclient, msg);
            }
        }

        private void mremote_finish_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string msg = "<mastercafe><cmd>finish</cmd></mastercafe>";
                string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                Send(ip, Program.port_servertoclient, msg);
            }
        }

        private void mremote_password_choose_Click(object sender, EventArgs e)
        {
            Password pwd = new Password();
            pwd.ShowDialog(this);
            if (pwd.ok)
            {
                string msg = "<mastercafe><cmd>password</cmd>";
                msg += "<pwd>" + pwd.textBox_password.Text + "</pwd>";
                msg += "<clients>";
                msg += "<client>";
                msg += "<ip>" + listView_clients.SelectedItems[0].SubItems[11].Text + "</ip>";
                msg += "</client>";
                msg += "</clients>";
                msg += "</mastercafe>";
                Send(serverip, Program.port_monitortoserver, msg);
            }
        }

        private void mremote_password_all_Click(object sender, EventArgs e)
        {
            Password pwd = new Password();
            pwd.ShowDialog(this);
            if (pwd.ok)
            {
                string msg = "<mastercafe><cmd>password</cmd>";
                msg += "<pwd>" + pwd.textBox_password.Text + "</pwd>";
                msg += "<clients>";
                for (int i = 0; i < listView_clients.Items.Count; i++)
                {
                    msg += "<client>";
                    msg += "<ip>" + listView_clients.Items[i].SubItems[11].Text + "</ip>";
                    msg += "</client>";
                }
                msg += "</clients>";
                msg += "</mastercafe>";
                Send(serverip, Program.port_monitortoserver, msg);
            }
        }

        private void mmsg_choose_Click(object sender, EventArgs e)
        {
            msg msg = new msg();
            msg.ShowDialog(this);
            if (msg.ok)
            {
                for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
                {
                    string _msg = "<mastercafe><cmd>msg</cmd><text>" + Program.Compress(msg.richTextBox.Text) + "</text></mastercafe>";
                    string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                    Send(ip, Program.port_servertoclient, _msg);
                }
            }
        }
        
        private void mmsg_using_Click(object sender, EventArgs e)
        {
            msg msg = new msg();
            msg.ShowDialog(this);
            if (msg.ok)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients.Where(_c => _c.status > 1);
                    foreach (var c in cls)
                    {
                        string _msg = "<mastercafe><cmd>msg</cmd><text>" + Program.Compress(msg.richTextBox.Text) + "</text></mastercafe>";
                        Send(c.ip, Program.port_servertoclient, _msg);
                    }
                }
            }
        }

        private void mmsg_all_Click(object sender, EventArgs e)
        {
            msg msg = new msg();
            msg.ShowDialog(this);
            if (msg.ok)
            {
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    var cls = dcm.clients;
                    foreach (var c in cls)
                    {
                        string _msg = "<mastercafe><cmd>msg</cmd><text>" + Program.Compress(msg.richTextBox.Text) + "</text></mastercafe>";
                        Send(c.ip, Program.port_servertoclient, _msg);
                    }
                }
            }
        }

        private void mnotrespond_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string _msg = "<mastercafe><cmd>notrespond</cmd></mastercafe>";
                string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                Send(ip, Program.port_servertoclient, _msg);
            }
        }

        private void mgetmoney_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string _msg = "<mastercafe><cmd>refund</cmd><client>" + listView_clients.SelectedItems[i].Name + "</client></mastercafe>";
                Send(serverip, Program.port_monitortoserver, _msg);
            }
        }
        private void getmoney(XmlDocument xd)
        {
            transfer tf = new transfer(0);
            if (tf.InvokeRequired)
            {
                tf.Invoke(new MethodInvoker(delegate
                {
                    tf.ShowDialog();
                }));
            }
            else
            {
                tf.ShowDialog();
            }
        }

        private void mchange_Click(object sender, EventArgs e)
        {
            string current = listView_clients.SelectedItems[0].Name;
            int c = 0;
            for (int i = 0; i < listView_clients.Items.Count; i++)
            {
                if (listView_clients.Items[i].ImageIndex < 2)
                {
                    c++;
                }
            }
            string[] str = new string[c];
            int z = 0;
            for (int i = 0; i < listView_clients.Items.Count; i++)
            {
                if (listView_clients.Items[i].ImageIndex < 2)
                {
                    str[z] = listView_clients.Items[i].Name;
                    z++;
                }
            }
            changepc cp = new changepc(str, current);
            cp.ShowDialog(this);
            if (cp.ok)
            {
                string change = cp.comboBox_clients.Text;
                string msg = "<mastercafe><cmd>changepc</cmd>";
                msg += "<client>" + current + "</client>";
                msg += "<client>" + change + "</client>";
                msg += "</mastercafe>";

                Send(serverip, Program.port_monitortoserver, msg);
            }
        }

        private void mtime_open_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
            {
                string msg = "<mastercafe><cmd>open</cmd><name>" + listView_clients.SelectedItems[i].Name + "</name></mastercafe>";
                Send(serverip, Program.port_monitortoserver, msg);
            }
        }

        private void mtime_stop_Click(object sender, EventArgs e)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                int totalmoney = 0;
                total total = new total();
                for (int i = 0; i < listView_clients.SelectedItems.Count; i++)
                {
                    int usedmoney = Convert.ToInt32(listView_clients.SelectedItems[i].SubItems[5].Text);
                    string msg = "<mastercafe><cmd>stop</cmd><name>" + listView_clients.SelectedItems[i].Name + "</name></mastercafe>";
                    string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                    
                    transfer t = new transfer(usedmoney);
                    t.ShowDialog(this);
                    if (t.ok)
                    {
                        employee_hour eh = new employee_hour();
                        eh.client_name = listView_clients.SelectedItems[i].Name;
                        eh.employee_name = name;
                        eh.price = usedmoney;
                        totalmoney = totalmoney + usedmoney;
                        dcm.employee_hours.InsertOnSubmit(eh);
                        if (listView_clients.SelectedItems.Count > 1)
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { listView_clients.SelectedItems[i].Name, listView_clients.SelectedItems[i].SubItems[6].Text, listView_clients.SelectedItems[i].SubItems[3].Text, usedmoney.ToString("#,##0") });
                            total.listView_sale.Items.Add(lvi);
                        }
                        Send(ip, Program.port_servertoclient, msg);
                    }
                }
                dcm.SubmitChanges();
                if (listView_clients.SelectedItems.Count > 1)
                {
                    total.textBox_total.Text = totalmoney.ToString("#,##0");
                    total.ShowDialog(this);
                }
            }
        }

        
        private void simpleButton_print_ticket_Click(object sender, EventArgs e)
        {
            System.Management.ObjectQuery oquery =
                     new System.Management.ObjectQuery("SELECT * FROM Win32_Printer where Default = true and PrinterStatus=3");

            System.Management.ManagementObjectSearcher mosearcher =
                new System.Management.ManagementObjectSearcher(oquery);

            System.Management.ManagementObjectCollection moc = mosearcher.Get();
            string printer = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                printer = mo["Name"].ToString();
                break;
            }
            if (printer.Length > 0)
            {
                Money m = new Money();
                m.ShowDialog(this);
                if (m.ok)
                {
                    string msg = "<mastercafe><cmd>timecode</cmd>";
                    msg += "<money>" + m.price + "</money>";
                    msg += "</mastercafe>";
                    Send(serverip, Program.port_monitortoserver, msg);
                }
            }
            else
            {
                MessageBox.Show(this, "Хэвлэх төхөөрөмж байхгүй байна.", "Анхаар!", MessageBoxButtons.OK);
            }
        }

        private string ptext = "";
        private void printticket(XmlDocument xd)
        {
            ptext = xd.FirstChild.ChildNodes[1].InnerText + "\n";
            ptext += "\nЦагны код:\n";
            ptext += xd.FirstChild.ChildNodes[2].InnerText + "\n";
            ptext += "Үнэ:\n";
            ptext += xd.FirstChild.ChildNodes[3].InnerText + "\n";
            ptext += "\nТаньд баярлалаа. \n\n" + DateTime.Parse(xd.FirstChild.ChildNodes[4].InnerText).ToString("HH:mm yyyy.MM.dd") + "\n";
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
            pd.Print();
        }

        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            Font oFont = new Font("Courier New", 9);
            Rectangle marginRect = ev.MarginBounds;
            float _x = (ev.PageBounds.Height / 100) * 5;
            float _y = (ev.PageBounds.Width / 100) * 5;
            ev.Graphics.DrawString(ptext, oFont, new SolidBrush(System.Drawing.Color.Black),
               _x, _y);
        }

        private void textBox_search_EditValueChanged(object sender, EventArgs e)
        {
            member();
        }
       
        private void member()
        {
            if (listView_member.InvokeRequired)
            {
                listView_member.Invoke(new MethodInvoker(delegate
                {
                    listView_member.Items.Clear();
                    listView_member.BeginUpdate();

                }));
            }
            else
            {
                listView_member.Items.Clear();
                listView_member.BeginUpdate();
            }
            using(DataContext_mastercafe db = new DataContext_mastercafe(Program.constr))
            {
                var _members = from m in db.members orderby m.name select new { m.name, m.money,m.ot };
                foreach (var pm in _members) 
                {
                    
                    if (textBox_search.Text.Length < 1)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { pm.name, pm.money.ToString(),pm.ot.ToShortDateString()});
                        if (listView_member.InvokeRequired)
                        {
                            listView_member.Invoke(new MethodInvoker(delegate
                            {
                                listView_member.Items.Add(lvi);
                            }));
                        }
                        else
                        {
                            listView_member.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        if (pm.name.ToLower().IndexOf(textBox_search.Text.ToLower()) == 0)
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { pm.name, pm.money.ToString(), pm.ot.ToShortDateString() });
                            if (listView_member.InvokeRequired)
                            {
                                listView_member.Invoke(new MethodInvoker(delegate
                                {
                                    listView_member.Items.Add(lvi);
                                }));
                            }
                            else
                            {
                                listView_member.Items.Add(lvi);
                            }
                        }
                    }
                }
            }
            if (listView_member.InvokeRequired)
            {
                listView_member.Invoke(new MethodInvoker(delegate
                {
                    listView_member.EndUpdate();
                    listView_member.Refresh();
                }));
            }
            else
            {
                listView_member.EndUpdate();
                listView_member.Refresh();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string msg = "<mastercafe>";
            msg += "<cmd>refresh</cmd>";
            msg += "</mastercafe>";
            Send(serverip, Program.port_monitortoserver, msg);
            member();
        }

        private void simpleButton_add_Click(object sender, EventArgs e)
        {
            try
            {
                addmember add = new addmember();
                add.ShowDialog(this);
                if (add.ok)
                {
                    string msg = "<mastercafe>";
                    msg += "<cmd>refresh</cmd>";
                    msg += "</mastercafe>";
                    Send(serverip, Program.port_monitortoserver, msg);
                }
            }
            catch { ;}
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _c = (from c in ms.configs select c).ToList();
           
            string msg = "<mastercafe><cmd>password</cmd>";
            msg += "<pwd>" + textEdit_client_pwd.Text + "</pwd>";
            msg += "<clients>";
            for (int i = 0; i < listView_clients.Items.Count; i++)
            {
                msg += "<client>";
                msg += "<ip>" + listView_clients.Items[i].SubItems[11].Text + "</ip>";
                msg += "</client>";
            }
            msg += "</clients>";
            msg += "</mastercafe>";
            Send(serverip, Program.port_monitortoserver, msg);
        }

        private void simpleButton_charge_Click(object sender, EventArgs e)
        {
            if (listView_member.SelectedItems.Count > 0)
            {
                chargemember();
            }
        }

        private void chargemember()
        {
            chargemember cm = new chargemember(listView_member.SelectedItems[0].SubItems[0].Text.ToString());
            cm.ShowDialog(this);
            if (cm.ok)
            {
                member();
                string msg = "<mastercafe>";
                msg += "<cmd>stockmember</cmd>";
                msg += "<name>" + cm.textEdit1.Text + "</name>";
                msg += "<stock>" + cm.maskedTextBox_money.Text + "</stock>";
                msg += "</mastercafe>";
                Send(serverip, Program.port_monitortoserver, msg);
            }
        }
        
        private void simpleButton_edit_member_Click(object sender, EventArgs e)
        {
            if (listView_member.SelectedItems.Count > 0)
            {
                editmember();

            }
        }
        private void editmember()
        {
            editmember ex = new editmember(listView_member.SelectedItems[0].SubItems[0].Text);
            ex.ShowDialog(this);
            if (ex.ok)
            {

                string msg = "<mastercafe>";
                msg += "<cmd>refresh</cmd>";
                msg += "</mastercafe>";
                Send(serverip, Program.port_monitortoserver, msg);
            }
        }
        private void delete_member()
        {
            int min_price =0;
            if (int.Parse(listView_member.SelectedItems[0].SubItems[1].Text) <= min_price)
            {
                if (MessageBox.Show("Та " + listView_member.SelectedItems[0].SubItems[0].Text + "нэртэй гишүүнийг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                    member m = ms.members.Single(p => p.name == listView_member.SelectedItems[0].SubItems[0].Text);
                    ms.members.DeleteOnSubmit(m);
                    ms.SubmitChanges();
                    listView_member.SelectedItems[0].Remove();
                }
            }
            else
            {
                MessageBox.Show("Устгах хэрэглэгчийн мөнгөн дүн " + min_price.ToString() + "-с бага байх ёстой.");
            }
        }
        private void simpleButton_delete_member_Click(object sender, EventArgs e)
        {
            delete_member();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView_member.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void цэнэглэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chargemember();
        }

        private void засахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editmember();
        }

        private void устгахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete_member();
        }

        private void simpleButton_add_timez_Click(object sender, EventArgs e)
        {
            addTimez addtimez = new addTimez(null);
            addtimez.ShowDialog(this);
            if (addtimez.ok)
            {
                timez();
            }
        }
        private void mtime_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Нээх" && e.ClickedItem.Text != "Зогсоох" && e.ClickedItem.Text != "Тавих")
            {
                timetemplate t = new timetemplate(e.ClickedItem.Text);
                t.ShowDialog(this);
                if (t.ok)
                {
                    string msg = "<mastercafe><cmd>hourtemplate</cmd>";
                    msg += "<client>" + listView_clients.SelectedItems[0].Name + "</client>";
                    msg += "<ht>" + e.ClickedItem.Text + "</ht>";
                    msg += "</mastercafe>";
                    Send(serverip, Program.port_monitortoserver,msg);
                }
            }
        }

        private void simpleButton_report_ok_Click(object sender, EventArgs e)
        {
            DataSet1_rp.emphourDataTable dta = new DataSet1_rp.emphourDataTable();
            string emp_id = "";
            
            DateTime begd = DateTime.Parse(start_date1.DateTime.Year.ToString() + "-" + start_date1.DateTime.Month.ToString() + "-" + start_date1.DateTime.Day.ToString() + " " + start_hour1.Text.ToString() + ":00:00");
            DateTime endd = DateTime.Parse(end_date.DateTime.Year.ToString() + "-" + end_date.DateTime.Month.ToString() + "-" + end_date.DateTime.Day.ToString() + " " + end_hour.Text.ToString() + ":00:00");
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _data = from g in ms.employee_hours where g.ot >= begd && g.ot <= endd select g;
            if (emp_id != "")
            {
                _data = from g in ms.employee_hours where g.employee_name == emp_id && g.ot >= begd && g.ot <= endd select g;
            }
            int sum = 0;
            foreach(var _d in _data)
            {
                if (_d.price != 0)
                {
                    string type = "Цаг тависан";
                    if (_d.price < 0) type = "Буцаалт";
                    dta.Rows.Add(_d.employee.name, _d.client_name, _d.price, type, _d.ot.ToString("yyyy-MM-dd H:mm:ss"));
                    sum += _d.price;
                }
            }
            dta.Rows.Add(null,"Нийт",sum.ToString(),null,null);
            DataSet ds = new DataSet();
            ds.Tables.Add(dta);
            XtraReport_orlogo t = new XtraReport_orlogo(start_date1.DateTime.ToShortDateString()+" "+start_hour1.Text.ToString()+" цагаас "+ end_date.DateTime.ToShortDateString()+" "+end_hour.Text.ToString()+" цаг хүртэл");
            t.DataSource = ds;
            t.DataMember = "dta";
            documentViewer1.PrintingSystem = t.PrintingSystem;
            try
            {
                t.CreateDocument();
            }
            catch { MessageBox.Show("Шүүлтэд тохирох үр дүн олдсонгүй"); }
            //member
            DataSet1_rp.empmemberDataTable emember = new DataSet1_rp.empmemberDataTable();
            var _employee_member = from emp_member in ms.employee_members where  emp_member.ot >= begd && emp_member.ot <= endd select emp_member;
            if (emp_id != "")
            {
                _employee_member = from emp_member in ms.employee_members where emp_member.employee_name == emp_id && emp_member.ot >= begd && emp_member.ot <= endd select emp_member;
            }
            int sum_employee_member = 0;
            foreach (var _e in _employee_member)
            {
                sum_employee_member += _e.price; 
               emember.Rows.Add(_e.employee.name, _e.member.name, _e.price.ToString(), _e.ot.ToString("yyyy-MM-dd H:mm:ss"));
                
            }
            emember.Rows.Add(null,"Нийт",sum_employee_member.ToString(),null);
            DataSet md = new DataSet();
            md.Tables.Add(emember);
            XtraReport_employee_member xr = new XtraReport_employee_member(start_date1.DateTime.ToShortDateString() + " " + start_hour1.Text.ToString() + " цагаас " + end_date.DateTime.ToShortDateString() + " " + end_hour.Text.ToString() + " цаг хүртэл");
            xr.DataSource = md;
            xr.DataMember = "emember";
            documentViewer2.PrintingSystem = xr.PrintingSystem;
           
            try
            {
                xr.CreateDocument();
            }
            catch { ;}
            //timecode
            DataSet1_rp.emptimecodeDataTable emptimecode = new DataSet1_rp.emptimecodeDataTable();
            var _employee_timecode = from timecode in ms.employee_timecodes where timecode.ot >= begd && timecode.ot <= endd select timecode;
            if (emp_id != "")
            {
                _employee_timecode = from timecode in ms.employee_timecodes where timecode.employee_name==emp_id && timecode.ot >= begd && timecode.ot <= endd select timecode;
            }
            int sum_employee_timecode = 0;
            foreach (var _t in _employee_timecode)
            {
                sum_employee_timecode += _t.price;
                emptimecode.Rows.Add(_t.employee.name, _t.price.ToString(), _t.ot.ToString("yyyy-MM-dd H:mm:ss"),_t.timecode_code);
            }
            emptimecode.Rows.Add(null,sum_employee_timecode.ToString(),null,"Нийт");
            DataSet tc = new DataSet();
            tc.Tables.Add(emptimecode);
            XtraReport_emptimecode tcode = new XtraReport_emptimecode(start_date1.DateTime.ToShortDateString() + " " + start_hour1.Text.ToString() + " цагаас " + end_date.DateTime.ToShortDateString() + " " + end_hour.Text.ToString() + " цаг хүртэл");
            tcode.DataSource = tc;
            tcode.DataMember = "emptimecode";
            //documentViewer.PrintingSystem = tcode.PrintingSystem;
            try
            {
                tcode.CreateDocument();
            }
            catch { ; }

            int total = 0;
            XtraReport_topmember top = new XtraReport_topmember(start_date1.DateTime.ToShortDateString() + " " + start_hour1.Text.ToString() + " цагаас " + end_date.DateTime.ToShortDateString() + " " + end_hour.Text.ToString() + " цаг хүртэл");
            top.DataSource = total;
            top.DataMember = "tpmember";
            documentViewer7.PrintingSystem = top.PrintingSystem;
            try
            {
                top.CreateDocument();
            }
            catch { ;}
            labelControl_time.Text = sum.ToString();
            labelControl_ognoo.Text = start_date1.DateTime.ToShortDateString() + " " + start_hour1.Text.ToString() + " цагаас " + end_date.DateTime.ToShortDateString() + " " + end_hour.Text.ToString() + " цаг хүртэл";
            labelControl1_member.Text = sum_employee_member.ToString();
            labelControl1_timecode.Text = sum_employee_timecode.ToString();
            labelControl2_total.Text = (sum + sum_employee_member + sum_employee_timecode).ToString();
            
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            /*
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer1;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer2;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer3;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 3)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer4;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 4)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer5;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 5)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer6;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 6)
            {
                documentViewerBarManager1.DocumentViewer = documentViewer7;
            }
            */
        }

        private void mtime_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void listView_clients_SizeChanged(object sender, EventArgs e)
        {
            int cw = listView_clients.Width / listView_clients.Columns.Count;
            for (int i = 0; i < listView_clients.Columns.Count; i++)
            {
                listView_clients.Columns[i].Width = cw;
                listView_clients.Columns[i].TextAlign = HorizontalAlignment.Center;
            }
        }

        private void listView_clients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView_clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_clients.SelectedItems.Count > 1)
            {
                for(int i=1;i<listView_clients.SelectedItems.Count;i++)
                {
                    if (listView_clients.SelectedItems[i].ImageIndex != listView_clients.SelectedItems[0].ImageIndex)
                    {
                        listView_clients.SelectedItems[i].Selected = false;
                    }
                }
            }
        }

        private void simpleButton_switch_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void mremote_screenshot_Click(object sender, EventArgs e)
        {
            for(int i=0;i<listView_clients.SelectedItems.Count;i++)
            {
                string msg = "<mastercafe><cmd>screenshot</cmd></mastercafe>";
                string ip = listView_clients.SelectedItems[i].SubItems[9].Text;
                Send(ip, Program.port_servertoclient, msg);
            }
        }

        private void Mainfrm_Resize(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = 250;
        }

        private void splitContainer_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void simpleButton_print_Click(object sender, EventArgs e)
        {

        }


    }
}
