using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
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
                Id = putProductDto.Id,
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
            var product = new Product()
            {
                Id = deleteProductDto.Id,
                ProductName = deleteProductDto.ProductName,
                UnitPrice= deleteProductDto.UnitPrice,
                ProductDescription = deleteProductDto.ProductDescription,
                
            };
            await _productRepository.Delete(product);
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
