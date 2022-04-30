namespace ECommerceProjectWithWebAPI.DAL.Concrete.EntityFramework
{
    using DAL.Abstract;
    using DAL.Concrete.Contexts;
    using Entities.Concrete;

    public  class EfUserDal : EFBaseRepository<User,ECommerceProjectWithWebAPIContext>,IUserDal
    {

    }
}
