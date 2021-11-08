using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class CustomerListResponse : BaseResponse
    {
        public CustomerListResponse()
        {
        }

        public CustomerListResponse(Guid correlationId) : base(correlationId)
        {
        }

        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
    }
}
