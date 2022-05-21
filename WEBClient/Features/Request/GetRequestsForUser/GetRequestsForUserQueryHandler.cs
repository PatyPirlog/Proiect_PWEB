using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Api.Features.Request.GetRequest;
using Proiect_PWEB.Api.Web;
using Proiect_PWEB.Infrastructure.Data;

namespace Proiect_PWEB.Api.Features.Request.GetRequestsForUser
{
    public class GetRequestsForUserQueryHandler : IGetRequestsForUserQueryHandler
    {
        private readonly PwebContext _context;

        public GetRequestsForUserQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestWithDetailsDTO>> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var userId = await _context.User.Where(user => user.IdentityId == identityId)
               .Select(user => user.Id)
               .FirstOrDefaultAsync(cancellationToken);

            var requestDTOs = await _context.Request
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.Country)
                .Where(a => a.UserId == userId)
                .Select(request => new RequestWithDetailsDTO(
                    request.Id,
                    request.Category.Name,
                    request.Country.Name,
                    request.Title,
                    request.Address,
                    request.Description,
                    request.User.Email,
                    request.Name,
                    request.Surname,
                    request.Phone
                    ))
                .ToListAsync();

            if (requestDTOs == null)
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "This user doesn't have any requests yet!");

            return requestDTOs;
        }
    }
}
