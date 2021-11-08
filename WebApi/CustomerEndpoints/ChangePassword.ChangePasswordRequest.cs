using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class ChangePasswordRequest : BaseRequest
    {
        public int Id { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
