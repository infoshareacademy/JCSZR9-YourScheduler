using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Entities
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }

        public Message(IEnumerable<string> to, string subject, string messageContent)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(t => new MailboxAddress(t)));
            Subject = subject;
            MessageContent = messageContent;
        }
    }
}
