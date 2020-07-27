namespace AssessmentApp.Services.Messaging
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using MimeKit;

    public class Message
    {
        public Message(IEnumerable<string> to, string subject, string content, IEnumerable<IFormFile> attachments)
        {
            this.To = new List<MailboxAddress>();
            this.To.AddRange(to.Select(x => new MailboxAddress(x)));

            this.Subject = subject;
            this.Content = content;
            this.Attachments = attachments;
        }

        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IEnumerable<IFormFile> Attachments { get; set; }
    }
}
