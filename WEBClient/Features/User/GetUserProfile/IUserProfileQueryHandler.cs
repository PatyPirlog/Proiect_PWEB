namespace Proiect_PWEB.Api.Features.User.GetUserProfile
{
    public interface IUserProfileQueryHandler
    {
        public Task<UserProfileDTO> HandleAsync(string identityId, CancellationToken cancellationToken);
    }
}
