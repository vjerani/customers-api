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
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateCustomerRequest>
        .WithResponse<CreateCustomerResponse>
    {
        private readonly ICustomerService _customerService;

        public Create(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("api/customer/create")]
        [SwaggerOperation(
            Summary = "Creates a new customer",
            Description = "Creates a new customer",
            OperationId = "customer.create",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerResponse>> HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateCustomerResponse(request.CorrelationId());
            var customer = await _customerService.AddCustomerAsync(request.Firstname, request.Lastname, request.Email, request.Password);
            var dto = new CustomerDto
            {
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName,
                Email = customer.Email
            };
            response.Customer = dto;
            return Ok(response);
        }
    }
}
