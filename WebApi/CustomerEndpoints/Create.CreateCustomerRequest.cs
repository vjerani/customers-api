using Ardalis.ApiEndpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomerEndpoints
{
    public class CreateCustomerRequest : BaseRequest
    {
        public CreateCustomerRequest()
        {
        }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
