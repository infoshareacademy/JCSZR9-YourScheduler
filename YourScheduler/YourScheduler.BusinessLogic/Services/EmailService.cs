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

namespace YourScheduler.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(MailSettings mailSettings)
        {
            _mailSettings= mailSettings;
        }

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = await CreateEmailMessage(message);

            Send(emailMessage);
        }

        public Task<MimeMessage> CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_mailSettings.MailAddress));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
        }
        public void Send(MimeMessage mailMessage);
        public  async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            






             


        }
    }
}
