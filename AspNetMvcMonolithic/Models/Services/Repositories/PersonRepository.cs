using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        #region [-Private Fields-]
        private readonly ProjectDbContext _context;
        #endregion

        #region [-Ctor-]
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region [-Implement IPersonRepository-]
        public async Task<IEnumerable<Person>> SelectAll()
        {
            try
            {
                return await _context.Person.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
