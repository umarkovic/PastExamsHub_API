using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using PastExamsHub.Base.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PastExamsHub.Base.Infrastructure.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        readonly Application.Options.SendGrid Options;

        public EmailTemplateService(IConfiguration configuration)
        {
            this.Options = configuration.Read<Application.Options.SendGrid>();
        }

        public async Task SendAsync(string recipientEmail, string templateId, object templateData, string senderName = null, string senderMail = null)
        {
            var client = new SendGridClient(Options.ApiKey);

            var message = new SendGridMessage()
            {
                TemplateId = templateId,
                From = new EmailAddress(senderMail ?? Options.SenderEmail, senderName ?? Options.SenderName),
            };
            message.AddTo(recipientEmail);
            message.SetTemplateData(templateData);

            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            message.SetClickTracking(false, false);

            var result = await client.SendEmailAsync(message);
            if(!result.IsSuccessStatusCode)
            {
                //TODO: log
                throw new Exception("Not sent");
            }
        }
    }
}
