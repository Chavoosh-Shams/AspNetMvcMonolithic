using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task Insert(Person person); //Insert

        Task Update(Person person); //UpdatePerson

        Task<IEnumerable<Person>> SelectAll();//SelectAll

        Person? GetPersonById(Guid id); //SelectPersonById
    }
}
