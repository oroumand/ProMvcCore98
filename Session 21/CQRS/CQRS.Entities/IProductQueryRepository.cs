using System.Collections.Generic;

namespace CQRS.Entities
{
    public interface IProductQueryRepository
    {
        List<Product> GetAll();
    }
}
