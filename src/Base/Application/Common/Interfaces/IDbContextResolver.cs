using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface IDbContextResolver
    {
        DbContext GetContext();
    }
}
