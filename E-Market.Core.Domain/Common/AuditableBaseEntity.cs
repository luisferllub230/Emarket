using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Common
{
    public class AuditableBaseEntity
    {
        public virtual int id { get; set; }

        public virtual string? CreatedBy { get; set; }

        public virtual DateTime? Created { get; set; }

        public virtual string? LastModifiedBy { get; set; }

        public virtual string? LastModified { get; set; }
    }
}
