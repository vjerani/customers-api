using Ardalis.ApiEndpoints;
using Core.Entities;
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
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateCustomerRequest>
        .WithResponse<UpdateCustomerResponse>
    {
        private readonly ICustomerService _customerService;

        public Update(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPut("api/customer/update")]
        [SwaggerOperation(
            Summary = "Update customer by Id",
            Description = "Update customer by Id",
            OperationId = "customer.Update",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var response = new UpdateCustomerResponse(request.CorrelationId());
            var customer = await _customerService.UpdateCustomerAsync(request.Id, request.Firstname, request.Lastname, request.Email, request.Version);
            response.Customer = new CustomerDto
            {
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName,
                Email = customer.Email,
                Version = customer.RowVersion
            };

            return response;
        }
    }
}
