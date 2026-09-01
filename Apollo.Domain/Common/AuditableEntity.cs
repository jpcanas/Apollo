using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.Common
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }                    
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

    }
}
