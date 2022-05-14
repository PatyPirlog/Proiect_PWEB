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
            var request = new Request(
                command.UserId,
                command.CategoryId,
                command.CountryId,
                command.Title,
                command.Address,
                command.Description
                );

            await _context.Request.AddAsync(request, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public Task DeleteUserAsync(Request model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DomainOfAggregate<Request>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

    }
}
