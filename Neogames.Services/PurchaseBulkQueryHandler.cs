using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Neogames.Domain;

namespace Neogames.Services
{
    public class PurchaseBulkQueryHandler : 
        MediatR.IRequestHandler<PurchaseBulkQuery, IReadOnlyCollection<PurchaseDto>>
    {
        public Task<IReadOnlyCollection<PurchaseDto>> Handle(PurchaseBulkQuery request, CancellationToken cancellationToken)
        {

            request = request ?? throw new ArgumentNullException(nameof(request));


            var items = PopulatePurshases();
            IReadOnlyCollection<PurchaseDto> bulkItems = items
                .Where(x => x.Date > request.StartTime)
                //.OrderBy(x => x.Id)
                .Take(request.BulkSize)
                .ToArray();

            return Task.FromResult(bulkItems);
        }

        private static IEnumerable<PurchaseDto> PopulatePurshases()
        {
            Random random = new Random();

            IReadOnlyCollection<PurchaseDto> items = 
                Enumerable.Range(1, 20)
                    .Select(x => new PurchaseDto()
                    {
                        Id = x,
                        Amount = random.Next(5, 100),
                        Date = DateTime.UtcNow.AddMinutes(x)
                    })
                    .ToArray();

            return items;
        }
    }
}
