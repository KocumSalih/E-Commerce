using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Entities.Abstract
{
    public interface IUpdatedEntity
    {
        int? CreatedUser { get; set; }
        DateTime? CreatedDate { get; set; }
    }
}
