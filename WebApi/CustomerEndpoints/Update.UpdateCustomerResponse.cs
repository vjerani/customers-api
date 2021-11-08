using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class UpdateCustomerResponse : BaseResponse
    {
        public UpdateCustomerResponse()
        {
        }

        public UpdateCustomerResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CustomerDto Customer { get; set; }
    }
}
