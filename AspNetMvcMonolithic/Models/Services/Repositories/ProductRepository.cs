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
        public async Task Delete(Guid id)
        {
            try
            {
                var product = await _context.Product.FindAsync(id);
                if (product != null)
                {
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        #region [- GetProductById() -]
        public async Task<Product?> GetProductById(Guid id)
        {
            return await _context.Product.FirstOrDefaultAsync(x=>id==x.Id);
        } 
        #endregion

    }
}
