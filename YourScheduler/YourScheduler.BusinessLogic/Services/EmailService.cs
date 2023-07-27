using MailKit.Net.Smtp;
using Azure.Core;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.BusinessLogic.Services.Settings;
using YourScheduler.Infrastructure.Entities;
using MailKit.Security;

namespace YourScheduler.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_mailSettings.MailAddress));
            emailMessage.To.Add(MailboxAddress.Parse(message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.MessageContent };

            return emailMessage;
        }
        public void Send(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_mailSettings.MailAddress, _mailSettings.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

        }
    }
}

