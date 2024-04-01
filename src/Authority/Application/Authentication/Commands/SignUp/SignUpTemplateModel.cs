using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Authority.Application.Authentication.Commands.SignUp
{
    public class SignUpTemplateModel
    {
        [JsonProperty("confirm-account-url")]
        public string RedirectUrl { get; set; }
    }
}
