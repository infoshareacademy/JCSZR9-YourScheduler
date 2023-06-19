using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(Message message);
        public MimeMessage CreateEmailMessage(Message message);
        public void Send(MimeMessage mailMessage);
    }
}
