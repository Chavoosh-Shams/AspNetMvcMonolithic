using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {

        Task Insert(Product product);

        Task Update(Product product);

        Task Delete(Guid id);

        Task<IEnumerable<Product>> SelectAll();

        Task<Product?> GetProductById(Guid id);

    }
}
