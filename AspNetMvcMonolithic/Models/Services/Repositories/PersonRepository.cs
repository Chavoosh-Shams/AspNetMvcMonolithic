using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

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

        #region [- SelectPersonForEdite() -]
        public async Task<Person?> SelectPersonForEdite(Person person)
        {
            return await _context.Person.FindAsync(person.Id);
        } 
        #endregion

        #region [- Delete() -]
        public  async Task Delete(Person person)
        {
            try
            {
                var personEntity = await _context.Person.FindAsync(person.Id);
                if (personEntity != null)
                {
                    _context.Person.Remove(personEntity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }
        #endregion

        #region [- SelectPersonForDelete() -]
        public async Task<Person?> SelectPersonForDelete(Person person)
        {
            return await _context.Person.FindAsync(person.Id);
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
        public async Task<Person?> SelectPersonById(Person person)
        {
           return await _context.Person.FindAsync(person.Id);
        }
        #endregion

    }
}
