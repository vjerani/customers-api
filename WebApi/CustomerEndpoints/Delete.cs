using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
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
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteCustomerRequest>
        .WithResponse<DeleteCustomerResponse>
    {
        private readonly ICustomerService _customerService;

        public Delete(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpDelete("api/customer/delete/{Id}")]
        [SwaggerOperation(
        Summary = "Delete customer by Id",
        Description = "Delete customer by Id",
        OperationId = "customer.Delete",
        Tags = new[] { "CustomerEndpoints" })]
        public override async Task<ActionResult<DeleteCustomerResponse>> HandleAsync([FromRoute] DeleteCustomerRequest request, CancellationToken cancellationToken = default)
        {
            Guard.Against.Zero(request.Id, nameof(request.Id));
            DeleteCustomerResponse response = new DeleteCustomerResponse(request.CorrelationId());
            await _customerService.DeleteCustomerAsync(request.Id);
            return Ok(response);
        }
    }
}
