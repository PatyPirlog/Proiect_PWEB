using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Infrastructure.Data;

namespace Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser
{
    public class GetAllSubscriptionsForUserQueryHandler : IGetAllSubscriptionsForUserQueryHandler
    {
        private readonly PwebContext _context;

        public GetAllSubscriptionsForUserQueryHandler(PwebContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubscriptionDTO>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var subscriptionDTOs = await _context.Subscription
                .AsNoTracking()
                .Include(a => a.Country)
                .Where(a => a.UserId == id)
                .Select(request => new SubscriptionDTO(
                    request.Id,
                    request.Country.Name
                 ))
                .ToListAsync(cancellationToken);

            return subscriptionDTOs;
        }
    }
}
