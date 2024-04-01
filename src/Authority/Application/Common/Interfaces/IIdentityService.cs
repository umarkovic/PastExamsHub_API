using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Base.Domain.Common;

namespace PastExamsHub.Authority.Application.Common.Interfaces
{
    public interface IIdentityService 
    {
        Task<IApplicationUser> FindByEmailAsync(string email);
        Task SignInAsync(string email, string password, string returnUri);
        Task SignUpAsync(string email, string password, string firstName, string lastName, bool isTeacher, CancellationToken cancellationToken);
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<string> SignOutAsync(string logoutId);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task ResetPasswordAsync(string email, string token, string password);
    }
}
