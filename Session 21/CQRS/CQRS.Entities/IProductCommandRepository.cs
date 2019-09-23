namespace CQRS.Entities
{
    public interface IProductCommandRepository
    {
        void Add(Product product);
    }
}
