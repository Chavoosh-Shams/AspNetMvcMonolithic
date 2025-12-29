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

        #region [- Insert () -]
        public Task Insert(Person person)
        {
            try
            {
                _context.Add(person);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Update() -]
        public Task Update(Person person)
        {
            try
            {
                _context.Person.Update(person);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- SelectAll() -]
        public async Task<IEnumerable<Person>> SelectAll()
        {
            try
            {
                return await _context.Person.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- GetAllPersonById() -]
        public Person? GetPersonById(Guid id)
        {
            return _context.Person.FirstOrDefault(p => p.Id == id);
        }
        #endregion

    }
}
