namespace Proiect_PWEB.Api.Features.User.GetUserProfile
{
    public class UserProfileDTO
    {
        public UserProfileDTO(string identityId, string email)
        {
            IdentityId = identityId;
            Email = email;
        }
        public string IdentityId { get; set; }
        public string Email { get; set; }

    }
}
