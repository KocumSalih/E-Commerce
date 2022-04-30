using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.DAL.Abstract
{
    using Entities.Concrete;

    public interface IUserDal:IBaseRepository<User>
    {
    }
}
