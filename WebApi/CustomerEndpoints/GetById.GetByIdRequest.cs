using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class GetByIdRequest : BaseRequest
    {
        public GetByIdRequest()
        {
        }

        public GetByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
