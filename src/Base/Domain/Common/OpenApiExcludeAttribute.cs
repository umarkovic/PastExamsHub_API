using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Domain.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OpenApiExcludeAttribute : Attribute
    {
    }
}
