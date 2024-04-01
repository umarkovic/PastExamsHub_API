using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Core.Application.Common.Interfaces
{
    public interface IAuthorityService
    {
        Task<string> CreateOrUpdateUser(IApplicationUser user);
    }
}
