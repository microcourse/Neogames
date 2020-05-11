using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neogames.Domain
{
    public class PurchaseBulkQuery : IRequest<IReadOnlyCollection<PurchaseDto>>
    {
        public DateTime StartTime { get; set; } = DateTime.UtcNow;

        public int BulkSize { get; set; } = 5;
    }
}
