using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ConcurrentEntity: BaseEntity, IHasConcurrency
    {
        public long RowVersion { get; set; }
    }
}
