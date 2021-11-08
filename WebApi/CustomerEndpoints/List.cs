using Ardalis.ApiEndpoints;
using AutoMapper;
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
    public class List : BaseAsyncEndpoint
        .WithRequest<CustomerListRequest>
        .WithResponse<CustomerListResponse>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public List(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customer")]
        [SwaggerOperation(
            Summary = "List Customers",
            Description = "List Customers",
            OperationId = "customer.List",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<CustomerListResponse>> HandleAsync([FromQuery] CustomerListRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CustomerListResponse(request.CorrelationId());
            var items = await _repository.GetAllAsync(cancellationToken);
            response.Customers.AddRange(items.Select(_mapper.Map<CustomerDto>));
            return Ok(response);
        }
    }
}
