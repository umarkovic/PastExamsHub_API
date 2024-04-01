using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Application.Options
{
    public class ForgotPassword
    {
        public string SendGridTemplateId { get; set; } //TODO: create template and add to appsettings.json
        public string RedirectUrl { get; set; }
    }
}
