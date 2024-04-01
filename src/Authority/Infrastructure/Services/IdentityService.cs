using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using FluentValidation.Results;
using PastExamsHub.Authority.Application.Common.Interfaces;
using PastExamsHub.Base.Application.Common.Exceptions;
using PastExamsHub.Base.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using PastExamsHub.Authority.Infrastructure.Identity;
using PastExamsHub.Base.Domain.Common;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using PastExamsHub.Base.Domain.Enums;

namespace PastExamsHub.Authority.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        readonly UserManager<IdentityApplicationUser> UserManager;
        readonly SignInManager<IdentityApplicationUser> SignInManager;
        readonly IIdentityServerInteractionService Interaction;

        public IdentityService
        (
            UserManager<IdentityApplicationUser> userManager,
            SignInManager<IdentityApplicationUser> signInManager,
            IIdentityServerInteractionService interaction
        )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Interaction = interaction;
        }

        async Task<IdentityApplicationUser> _FindByIdAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }

            return user;
        }

        async Task<IdentityApplicationUser> _FindByEmailAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException(nameof(IdentityApplicationUser), email);
            }

            return user;
        }


        public async Task<IApplicationUser> FindByEmailAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException(nameof(IdentityApplicationUser), email);
            }

            return user;
        }

        public async Task SignInAsync(string email, string password, string returnUri)
        {
            await ValidateReturnUrl(returnUri);

            await SignInManager.SignOutAsync();
            var trimmedEmail = email.Trim();

            var user = await _FindByEmailAsync(email);

            if (user.EmailConfirmed == false)
            {
                var validationFailure = new ValidationFailure("signInValues", "Vaš profesorski nalog još nije potvrdjen. Pokušajte ponovo!");
                throw new ValidationException(validationFailure);
            }

            string returnUrl = new Uri(returnUri).PathAndQuery;
            var context = await Interaction.GetAuthorizationContextAsync(returnUrl);

            var result = await SignInManager.PasswordSignInAsync(email, password, true, false);


            if (!result.Succeeded)
            {
                var validationFailure = new ValidationFailure("signInValues", " Uneli ste pogrešnu šifra ili email, pokušajte ponovo!");
                throw new ValidationException(validationFailure);
            }
        }


        async Task ValidateReturnUrl(string returnUri)
        {
            string returnUrl = new Uri(returnUri).PathAndQuery;
            var context = await Interaction.GetAuthorizationContextAsync(returnUrl);
            if (context == null)
            {
                var validationFailure = new ValidationFailure(nameof(returnUrl), "Not authorized");
                throw new ValidationException(validationFailure);
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {

            var user = await _FindByEmailAsync(email);

            return await UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task SignUpAsync(string email, string password, string firstName, string lastName, bool isTeacher ,CancellationToken cancellationToken)
        {

            var user = new IdentityApplicationUser
            {
                Email = email,
                UserName = email,
                FirstName = firstName,
                LastName = lastName,
                Role = isTeacher ? RoleType.Teacher : RoleType.Student,
                EmailConfirmed = isTeacher? false : true
            };

            

            {
                var result = await UserManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    List<ValidationFailure> validationFailures = WrapServerErrors(result.Errors);

                    throw new ValidationException(validationFailures);
                }

                result.ThrowOnFailure(); 
            }
            
            {
                var result = await UserManager.AddToRoleAsync(user, user.Role.ToString());

                if (!result.Succeeded)
                {
                    var validationFailure = new ValidationFailure
                       (
                       result.Errors.LastOrDefault().Code.ToString(),
                       result.Errors.LastOrDefault().Description.ToString()
                       ); //TODO: test/refactor message

                    throw new ValidationException(validationFailure);
                }
                //result.ThrowOnFailure(); 
            }
        }


        public List<ValidationFailure> WrapServerErrors(IEnumerable<IdentityError> errors)
        {
            List<ValidationFailure> validationFailures = new List<ValidationFailure>();

            foreach (var error in errors)
            {
                validationFailures.Add(new ValidationFailure
                    (
                    error.Code.ToString(),
                    error.Description.ToString()
                    ));
            }

            return validationFailures;
        }
        public async Task<string> SignOutAsync(string logoutId)
        {
            var context = await Interaction.GetLogoutContextAsync(logoutId);

            await SignInManager.SignOutAsync();

            return context?.PostLogoutRedirectUri;
        }

        public async Task ResetPasswordAsync(string email, string token, string password)
        {
            var user = await _FindByEmailAsync(email);

            var result = await UserManager.ResetPasswordAsync(user, token, password);
            result.ThrowOnFailure();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _FindByEmailAsync(email);

            return await UserManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
