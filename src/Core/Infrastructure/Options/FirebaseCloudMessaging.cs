using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Infrastructure.Options
{
    public class FirebaseCloudMessaging
    {
        public string Url { get; set; }
        public string SenderId { get; set; }
        public string ServerKey { get; set; }
    }
}
