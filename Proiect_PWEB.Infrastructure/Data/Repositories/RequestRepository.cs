﻿using Microsoft.EntityFrameworkCore;
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

            StringBuilder sb = new StringBuilder("[SUBSCRIBER] ");

            var countryName = _context.Country
                .Where(country => country.Id == command.CountryId)
                .Select(country => country.Name).ToString();
            var categoryName = _context.Category
                .Where(category => category.Id == command.CategoryId)
                .Select(category => category.Name)
                .ToString();

            sb.Append($"{countryName};{categoryName}");

            await SaveAsync(cancellationToken);

            Console.Out.WriteLine(sb);
        }

        public async Task DeleteRequestAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = await _context.Request.FirstOrDefaultAsync(request => request.Id == id, cancellationToken);

            if (request != null)
                _context.Request.Remove(request);
        }

        public Task<DomainOfAggregate<Request>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

    }
}
