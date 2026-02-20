using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
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
        public async Task PostAsync(PostProductDto postProductDto)
        {
            var product = new Product()
            {
                Title = postProductDto.Title,
                DescriptionRecord = postProductDto.DescriptionRecord,
                UnitPrice = postProductDto.UnitPrice
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
                Title = putProductDto.Title,
                DescriptionRecord = putProductDto.DescriptionRecord,
                UnitPrice = putProductDto.UnitPrice
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
                Title = deleteProductDto.Title,
                DescriptionRecord = deleteProductDto.DescriptionRecord,
                UnitPrice = deleteProductDto.UnitPrice
            };
            await _productRepository.Delete(product);
        }
        #endregion


        #region [- GetForEditAsync() -]
        public async Task<GetProductForEdit?> GetForEditAsync(GetProductForEdit getProductForEdit)
        {
            var product = new Product()
            {
                Id = getProductForEdit.Id,
                Title = getProductForEdit.Title,
                DescriptionRecord = getProductForEdit.DescriptionRecord,
                UnitPrice = getProductForEdit.UnitPrice
            };
            var productDto = await _productRepository.SelectProductForEdit(product);
            if (productDto == null)
            {
                return null;
            }
            return new GetProductForEdit()
            {
                Id = productDto.Id,
                Title = productDto.Title,
                DescriptionRecord = productDto.DescriptionRecord,
                UnitPrice = productDto.UnitPrice
            };
        }
        #endregion


        #region [- GetForDeleteAsync() -]
        public async Task<GetProductForDelete?> GetForDeleteAsync(GetProductForDelete getProductForDelete)
        {
            var product = new Product()
            {
                Id = getProductForDelete.Id,
                Title = getProductForDelete.Title,
                DescriptionRecord = getProductForDelete.DescriptionRecord,
                UnitPrice = getProductForDelete.UnitPrice
            };
            var productDto = await _productRepository.SelectProductForDelete(product);
            if (productDto == null)
            {
                return null;
            }
            return new GetProductForDelete()
            {
                Id = productDto.Id,
                Title = productDto.Title,
                DescriptionRecord = productDto.DescriptionRecord,
                UnitPrice = productDto.UnitPrice
            };
        }
        #endregion


        #region [- GetProductByIdAsync() -]
        public async Task<ProductDetail?> GetProductByIdAsync(ProductDetail productDetail)
        {
            var product = new Product()
            {
                Id = productDetail.Id,
                Title = productDetail.Title,
                DescriptionRecord = productDetail.DescriptionRecord,
                UnitPrice = productDetail.UnitPrice
            };
            var productDto = await _productRepository.SelectProductById(product);
            if (productDto == null)
            {
                return null;
            }
            return new ProductDetail()
            {
                Id = productDto.Id,
                Title = productDto.Title,
                DescriptionRecord = productDto.DescriptionRecord,
                UnitPrice = productDto.UnitPrice
            };
        }
        #endregion


        #region [- GetAsync() -]
        public async Task<List<GetProductDto>> GetAsync()
        {
            var product = await _productRepository.SelectAll();
            var result = product.Select(product => new GetProductDto
            {
                Id = product.Id,
                Title = product.Title,
                DescriptionRecord = product.DescriptionRecord,
                UnitPrice = product.UnitPrice
            }).ToList();

            return result;
        }
        #endregion

    }
}
