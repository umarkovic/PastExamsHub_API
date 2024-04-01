using System;
using System.Collections.Generic;
using System.Text;

namespace PastExamsHub.Base.Application.Options
{
    public class Authentication
    {
        public string SignInUrl { get; set; }
        public string SignOutUrl { get; set; }
        public string SignUpUrl { get; set; }
        public string AuthorityUrl { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string ApiResourceName { get; set; }
        public string ApiResourceSecret { get; set; }
        public string DefaultCorsPolicyName { get; set; }
        public string AllowAllCorsPolicyName { get; set; }
        public string CorsOrigins { get; set; }
    }
}
