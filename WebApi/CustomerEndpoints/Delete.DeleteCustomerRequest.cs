using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class DeleteCustomerRequest: BaseRequest
    {
        public int Id { get; set; }
    }
}
