using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Base.Domain.Enums;

namespace PastExamsHub.Base.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public ApplicationUser ApplicationUser { get; }

        public string UserUid { get; }

        public bool IsInRole(string role);
    }
}
