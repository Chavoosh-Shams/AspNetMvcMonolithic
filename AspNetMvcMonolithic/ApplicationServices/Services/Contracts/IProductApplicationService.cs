using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {

        Task PostAsync(PostProductDto postProductDto);

        Task PutAsync(PutProductDto putProductDto);

        Task DeleteAsync(DeleteProductDto deleteProductDto);

        Task<GetProductForEdit?> GetForEditAsync(GetProductForEdit getProductForEdite);

        Task<GetProductForDelete?> GetForDeleteAsync(GetProductForDelete getProductForDelete);

        Task<ProductDetail?> GetProductByIdAsync(ProductDetail productDetail);

        Task<List<GetProductDto>> GetAsync();

    }
}
