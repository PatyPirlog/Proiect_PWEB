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

        public async Task<IEnumerable<RequestWithDetailsDTO>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var requestDTOs = await _context.Request
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.Country)
                .Where(a => a.UserId == id)
                .Select(request => new RequestWithDetailsDTO(
                    request.Id,
                    $"{request.User.Name} {request.User.Surname}",
                    request.Category.Name,
                    request.Country.Name,
                    request.Title,
                    request.Address,
                    request.Description,
                    request.User.Phone,
                    request.User.Email))
                .ToListAsync();

            if (requestDTOs == null)
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "This user doesn't have any requests yet!");

            return requestDTOs;
        }
    }
}
