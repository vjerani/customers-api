using Ardalis.ApiEndpoints;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdRequest>
        .WithResponse<GetByIdResponse>
    {
        private readonly ICustomerService _customerService;

        public GetById(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("api/customer/{Id}")]
        [SwaggerOperation(
            Summary = "Get a customer by Id",
            Description = "Gets a customer by Id",
            OperationId = "customer.GetById",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdResponse>> HandleAsync([FromRoute] GetByIdRequest request, CancellationToken cancellationToken = default)
        {
            GetByIdResponse response = new GetByIdResponse(request.CorrelationId());
            var customer = await _customerService.GetCustomerAsync(request.Id);
            response.Customer = new CustomerDto
            {
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName,
                Email = customer.Email,
                Version = customer.RowVersion
            };
            return Ok(response);
        }
    }
}
