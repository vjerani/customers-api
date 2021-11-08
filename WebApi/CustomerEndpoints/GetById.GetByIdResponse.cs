using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class GetByIdResponse : BaseResponse
    {
        public GetByIdResponse()
        {
        }

        public GetByIdResponse(Guid correlationId) : base(correlationId)
        {
        }
        public CustomerDto Customer { get; set; }
    }
}
