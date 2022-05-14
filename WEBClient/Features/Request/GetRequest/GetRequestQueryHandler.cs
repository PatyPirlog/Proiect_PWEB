using Proiect_PWEB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Api.Web;

namespace Proiect_PWEB.Api.Features.Request.GetRequest
{
    public class GetRequestQueryHandler : IGetRequestQueryHandler
    {
        private readonly PwebContext _context;

        public GetRequestQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<RequestWithDetailsDTO> HandleAsync(Guid Id, CancellationToken cancellationToken)
        {
            var request = await _context.Request
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.Country)
                .SingleOrDefaultAsync(request => request.Id == Id, cancellationToken);

            if (request == null)
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "Couldn't find the request you are looking for!");

            var requestDTO = new RequestWithDetailsDTO(
                    request.Id,
                    $"{request.User.Name} {request.User.Surname}",
                    request.Category.Name,
                    request.Country.Name,
                    request.Title,
                    request.Address,
                    request.Description,
                    request.User.Phone,
                    request.User.Email);

            return requestDTO;
        }
    }
}
