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
        public async Task<IEnumerable<SubscriptionDTO>> HandleAsync(string identityId, CancellationToken cancellationToken)
        {
            var userId = await _context.User.Where(user => user.IdentityId == identityId)
                .Select(user => user.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var subscriptionDTOs = await _context.Subscription
                .AsNoTracking()
                .Include(a => a.Country)
                .Where(a => a.UserId == userId)
                .Select(request => new SubscriptionDTO(
                    request.Id,
                    request.Country.Name
                 ))
                .ToListAsync(cancellationToken);

            return subscriptionDTOs;
        }
    }
}
