using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        #region [- Private Fields -]
        private readonly ProjectDbContext _context;
        #endregion

        #region [- Ctor -]
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        }

        #endregion

        #region [- Insert() -]
        public  async Task Insert(Person person)
        {
            try
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Update() -]
        public async Task Update(Person person)
        {
            try
            {
                _context.Person.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Delete() -]
        public  async Task Delete(Guid id)
        {
            try
            {
                var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == id);
                if (person != null)
                {
                    _context.Person.Remove(person);
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
        public async Task<Person?> GetPersonById(Guid id)
        {
           return await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion

    }
}
