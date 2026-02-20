using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {

        #region [- Private Fields -]
        private readonly ProjectDbContext _context;
        #endregion


        #region [- Ctor -]
        public ProductRepository(ProjectDbContext context)
        {
            _context = context;
        }
        #endregion


        #region [- Insert() -]
        public async Task Insert(Product product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region [- Update() -]
        public async Task Update(Product product)
        {
            try
            {
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region [- Delete() -]
        public async Task Delete(Product product)
        {
            try
            {
                var productEntity = await _context.Product.FindAsync(product.Id);
                if (productEntity != null)
                {
                    _context.Product.Remove(productEntity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region [- SelectProductForEdite() -]
        public async Task<Product?> SelectProductForEdit(Product product)
        {
            return await _context.Product.FindAsync(product.Id);
        }
        #endregion


        #region [- SelectProductForDelete() -]
        public async Task<Product?> SelectProductForDelete(Product product)
        {
            return await _context.Product.FindAsync(product.Id);
        }
        #endregion


        #region [- SelectProductById() -]
        public async Task<Product?> SelectProductById(Product product)
        {
            return await _context.Product.FindAsync(product.Id);
        } 
        #endregion


        #region [- SelectAll() -]
        public async Task<IEnumerable<Product>> SelectAll()
        {
            try
            {
                return await _context.Product.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


    }
}
