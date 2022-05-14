using Proiect_PWEB.Core.Domain.RequestDomain;

namespace Proiect_PWEB.Api.Features.Request.AddRequest
{
    public class AddRequestCommand : InsertRequestCommand
    {
        public AddRequestCommand(
            Guid userId, 
            Guid categoryId,
            Guid countryId, 
            string title, 
            string address,
            string description)
            : base(userId, categoryId, countryId, title, address, description)
        {
        }
    }
}
