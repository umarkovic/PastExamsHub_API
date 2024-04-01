using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PastExamsHub.Base.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoleType
    {
        Unknown = 0,

        Admin = 1,
        Student = 2,
        Teacher = 3
    }
}
