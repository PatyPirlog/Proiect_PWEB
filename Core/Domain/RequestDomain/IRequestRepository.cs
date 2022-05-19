using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.RequestDomain
{
    public interface IRequestRepository : IRepositoryOfAggregate<Request, InsertRequestCommand>
    {
        public Task DeleteRequestAsync(Guid id, CancellationToken cancellationToken);
    }
}
