namespace ECommerceProjectWithWebAPI.Core.Entity.Abstract
{
    /// <summary>
    /// Veritabanına karşılık gelen tablolara implemente edilecek.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
