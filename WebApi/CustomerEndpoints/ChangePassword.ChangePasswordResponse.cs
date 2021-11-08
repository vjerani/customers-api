using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class ChangePasswordResponse : BaseResponse
    {
        public ChangePasswordResponse()
        {
        }

        public ChangePasswordResponse(Guid correlationId) : base(correlationId)
        {
        }
    }
}
