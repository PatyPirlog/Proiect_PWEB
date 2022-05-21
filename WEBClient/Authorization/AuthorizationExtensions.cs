using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Proiect_PWEB.Api.Authorization
{
    public static class AuthorizationExtensions
    {
        public static void AddAuthenticationAndAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth:Authority"];
                options.Audience = builder.Configuration["Auth:Audience"];
            });

            // Add Authorization configuration
            builder.Services.AddAuthorization(configure =>
            {
                configure.AddPolicy("AdminAccess", policy => policy.RequireClaim("permissions", "admin"));
            });
        }

        public static void UseAuthenticationAndAuthorization(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
