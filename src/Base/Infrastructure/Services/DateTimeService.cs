using PastExamsHub.Base.Application.Common.Interfaces;
using System;

namespace PastExamsHub.Base.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
