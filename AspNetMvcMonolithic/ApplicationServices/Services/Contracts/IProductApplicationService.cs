using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {
        Task PostAsync(PostProductDto postProductDto);

        Task PutAsync(PutProductDto putProductDto);

        Task DeleteAsync(DeleteProductDto deleteProductDto);

        Task<List<GetProductDto>> GetAsync();

        Task<ProductDetail?> GetProductByIdAsync(Guid id);
    }
}
