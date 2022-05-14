
using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Core.Domain.CategoryDomain;
using Proiect_PWEB.Core.Domain.RequestDomain;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;
using Proiect_PWEB.Core.Domain.UserDomain;
using Proiect_PWEB.Infrastructure.Data;
using Proiect_PWEB.Infrastructure.Data.Repositories;

namespace Proiect_PWEB.Api.Infrastructure
{
    public static partial class DataAccessExtensions
    {
        public static void AddPWEBDbContext(this WebApplicationBuilder builder)
        {
            //builder.Services.AddDbContext<PwebContext>(opt =>
            //    opt.UseSqlServer(builder.Configuration.GetConnectionString("PWEB"))); // in appsettings.Development.json trb scris
            builder.Services.AddDbContext<PwebContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddPWEBAggregateRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IBooksRepository, BooksRepository>();
            //services.AddTransient<IUsersRentalsRepository, UsersRentalsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
