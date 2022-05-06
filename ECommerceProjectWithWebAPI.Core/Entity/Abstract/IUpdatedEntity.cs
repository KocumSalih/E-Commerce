using System;

namespace ECommerceProjectWithWebAPI.Core.Entity.Abstract
{
    public interface IUpdatedEntity
    {
        int? UpdatedUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
