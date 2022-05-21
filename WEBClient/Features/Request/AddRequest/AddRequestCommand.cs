using Proiect_PWEB.Core.Domain.RequestDomain;

namespace Proiect_PWEB.Api.Features.Request.AddRequest
{
    public class AddRequestCommand : InsertRequestCommand
    {
        public AddRequestCommand(
            string identityId, 
            Guid categoryId,
            Guid countryId, 
            string title, 
            string address,
            string description,
            string name,
            string surname,
            string phone)
            : base(identityId, categoryId, countryId, title, address, description, name, surname, phone)
        {
        }
    }
}
