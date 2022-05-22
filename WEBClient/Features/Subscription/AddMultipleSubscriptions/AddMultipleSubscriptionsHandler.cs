using Proiect_PWEB.Api.Features.EmailSender;
using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Core.Domain.CountryDomain;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddMultipleSubscriptions
{
    public class AddMultipleSubscriptionsHandler :IAddMultipleSubscriptionsHandler
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly IEmailSenderHandler emailSenderHandler;
        private readonly ICountryRepository countryRepository;

        public AddMultipleSubscriptionsHandler(ISubscriptionRepository subscriptionRepository, 
            IEmailSenderHandler emailSenderHandler,
            ICountryRepository countryRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.emailSenderHandler = emailSenderHandler;
            this.countryRepository = countryRepository;
        }

        public async Task HandleAsync(List<AddSubscriptionCommand> commands, CancellationToken cancellationToken)
        {
            var subscriptions = commands.Select(command => new InsertSubscriptionCommand(
                command.IdentityId,
                command.CountryId))
                .ToList();
            var countriesGuids = subscriptions.Select(subscription => subscription.CountryId).ToList();
            var countriesNames = await countryRepository.GetCountriesNames(countriesGuids);

            await subscriptionRepository.AddMultipleAsync(subscriptions, cancellationToken);

            emailSenderHandler.HandleAsync(new EmailDTO(commands[0].Email, countriesNames));
        }
    }
}
