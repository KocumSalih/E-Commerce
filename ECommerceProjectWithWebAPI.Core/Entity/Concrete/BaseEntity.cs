namespace ECommerceProjectWithWebAPI.Core.Entity.Concrete
{
    using Abstract;

    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
