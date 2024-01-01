using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentitiyService1.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentitiyService
{
    public class ProfileService : DefaultProfileService, IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager, ILogger<ProfileService> logger)
            : base(logger)
        {
            _userManager = userManager;
        }

        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            
            await base.GetProfileDataAsync(context);
            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
        };

            context.IssuedClaims.AddRange(claims);
        }
    }
}
