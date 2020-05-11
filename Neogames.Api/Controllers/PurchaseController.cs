using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Neogames.Domain;

namespace Neogames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IMediator mediator;

        public PurchaseController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<PurchaseDto>> Get([FromQuery] PurchaseBulkQuery query)
        {
            var model = await mediator.Send(query);

            return model;
        }
    }
}