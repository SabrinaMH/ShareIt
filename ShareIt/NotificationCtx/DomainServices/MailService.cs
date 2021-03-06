﻿using System.Net;
using System.Net.Mail;

namespace ShareIt.NotificationCtx.DomainServices
{
    public class MailService
    {
        private readonly SmtpClient _smtpServer;

        public MailService(SmtpClient smtpClient, NetworkCredential credentials)
        {
            _smtpServer = smtpClient;
            _smtpServer.UseDefaultCredentials = false;
            _smtpServer.Credentials = credentials;
            _smtpServer.EnableSsl = true;
        }

        public void Send(MailMessage mail)
        {
            _smtpServer.Send(mail);
        }
    }
}