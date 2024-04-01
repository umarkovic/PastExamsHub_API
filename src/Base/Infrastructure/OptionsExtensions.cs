using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using PastExamsHub.Base.Application.Common.Exceptions;

namespace PastExamsHub.Base.Infrastructure
{
    public static class OptionsExtensions
    {
        public static T Read<T>(this IConfiguration configuration) where T: class
        {
            var typeName = typeof(T).Name;
            var sectionName = $"{nameof(Application.Options)}:{typeName}"; 
            var section = configuration.GetSection(sectionName);
            if (section == null) 
            {
                throw new NotFoundException(nameof(IConfigurationSection), sectionName);
            }

            var value = section.Get<T>();
            if (value == null)
            {
                throw new NotFoundException(nameof(IOptions<T>), sectionName);
            }

            return value;
        }
    }
}
