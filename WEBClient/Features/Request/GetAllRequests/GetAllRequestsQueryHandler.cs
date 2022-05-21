using Proiect_PWEB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Proiect_PWEB.Api.Features.Request.GetAllRequests
{
    public class GetAllRequestsQueryHandler : IGetAllRequestsQueryHandler
    {
        private readonly PwebContext _context;

        public GetAllRequestsQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestDTO>> HandleAsync(CancellationToken cancellationToken)
        {
            var requestDTOs = await _context.Request
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.Country)
                .Select(request => new RequestDTO(
                    request.Id,
                    request.Category.Name,
                    request.Country.Name,
                    request.Title,
                    request.Address,
                    request.Description,
                    request.Name,
                    request.Surname,
                    request.Phone
                 ))
                .ToListAsync(cancellationToken);

            return requestDTOs;
        }
    }
}
