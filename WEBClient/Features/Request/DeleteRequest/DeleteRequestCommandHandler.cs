using Proiect_PWEB.Api.Web;
using Proiect_PWEB.Core.Domain.RequestDomain;

namespace Proiect_PWEB.Api.Features.Request.DeleteRequest
{
    public class DeleteRequestCommandHandler : IDeleteRequestCommandHandler
    {
        private readonly IRequestRepository requestRepository;

        public DeleteRequestCommandHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task HandleAsync(Guid id, CancellationToken cancellation)
        {
            var request = await requestRepository.GetByIdAsync(id, cancellation) as RequestDomain;

            if (request == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, $"Couldn't find the request with the specified id: {id}");
            }

            await requestRepository.DeleteRequestAsync(id, cancellation);
            await requestRepository.SaveAsync(cancellation);
        }
    }
}
