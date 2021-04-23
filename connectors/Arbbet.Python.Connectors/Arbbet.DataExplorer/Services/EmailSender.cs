using Arbbet.DataExplorer.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _host;
        private readonly int _port;
        private bool _enableSSL;
        private string _username;
        private string _password;
        private string _from;

        public EmailSender(IOptions<EmailSenderConfiguration> configuration)
        {
            var conf = configuration.Value;

            _host = conf.Host;
            _port = conf.Port;
            _enableSSL = conf.EnableSSL;
            _username = conf.Username;
            _password = conf.Password;
            _from = conf.From;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };

            return client.SendMailAsync(
                new MailMessage(_from, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
