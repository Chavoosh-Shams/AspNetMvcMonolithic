using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.Services.Contracts;

namespace AspNetMvcMonolithic.ApplicationServices.Services
{
    public class ProductApplicationService : IProductApplicationService
    {

        #region [- Private Fields-]
        private readonly IProductRepository _productRepository;
        #endregion

        #region [- Ctor -]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- PostAsync() -]
        public Task PostAsync(PostProductDto postProductDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [- PutAsync() -]
        public Task PutAsync(PutProductDto putProductDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [- DeleteAsync() -]
        public Task DeleteAsync(DeleteProductDto deleteProductDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [- GetAsync() -]
        public Task<List<GetProductDto>> GetAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [- GetProductById() -]
        public Task<ProductDetail?> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
