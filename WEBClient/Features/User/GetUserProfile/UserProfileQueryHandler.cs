using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Api.Web;
using Proiect_PWEB.Infrastructure.Data;

namespace Proiect_PWEB.Api.Features.User.GetUserProfile
{
    public class UserProfileQueryHandler : IUserProfileQueryHandler
    {
        private readonly PwebContext _context;

        public UserProfileQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<UserProfileDTO> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var userProfile = await _context.User
                .Where(user => user.IdentityId == identityId)
                .Select(user => new UserProfileDTO(user.IdentityId, user.Email))
                .FirstOrDefaultAsync(cancellationToken);

            if (userProfile == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.Unauthorized, "This user does not have a registered profile!");
            }

            return userProfile;
        }
    }
}
