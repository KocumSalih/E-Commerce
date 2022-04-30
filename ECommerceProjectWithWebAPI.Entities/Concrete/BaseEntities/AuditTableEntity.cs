using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Entities.Concrete.BaseEntities
{
    using Abstract;

    public class AuditTableEntity : BaseEntity, ICreatedEntity,IUpdatedEntity
    {
        public int CreatedUser { get ; set ; }
        public DateTime CreatedDate { get; set; }
        int? IUpdatedEntity.CreatedUser { get; set; }
        DateTime? IUpdatedEntity.CreatedDate { get; set ; }
    }
}
