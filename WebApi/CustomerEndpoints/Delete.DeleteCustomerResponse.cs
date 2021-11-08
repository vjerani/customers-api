using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class DeleteCustomerResponse : BaseResponse
    {
        public DeleteCustomerResponse()
        {
        }

        public DeleteCustomerResponse(Guid correlationId) : base(correlationId)
        {
        }
    }
}
