using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Configuration
{
    public class EmailSenderConfiguration
    {
        public static string SectionName = "EmailSender";

        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSSL { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
