using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class CreateCustomerResponse: BaseResponse
    {
        public CreateCustomerResponse()
        {
        }

        public CreateCustomerResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CustomerDto Customer { get; set; }
    }
}
