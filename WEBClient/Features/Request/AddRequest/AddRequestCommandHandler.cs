using Proiect_PWEB.Core.Domain.RequestDomain;

namespace Proiect_PWEB.Api.Features.Request.AddRequest
{
    public class AddRequestCommandHandler : IAddRequestCommandHandler
    {
        private readonly IRequestRepository requestRepository;

        public AddRequestCommandHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public Task HandleAsync(AddRequestCommand command, CancellationToken cancellationToken)
        => requestRepository
            .AddAsync(new InsertRequestCommand(
                command.UserId,
                command.CategoryId, 
                command.CountryId, 
                command.Title,
                command.Address,
                command.Description), cancellationToken);
    }
}
