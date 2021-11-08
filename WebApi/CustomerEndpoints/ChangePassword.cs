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
    public class ChangePassword : BaseAsyncEndpoint
        .WithRequest<ChangePasswordRequest>
        .WithResponse<ChangePasswordResponse>
    {
        private readonly ICustomerService _customerService;

        public ChangePassword(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPut("api/customer/password/{Id}")]
        [SwaggerOperation(
            Summary = "Change customer password by Id",
            Description = "Change customer password by Id",
            OperationId = "customer.Password",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<ChangePasswordResponse>> HandleAsync([FromRoute] ChangePasswordRequest request, CancellationToken cancellationToken = default)
        {
            var response = new ChangePasswordResponse(request.CorrelationId());
            await _customerService.ChangePasswordAsync(request.Id, request.NewPassword);
            return Ok(response);
        }
    }
}
