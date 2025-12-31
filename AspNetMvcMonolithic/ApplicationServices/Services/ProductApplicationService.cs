using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using AspNetMvcMonolithic.Models.Services.Repositories;

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
        public async Task PostAsync(PostProductDto postProductDto)
        {
            var product = new Product()
            {
                ProductName = postProductDto.ProductName,
                UnitPrice = postProductDto.UnitPrice,
                ProductDescription = postProductDto.ProductDescription,
            };
             await _productRepository.Insert(product);
        }
        #endregion

        #region [- PutAsync() -]
        public async Task PutAsync(PutProductDto putProductDto)
        {
            var product = new Product()
            {
                ProductName = putProductDto.ProductName,
                UnitPrice = putProductDto.UnitPrice,
                ProductDescription = putProductDto.ProductDescription,
            };
            await _productRepository.Update(product);
        }
        #endregion

        #region [- DeleteAsync() -]
        public async Task DeleteAsync(DeleteProductDto deleteProductDto)
        {
            await _productRepository.Delete(deleteProductDto.Id);
        }
        #endregion

        #region [- GetAsync() -]
        public async Task<List<GetProductDto>> GetAsync()
        {
            var product= await _productRepository.SelectAll();
            var result = product.Select(product => new GetProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                ProductDescription= product.ProductDescription
            }).ToList();

            return result;
        }
        #endregion

        #region [- GetProductById() -]
        public async Task<ProductDetail?> GetProductByIdAsync(Guid id)
        {
            var product= await _productRepository.GetProductById(id);
            if(product == null)
            {
                return null;
            }
            var productDetail = new ProductDetail()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                ProductDescription = product.ProductDescription
            };
            return productDetail;
        } 
        #endregion

    }
}
