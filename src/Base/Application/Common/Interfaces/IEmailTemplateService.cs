using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IEmailTemplateService
    {
        Task SendAsync(string recipientEmail, string templateId, object templateData, string senderName = null, string senderMail = null);
    }
}
