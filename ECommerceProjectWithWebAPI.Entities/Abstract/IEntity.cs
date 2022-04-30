using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Entities.Abstract
{
    /// <summary>
    /// Veritabanına karşılık gelen tablolara implemente edilecek.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
