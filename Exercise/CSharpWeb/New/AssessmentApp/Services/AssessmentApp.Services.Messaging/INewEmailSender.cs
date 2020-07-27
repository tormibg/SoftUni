namespace AssessmentApp.Services.Messaging
{
    using System.Threading.Tasks;

    public interface INewEmailSender
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }
}
