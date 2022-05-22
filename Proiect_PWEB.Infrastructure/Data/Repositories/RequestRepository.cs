using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.RequestDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Infrastructure.Data.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly PwebContext _context;

        public RequestRepository(PwebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsertRequestCommand command, CancellationToken cancellationToken)
        {
            var userId = await _context.User.Where(user => user.IdentityId == command.IdentityId)
                .Select(user => user.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var request = new Request(
                userId,
                command.CategoryId,
                command.CountryId,
                command.Title,
                command.Address,
                command.Description,
                command.Name,
                command.Surname,
                command.Phone
                );

            await _context.Request.AddAsync(request, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteRequestAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = await _context.Request.FirstOrDefaultAsync(request => request.Id == id, cancellationToken);

            if (request != null)
                _context.Request.Remove(request);
        }

        public async Task<DomainOfAggregate<Request>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            var request = await _context.Request.FirstOrDefaultAsync(request => request.Id == aggregateId, cancellationToken);

            if (request == null)
                return null;

            return new RequestDomain(request);
        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

    }
}
