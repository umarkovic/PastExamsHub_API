using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PastExamsHub.Base.Domain.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
    public enum UserStatusType
    {
        Unknown = 0,

        Pending,
        Active,
        Archived
    }
}
