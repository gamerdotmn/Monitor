using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Monitor
{
    static class Program
    {
        public static string host = "gamer.mn";
        public static int port_servertoclient = 40001;
        public static int port_servertomonitor = 40002;
        public static int port_monitortoserver = 40003;
        public static int port_broadcast = 40004;
        public static int port_clienttoserver = 40005;
        public static int port_clienttoserver1 = 40005;
        public static int port_clienttoserver2 = 40006;
        public static int port_clienttoserver3 = 40007;
        public static int port_clienttoserver4 = 40008;
        public static int port_clienttoserver5 = 40009;
        public static int port_clienttoserver6 = 40010;
        public static int port_clienttoserver7 = 40011;
        public static int port_clienttoserver8 = 40012;
        public static int port_clienttoserver9 = 40013;
        public static int port_clienttoserver10 = 40014;

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string constr = @"Data Source=.\MASTERCAFE;Initial Catalog=mastercafedb;Persist Security Info=True;User ID=sa;Password=pldifvzz7x;MultipleActiveResultSets=True";
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            if (args.Length > 0)
            {
                if (args[0].IndexOf("-stats") > -1)
                {
                    Application.Run(new stats());
                }
            }
            else
            {
                Application.Run(new mainfrm());
            }
        }

        public static string Compress(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        public static string Decompress(string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
    }
}
