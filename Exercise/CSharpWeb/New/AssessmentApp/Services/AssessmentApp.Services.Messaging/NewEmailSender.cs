namespace AssessmentApp.Services.Messaging
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MailKit.Net.Smtp;
    using MimeKit;

    public class NewEmailSender : INewEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;

        public NewEmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = this.CreateEmailMessage(message);
            this.Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = this.CreateEmailMessage(message);
            await this.SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            // emailMessage.From.Add(new MailboxAddress(this.emailConfiguration.From));
            emailMessage.From.Add(message.From);
            emailMessage.Cc.Add(message.Cc);
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = $"<h2 style='color:red;'>{message.Content}</h2>" };

            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] filebytes;
                foreach (var attacment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attacment.CopyTo(ms);
                        filebytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attacment.FileName, filebytes, ContentType.Parse(attacment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(this.emailConfiguration.UserName, this.emailConfiguration.Password);

                    client.Send(emailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // await client.AuthenticateAsync(this.emailConfiguration.UserName, this.emailConfiguration.Password);
                    await client.SendAsync(emailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
