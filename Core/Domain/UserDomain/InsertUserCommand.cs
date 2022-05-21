using Proiect_PWEB.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.UserDomain
{
    public class InsertUserCommand : ICreateAggregateCommand
    {
        public string? IdentityId { get; set; }
        public string Email { get; set; }

        public InsertUserCommand(string identityId, string email)
        {
            IdentityId = identityId;
            Email = email;
        }
    }
}
